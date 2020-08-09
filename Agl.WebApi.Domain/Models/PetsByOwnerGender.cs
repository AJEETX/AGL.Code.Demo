using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agl.WebApi.Domain.Models
{
    /// <summary>
    /// Pet owner gender and collection of their pets
    /// </summary>
    public class PetsByOwnerGender
    {
        /// <summary>
        /// Owner gender
        /// </summary>
        [Required]
        public string Gender { get; }
        /// <summary>
        /// Collection of owner's pets
        /// </summary>
        public IEnumerable<string> Pets { get; }
        public PetsByOwnerGender(string gender, IEnumerable<string> pets)
        {
            Gender = gender;
            Pets = pets;
        }
    }
}
