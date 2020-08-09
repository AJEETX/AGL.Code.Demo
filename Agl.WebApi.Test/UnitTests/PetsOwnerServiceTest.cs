using Agl.WebApi.Domain.Models;
using Agl.WebApi.Domain.Proxy;
using Agl.WebApi.Domain.Services;
using Agl.WebApi.Test.Setup;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Agl.WebApi.Test.UnitTests
{
    public class PetsOwnerServiceTest
    {
        [Theory]
        [InlineData("cat", "/people.json", 1)]
        public async Task GetPetsByOwnerGenderAsync_Given_Input_endpoint_and_type_of_pet_Returns_pet_owners_gender_with_pets(string type,string endpoint,int httpClientProxyTimes)
        {
            //GIVEN
            var moqHttpClientProxy = new Mock<IHttpClientProxy>();
            moqHttpClientProxy.Setup(m => m.GetPetsAndOwnersAsync(It.Is<string>(e => e.Equals(endpoint)))).ReturnsAsync(TestData.PetOwnersData);
            var sut = new PetsOwnerService(moqHttpClientProxy.Object);

            //WHEN
            var actualResult = await sut.GetPetsByOwnerGenderAsync(endpoint,type);

            //THEN
            Assert.IsAssignableFrom<IEnumerable<PetsByOwnerGender>>(actualResult);
            moqHttpClientProxy.Verify(v => v.GetPetsAndOwnersAsync(It.Is<string>(s => s.Equals(endpoint))), Times.Exactly(httpClientProxyTimes));
        }
        [Theory]
        [InlineData(null, "/people.json", 0)]
        [InlineData(null, null, 0)]
        [InlineData("cat", null, 0)]
        public void GetPetsByOwnerGenderAsync_Given_Input__null_endpoint_and_or_null_type_of_pet_Throws_Exception(string type, string endpoint, int httpClientProxyTimes)
        {
            //GIVEN
            var moqHttpClientProxy = new Mock<IHttpClientProxy>();
            moqHttpClientProxy.Setup(m => m.GetPetsAndOwnersAsync(It.Is<string>(e => e.Equals(endpoint)))).Throws(new ArgumentNullException("argument(s) null"));
            var sut = new PetsOwnerService(moqHttpClientProxy.Object);

            //WHEN

            //THEN
            moqHttpClientProxy.Verify(v => v.GetPetsAndOwnersAsync(It.Is<string>(s => s.Equals(endpoint))), Times.Exactly(httpClientProxyTimes));
            _ = Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.GetPetsByOwnerGenderAsync(endpoint, type));
        }
    }
}
