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
            switch (level)
            {
                case "A":
                    salary += 500;
                    break;
                case "B":
                    salary += 200;
                    break;
                case "C": break;
                case "D":
                    salary -= 200;
                    break;
                case "E":
                    salary -= 500;
                    break;
                default:
                    isTrue = false;
                    Console.WriteLine("输出职级格式不正确!");
                    break;
            }
            #endregion
            if (isTrue)
            {
                Console.WriteLine($"薪资是: {salary}");
            }

            Console.ReadKey();
        }
    }
}
