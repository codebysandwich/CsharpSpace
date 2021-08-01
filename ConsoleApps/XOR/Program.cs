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
    }
}
