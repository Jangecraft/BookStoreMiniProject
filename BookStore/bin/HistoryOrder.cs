using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class HistoryOrder
    {
        public string ISBN { get; set; }
        public string Customers_ID { get; set; }
        public string Quatity { get; set; }
        public string Total_Price { get; set; }
        public string Personnel_Name { get; set; }
    }
}
