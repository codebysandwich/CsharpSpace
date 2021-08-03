using System;

namespace Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "this is an extension sample!";
            Console.WriteLine("s have {0} words", s.CountWord());
        }
    }
    public static class StrExtension
    {
        /// <summary>
        /// 为string类型拓展接口,计算单词个数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountWord(this string str)
        {
            return str.Split(new char[] {' ', ',', '!', '?'},
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
