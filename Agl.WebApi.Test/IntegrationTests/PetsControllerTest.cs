using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Agl.WebApi.Test.IntegrationTests
{
    public partial class PetsControllerTest : IClassFixture<WebApplicationFactory<Startup>>, IDisposable
    {
        private readonly HttpClient _client;
        private bool disposedValue;

        public PetsControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Theory]
        [InlineData("api/pets/", "cat", true, StatusCodes.Status200OK)]
        [InlineData("api/pet/", "cat", false, StatusCodes.Status404NotFound)]
        [InlineData("api/pets/", null, false, StatusCodes.Status404NotFound)]
        [InlineData("api/pets/", "", false, StatusCodes.Status404NotFound)]
        public async Task GetPetsByByOwnerGender_Given_Input_pet_type_Returns_response_status_code(string url,string type,bool success,int statusCode)
        {
            //GIVEN

            //WHEN
            var response = await _client.GetAsync(url+type);
            response.Dispose();

            //THEN
            Assert.Equal(success,response.IsSuccessStatusCode);
            Assert.Equal(statusCode,(int) response.StatusCode);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
