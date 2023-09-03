using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SimpleConsoleOnlineStore.Services;

namespace SimpleConsoleOnlineStore
{
    public class App
    {
        private readonly CartService _cartService;
        private readonly ProductService _productService;

        public App(CartService cartService, ProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public void Start()
        {
            bool isNotExit = true;

            while (isNotExit)
            {
                Console.WriteLine("Hello! Here's list of command's:\n show\n cart\n buy\n add\n exit");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "show":
                        Show();
                        continue;
                    case "cart":
                        AddToCart();
                        continue;
                    case "buy":
                        BuyFromCart();
                        continue;
                    case "add":
                        AddNewProducts();
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

            Console.WriteLine("Product list:");
            var product = _productService?.GetProducts();

            Console.WriteLine("\nCurrent cart list:");
            var cart = _cartService?.GetProducts();

            Console.WriteLine("\nCurrent order list:");
            var historyCart = _cartService?.GetHistoryCart();
        }

        private void AddToCart()
        {
            Console.WriteLine("Please type Id for adding item to cart");
            string? input = Console.ReadLine();
            var product = _productService.GetProduct(input);

            if (product == null)
            {
                Console.WriteLine($"Product does not exist with Id = {input}");
            }
            else
            {
                _cartService.AddProduct(product.Name, product.Price);
                _productService.RemoveProduct(product.Id);
                Console.WriteLine("Product added to cart!");
            }
        }

        private void BuyFromCart()
        {
            string cartLength = _cartService.GetCartLength();

            if (cartLength.Equals("0"))
            {
                Console.WriteLine("Cart is empty!");
            }
            else
            {
                _cartService.AddHistoryCartProduct(cartLength);
                _cartService.RemoveAllCart();
                Console.WriteLine("Order confirmed!");
            }
        }

        private void AddNewProducts()
        {
            _productService?.AddProduct("Coca-cola", "10");
            _productService?.AddProduct("Pepsi-cola", "11");
            _productService?.AddProduct("Fanta-cola", "12");
            _productService?.AddProduct("Sprite-cola", "13");
            _productService?.AddProduct("Beer-cola", "14");
            _productService?.AddProduct("Tea-cola", "15");
            _productService?.AddProduct("White-cola", "16");
            Console.WriteLine("Products added!");
        }
    }
}
