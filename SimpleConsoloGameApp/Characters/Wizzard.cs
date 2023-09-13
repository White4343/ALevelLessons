using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Characters
{
    internal class Wizzard : Character
    {
        public int ManaPoints;
        public int MaxManaPoints;

        public Wizzard(string name, string specialization, int healthPoints, int defencePoints, int strength, int manaPoints, int maxManaPoints) : base(name, specialization, healthPoints, defencePoints, strength)
        {
            ManaPoints = manaPoints;
            MaxManaPoints = maxManaPoints;
        }

        public override void PrintCharacter()
        {
            Console.WriteLine($"Name: {Name}, Specialization: {Specialization}, HP: {HealthPoints}, DF: {DefencePoints}, Strength: {Strength}, MP: {ManaPoints}");
        }

        public void RegenerateManaPoints()
        {
            if (ManaPoints == MaxManaPoints)
            {
                Console.WriteLine("You're Mana if full!");
            }
            else if (ManaPoints > MaxManaPoints)
            {
                ManaPoints = MaxManaPoints;
            }
            else
            {
                int _range = (MaxManaPoints - ManaPoints);
                ManaPoints = _range / 2;
            }
        }
    }
}
