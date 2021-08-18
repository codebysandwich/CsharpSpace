using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = Product.GetSampleProducts();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    public class Product
    {
        #region C#1
        //string name;
        //decimal price;
        ///*return name可以省略*/
        //public string Name { get { return name; } }
        //public decimal Price { get { return price; } }

        //public Product(string name, decimal price)
        //{
        //    this.name = name;
        //    this.price = price;
        //}
        #endregion

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// 静态方法：生产数据模板 C#1
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetSampleProducts()
        {
            ArrayList list = new ArrayList();
            list.Add(new Product("West Side Story", 9.99m));
            list.Add(new Product("Assassins", 14.99m));
            list.Add(new Product("Frogs", 13.99m));
            list.Add(new Product("Sweeney Todd", 10.99m));
            return list;
        }

        #region C# 2
        /// <summary>
        /// List<Product> 等价与 ArrayList [Product], 无法重载
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetSampleProducts(string info)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("West Side Story", 9.99m));
            list.Add(new Product("Assassins", 14.99m));
            list.Add(new Product("Frogs", 13.99m));
            list.Add(new Product("Sweeney Todd", 10.99m));
            // 无实际意义
            Console.WriteLine(info);
            return list;
        }
        #endregion
        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }
}
