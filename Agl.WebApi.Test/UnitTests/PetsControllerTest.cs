using Agl.WebApi.Controllers;
using Agl.WebApi.Domain.Models;
using Agl.WebApi.Domain.Services;
using Agl.WebApi.Test.Setup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Agl.WebApi.Test.UnitTests
{
    public partial class PetsControllerTest :IDisposable
    {
        private bool disposedValue;
        Mock<IPetsOwnerService> moqPetOwnerService = null;
        Mock<ILogger<PetsController>> moqLogger = null;
        Mock<IConfiguration> moqConfiguration = null;
        public PetsControllerTest()
        {
            moqPetOwnerService = new Mock<IPetsOwnerService>();
            moqLogger = new Mock<ILogger<PetsController>>();
            moqConfiguration = new Mock<IConfiguration>();
        }
        [Fact]
        public async Task GetPetsByByOwnerGender_Given_Input_pet_type_Returns_pet_owner_gender_with_pets()
        {
            //GIVEN
            string type = "cat",endpoint="EndPoint";
            moqPetOwnerService.Setup(m => m.GetPetsByOwnerGenderAsync(It.Is<string>(e=>e.Equals(endpoint)), It.Is<string>(t=>t.Equals(type)))).ReturnsAsync(TestData.PetsByOwnerGendersData);
            moqConfiguration.Setup(m => m.GetSection(It.Is<string>(e => e.Equals("Endpoint"))).Value).Returns(endpoint);
            var sut = new PetsController(moqLogger.Object, moqPetOwnerService.Object, moqConfiguration.Object);

            //WHEN
            var response = await sut.Get(type);
            var resultData = response as OkObjectResult;
            var actualResult = resultData.Value as IEnumerable<PetsByOwnerGender>;

            //THEN
            Assert.Equal(StatusCodes.Status200OK, resultData.StatusCode);
            Assert.Equal(TestData.PetsByOwnerGendersData.FirstOrDefault().Gender, actualResult.FirstOrDefault().Gender);
            Assert.Equal(TestData.PetsByOwnerGendersData.FirstOrDefault().Pets.FirstOrDefault(), actualResult.FirstOrDefault().Pets.FirstOrDefault());
            moqPetOwnerService.Verify(m => m.GetPetsByOwnerGenderAsync(It.Is<string>(e => e.Equals(endpoint)), It.Is<string>(t => t.Equals(type))), Times.Exactly(1));
            moqLogger.Verify(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Never);
        }
        [Fact]
        public async Task GetPetsByByOwnerGender_Given_Input_pet_type_Returns_NotFound()
        {
            //GIVEN
            string type="cat", endpoint = "EndPoint";
            IEnumerable<PetsByOwnerGender> petsOwners = null;
            moqPetOwnerService.Setup(m => m.GetPetsByOwnerGenderAsync(It.Is<string>(e => e.Equals(endpoint)), It.Is<string>(t => t.Equals(type)))).ReturnsAsync(petsOwners);
            moqConfiguration.Setup(m => m.GetSection(It.Is<string>(e => e.Equals("Endpoint"))).Value).Returns(endpoint);
            var sut = new PetsController(moqLogger.Object, moqPetOwnerService.Object, moqConfiguration.Object);

            //WHEN
            var actualResponse = await sut.Get(type) as NotFoundResult;

            //THEN
            Assert.Equal(StatusCodes.Status404NotFound, actualResponse.StatusCode);
            moqPetOwnerService.Verify(m => m.GetPetsByOwnerGenderAsync(It.Is<string>(e => e.Equals(endpoint)), It.Is<string>(t => t.Equals(type))), Times.Exactly(1));
            moqLogger.Verify(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Never);
        }
        [Fact]
        public async Task GetPetsByByOwnerGender_Given_Input_pet_type_Returns_BadRequest()
        {
            //GIVEN
            string type = string.Empty, endpoint = "EndPoint";
            var sut = new PetsController(moqLogger.Object, moqPetOwnerService.Object, moqConfiguration.Object);

            //WHEN
            var actualResponse = await sut.Get(type)as BadRequestResult;

            //THEN
            Assert.Equal(StatusCodes.Status400BadRequest, actualResponse.StatusCode);
            moqPetOwnerService.Verify(m => m.GetPetsByOwnerGenderAsync(It.Is<string>(e => e.Equals(endpoint)), It.Is<string>(t => t.Equals(type))), Times.Exactly(0));
            moqLogger.Verify(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Never);
        }
        [Fact]
        public async Task GetPetsByByOwnerGender_Given_Input_pet_type_Returns_InternalServerError()
        {
            //GIVEN
            string type = "cat", endpoint = "EndPoint";
            moqPetOwnerService.Setup(m => m.GetPetsByOwnerGenderAsync(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
            moqConfiguration.Setup(m => m.GetSection(It.Is<string>(e => e.Equals("Endpoint"))).Value).Returns(endpoint);
            var sut = new PetsController(moqLogger.Object, moqPetOwnerService.Object, moqConfiguration.Object);

            //WHEN
            var actualResponse = await sut.Get(type) as ObjectResult;

            //THEN
            Assert.Equal(StatusCodes.Status500InternalServerError, actualResponse.StatusCode);
            moqPetOwnerService.Verify(m => m.GetPetsByOwnerGenderAsync(It.Is<string>(e => e.Equals(endpoint)), It.Is<string>(t => t.Equals(type))), Times.Exactly(1));
            moqLogger.Verify(x => x.Log(It.IsAny<LogLevel>(),It.IsAny<EventId>(),It.IsAny<It.IsAnyType>(),It.IsAny<Exception>(),(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),Times.Once);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    moqPetOwnerService = null;
                    moqLogger = null;
                    moqConfiguration = null;
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
