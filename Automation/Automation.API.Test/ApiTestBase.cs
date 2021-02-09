using Automation.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Automation.API.Test
{
    public class ApiTestWrapper
    {

        public string Serialize<T>(T toSerialize)=>JsonConvert.SerializeObject(toSerialize);

        public IList<T> DesirializeToList<T>(string toDesirialize, string node="")
        {
            if (!string.IsNullOrEmpty(node))
            {
                var nodes = JObject.Parse(toDesirialize);
                toDesirialize = nodes.SelectToken(node).ToString();
            }

            return JsonConvert.DeserializeObject<IList<T>>(toDesirialize);
        }

        public T DesirializeToObject<T>(string toDesirialize, string node="")
        {
            if (!string.IsNullOrEmpty(node))
            {
                var nodes = JObject.Parse(toDesirialize);
                toDesirialize = nodes.SelectToken(node).ToString();
            }
            return JsonConvert.DeserializeObject<T>(toDesirialize);
        }
    }
}
