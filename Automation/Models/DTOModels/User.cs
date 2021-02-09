using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOModels
{
    public class User
    {
      public int Id{get;set;}
        public string Name { get;set;}
        public string Email { get;set;}
        public string Gender { get;set;}
        public string Status { get;set;}

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedOn { get;set;}

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedOn { get;set;}
    }
}
