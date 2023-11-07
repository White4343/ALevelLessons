using System.ComponentModel.DataAnnotations;

namespace DBContextApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Pet> Pets { get; } = new List<Pet>();

        public ICollection<Breed> Breeds { get; } = new List<Breed>();
    }
}
