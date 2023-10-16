using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAsyncApp.Models;
using ContactAsyncApp.Services;

namespace ContactAsyncApp
{
    public class App
    {
        private readonly ContactService _contactService;

        public App(ContactService contactService)
        {
            _contactService = contactService;
        }

        public void Start()
        {
            bool isNotExit = true;

            while (isNotExit)
            {
                Console.WriteLine("Hello! Here's list of command's:\n show\n search\n clearAll\n add\n exit");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "show":
                        Show();
                        continue;
                    case "clearAll":
                        ClearAll();
                        continue;
                    case "add":
                        using (var mutex = new Mutex(false, "WriteToFile"))
                        {
                            mutex.WaitOne();
                            try
                            {
                                AddContacts();
                            }
                            finally
                            {
                                mutex.ReleaseMutex();
                            }
                        }
                        continue;
                    case "search":
                        Search();
                        continue;
                    case "exit":
                        isNotExit = false;
                        break;
                    default:
                        Console.WriteLine("Please write command!");
                        continue;
                }
            }
        }

        private void Show()
        {
            try
            {
                _contactService.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Print failure: {e.Message}");
            }
        }

        private void ClearAll()
        {
            try
            {
                _contactService.ClearAll();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Clear failure: {e.Message}");
            }
        }

        private void AddContacts()
        {
            try
            {
                _contactService.Add(new Contact("1", "John", "Doe", "555-1234"));
                _contactService.Add(new Contact("2", "Jane", "Smith", "555-5678"));
                _contactService.Add(new Contact("3", "Bob", "Johnson", "555-9876"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Adding failure {e.Message}");
            }
        }

        private void Search()
        {
            Console.WriteLine("Write search value");
            string? value = Console.ReadLine();

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Value failure");
            }

            try
            {
                Task<Contact?> result = _contactService.Search(value);
                Console.WriteLine(result.Result.ToString());
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Search result is null: {e.Message}");
            }
        }
    }
}
