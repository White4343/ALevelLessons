using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAsyncApp.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }

        public Contact (string id, string name, string surname, string telephoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            TelephoneNumber = telephoneNumber;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Surname: {Surname}, TelephoneNumber: {TelephoneNumber}";
        }
    }
}
