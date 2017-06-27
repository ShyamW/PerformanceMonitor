using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void helper_method(PerformanceCounterCategory [] perfCats)
        {
            //Get single category by category name.
            PerformanceCounterCategory cat = perfCats.Where(c => c.CategoryName == "Memory").FirstOrDefault();

            //print all memory counters
            string[] instances = cat.GetInstanceNames();
            if (instances.Length == 0)
            {
                //This block will execute when category has no instance.
                //loop all the counters available withing category
                foreach (PerformanceCounter counter in cat.GetCounters())
                    Console.WriteLine("Counter Name: {0}", counter.CounterName);
            }
        }

        static void Main(string[] args)
        {
            //Get all performance categories
            PerformanceCounterCategory[] perfCats = PerformanceCounterCategory.GetCategories();
            helper_method(perfCats);
           
;

           Console.ReadLine();
        }

        
    }
}
