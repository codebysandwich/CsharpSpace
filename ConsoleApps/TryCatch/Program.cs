using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int number=0;
            // 标记是否成功
            bool iserror = false;
            Console.WriteLine("请输入需要转换的数字:");
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("输入的数据格式无法转化为整形");
            }
            catch (Exception e)
            {
                iserror = true;
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("测试完成!");
            }
            if (!iserror)
            {
                Console.WriteLine(number*2);
            }
            Console.ReadKey();
        }
    }
}
