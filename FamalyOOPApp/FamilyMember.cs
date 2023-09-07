using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOOPApp
{
    internal class FamilyMember : IFamilyMember, IComparable<FamilyMember>
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Job { get; set; }
        public int Money { get; set; }

        public FamilyMember(string name, string dateOfBirth, string job, int money)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Job = job;
            Money = money;
        }

        public virtual void PrintInformation()
        {
            Console.WriteLine($"Name: {Name}. Date of Birth: {DateOfBirth}. Profession: {Job}. Money: {Money}");
        }

        public void SetMoney(int money)
        {
            Money = money;
        }

        int IComparable<FamilyMember>.CompareTo(FamilyMember member)
        {
            if (Money == member.Money) return 0;
            if (Money > member.Money) return 1;
            if (Money < member.Money) return -1;

            return 0;
        }
    }
}
