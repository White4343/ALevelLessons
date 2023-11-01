using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBContextApp.Models
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        public required string BreedName { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
        
        public ICollection<Pet> Pets { get; } = new List<Pet>();
    }
}
