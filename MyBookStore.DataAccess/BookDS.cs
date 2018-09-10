using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.DataAccess
{
    public class BookDS
    {
        public string title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public int inStock { get; set; }
        public int cart { get; set; }
        public string ISBN { get; set; }
    }
}
