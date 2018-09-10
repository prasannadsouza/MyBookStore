using MyBookStore.BusinessLogic;
using MyBookStore.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    /// <summary>
    /// Class to Addd items to cart, list them and place the order
    /// </summary>
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            try
            {
                ICart cart = BSUtility.BookStoreService.GetCart();
                return View(cart);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "An Error Occurred, Error" + e.Message;
                ICart cart = null;
                return View(cart);
            }
}

        [HttpGet, ActionName("AddToCart")]
        public ActionResult AddToCart(string ISBN)
        {
            try
            {
                BSUtility.BookStoreService.AddToCart(ISBN, 1);
                return Content("true");
            }
            catch (Exception e)
            {
                return Content("An Error Occurred, Error" + e.Message);
            }
        }

        [HttpGet, ActionName("PlaceOrder")]
        public ActionResult PlaceOrder()
        {
            try
            {
                ICart cart = BSUtility.BookStoreService.GetCart();
                BSUtility.BookStoreService.PlaceOrder();
                return View(cart);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "An Error Occurred, Error" + e.Message;
                ICart cart = null;
                return View(cart);
            }
        }
    }
}