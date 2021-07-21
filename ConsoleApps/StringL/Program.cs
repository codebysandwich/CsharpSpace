using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringL
{
    class Program
    {
        static void Main(string[] args)
        {
            // 字符串加法
            Console.WriteLine("演示string重载加号");
            string s1 = "hello", s2 = "world";
            Console.WriteLine(s1 + s2);
            EndOfPrint();

            Console.ReadKey();
        }

        static void EndOfPrint()
        {
            Console.WriteLine("=====================================");
        }
    }
}
