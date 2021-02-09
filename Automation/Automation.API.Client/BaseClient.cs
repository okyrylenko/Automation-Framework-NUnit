using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.API
{
    public abstract class BaseClient
    {
        private static string BASEURL = "https://gorest.co.in/public-api/users/";
        private readonly HttpClient _client;

        public BaseClient()
        {
            _client =  new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer 53ca9ab06b4bc9b42c6ba294d62b2c399510d9243c97bb39f744de98236c2892");
        }
        protected virtual async Task<HttpResponseMessage> Post(string body,string endpoint ="")
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{BASEURL}{endpoint}"))
            {
                Content = new StringContent(body)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await Execute(request);
        }

        protected virtual async Task<HttpResponseMessage> Post(MemoryStream body,string endpoint="")
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{BASEURL}{endpoint}"));
            body.Seek(0, SeekOrigin.Begin);
            using var streamContent = new StreamContent(body);
            request.Content = streamContent;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await Execute(request);


        }

        protected virtual async Task<HttpResponseMessage> Get(string endpoint="", List<NameValueHeaderValue> headers=null, CancellationToken token = default)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri($"{BASEURL}{endpoint}"));
            if (headers != null)
            {
                foreach(var header in headers)
                {
                    request.Headers.Add(header.Name, header.Value);
                }
            }
            return await Execute(request, token);
        }

        protected virtual async Task<HttpResponseMessage> Update(string body,string endpoint="")
        {
            var request = new HttpRequestMessage(HttpMethod.Put, new Uri($"{BASEURL}{endpoint}"));
            request.Content = new StringContent(body);

            return await Execute(request);
        }

        protected async Task<HttpResponseMessage> Delete(string endpoint="")
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, new Uri($"{BASEURL}{endpoint}"));
            return await Execute(request);
        }

        protected virtual async Task<HttpResponseMessage> Patch(string endpoint, string patch)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, new Uri($"{BASEURL}{endpoint}"));
            request.Content = new StringContent(patch);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");
            return await Execute(request);
        }

        private async Task<HttpResponseMessage> Execute(HttpRequestMessage request, CancellationToken token = default)
        {
            try
            {
                return await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.RequestTimeout
                };
            }
            
        } 


    }
}
