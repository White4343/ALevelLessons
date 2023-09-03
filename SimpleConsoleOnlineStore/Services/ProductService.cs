using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleConsoleOnlineStore.Entities;
using SimpleConsoleOnlineStore.Repositories;

namespace SimpleConsoleOnlineStore.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        
        public ProductService(
            ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(string name, string price)
        {
            _productRepository?.AddProduct(name, price);
        }

        public void RemoveProduct(string id)
        {
            _productRepository.RemoveProduct(id);
        }

        public ProductEntity GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public ProductEntity GetProduct(string id)
        {
            var product = _productRepository.GetProduct(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}
