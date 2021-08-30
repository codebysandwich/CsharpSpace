using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Params
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Sum(3, 5, 8);
            Console.WriteLine(sum);

            Console.ReadKey();
        }

        /// <summary>
        /// 演示搜集参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scores"></param>
        /// <returns></returns>
        static int Sum(params int[] scores)
        {
            int sum = 0;
            foreach (var item in scores)
            {
                sum += item;
            }
            return sum;
        }
    }
}
