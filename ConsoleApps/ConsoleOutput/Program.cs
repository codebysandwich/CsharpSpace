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
            int x = 12;
            int y = 13;
            Swap(ref x, ref y);
            Console.WriteLine("{0:}, {1:}", x, y);

            Console.WriteLine("-------------------------------------");
            int i = 4, j = 5;
            // 声明或定义了一个整形对象
            int k;
            Console.WriteLine(k = i);
            // 连续赋值
            j = k = 12;
            // 字符串内插
            Console.WriteLine($"连续赋值后：j={j}, k={k}");
            Console.WriteLine("-------------------------------------");
            StringFunc();

            Console.ReadKey();
        }

        static void Swap(ref int x, ref int y)
        {
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;
        }

        #region 字符串练习
        /// <summary>
        /// 学习字符串相关的知识
        /// </summary>
        static void StringFunc()
        {
            string str = "abcd";
            Console.WriteLine(Reverse(str));
            // 字符串赋值为空字符串
            str = "";
            Console.WriteLine(str.Equals(string.Empty));
        }
        static string Reverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }
        #endregion
    }
 
}