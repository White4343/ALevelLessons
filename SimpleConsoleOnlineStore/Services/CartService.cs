using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleConsoleOnlineStore.Entities;
using SimpleConsoleOnlineStore.Repositories;

namespace SimpleConsoleOnlineStore.Services
{
    public class CartService
    {
        private readonly CartRepository _cartRepository;

        public CartService(
            CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddHistoryCartProduct(string count)
        {
            _cartRepository.AddHistoryCartProduct(count);
        }

        public void RemoveAllCart()
        {
            _cartRepository.RemoveAllCart();
        }

        public void AddProduct(string name, string price)
        {
            _cartRepository.AddProduct(name, price);
        }

        public HistoryCartEntity GetHistoryCart()
        {
            return _cartRepository.GetHistoryCart();
        }

        public ProductEntity GetProducts()
        {
            return _cartRepository.GetProducts();
        }

        public string GetCartLength()
        {
            return _cartRepository.GetCartLength();
        }

        public ProductEntity GetProduct(string id)
        {
            var product = _cartRepository.GetProduct(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}
