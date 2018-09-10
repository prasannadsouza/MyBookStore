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
    public class BookControllerTest
    {
        int PageSize
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            }
        }
        /// <summary>
        /// Test default Load of Books Page shows all the books
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            BookController controller = new BookController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            List<IBook> model = (List<IBook>)result.Model;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Count, 7);
            
        }

        /// <summary>
        /// Test the Book search by Authot and Title in different combinations
        /// </summary>
        [TestMethod]
        public void GetBooks()
        {
            // Arrange
            BookController controller = new BookController();

            // Act
            PartialViewResult result = controller.GetBooks("Generic", "First") as PartialViewResult;
            List <IBook> model = (List<IBook>)result.Model;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(model.Count, 1);

            result = controller.GetBooks("", "") as PartialViewResult;
            model = (List<IBook>)result.Model;
            Assert.AreEqual(model.Count, 7);

            result = controller.GetBooks("Random Sales", "") as PartialViewResult;
            model = (List<IBook>)result.Model;
            Assert.AreEqual(model.Count, 2);

            result = controller.GetBooks("", "Rich") as PartialViewResult;
            model = (List<IBook>)result.Model;
            Assert.AreEqual(model.Count, 2);

        }
    }
}
