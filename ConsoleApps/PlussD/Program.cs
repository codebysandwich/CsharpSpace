using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlussD
{
    class Program
    {
        /// <summary>
        /// 演示 ++ -- 运算符
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int number = 10;
            number++;
            Console.WriteLine(number);

            //++ 作用在变量上，前后对于变量是没有区别的

            /*
             ++在后, 先返回再递增
             ++在前, 先递增再返回
             */
            number = 10;
            int result = 10 + number++;
            Console.WriteLine(result); // 20

            number = 10;
            result = 10 + ++number;
            Console.WriteLine(result); // 21


            // 运算理解
            int a = 5;
            int b = a++ + ++a * 2 + --a + a++;
            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.ReadKey();
        }
    }
}
