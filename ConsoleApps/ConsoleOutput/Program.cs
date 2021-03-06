using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOutput
{
    class Program
    {
        /// <summary>
        /// 主函数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("hello world!");
            int x = 12;
            int y = 13;
            Swap(ref x, ref y);
            Console.WriteLine("{0:}, {1:}", x, y);
            EndOfPrint();

            int i = 4, j = 5;
            // 声明或定义了一个整形对象
            int k;
            // 赋值会返回一个值，可以用于连续赋值
            Console.WriteLine(k = i);
            // 连续赋值
            j = k = 12;
            // 字符串内插
            Console.WriteLine($"连续赋值后：j={j}, k={k}");
            EndOfPrint();

            Console.WriteLine("使用数据技巧交换两个int");
            i = 22;
            j = 32;
            Swap_int(ref i, ref j);
            Console.WriteLine($@"交换后i={i}, j={j}");
            EndOfPrint();

            // 展示隐式转换
            Console.WriteLine(10 / 3);
            Console.WriteLine(10 / 3.0);
            i = 10;
            double d = i;
            Console.WriteLine(d);

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

        /// <summary>
        /// 不使用临时变量，交换两个int类型的数据
        /// </summary>
        static void Swap_int(ref int x, ref int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;
        }

        #region 数值型数据练习
        static void NumFunc()
        {
            // 浮点数据精度损失问题
            Console.WriteLine("浮点数损失精度问题");
            double a = 3000.2, b = 3000;
            double c = a - b;
            Console.WriteLine(c);
            EndOfPrint();
            // 使用decimal金融数据类型解决这个问题
            Console.WriteLine("引入decimal解决精度损失问题");
            decimal c1 = 3000.2M, c2 = 3000M;
            Console.WriteLine(c1 - c2);
            EndOfPrint();
            // round_trip
            Console.WriteLine("演示round_trip获取double准确转化字符串");
            RoundTrip();
            EndOfPrint();

            Console.WriteLine("演示值类型地址关系");
            int x1, x2;
            x1 = 12;
            Console.WriteLine($"x1{GetAddress(ref x1)}");
            x2 = x1;
            x1 = 22;
            Console.WriteLine($"x1{GetAddress(ref x1)}");
            unsafe
            {
                int* p = &x1;
                Console.WriteLine("x1 {0:X}", (uint)p);
            }
            Console.WriteLine($"x2{GetAddress(ref x2)}");
            Swap(x1, x2);
            EndOfPrint();
        }

        /// <summary>
        /// 更准确的得到double对应的字符串形式，使用"{:R}"
        /// </summary>
        static void RoundTrip()
        {
            const double number = 1.618033988749895;
            Console.WriteLine(number);
            // double无法精确表示
            Console.WriteLine("{0:R}", number);
            //使用一下转换解释
            double result;
            string text;

            text = $"{number}";
            result = double.Parse(text);
            Console.WriteLine($"{result == number}: result == number");

            text = $"{number:R}";
            result = double.Parse(text);
            Console.WriteLine($"{result == number}: result == number");
        }

        #endregion

        #region 字符串练习
        /// <summary>
        /// 学习字符串相关的知识
        /// </summary>
        static void StringFunc()
        {
            string str = "abcd";
            Console.WriteLine("反转字符串{0}", str);
            Console.WriteLine(Reverse(str));
            EndOfPrint();

            // 字符串赋值为空字符串
            Console.WriteLine("string.Empty == \"\"");
            str = "";
            Console.WriteLine(str.Equals(string.Empty));
            EndOfPrint();

            Console.WriteLine("演示字符串 abd 的编码");
            char[] chrs = new char[] { 'a', 'b', 'd' };
            str = new string(chrs);
            foreach (byte b in Encoding.UTF8.GetBytes(str))
            {
                Console.WriteLine(b);
            }
            EndOfPrint();

            // 演示占位符的使用
            Console.WriteLine("解释占位符格式化");
            string firstName = "leo", lastName = "sandwich";
            Console.WriteLine("你好，{1} {0}", firstName, lastName);
            // 演示变量占位符使用
            Console.WriteLine($"你好{firstName} {lastName}");
            EndOfPrint();

            Console.WriteLine("加法强制重载了+号");
            Console.WriteLine(10 + "5");
            Console.WriteLine(10.62 + "5");
            EndOfPrint();

            Console.WriteLine("十六进制格式化字符串");
            Console.WriteLine("0x{0:X}", 42);
            EndOfPrint();
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static string Reverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }
        #endregion

        /// <summary>
        /// 格式化输出演示结果
        /// </summary>
        static void EndOfPrint()
        {
            Console.WriteLine("==============================");
        }

        /// <summary>
        /// 获取int类型地址，演示值类型含义
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static string GetAddress(ref int x)
        {
            unsafe
            {
                fixed (int* p = &x)
                {
                    return string.Format("值{0}, 地址0x{1:X}", *p, (uint)p);
                }
            }
        }

        static void Swap(int a, int b)
        {
            unsafe
            {
                int* p = &a;
                Console.WriteLine($"地址:0x{(uint)p:X}");
                int* p1 = &b;
                Console.WriteLine($"地址:0x{(uint)p1:X}");

            }
        }
    }

}