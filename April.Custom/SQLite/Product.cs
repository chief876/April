using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Custom.SQLite
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount_Price { get; set; }
        public int Price_Without_Discount { get; set; }
        public string Manufacturer { get; set; }

    }
}
