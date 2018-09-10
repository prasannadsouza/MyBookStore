using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Entities.Interfaces
{
    public interface IBook

    {
        string ISBN { get; }
        string Title { get; }
        string Author { get; }
        decimal Price { get; }
        int InStock { get; }
        int CartQuantity { get;}
    }
}
