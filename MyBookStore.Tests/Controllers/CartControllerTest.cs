using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBookStore;
using MyBookStore.Controllers;
using MyBookStore.Entities.Interfaces;


namespace MyBookStore.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {

        int PageSize
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            }
        }
        /// <summary>
        /// Test Add to cart
        /// </summary>
        [TestMethod]
        public void AddToCart()
        {
            CartController controller = new CartController();
            ContentResult result = controller.AddToCart("1") as ContentResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, "true");
            result = controller.AddToCart("2") as ContentResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, "true");
            result = controller.AddToCart("7") as ContentResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, "true");
        }

        /// <summary>
        /// Test the Cart Load Page shows items in the cart
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            CartController controller = new CartController();
           //Clear the cart to start afresh
            controller.PlaceOrder();
            //Add 3 items to cart
            controller.AddToCart("1");
            controller.AddToCart("2");
            controller.AddToCart("7");
            // Act
            ViewResult result = controller.Index() as ViewResult;
            ICart model = (ICart)result.Model;
            // Assert
            Assert.IsNotNull(result);
            //Check If Cart Item count is 3
            Assert.AreEqual(model.Items.Count, 3);
        }

        /// <summary>
        /// Test Placing an Order
        /// </summary>
        [TestMethod]
        public void PlaceOrder()
        {
            // Arrange
            CartController controller = new CartController();
            //Clear the cart to start afresh
            controller.PlaceOrder();
            //Add 3 items to cart
            controller.AddToCart("1"); //this is in stock
            controller.AddToCart("2"); //this is in stock
            controller.AddToCart("7"); //this has zero stock
            // Act
            ViewResult result = controller.PlaceOrder() as ViewResult;
            ICart model = (ICart)result.Model;
            // Assert
            Assert.IsNotNull(result);
            //Check Available and Unavailable Count
            Assert.AreEqual(model.AvailableBooks.Count, 2);
            Assert.AreEqual(model.UnAvailableBooks.Count, 1);

            result = controller.Index() as ViewResult;
            model = (ICart)result.Model;
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Items.Count, 0);
        }
    }
}
