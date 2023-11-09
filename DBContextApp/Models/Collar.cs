namespace DBContextApp.Models
{
    public class Collar
    {
        public int Id { get; set; }

        public string Color { get; set; }

        List<Pet> Pets { get; } = new();
    }
}
