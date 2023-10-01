using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLINQApp
{
    internal class UserLINQ
    {
        public static void Run()
        {
            List<User> users = GenerateUsers(12);

            // 1. Find all users whose age > 18
            var over18 = users
                .Where(u => CalculateAge(u.DateOfBirth) > 18)
                .Select(u => new
                {
                    FullName = $"{u.FirstName} {u.LastName}",
                    u.DateOfBirth,
                    Age = CalculateAge(u.DateOfBirth)
                });

            Console.WriteLine("Query 1 - Users over 18:");
            foreach (var user in over18)
            {
                Console.WriteLine($"Name: {user.FullName}, DOB: {user.DateOfBirth.ToShortDateString()}, Age: {user.Age}");
            }
            Console.WriteLine();

            // 2. Group users by email domain
            var emailDomainGroups = users
                .GroupBy(u => u.Email.Split('@').Last())
                .OrderByDescending(group => group.Count())
                .Select(group => new
                {
                    Domain = group.Key,
                    UserCount = group.Count()
                })
                .FirstOrDefault();

            Console.WriteLine($"Query 2 - Most used email domain: {emailDomainGroups.Domain} (User Count: {emailDomainGroups.UserCount})\n");

            // 3. Convert collection for optimized search based on UserId
            Dictionary<int, User> optimizedCollection = users.ToDictionary(u => u.Id);

            // Search by UserId
            int searchUserId = 3;
            if (optimizedCollection.TryGetValue(searchUserId, out User userFound))
            {
                Console.WriteLine($"Query 3 - User with ID {searchUserId} found: {userFound.FirstName} {userFound.LastName}\n");
            }
            else
            {
                Console.WriteLine($"Query 3 - User with ID {searchUserId} not found.\n");
            }

            // 4. Group users by Last Name and project into new format
            var relativesGroups = users
                .GroupBy(u => u.LastName)
                .Select(group => new
                {
                    LastName = group.Key,
                    PossibleRelatives = group
                        .OrderBy(u => u.DateOfBirth)
                        .Select(u => new
                        {
                            u.FirstName,
                            u.DateOfBirth
                        })
                        .ToList()
                })
                .ToList();

            Console.WriteLine("Query 4 - Possible Relatives:");

            foreach (var group in relativesGroups)
            {
                Console.WriteLine($"Last Name: {group.LastName}");
                foreach (var relative in group.PossibleRelatives)
                {
                    Console.WriteLine($"  Name: {relative.FirstName}, DOB: {relative.DateOfBirth.ToShortDateString()}");
                }
                Console.WriteLine();
            }
        }

        static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age--;

            return age;
        }

        static List<User> GenerateUsers(int count)
        {
            Random random = new Random();
            List<string> firstNames = new List<string> { "John", "Jane", "Michael", "Emily", "David", "Sarah" };
            List<string> lastNames = new List<string> { "Doe", "Smith", "Johnson", "Brown", "Taylor", "Davis" };
            List<string> emailDomains = new List<string> { "gmail.com", "yahoo.com", "hotmail.com" };
            List<User> users = new List<User>();

            for (int i = 1; i <= count; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Count)];
                string lastName = lastNames[random.Next(lastNames.Count)];
                string email = $"{firstName.ToLower()}.{lastName.ToLower()}@{emailDomains[random.Next(emailDomains.Count)]}";
                DateTime dateOfBirth = DateTime.Now.AddYears(-random.Next(18, 40));
                int userId = i;

                users.Add(new User
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = dateOfBirth,
                });
            }

            return users;
        }
    }
}
