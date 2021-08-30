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
            #region 递归获取文件夹下的文件
            DirectoryInfo dir = new DirectoryInfo(@"..\..\..\..\MyWork\IEM\IEM");
            List<string> list = new List<string>();
            GetFiles(dir, list);
            foreach (var fileName in list)
            {
                Console.WriteLine(fileName);
            }
            #endregion

            int[] nums = { 3, 1, 9 };
            int max, min, sum;
            double mean;
            if (Cal(nums, out max, out min, out sum, out mean))
            {
                Console.WriteLine("最大值:{0}, 最小值:{1}, 和:{2}, 均值:{3:N2}", max,
                    min, sum, mean);
            }

            Console.WriteLine("===============================================");
            nums = new int[] { 3, 8, 1 };
            ShowRef(ref nums);
            foreach (var item in nums)
            {
                Console.WriteLine(item);
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
        /// <summary>
        /// 判断和是否不为零
        /// 获取最大最小值，和与均值
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="max">最大值</param>
        /// <param name="min">最小值</param>
        /// <param name="sum">和</param>
        /// <param name="mean">均值</param>
        /// <returns></returns>
        static bool Cal(int[] nums, out int max, out int min, out int sum, out double mean)
        {
            bool isCheck = false;
            sum = 0;
            max = nums[0];
            min = nums[0];
            mean = 0;
            foreach (var item in nums)
            {
                sum += item;
                min = min > item ? item : min;
                max = max < item ? item : max;
            }
            if (sum == 0)
            {
                return isCheck;
            }
            else
            {
                isCheck = true;
                mean = 1.0 * sum / nums.Length;
                return isCheck;
            }
        }

        static void ShowRefence(int[] nums)
        {
            nums[0] = -99;
            nums = new int[] { 0, 1, 2 };
        }

        static void ShowRef(ref int[] nums)
        {
            nums[0] = -99;
            nums = new int[] { 0, 1, 2 };
        }
    }
}
