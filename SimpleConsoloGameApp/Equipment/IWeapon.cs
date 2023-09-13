using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGameApp.Equipment
{
    public interface IWeapon
    {
        string Name { get; set; }
        string Type { get; set; }
        int Damage { get; set; }

        void PrintWeapon();
        int DealDamage();
    }
}
