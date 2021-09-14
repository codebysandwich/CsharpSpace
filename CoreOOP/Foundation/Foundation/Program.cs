using System;

namespace Foundation
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new PhoneCustomer("sandwich");
            Console.WriteLine("customer-> FirstName:{0}, Age:{1}", customer.FirstName, customer.Age);
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
}
