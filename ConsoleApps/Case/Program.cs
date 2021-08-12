using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case
{
    class Program
    {
        /// <summary>
        /// 演示switch-case结构
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int salary = 5000;
            bool isTrue = true;
            Console.WriteLine("请输入职级评定(A/B/C/D/E):");
            string level = Console.ReadLine().ToUpper();
            #region if-else实现
            //if (level.Equals("A"))
            //{
            //    salary += 500;
            //}
            //else if (level.Equals("B"))
            //{
            //    salary += 200;
            //}
            //else if (level.Equals("C"))
            //{
            //    salary += 0;
            //}
            //else if (level.Equals("D"))
            //{
            //    salary -= 200;
            //}
            //else if (level.Equals("E"))
            //{
            //    salary -= 500;
            //}
            //else
            //{
            //    isTrue = false;
            //    Console.WriteLine("输入的职级不正确!");
            //}
            #endregion

            #region switch-case实现
            //switch (level)
            //{
            //    case "A":
            //        salary += 500;
            //        break;
            //    case "B":
            //        salary += 200;
            //        break;
            //    case "C": break;
            //    case "D":
            //        salary -= 200;
            //        break;
            //    case "E":
            //        salary -= 500;
            //        break;
            //    default:
            //        isTrue = false;
            //        Console.WriteLine("输出职级格式不正确!");
            //        break;
            //}
            #endregion

            #region 测试
            switch (level)
            {
                case "A": // 执行case B 代码
                case "B":
                    salary += 500;
                    break;
                case "C":
                    break;
                case "D":
                    salary -= 200;
                    break;
                default:
                    Console.WriteLine("输入的职级格式不正确!");
                    isTrue = false;
                    break;
            }
            #endregion

            if (isTrue)
            {
                Console.WriteLine($"薪资是: {salary}");
            }

            #region 判断万年历月份的天数
            Console.WriteLine("请输入年份:");
            int year;
            int month;
            int day;
            bool isLeap = false;
            bool isActive = true;
            if (int.TryParse(Console.ReadLine(), out year))
            {
                if (year < 0)
                {
                    isActive = false;
                    Console.WriteLine("输入年份格式不正确!");
                }
            }
            else
            {
                Console.WriteLine("输入年份格式不正确!");
            }
            Console.WriteLine("请输入月份:");
            if (int.TryParse(Console.ReadLine(), out month))
            {
                if (month < 1 || month > 12)
                {
                    isActive = false;
                    Console.WriteLine("输入的月份格式不正确!");
                }
            }
            else
            {
                Console.WriteLine("输入的月份格式不正确!");
            }
             
            // 判断闰年
            isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: day = 31;
                    break;
                case 2:
                    day = isLeap ? 29 : 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11: day = 30;
                    break;
                default:
                    day = -1;
                    isActive = false;
                    break;
            }

            if (isActive)
            {
                Console.WriteLine($"{year}年{month}月有{day}天");
            }
            #endregion
            Console.ReadKey();
        }
    }
}
