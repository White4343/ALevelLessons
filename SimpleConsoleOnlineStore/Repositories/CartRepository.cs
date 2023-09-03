using SimpleConsoleOnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleOnlineStore.Repositories
{
    public class CartRepository : ProductRepository
    {
        private readonly List<HistoryCartEntity> _historyCart = new List<HistoryCartEntity>();

        public void AddHistoryCartProduct(string count)
        {
            _historyCart.Add(new HistoryCartEntity(Guid.NewGuid().ToString(), count));
        }

        public HistoryCartEntity GetHistoryCart()
        {
            foreach (var product in _historyCart)
            {
                Console.WriteLine(product.ToString());
            }

            return null;
        }

        public void RemoveAllCart()
        {
            _products.Clear();
        }
    }
}
