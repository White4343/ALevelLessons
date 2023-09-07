using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOOPApp
{
    internal static class FamilyExtension
    {
        public static List<T> FilterByPositiveMoney<T>(this List<T> family) where T : FamilyMember
        {
            return family.Where(i => i.Money > 0).ToList();
        }
    }
}
