using System;

namespace Foundation
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new PhoneCustomer("sandwich");
            Console.WriteLine("customer-> FirstName:{0}, Age:{1}", customer.FirstName, customer.Age);

            #region math class
            Math math = new Math();
            math.Value = 2;
            Console.WriteLine(math.GetSquare());
            int res = Math.GetSquareOf(3);
            Console.WriteLine($"类方法输出平方结果:{res}");
            #endregion
        }
    }

    /// <summary>
    /// PhoneCustomer类
    /// </summary>
    class PhoneCustomer
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            // 设置属性的访问权限
            private set
            {
                _firstName = value;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="firstName"></param>
        public PhoneCustomer(string firstName)
        {
            FirstName = firstName;
        }
        public int Age { get; set; } = 42;
    }

    /// <summary>
    /// 演示静态方法和成员方法
    /// </summary>
    class Math
    {
        public int Value { get; set; }
        public int GetSquare() => Value * Value;
        public static int GetSquareOf(int x) => x * x;
        public static double GetPi() => 3.14159;

    }
}