using System.Collections.Generic;

namespace Agl.WebApi.Domain.Models
{
    internal class PetOwner
    {
        public string Name { get; }
        public string Gender { get; }
        public int Age { get; }
        public IEnumerable<Pet> Pets { get; }
        public PetOwner(string name, string gender, int age, IEnumerable<Pet> pets)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Pets = pets;
        }
    }
}
