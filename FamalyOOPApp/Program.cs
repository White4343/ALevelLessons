namespace FamilyOOPApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<FamilyMember> familyMembers = new List<FamilyMember>();

            familyMembers.Add(new FamilyMember("Andrew", "10/04/1997", "Student", 1000));
            familyMembers.Add(new FamilyMember("Katy", "11/05/2000", "Student", 0));
            familyMembers.Add(new FamilyPatriarch("Jon", "10/03/1970", "Doctor", 10000, "10/11/2001"));
            familyMembers.Add(new FamilyMatriarch("Daphne", "11/12/1971", "Housewife", 1200, "21/03/2002", "Lovegood"));

            animals.Add(new Cat("Lucius", 3));
            animals.Add(new ("Max", 1));

            Console.WriteLine("Animals");
            foreach (var value in animals)
            {
                value.PrintAnimal();
            }

            Console.WriteLine("Family");
            foreach (var value in familyMembers)
            {
                value.PrintInformation();
            }

            animals.Sort();
            Console.WriteLine("Animals Sorted by age:");
            foreach (var value in animals)
            {
                value.PrintAnimal();
            }

            familyMembers.Sort();
            Console.WriteLine("Family Sorted by money:");
            foreach (var value in familyMembers)
            {
                value.PrintInformation();
            }

            var familyMembersPositiveMoney = familyMembers.ToList();

            familyMembersPositiveMoney = familyMembers.FilterByPositiveMoney();

            Console.WriteLine("Family where money count is positive:");
            foreach (var value in familyMembersPositiveMoney)
            {
                value.PrintInformation();
            }

        }
    }
}