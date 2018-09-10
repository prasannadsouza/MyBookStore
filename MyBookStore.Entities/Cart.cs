using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookStore.Entities.Interfaces;

namespace MyBookStore.Entities
{
    /// <summary>
    /// data model of a cart
    /// </summary>
    public class Cart: ICart
    {
        public decimal TotalValue {
            get
            {
                return Items.Sum(e => e.CartQuantity * e.Price);
            }
        }

        public decimal OrderValue
        {
            get
            {
                return AvailableBooks.Sum(e => e.CartQuantity * e.Price);
            }
        }
        public List<IBook> Items { get; set; }
        public List<IBook> AvailableBooks { get; set; }
        public List<IBook> UnAvailableBooks { get; set; }
    }
}
