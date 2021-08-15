using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            // 测试continue和break
            TestContinueAndBreak();

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
    }
}
