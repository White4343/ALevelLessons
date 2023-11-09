using System.ComponentModel.DataAnnotations;

namespace DBContextApp.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public Pet? Pet { get; set; }
    }
}
