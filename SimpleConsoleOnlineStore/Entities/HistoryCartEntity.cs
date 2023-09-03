using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleConsoleOnlineStore.Entities
{
    public class HistoryCartEntity
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string ItemsCount { get; set; }

        public HistoryCartEntity(string Id, string itemsCount)
        {
            Id = Id;
            Date = DateTime.Now;
            ItemsCount = itemsCount;
        }

        public override string ToString()
        {
            return $"№{Id}. Date: {Date}. Count: {ItemsCount}";
        }
    }
}
