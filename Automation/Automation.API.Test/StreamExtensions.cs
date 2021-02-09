using Models.DTOModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Test
{
    public static class StreamExtensions
    {

        public static Task<IList<T>> DesirializeStreamAsyncToList<T>(this Stream message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("stream cannot be null");
            }

            if (!message.CanRead)
            {
                throw new NotSupportedException("this type of stream is not supported " + message.ToString());
            }

            using (var reader = new StreamReader(message))
            {
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var jsonSerialize = new JsonSerializer();

                    var v = jsonSerialize.Deserialize<IList<T>>(jsonReader);
                    return (Task<IList<T>>)v;
                }


            }
           
        }

        public static void Serialize<T>(this Stream stream, T objectToSerialize)
        {
            using (var streamWriter = new StreamWriter(stream, new UTF8Encoding(), 1024, true))
            {
                using JsonTextWriter writer = new JsonTextWriter(streamWriter);
                var jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(writer, objectToSerialize);
                writer.Flush();
            }
        }

        public static IList<T> DesirializeToList<T>(string toDesirialize, string node = "")
        {
            if (!string.IsNullOrEmpty(node))
            {
                var nodes = JObject.Parse(toDesirialize);
                toDesirialize = nodes.SelectToken(node).ToString();
            }

            return JsonConvert.DeserializeObject<IList<T>>(toDesirialize);
        }
    }
}
