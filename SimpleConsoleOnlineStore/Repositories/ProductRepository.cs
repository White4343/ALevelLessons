using SimpleConsoleOnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleOnlineStore.Repositories
{
    public class ProductRepository
    {
        protected readonly List<ProductEntity> _products = new List<ProductEntity>();
        
        public void AddProduct(string name, string price)
        {
            _products.Add(new ProductEntity(Guid.NewGuid().ToString(), name, price));
        }

        public void RemoveProduct(string id)
        {
            _products.RemoveAll(x => x.Id.Equals(id));
        }

        public ProductEntity GetProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product.ToString());
            }

            return null;
        }

        public string GetCartLength()
        {
            return _products.Count.ToString();
        }

        public ProductEntity GetProduct(string id)
        {
            foreach (var product in _products)
            {
                if (product.Id.Equals(id))
                {
                    return product;
                }
            }

            return null;
        }
    }
}
