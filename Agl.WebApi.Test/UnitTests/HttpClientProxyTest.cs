using Agl.WebApi.Domain.Models;
using Agl.WebApi.Domain.Proxy;
using Agl.WebApi.Test.Setup;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Agl.WebApi.Test.UnitTests
{
    public class HttpClientProxyTest
    {
        [Fact]
        public async Task GetPetOwnersAsync_Given_Input_endpoint_Returns_owners_with_pets()
        {
            //GIVEN
            var endPoint = "endPoint";
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock .Protected().Setup<Task<HttpResponseMessage>>("SendAsync",ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(TestData.HttpResponseData);
            using var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://blahblahblah.com")
            };
            var sut = new HttpClientProxy(httpClient);

            //WHEN
            var actualResult = await sut.GetPetsAndOwnersAsync(endPoint);

            //THEN
            Assert.IsAssignableFrom<List<PetOwner>>(actualResult);
            handlerMock.Protected().Verify("SendAsync",Times.Exactly(1),ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), ItExpr.IsAny<CancellationToken>());
        }
        [Fact]
        public void GetPetOwnersAsync_Given_Input_endpoint_Throws_Exception()
        {
            //GIVEN
            var endPoint = "endPoint";
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(TestData.HttpResponseData);
            using var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://blahblahblah.com")
            };
            var sut = new HttpClientProxy(httpClient);

            //WHEN

            //THEN
            _ = Assert.ThrowsAsync<Exception>(async () => await sut.GetPetsAndOwnersAsync(endPoint));
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), ItExpr.IsAny<CancellationToken>());
        }
    }
}
