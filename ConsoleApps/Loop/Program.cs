using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    /// <summary>
    /// 展示C#中的循环语法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 测试continue和break
            TestContinueAndBreak();

            //CalScore();

            Console.WriteLine("100以内的素数和是：{0}", SumPrime(100));

            Console.WriteLine(SumNarcissistic());

            Console.WriteLine("=============================================");
            Multi();

            Console.ReadKey();
        }
        /// <summary>
        /// 测试continue和break
        /// </summary>
        static void TestContinueAndBreak()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    continue;
                else if (i == 7)
                    break;
                else
                    Console.WriteLine(i);
            }
        }
        /// <summary>
        /// 输入与计算联系，并且处理异常
        /// </summary>
        static void CalScore()
        {
            int num;
            while (true)
            {
                Console.Write("请输入班级成员数量:");
                if (int.TryParse(Console.ReadLine(), out num))
                    break;
                else
                {
                    Console.WriteLine("输入格式错误!");
                    continue;
                }
            }
            double sum = 0;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("请输入第{0}个学生的成绩:", i + 1);
                double score;
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out score))
                    {
                        sum += score;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("格式错误,请重新输入成绩:");
                        continue;
                    }
                }
            }
            Console.WriteLine("总成绩：{0}, 平均分数：{1}", sum, sum / num);
        }
        /// <summary>
        /// 判断一个数是否是素数
        /// </summary>
        /// <param name="num">数值</param>
        /// <returns>是否是素数</returns>
        static bool IsPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 求2-num之间素数的和
        /// </summary>
        /// <param name="num">最大的范围</param>
        /// <returns></returns>
        static int SumPrime(int num)
        {
            int sum = 0;
            for (int i = 2; i <= num; i++)
            {
                if (IsPrime(i))
                    sum += i;
            }
            return sum;
        }
        /// <summary>
        /// 水仙花数:一个 n 位正整数，它的每个位上的数字的 n 次幂之和 等于它本身
        /// 这里n取3
        /// </summary>
        /// <param name="num">100~999的三位正整数</param>
        /// <returns></returns>
        static bool IsNarcissistic(int num)
        {
            // 个位数
            int x = num % 10;
            // 十位数
            int y = num / 10 % 10;
            // 百位数
            int z = num / 100;
            return x * x * x + y * y * y + z * z * z == num;

        }
        /// <summary>
        /// 求100-999之内水仙花数的和
        /// </summary>
        /// <returns></returns>
        static int SumNarcissistic()
        {
            int sum = 0;
            for (int i = 100; i <= 999; i++)
            {
                if (IsNarcissistic(i))
                    sum += i;
            }
            return sum;
        }
        /// <summary>
        /// 打印乘法口诀
        /// </summary>
        static void Multi()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}x{i}={i * j}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
