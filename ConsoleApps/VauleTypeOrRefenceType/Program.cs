using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VauleTypeOrRefenceType
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            unsafe
            {
                int* p = &x;
                Console.WriteLine("x地址:0x{0:X}", (uint)p);
            }
            // 赋值后地址变化，说明将值拷贝到新的地址
            int y = x;
            unsafe
            {
                int* p = &y;
                Console.WriteLine("y地址:0x{0:X}", (uint)p);
            }
            int[] arrx = { 1, 4, 0 };
            unsafe
            {
                fixed (int* p = &arrx[0])
                {
                    Console.WriteLine("arrx地址:0x{0:X}", (uint)p);
                }
            }
            // 引用类型赋值地址不变，说明arry和arrx指向同一个存储区域（存储堆上的数据地址），并不会发生拷贝
            int[] arry = arrx;
            unsafe
            {
                fixed (int* p = &arry[0])
                {
                    Console.WriteLine("arry地址:0x{0:X}", (uint)p);
                }
            }

            ChangeRefence(arrx);
            unsafe
            {
                fixed (int* p = &arrx[0])
                {
                    Console.WriteLine("arrx地址:0x{0:X}", (uint)p);
                }
            }

            ChangeRef(ref arrx);
            unsafe
            {
                fixed (int* p = &arrx[0])
                {
                    Console.WriteLine("arrx地址:0x{0:X}", (uint)p);
                }
            }

            int[] arrz = { 1, 4, 9 };

            Console.ReadKey();
        }

        /// <summary>
        /// 演示作用域内，引用类型给改引用的变化
        /// </summary>
        /// <param name="arr">引用类型int[]</param>
        static void ChangeRefence(int[] arr)
        {
            unsafe
            {
                fixed (int* p = &arr[0])
                {
                    Console.WriteLine("初始地址为:0x{0:X}", (uint)p);
                }
                // 局部变量引用位置发生变化，无法影响到外部变量
                arr = new int[] { 1, 6, 0, 9 };
                fixed (int* p = &arr[0])
                {
                    Console.WriteLine("修改后地址为:0x{0:X}", (uint)p);
                }
            }
        }

        /// <summary>
        /// 演示ref将变量作用域提升，外部与函数体内保持一致
        /// </summary>
        /// <param name="arr">引用类型int[]</param>
        static void ChangeRef(ref int[] arr)
        {
            unsafe
            {
                fixed (int* p = &arr[0])
                {
                    Console.WriteLine("初始地址为:0x{0:X}", (uint)p);
                }
                // 局部变量引用位置发生变化，通过ref传递到外部变量
                arr = new int[] { 1, 6, 0, 9 };
                fixed (int* p = &arr[0])
                {
                    Console.WriteLine("修改后地址为:0x{0:X}", (uint)p);
                }
            }
        }
    }
}
