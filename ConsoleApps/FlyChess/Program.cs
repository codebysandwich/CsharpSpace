using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyChess
{
    /* 数据说明
     * 0: 普通     ▢    
     * 1: 幸运轮盘  ◎
     * 2: 地雷     ☆
     * 3: 暂停     ▲
     * 4: 失控隧道  卐
     */
    /// <summary>
    /// 棋子结构数据
    /// </summary>
    struct Chess
    {
        public string Appearence;
        public ConsoleColor Color;
    }
    class Program
    {
        // 存储用户名称信息
        private static string playerAName;
        private static string playerBName;
        // 存储用户在地图中的位置
        private static int playerALocation;
        private static int playerBLocation;
        #region 地图元素信息
        // 存储地图的数据
        private static int[] maps = new int[100];
        private static string playerAll = "<>";
        private static string playerA = "Ａ";
        private static string playerB = "Ｂ";
        private static Chess normalChess = new Chess() { Appearence = "▢", Color = ConsoleColor.Yellow };
        private static Chess lucyChess = new Chess() { Appearence = "◎", Color = ConsoleColor.Red };
        private static Chess mineChess = new Chess() { Appearence = "☆", Color = ConsoleColor.Green };
        private static Chess pauseChess = new Chess() { Appearence = "▲", Color = ConsoleColor.Blue };
        private static Chess timeTunnelChess = new Chess() { Appearence = "卐", Color = ConsoleColor.Gray };
        private static Chess[] chesses = { normalChess, lucyChess, mineChess, pauseChess, timeTunnelChess };
        // 存储特殊地图元素的位置标记
        private static int[] lukyTurn;
        private static int[] mines;
        private static int[] pause;
        private static int[] timeTunnel;
        #endregion
        static void Main(string[] args)
        {
            // 初始化玩家位置
            playerALocation = playerBLocation = 0;
            // 绘制游戏头
            ShowFlyHeader();
            #region 准备初始化地图数据
            lukyTurn = new int[] { 6, 23, 40, 55, 69, 83 };
            mines = new int[] { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            pause = new int[] { 9, 27, 60, 93 };
            timeTunnel = new int[] { 20, 25, 45, 63, 72, 88, 90 };
            #endregion
            InitFlyMap();


            Console.ReadKey();
        }
        /// <summary>
        /// 绘制游戏头
        /// </summary>
        public static void ShowFlyHeader()
        {
            string msg = "***********************";
            ColorWriteLine(msg, ConsoleColor.DarkBlue);
            ColorWriteLine(msg, ConsoleColor.Yellow);
            ColorWriteLine(msg, ConsoleColor.Green);
            ColorWriteLine("******飞行棋-v1.0******", ConsoleColor.Green);
            ColorWriteLine(msg, ConsoleColor.Red);
            ColorWriteLine(msg);
            ColorWriteLine(msg, ConsoleColor.Cyan);
        }
        /// <summary>
        /// 初始化飞行棋地图数据
        /// </summary>
        static void InitFlyMap()
        {
            foreach (var index in lukyTurn)
            {
                maps[index] = 1;
            }
            foreach (var index in mines)
            {
                maps[index] = 2;
            }
            foreach (var index in pause)
            {
                maps[index] = 3;
            }
            foreach (var index in timeTunnel)
            {
                maps[index] = 4;
            }
        }
        /// <summary>
        /// 绘制地图
        /// </summary>
        static void DrawFlyMap()
        {
            
        }

        #region 内部函数，绘制地图时使用
        /// <summary>
        /// 终端中绘制一行
        /// </summary>
        /// <param name="start">maps地图中开始索引</param>
        /// <param name="end">maps地图中结束索引</param>
        static void DrawRow(int start, int end)
        {

        }
        /// <summary>
        /// 终端中绘制一列
        /// </summary>
        /// <param name="start">maps地图中开始索引</param>
        /// <param name="end">maps地图中结束索引</param>
        static void DrawCol(int start, int end)
        {

        }
        #endregion
        #region 终端打印带有颜色的信息
        /// <summary>
        /// 在终端打印彩色一行信息，默认颜色为终端默认颜色，打印后恢复默认色
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="color">终端颜色</param>
        static void ColorWriteLine(string msg, ConsoleColor color = ConsoleColor.Gray)
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
        static void ColorWrite(string msg, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}
