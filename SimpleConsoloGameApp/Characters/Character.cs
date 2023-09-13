using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Characters
{
    internal class Character : ICharacter
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int HealthPoints { get; set; }
        public int DefencePoints { get; set; }
        public int Strength { get; set; }

        public Character(string name, string specialization, int healthPoints, int defencePoints, int strength)
        {
            Name = name;
            Specialization = specialization;
            HealthPoints = healthPoints;
            DefencePoints = defencePoints;
            Strength = strength;
        }
        
        public virtual bool TakeDamage(int damageValue)
        {
            bool isAlive = true;
            int _currentHP = HealthPoints - (damageValue - DefencePoints);

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

        public virtual void PrintCharacter()
        {
            Console.WriteLine($"Name: {Name}, Specialization: {Specialization}, HP: {HealthPoints}, DF: {DefencePoints}, Strength: {Strength}");
        }
    }
}
