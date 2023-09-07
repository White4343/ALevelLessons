using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOOPApp
{
    internal interface IFamilyMember
    {
        string Name { get; set; }
        string DateOfBirth { get; set; }
        string Job { get; set; }
        int Money { get; set; }

        void PrintInformation();
        void SetMoney(int money);
    }
}
