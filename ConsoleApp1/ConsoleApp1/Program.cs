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
        static void Main(string[] args) {
            PerformanceCounterCategory[] perfCats = PerformanceCounterCategory.GetCategories();
            foreach (PerformanceCounterCategory category in perfCats.OrderBy(c => c.CategoryName))
            {
                Console.WriteLine("Category Name: {0}", category.CategoryName);
            }        
            Console.ReadLine();
        }
    }
}
