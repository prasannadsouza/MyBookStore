using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookStore.DataAccess.Interfaces;
using MyBookStore.Entities;
using MyBookStore.Entities.Interfaces;
using Newtonsoft.Json;

namespace MyBookStore.DataAccess
{
    /// <summary>
    /// Class created to read books data from a File, the underlying data type used is JSON
    /// </summary>
    public class FileBookStore : IMyBookStoreService
    {

        string DataFile
        {
            get
            {
                return ConfigurationManager.AppSettings["DataFile"];
            }
        }

        public List<BookDS> GetData()
        {
            string dataSource = AppDomain.CurrentDomain.BaseDirectory + DataFile;
            using (StreamReader r = File.OpenText(dataSource))
            {
                string json = r.ReadToEnd();
                List<BookDS> items = JsonConvert.DeserializeObject<List<BookDS>>(json);
                return items;
            }
        }

        public bool UpdateData(List<BookDS> bookds)
        {
            string dataSource = AppDomain.CurrentDomain.BaseDirectory + DataFile;
            string json = JsonConvert.SerializeObject(bookds);
            File.WriteAllText(dataSource, json);
            return true;
        }
    }
}
