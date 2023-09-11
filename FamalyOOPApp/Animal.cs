using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOOPApp
{
    internal class Animal : IAnimal, IComparable<Animal>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void GreetOwner()
        {
            Console.WriteLine($"'Hello owner' says {Name}");
        }

        public virtual void PrintAnimal()
        {
            Console.WriteLine($"Name: {Name}. Age: {Age}");
        }

        int IComparable<Animal>.CompareTo(Animal animal)
        {
            if (Age == animal.Age) return 0;
            if (Age > animal.Age) return 1;
            if (Age < animal.Age) return -1;

            return 0;
        }
    }
}
