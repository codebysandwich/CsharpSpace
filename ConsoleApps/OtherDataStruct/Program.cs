using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 演示非基元数据结构
/// </summary>
namespace OtherDataStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            GenArray();

            Console.ReadKey();
        }

        /// <summary>
        /// 创建数组的几种方法
        /// </summary>
        static void GenArray()
        {
            // 完整的声明
            int[] nums1 = new int[7] { 3, 4, 9, 1, 2, 7, 6 };
            // 简化申明
            int[] nums2 = new int[] { 2, 1, 0, 4 };
            // 再简化
            int[] nums3 = { 4, 8, 0, 1 };

            // 创建二维数组，多为数组的各维度尺寸必须一致
            string[,] strs2 = new string[,] { { "a", "b", "c" },{ "c", "d", "f"} };

            // 创建嵌套数组, 嵌套数组的尺寸可以不一致, 但是创建方式不可减缓
            string[][] strs1 = new string[][] { new string[] { "a", "b", "c" }, new string[]{"c", "d" } };


            // 使用Linq获取满足条件的值并排序
            var res = nums1.Where(Test).OrderBy(x => x);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        
        static bool Test(int i)
        {
            return i % 2 == 0;
        }
    } 
}
