using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndOut
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Code\1.Repos\CsharpSpace\MyWork\IEM\IEM");
            List<string> list = new List<string>();
            GetFiles(dir, list);
            foreach (var fileName in list)
            {
                Console.WriteLine(fileName);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// 递归获取文件夹下的所有文件
        /// </summary>
        /// <param name="dir">文件夹信息</param>
        /// <param name="fileList">存放文件地址的List</param>
        static void GetFiles(DirectoryInfo dir, List<string> fileList)
        {

            foreach (FileInfo item in dir.GetFiles())
            {
                fileList.Add(item.FullName);
            }
            foreach (DirectoryInfo item in dir.GetDirectories())
            {
                GetFiles(item, fileList);
            }
        }
    }
}
