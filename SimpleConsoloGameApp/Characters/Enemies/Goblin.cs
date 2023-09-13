using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Characters.Enemies
{
    internal class Goblin : Character
    {
        public int StealthPoints { get; set; }

        public Goblin(string name, string specialization, int healthPoints, int defencePoints, int strength, int stealthPoints) : base(name, specialization, healthPoints, defencePoints, strength)
        {
            StealthPoints = stealthPoints;
        }

        public override bool TakeDamage(int damageValue)
        {
            bool isAlive = true;
            int _currentHP = HealthPoints - (damageValue - (DefencePoints + StealthPoints));

            if (_currentHP > 0)
            {
                HealthPoints = _currentHP;
                return isAlive = true;
            }
            else
            {
                return isAlive = false;
            }
        }
    }
}
