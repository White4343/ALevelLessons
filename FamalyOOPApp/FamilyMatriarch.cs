using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FamilyOOPApp
{
    internal class FamilyMatriarch : FamilyPatriarch
    {
        public string Matriname { get; set; }

        public FamilyMatriarch (string name, string dateOfBirth, string job, int money, string dateOfBecomingLeader, string matriname) : base(name, dateOfBirth, job, money, dateOfBecomingLeader)
        {
            Matriname = matriname;
        }

        public override void PrintInformation()
        {
            base.PrintInformation();
            Console.WriteLine($"Mother's surname: {Matriname}");
        }
    }
}
