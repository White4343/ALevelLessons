using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOOPApp
{
    internal class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {

        }

        public override void PrintAnimal()
        {
            Console.WriteLine($"Type: Cat. Name: {Name}. Age: {Age}");
        }
    }
}
