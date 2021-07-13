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
            int x = 12;
            int y = 13;
            Swap(ref x, ref y);
            Console.WriteLine("{0:}, {1:}", x, y);

            Console.WriteLine("-------------------------------------");
            int i = 4, j = 5;
            int k;
            Console.WriteLine(k=i);
            // 连续赋值
            j = k = 12;
            // 字符串内插
            Console.WriteLine($"连续赋值后：j={j}, k={k}");
            Console.WriteLine("-------------------------------------");
            
            Console.ReadKey();
        }

        static double Add(double x, double y)
        {
            return Math.Pow(x, y);
        }

        static void Swap(ref int x, ref int y)
        {
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;
        }

        /// <summary>
        /// 学习字符串相关的知识
        /// </summary>
        static void StringFunc()
        {
            
        }
    }

}