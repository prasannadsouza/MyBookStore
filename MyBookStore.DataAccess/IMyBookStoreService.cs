using MyBookStore.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.DataAccess.Interfaces
{
    /// <summary>
    /// Data Store Interface, Implementation of this interface should be able to pull data fro any source 
    /// </summary>
    public interface IMyBookStoreService
    {
        List<BookDS> GetData();
        bool UpdateData(List<BookDS> bookds);
    }
}
