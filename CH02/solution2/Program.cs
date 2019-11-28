using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataQuery<DataItem> query = new DataQuery<DataItem>();
            query.Query().ToList();
            Console.ReadLine();
        }
        public class DataQuery<T> where T:class,new()
        {
            private Random rnd = new Random();
            private int rows = 0;
            public DataQuery()
            {
                this.rows = rnd.Next(1, 10);
            }
            public IEnumerable<T> Query()
            {
                for(int i = 0; i < this.rows; i++)
                {
                    T item = new T();
                    yield return item;
                }
            }
        }
        public class DataItem
        {
            public DataItem()
            {
                Console.WriteLine("DataItem created.");
            }
        }
    }
}
