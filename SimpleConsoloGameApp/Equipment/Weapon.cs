using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Equipment
{
    internal class Weapon : IWeapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }

        protected static Random _random = new Random();

        public Weapon(string name, string type, int damage)
        {
            Name = name;
            Type = type;
            Damage = damage;
        }

        public virtual int DealDamage()
        {
            switch (_random.Next(1, 4))
            {
                case 1:
                    return Damage * 10;
                case 2:
                    return Damage * 1;
                case 3:
                    return Damage * 0;
                default:
                    return Damage;
            }
        }

        public virtual void PrintWeapon()
        {
            Console.WriteLine($"Weapon Info: Name: {Name}, Type: {Type}, Damage Point's: {Damage}");
        }
    }
}
