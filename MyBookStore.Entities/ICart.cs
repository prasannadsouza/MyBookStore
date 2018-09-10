using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyBookStore.Entities.Interfaces
{
    public interface ICart
    {
        decimal TotalValue { get; }
        decimal OrderValue { get; }
        List<IBook> Items { get;}
        List<IBook> AvailableBooks { get; }
        List<IBook> UnAvailableBooks { get; }
    }
}
