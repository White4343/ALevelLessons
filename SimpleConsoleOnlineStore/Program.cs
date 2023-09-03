using System.Diagnostics;
using SimpleConsoleOnlineStore.Repositories;
using SimpleConsoleOnlineStore.Services;

namespace SimpleConsoleOnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new App(new CartService(new CartRepository()), new ProductService(new ProductRepository()));
            app.Start();
        }
    }
}