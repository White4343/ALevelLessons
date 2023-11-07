using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBContextApp.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Age { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? BreedId { get; set; }
        public Breed? Breed { get; set; }

        [ForeignKey("OwnerId")]
        public Owner? Owner { get; set; }

        public List<Pet> Pets { get; } = new();
    }
}
