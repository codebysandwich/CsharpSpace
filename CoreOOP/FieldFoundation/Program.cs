using System;

namespace FieldFoundation
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneCustomer customer = new PhoneCustomer();
            Console.WriteLine(customer.FirstName == null);
            Console.WriteLine(customer.Age);
        }
    }

    class PhoneCustomer
    {
        // 字段一般为私有
        private string firstName;
        public string FirstName
        {
            // 修饰设置字段为私有
            private set
            {
                firstName = value;
            }
            get
            {
                return firstName;
            }
        }

        /// <summary>
        /// 简化初始化属性
        /// </summary>
        public int Age { get; set; } = 42;
    }
}
