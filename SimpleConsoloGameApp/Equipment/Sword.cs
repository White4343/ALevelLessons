using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Equipment
{
    internal class Sword : Weapon
    {
        public Sword(string name, string type, int damage) : base(name, type, damage)
        {
            
        }

        public virtual int BlockDamage(int value)
        {
            switch (_random.Next(1, 3))
            {
                case 1:
                    return value * 0;
                case 2:
                    return value * 1;
                default:
                    return value;
            }
        }
    }
}
