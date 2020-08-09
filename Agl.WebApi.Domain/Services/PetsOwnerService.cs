using Agl.WebApi.Domain.Models;
using Agl.WebApi.Domain.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agl.WebApi.Domain.Services
{
    /// <summary>
    /// Gets the list of pets in alphabetical order grouped by gender of their owner
    /// </summary>
    public interface IPetsOwnerService
    {
        Task<IEnumerable<PetsByOwnerGender>> GetPetsByOwnerGenderAsync(string endPoint, string petType);
    }
    internal class PetsOwnerService : IPetsOwnerService
    {
        private readonly IHttpClientProxy _httpClientProxy;
        public PetsOwnerService(IHttpClientProxy httpClientProxy)
        {
            _httpClientProxy = httpClientProxy;
        }
        /// <summary>
        ///  Gets the list of pets in alphabetical order grouped by gender of their owner for a given endpoint and for given pet type
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="petType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PetsByOwnerGender>> GetPetsByOwnerGenderAsync(string endPoint, string petType)
        {
            //always good to do gatekeeping for public methods
            if (string.IsNullOrWhiteSpace(endPoint) || string.IsNullOrWhiteSpace(petType)) throw new ArgumentNullException("argument(s) null") ;
            
            var petOwners = await _httpClientProxy.GetPetsAndOwnersAsync(endPoint);

            return petOwners.Where(p => p.Pets != null && p.Pets.Any())
            .GroupBy(petOwner => petOwner.Gender)
            .Select(group => new PetsByOwnerGender
            (
                group.Key,
                group.SelectMany(p => p.Pets).Where(p => p.Type.Equals(petType, StringComparison.OrdinalIgnoreCase))
                    .Select(pet => pet.Name)
                    .OrderBy(name => name)
            ));
        }
    }
}
