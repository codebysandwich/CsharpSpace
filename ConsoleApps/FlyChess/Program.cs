using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChess
{
    /// <summary>
    /// 棋子结构数据
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            // 存储棋谱的数据
            int[] maps = new int[100];

            Console.ReadKey();

        }
        /// <summary>
        /// 在终端输出飞行棋地图
        /// </summary>
        static void ShowFlyMap()
        {
            
        }

        #region 终端打印带有颜色的信息
        /// <summary>
        /// 在终端打印彩色一行信息，默认颜色为终端默认颜色，打印后恢复默认色
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="color">终端颜色</param>
        static void ColorWriteLine(string msg, ConsoleColor color=ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /// <summary>
        /// 在终端打印彩色内容（不换行），默认颜色为终端默认颜色，打印后恢复默认色
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="color">终端颜色</param>
        static void ColorWrite(string msg, ConsoleColor color=ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}
