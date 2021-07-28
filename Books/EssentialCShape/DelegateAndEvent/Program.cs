using System;

/// <summary>
/// 讲解委托与事件
/// </summary>
namespace DelegateAndEvent
{
    // 定义一个委托
    public delegate void SayHello(string name); 
    class Program
    {
        // 事件-限制了的委托
        public static event SayHello SayEnv;
        static void Main(string[] args)
        {
            // 注册一个委托
            SayHello Say = new SayHello(Sayhello);
            // 链式注册
            Say += Godbey;
            // lambda表达式
            Say += (string name) => {
                Console.WriteLine($"hola, {name}");
            };
            Say("sandwich");

            // 通过事件实现
            SayEnv += Call;
            SayEnv("事件触发");
            
        }

        #region 注册的函数事件
        static void Sayhello(string name)
        {
            Console.WriteLine($"hello, {name}");
        }

        static void Godbey(string name)
        {
            Console.WriteLine($"godbey, {name}");
        }
        static void Call(string name)
        {
            Console.WriteLine($"事件触发，{name}");
        }
        #endregion
    }
}