using Agl.WebApi.Domain.Extensions;
using Agl.WebApi.Domain.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Agl.WebApi.Domain.Proxy
{
    internal interface IHttpClientProxy
    {
        Task<List<PetOwner>> GetPetsAndOwnersAsync(string endPoint);
    }
    internal class HttpClientProxy : IHttpClientProxy
    {
        private readonly HttpClient _httpClient;
        public HttpClientProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PetOwner>> GetPetsAndOwnersAsync(string endPoint)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, endPoint);
            
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            
            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode) return stream.DeserializeJsonFromStream<List<PetOwner>>();

            var content = await stream.StreamToStringAsync();

            throw new ApiException((int)response.StatusCode, content);
        }
    }
}
