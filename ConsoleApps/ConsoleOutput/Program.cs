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
            // 赋值会返回一个值，可以用于连续赋值
            Console.WriteLine(k = i);
            // 连续赋值
            j = k = 12;
            // 字符串内插
            Console.WriteLine($"连续赋值后：j={j}, k={k}");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("------------------数值型数据练习-------------------");
            NumFunc();

            Console.WriteLine("------------------字符串练习-------------------");
            StringFunc();

            Console.ReadKey();
        }

        /// <summary>
        /// 不引入临时变量，交换两个变量
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void Swap(ref int x, ref int y)
        {
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;
        }

        #region 数值型数据练习
        static void NumFunc()
        {
            // 浮点数据精度损失问题
            double a = 3000.2, b = 3000;
            double c = a - b;
            Console.WriteLine(c);
            // 使用decimal金融数据类型解决这个问题
            decimal c1 = 3000.2M, c2 = 3000M;
            Console.WriteLine(c1-c2);
        }

        #endregion

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

            char[] chrs = new char[] { 'a', 'b', 'd' };
            str = new string(chrs);
            foreach (byte b in Encoding.UTF8.GetBytes(str))
            {
                Console.WriteLine(b);
            }
            // 演示占位符的使用
            string firstName = "leo", lastName = "sandwich";
            Console.WriteLine("你好，{1} {0}", firstName, lastName);
            // 演示变量占位符使用
            Console.WriteLine($"你好{firstName} {lastName}");
        }
        static string Reverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }
        #endregion
    }

}