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
            // 命名参数
            int res = Math.GetSquareOf(x:3);
            Console.WriteLine($"类方法输出平方结果:{res}");
            #endregion
            Console.WriteLine(Singleton.Instance);

            Car car = new Car("Proton Persona");
            Console.WriteLine(car);
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

    /// <summary>
    /// 实现单例模式
    /// </summary>
    class Singleton
    {
        private static Singleton s_instance;
        private int _state;
        private Singleton(int state)
        {
            _state = state;
        }
        public static Singleton Instance 
        { 
            get{return s_instance ?? (s_instance = new Singleton(42));}
        }

        public override string ToString()
        {
            return $"Singleton state = {_state}";
        }
    }

    class Car
    {
        private string _description;
        private uint _nWheels;
        public Car(string description, uint nWheels=4)
        {
            _description = description;
            _nWheels = nWheels;
        }
        public Car(string description): this(description, 5)
        {// 此处级别高于参数默认值
        }
        public override string ToString()
        {
            return $"Car description:{_description}, nWheels:{_nWheels}";
        }
    }
}