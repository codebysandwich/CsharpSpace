using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    class Program
    {
        static bool IsEmpty(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return true;
            }
            else
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            string fileName = "F:\\VsCode\\hello.txt";
            Console.WriteLine(IsEmpty(fileName));
            Console.ReadKey();
        }
    }
}
