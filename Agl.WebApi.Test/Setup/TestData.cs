using Agl.WebApi.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Agl.WebApi.Test.Setup
{
    internal static class TestData
    {
        public static string JsonResponseData
        {
            get
            {
                return File.ReadAllText(@"Setup/people.json");
            }
        }
        public static List<PetOwner> PetOwnersData => new List<PetOwner>
                {
                    new PetOwner("azy","male",37,new List<Pet>{new Pet("Pussy","Cat") })
                };

        public static HttpResponseMessage HttpResponseData => new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(JsonResponseData) };
        public static IEnumerable<PetsByOwnerGender> PetsByOwnerGendersData=> new List<PetsByOwnerGender>
                {
                    new PetsByOwnerGender("male",new List<string> {"pussy","garfield" } )
                };
    }
}
