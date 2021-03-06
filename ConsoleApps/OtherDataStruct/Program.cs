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
    /// <summary>
    /// 枚举类型一般直接放在命名空间下
    /// </summary>
    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public struct Person
    {
        public string name;
        public int age;
        public Gender gender;
        /// <summary>
        /// 重载ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"name: {name}, age: {age}, gender: {gender}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenArray();

            Console.WriteLine(Gender.Male);

            // 数值型转enum
            Gender gen = (Gender)0;
            Console.WriteLine(gen);
            // 字符串转enum
            gen = (Gender)Enum.Parse(typeof(Gender), "1");
            Console.WriteLine(gen);
            gen = (Gender)Enum.Parse(typeof(Gender), "Female");
            // enum 转字符串
            Console.WriteLine(gen.ToString());
            // enum 转数值
            Console.WriteLine((int)gen);


            Console.WriteLine("======================================");

            Person p1;
            p1.name = "张三";
            p1.age = 21;
            p1.gender = Gender.Male;

            Console.WriteLine(p1.ToString());

            HandleArray();

            int[] nums = new int[] { 9, 3, 1, 0 };
            Reverse(nums);

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
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

            Console.WriteLine("测试数组的引用类型特性:");
            int[] num4 = nums3;
            num4[3] = 99;
            foreach (var item in nums3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("演示结束!");

            // 创建二维数组，多维数组的各维度尺寸必须一致
            string[,] strs2 = new string[,] { { "a", "b", "c" }, { "c", "d", "f" } };

            // 创建嵌套数组, 嵌套数组的尺寸可以不一致, 但是创建方式不可减缓
            string[][] strs1 = new string[][] { new string[] { "a", "b", "c" }, new string[] { "c", "d" } };


            // 使用Linq获取满足条件的值并排序, 使用lambda表达式
            var res = nums1.Where(x => x % 2 == 0).OrderBy(x => x);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("演示map");
            var res1 = nums1.Select(x => x * x);
            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("演示结束");
        }
        /// <summary>
        /// 演示数组的基本操作
        /// </summary>
        static void HandleArray()
        {
            int[] nums = { 3, 2, 1, 9, 2, 7, 3 };
            int min = nums[0], max = nums[0];
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
                min = num < min ? num : min;
                max = num > max ? num : max;
            }
            Console.WriteLine(nums.Mean());
            double mean = 1.0 * sum / nums.Length;
            Console.WriteLine($"数组最大值:{max}, 最小值:{min}," +
                $" 和:{sum}, 均值:{mean:F2}");
        }
        /// <summary>
        /// 反转数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static void Reverse(int[] nums)
        {
            for (int i = 0; i < nums.Length/2; i++)
            {
                int temp = nums[i];
                nums[i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = temp;
            }
        }
    }
    static class IntsExtension
    {
        public static double Mean(this int[] nums)
        {
            return 1.0 * nums.Sum() / nums.Length;
        }
    }
}
