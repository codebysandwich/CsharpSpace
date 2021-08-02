using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            bool b = false;
            Console.WriteLine(XOR(a, b));
            a = true;
            b = true;
            Console.WriteLine(XOR(a, b));
            a = false;
            b = false;
            Console.WriteLine(XOR(a, b));
            a = false;
            b = true;
            Console.WriteLine(XOR(a, b));

            Console.Write("输入需要判断闰年的年份:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(IsLeapYear(year));

            Console.ReadKey();
        }

        /// <summary>
        /// 使用与或非逻辑实现XOR
        /// </summary>
        /// <param name="x">输入1</param>
        /// <param name="y">输入2</param>
        /// <returns></returns>
        static bool XOR(bool x, bool y)
        {
            return (!(x && y)) && (x || y);
        }

        /// <summary>
        /// 判断年份是否是闰年
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        static bool IsLeapYear(int year)
        {
            /*
             * 年份能被100整除
             * 年份能被4整除但是不能被100整除
             */
            return year % 100 == 0 || (year % 4 == 0 && year % 100 != 0);
        }
    }
}
