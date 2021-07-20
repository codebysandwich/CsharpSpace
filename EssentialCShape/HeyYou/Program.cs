using System;

namespace HeyYou
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName;
            Console.WriteLine("Hey you");

            Console.WriteLine("Enter your first name: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name: ");
            lastName = Console.ReadLine();

            Console.WriteLine($"hey {firstName} {lastName}");
            Console.ReadKey();
        }
    }
}
