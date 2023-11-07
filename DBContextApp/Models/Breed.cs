using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBContextApp.Models
{
    public class Breed
    {
        public int Id { get; set; }
        
        public string BreedName { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public ICollection<Pet> Pets { get; } = new List<Pet>();
    }
}
