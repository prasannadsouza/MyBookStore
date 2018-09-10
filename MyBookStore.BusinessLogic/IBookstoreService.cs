using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookStore.Entities.Interfaces;
namespace MyBookStore.BusinessLogic.Interfaces
{
    public interface IBookstoreService
    {
        List<IBook> GetBooks();
        List<IBook> GetBooks(string Author, string Title);
        bool AddToCart(string ISBN,int Quantity);
        ICart GetCart();
        bool PlaceOrder();
    }
}
