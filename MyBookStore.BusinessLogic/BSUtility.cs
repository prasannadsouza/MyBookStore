using MyBookStore.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.BusinessLogic
{
    public static class BSUtility
    {
        public static IBookstoreService BookStoreService
        {
            get
            {
                return new BookStoreService();
            }
        }
    }
}
