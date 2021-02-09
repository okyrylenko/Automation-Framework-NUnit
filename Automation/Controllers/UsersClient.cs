using Automation.API;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Controllers
{
    public class UsersClient:BaseClient
    {
        private  CancellationTokenSource _tokenSource;

        public async Task<HttpResponseMessage> GetUsers()
        {
            _tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            

            return await Get(token:_tokenSource.Token);
        }

        public async Task<HttpResponseMessage> CreateUser(string user)
        {
            return await Post(user);
        }


        public async Task<HttpResponseMessage> CreateUserByStream(MemoryStream user)
        {
            return await Post(user);
        }


        public async Task<HttpResponseMessage> UpdateUser(int id, string user)
        {
            return await Update(user, id.ToString());
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            return await Delete(id.ToString());
        }

        public async Task<HttpResponseMessage> Patch(int id, JsonPatchDocument patch)
        {
            var body = JsonConvert.SerializeObject(patch);
            return await Patch(id.ToString(), body);
        }
    }
}
