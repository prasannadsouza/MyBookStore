using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookStore.Entities.Interfaces;

namespace MyBookStore.Entities
{
    /// <summary>
    /// Data Model of a Book
    /// </summary>
   public class Book: IBook
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int CartQuantity { get; set; }
    }
}
