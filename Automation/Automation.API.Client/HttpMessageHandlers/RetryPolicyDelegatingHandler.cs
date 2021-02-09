using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.API.Client.HttpMessageHandlers
{
    public class RetryPolicyDelegatingHandler:DelegatingHandler
    {
        private static int MAXRETRY = 3;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken token)
        {
            var response = new HttpResponseMessage();
            for (int i = 0; i < MAXRETRY; i++)
            {
                response = await base.SendAsync(message, token);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                i++;

            }

            return response;
            
        }
    }
}
