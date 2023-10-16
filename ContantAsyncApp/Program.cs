using ContactAsyncApp.Services;

namespace ContactAsyncApp
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            ContactService contactService = await ContactService.Create();
            App app = new(contactService);
            app.Start();
        }
    }
}