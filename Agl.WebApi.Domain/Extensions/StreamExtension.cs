using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Agl.WebApi.Domain.Extensions
{
    internal static class StreamExtension
    {
        public static T DeserializeJsonFromStream<T>(this Stream stream)
        {
            if (stream == null || !stream.CanRead)
                return default;

            using var streamReader = new StreamReader(stream);

            using var jsonTextReader = new JsonTextReader(streamReader);

            var jsonSerializer = new JsonSerializer();

            var searchResult = jsonSerializer.Deserialize<T>(jsonTextReader);

            return searchResult;
        }
        public static async Task<string> StreamToStringAsync(this Stream stream)
        {
            string content = null;

            if (stream != null)
            {
                using var sr = new StreamReader(stream);
                
                content = await sr.ReadToEndAsync();
            }

            return content;
        }
    }
}
