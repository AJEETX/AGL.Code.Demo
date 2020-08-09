namespace Agl.WebApi.Domain.Models
{
    internal class Pet
    {
        public string Name { get; }
        public string Type { get;  }
        public Pet(string name,string type)
        {
            Name = name;
            Type = type;
        }
    }
}
