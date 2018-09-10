using MyBookStore.BusinessLogic.Interfaces;
using MyBookStore.DataAccess.Interfaces;
using MyBookStore.DataAccess;
using MyBookStore.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookStore.Entities;

namespace MyBookStore.BusinessLogic
{
    public class BookStoreService: IBookstoreService
    {
        /// <summary>
        /// Gets all he available books
        /// </summary>
        /// <returns></returns>
        public List<IBook> GetBooks()
        {
            List<BookDS> data = DSUtility.BookStoreService.GetData();
            List<IBook> books = new List<IBook>();

            data.ForEach(e => books.Add(new Book { Title = e.title, Author = e.author, Price = e.price, InStock = e.inStock, ISBN=e.ISBN, CartQuantity=e.cart }));
            books.OrderBy(e => e.Title);
            return books;
        }

        /// <summary>
        /// Filter the books based on either Title, Author or both
        /// </summary>
        /// <param name="Author"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        public List<IBook> GetBooks(string Author, string Title)
        {
            List<IBook> books = GetBooks();
            if (string.IsNullOrWhiteSpace(Author)) Author = "";
            if (string.IsNullOrWhiteSpace(Title)) Title = "";

            var filteredBooks = books.Where(e => ((string.IsNullOrWhiteSpace(Author) || e.Author.ToLower().Contains(Author.ToLower()))
                   && (string.IsNullOrWhiteSpace(Title) || e.Title.ToLower().Contains(Title.ToLower()))));

            return filteredBooks.ToList().OrderBy(e => e.Title).ToList();
           
        }

        /// <summary>
        /// Saves the Selected Book to Cart with ISBN as primary key
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>
        public bool AddToCart(string ISBN,int Quantity)
        {
            List<BookDS> data = DSUtility.BookStoreService.GetData();
            var sel = data.First(e => e.ISBN == ISBN);
            sel.cart = sel.cart + Quantity;
            return DSUtility.BookStoreService.UpdateData(data);
            }

        /// <summary>
        /// Creates a Cart based on selected books and their cart quantity
        /// </summary>
        /// <returns></returns>
        public ICart GetCart()
        {
            List<BookDS> data = DSUtility.BookStoreService.GetData();
            var cart = new Cart();
            cart.Items = new List<IBook>();
            cart.AvailableBooks = new List<IBook>();
            cart.UnAvailableBooks = new List<IBook>();

            //Identifies all cart items,  the the books that are in stock and the out of stock books
            data.ForEach(e => 
            {
                if (e.cart > 0)
                {
                    cart.Items.Add(new Book { Title = e.title, Author = e.author, Price = e.price, InStock = e.inStock, ISBN = e.ISBN, CartQuantity = e.cart });

                    if (e.inStock > e.cart)
                        cart.AvailableBooks.Add(new Book { Title = e.title, Author = e.author, Price = e.price, InStock = e.inStock, ISBN = e.ISBN, CartQuantity = e.cart });

                    if (e.inStock == 0)
                        cart.UnAvailableBooks.Add(new Book { Title = e.title, Author = e.author, Price = e.price, InStock = e.inStock, ISBN = e.ISBN, CartQuantity = e.cart });
                    else if (e.inStock < e.cart)
                    {
                        cart.AvailableBooks.Add(new Book { Title = e.title, Author = e.author, Price = e.price, InStock = e.inStock, ISBN = e.ISBN, CartQuantity = e.inStock });
                        cart.UnAvailableBooks.Add(new Book { Title = e.title, Author = e.author, Price = e.price, InStock = e.inStock, ISBN = e.ISBN, CartQuantity = e.cart - e.inStock });
                    }
                }
            });

            cart.Items.OrderBy(e => e.Title);
            cart.AvailableBooks.OrderBy(e => e.Title);
            cart.UnAvailableBooks.OrderBy(e => e.Title);

            return cart;
        }

        /// <summary>
        /// Places the order
        /// Resets the Cart Quantity to zero, stock is not reduced for test purposes
        /// </summary>
        /// <returns></returns>
        public bool PlaceOrder()
        {
            List<BookDS> data = DSUtility.BookStoreService.GetData();
            data.ForEach(e => e.cart = 0);
            DSUtility.BookStoreService.UpdateData(data);
            return true;
        }
    }
}
