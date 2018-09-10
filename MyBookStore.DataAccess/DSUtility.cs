using MyBookStore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.DataAccess
{
    public static class DSUtility
    {
        public static IMyBookStoreService BookStoreService
        {
            get
            {
                return new FileBookStore();
            }
        }
    }
}
