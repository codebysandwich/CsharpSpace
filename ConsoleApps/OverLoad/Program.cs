using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(2, 5));
            Console.WriteLine(Sum(1.3, 2.0));
            Console.WriteLine(Sum("hello", "sand"));
            Console.WriteLine(Sum(100));

            Console.ReadKey();
        }

        static int Sum(int x, int y)
        {
            return x + y;
        }

        static double Sum(double x, double y)
        {
            return x + y;
        }
        static string Sum(string x, string y)
        {
            return x + y;
        }
        static int Sum(int x)
        {
            int sum = 0;
            for (int i = 1; i <= x; i++)
            {
                sum += i;
            }
            return sum;
        }
        #region 重载与函数返回值无关
        //static void Sum(int x, int y)
        //{
        //    Console.WriteLine(x + y);
        //}
        #endregion
    }
}
