using System.ComponentModel.DataAnnotations;

namespace DBContextApp.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required float Age { get; set; }

        public required string ImageUrl { get; set; }

        public required string Description { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int BreedId { get; set; }
        public Breed Breed { get; set; } = null!;
    }
}
