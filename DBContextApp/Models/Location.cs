using System.ComponentModel.DataAnnotations;

namespace DBContextApp.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public ICollection<Pet> Pets { get; } = new List<Pet>();
    }
}
