using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world!");
            Console.WriteLine(Add(2, 3));
            Console.ReadKey();
        }

        static double Add(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
    class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }

    }
}