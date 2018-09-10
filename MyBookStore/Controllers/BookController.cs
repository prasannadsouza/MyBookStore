using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyBookStore.BusinessLogic;
using MyBookStore.Entities;
using MyBookStore.Entities.Interfaces;


namespace MyBookStore.Controllers
{
    /// <summary>
    /// Class to List, and Search for Books
    /// </summary>
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            try
            {
                List<IBook> books = BSUtility.BookStoreService.GetBooks();
                return View(books);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "An Error Occurred, Error" + e.Message;
                return View(new List<IBook>());
            }
        }

        [HttpGet, ActionName("GetBooks")]
        public ActionResult GetBooks(string title,string author)
        {
            try
            {
                List<IBook> books = BSUtility.BookStoreService.GetBooks(author, title);
                return PartialView("~/Views/Shared/_ListOfBooks.cshtml", books);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "An Error Occurred, Error" + e.Message;
                return Content("An Error Occurred, Error" + e.Message);
            }
        }
              
     }
}