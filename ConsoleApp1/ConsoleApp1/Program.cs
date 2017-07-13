using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void mem_events(PerformanceCounterCategory [] perfCats)
        {
            foreach (PerformanceCounterCategory counter in perfCats)
                Console.WriteLine("{0}", counter.CategoryName);
            Console.WriteLine("_______________________________________\n\n");

            //Get single category by category name.
            PerformanceCounterCategory cat = perfCats.Where(c => c.CategoryName == "Memory").FirstOrDefault();
            
            //print all memory counters
            string[] instances = cat.GetInstanceNames();
            if (instances.Length == 0)
            {
                //This block will execute when category has no instance.
                //loop all the counters available withing category
                foreach (PerformanceCounter counter in cat.GetCounters())
                    Console.WriteLine("{0} : Counter Name: {1}", counter.CounterName, counter.NextValue().ToString());
            }
        }

        static void cpu_events(PerformanceCounterCategory[] perfCats)
        {
            //Get single category by category name.
            PerformanceCounterCategory cat = perfCats.Where(c => c.CategoryName == "Processor").FirstOrDefault();

            //print all memory counters
            string[] instances = cat.GetInstanceNames();
            Console.WriteLine("_______________________________________\n\n");

            foreach (string instance in instances)
            {
                //Console.WriteLine("\n  Instance Name: {0}", instance);
                if (cat.InstanceExists(instance))
                    //loop all the counters available withing category
                    if (instance == "_Total")
                        foreach (PerformanceCounter counter in cat.GetCounters(instance))
                            Console.WriteLine("{0} : Counter Name: {1}", counter.CounterName, counter.NextValue().ToString());
            }
        }

        static void Main(string[] args)
        {
            //Get all performance categories
            PerformanceCounterCategory[] perfCats = PerformanceCounterCategory.GetCategories();
            mem_events(perfCats);
            while (true) {
                cpu_events(perfCats);
                Thread.Sleep(600);
                Console.Clear();
            }
            


           Console.ReadLine();
        }

        
    }


}
