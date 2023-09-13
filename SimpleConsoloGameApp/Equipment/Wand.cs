using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Equipment
{
    internal class Wand : Weapon
    {
        public int MagicDamage {  get; set; }

        public Wand(string name, string type, int damage, int magicDamage) : base(name, type, damage)
        {
            MagicDamage = magicDamage;
        }

        public override int DealDamage()
        {
            return base.DealDamage() + MagicDamage;
        }

        public override void PrintWeapon()
        {
            Console.WriteLine($"Weapon Info: Name: {Name}, Type: {Type}, Damage Point's: {Damage}, Mag. Damage Point's: {MagicDamage}");
        }
    }
}
