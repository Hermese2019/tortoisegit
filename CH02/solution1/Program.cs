using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            SortUtil<SortCalss> util = new SortUtil<SortCalss>();
            SortCalss s1 = new SortCalss();
            int s2 = 123;
            util.Sort(s1);
            util.SortDesc(s1);
            s1.Sort();
            s1.SortDesc();
            Console.ReadLine();
        }

        public interface ISortable
        {
            void Sort();
            void SortDesc();
        }

        public class SortUtil<T> where T : ISortable
        {
            public void Sort(T target)
            {
                target.Sort();
            }
            public void SortDesc(T target)
            {
                target.SortDesc();
            }
        }

        public class SortCalss : ISortable
        {
            public void Sort()
            {
                Console.WriteLine("Sort() called.");
            }

            public void SortDesc()
            {
                Console.WriteLine("SortDesc() called.");
            }
        }
    }
}
