using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringL
{
    class Program
    {
        static void Main(string[] args)
        {
            // 字符串加法
            Console.WriteLine("演示string重载加号");
            string s1 = "hello", s2 = "world";
            Console.WriteLine(s1 + s2);
            EndOfPrint();

            // $和@前缀
            string firstName = "leo", lastName = "sandwich";
            Console.WriteLine($@"hello, 
            {firstName} {lastName}");
            // 对比观察 ${}会打断换行
            Console.WriteLine($@"hello, {
                firstName} {lastName}");

            // $等价实现 String.Format
            object[] param  = new object[] { firstName, lastName };
            //Console.WriteLine("hello, {0} {1}", param);
            // 也等价于以下写法
            Console.WriteLine(string.Format("hello, {0} {1}", param));
            EndOfPrint();

            // 比较两个字符串，返回相对位置, 0 if equals
            int res = string.Compare("abc", "ABC", true);
            Console.WriteLine(res);
            EndOfPrint();

            // @原生字符串演示
            /*
             * 除了原生字符串还可以起到保留字符串原格式的作用
             */
            Console.WriteLine("演示@原生字符串的作用");
            // \b 退格键放在字符串两边没有效果
            Console.WriteLine("hello\b, world!\b");
            Console.WriteLine(@"\n\t");
            EndOfPrint();

            // 不同平台之间换行符差异解决办法
            Console.Write($"使用系统换行符{System.Environment.NewLine}_l");
            EndOfPrint();

            Console.ReadKey();
        }

        #region 格式化输出
        /// <summary>
        /// 格式打印的结尾
        /// </summary>
        static void EndOfPrint()
        {
            Console.WriteLine("=====================================");
        }
        #endregion
    }
}
