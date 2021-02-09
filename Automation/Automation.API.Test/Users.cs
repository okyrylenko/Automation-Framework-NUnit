using Controllers;
using Microsoft.AspNetCore.JsonPatch;
using Models.DTOModels;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Automation.API.Test;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Autofac;

namespace Automation.API.Test
{
    [TestFixture]
    public class Users:ApiTestWrapper
    {
        
        private readonly UsersClient _usersController;
        public Users()
        {
            _usersController = new UsersClient();
        }

        [Test]
        public async Task GetUsersSuccessfully()
        {
            HttpResponseMessage response = await _usersController.GetUsers();

            var users = await response.Content.ReadAsStreamAsync().Result.DesirializeStreamAsyncToList<User>();

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                using var reader = new StreamReader(stream);
                using var jsonReader = new JsonTextReader(reader);
                var nodes = JObject.Load(jsonReader);
                var v = nodes.GetValue("data");
                users = v.ToObject<List<User>>(); ;
            }
            

            Assert.True(response.IsSuccessStatusCode);
            Assert.That(users.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task CreateUser()
        {
            User user = new User()
            {
                Name = "new user",
                Email = "nomail@nomail.com",
                Gender = "mail"
            };


            var memory = new MemoryStream();
            memory.Serialize(user);

            HttpResponseMessage response = await _usersController.CreateUserByStream(memory);

            Assert.True(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task UpdateUser()
        {
            var users = await _usersController.GetUsers();
            var user = DesirializeToList<User>(await users.Content.ReadAsStringAsync(), "data").PickRandomItem();

            user.Name = "OK";

            var update = await _usersController.UpdateUser(user.Id, Serialize(user));

            var d =  DesirializeToObject<User>(await update.Content.ReadAsStringAsync(), "data");

            Assert.True("OK".Equals(user.Name));
        }

        [Test]
        public async Task DeleteUser()
        {
            var users = await _usersController.GetUsers();
            var user = DesirializeToList<User>(await users.Content.ReadAsStringAsync(), "data").PickRandomItem();

            var response = await _usersController.Delete(user.Id);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task UpdateName()
        {
            var users = await _usersController.GetUsers();
            var user = DesirializeToList<User>(await users.Content.ReadAsStringAsync(), "data").PickRandomItem();

            var patch = new JsonPatchDocument();
            patch.Replace("name", "OK");
            patch.Remove("status");

            var response = await _usersController.Patch(user.Id,patch);

            var u = DesirializeToObject<User>(await response.Content.ReadAsStringAsync(), "data");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
