using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleConsoleGameApp.Equipment;

namespace SimpleConsoleGameApp.Characters
{
    public interface ICharacter
    {
        string Name { get; set; }
        string Specialization { get; set; }
        int HealthPoints { get; set; }
        int Strength { get; set; }
        int DefencePoints { get; set; }

        void PrintCharacter();
        bool TakeDamage(int damageValue);
    }
}
