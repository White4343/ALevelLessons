using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOOPApp
{
    internal class FamilyPatriarch : FamilyMember
    {
        public string DateOfBecomingLeader { get; set; }

        public FamilyPatriarch(string name, string dateOfBirth, string job, int money, string dateOfBecomingLeader) : base(name, dateOfBirth, job, money)
        {
            DateOfBecomingLeader = dateOfBecomingLeader;
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine($"Date of becoming leader: {DateOfBecomingLeader}");
        }
    }
}
