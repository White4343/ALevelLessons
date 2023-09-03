using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleOnlineStore.Entities
{
    public class ProductEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public ProductEntity(string id, string name, string price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"№{Id}. Name: {Name}. Price: {Price}";
        }
    }
}
