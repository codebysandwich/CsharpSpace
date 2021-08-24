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
        }
    }
}
