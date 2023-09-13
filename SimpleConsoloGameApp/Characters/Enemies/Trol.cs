using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Characters.Enemies
{
    internal class Trol : Warrior
    {
        public Trol(string name, string specialization, int healthPoints, int defencePoints, int strength) : base(name, specialization, healthPoints, defencePoints, strength)
        {

        }

        public override int EnterRage()
        {
            return base.Strength * 3;
        }
    }
}
