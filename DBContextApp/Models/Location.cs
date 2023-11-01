using System.ComponentModel.DataAnnotations;

namespace DBContextApp.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public required string LocationName { get; set; }

        public ICollection<Pet> Pets { get; } = new List<Pet>();
    }
}
