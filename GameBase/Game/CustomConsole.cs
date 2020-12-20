using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class CustomConsole
    {
        public static bool CursorVisible { get => Console.CursorVisible; set => Console.CursorVisible = value; }
        public static ConsoleColor ForegroundColor { get; set; }
        public static ConsoleColor BackgroundColor { get; set; }
        public static int WindowHeight { get => Console.WindowHeight; set => Console.WindowHeight = value; }
        public static int WindowWidth { get => Console.WindowWidth; set => Console.WindowWidth = value; }

        private static ConsolePixel[,] Grid;
        private static int CursorLeft = 0;
        private static int CursorTop = 0;

        internal static void Initialize(int xSize, int ySize)
        {
            Console.SetWindowSize(xSize, ySize);
            Console.SetBufferSize(xSize, ySize);
            Grid = new ConsolePixel[xSize, ySize];
        }

        internal static void Clear()
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, 0);

            Console.Clear();
            Initialize(Console.WindowWidth, Console.WindowHeight);
            CursorLeft = 0;
            CursorTop = 0;
        }

        internal static void SetCursorPosition(int left, int top)
        {
            CursorLeft = left;
            CursorTop = top;
        }

        internal static void Write(char character)
        {
            var current = Grid[CursorLeft, CursorTop];
            if (current == null || current.Character != character)
            {
                Grid[CursorLeft, CursorTop] = new ConsolePixel()
                {
                    Character = character,
                    BackgorundColor = BackgroundColor,
                    ForegroundColor = ForegroundColor
                };
                Console.SetCursorPosition(CursorLeft, CursorTop);
                Console.BackgroundColor = BackgroundColor;
                Console.ForegroundColor = ForegroundColor;
                Console.Write(character);
            }
            CursorLeft++;
        }

        internal static void WriteLine()
        {
            CursorLeft = 0;
            CursorTop++;
        }

        internal static void Write(string v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Write(v[i]);
            }
        }

        internal static void ResetColor()
        {
            Console.ResetColor();
        }
    }

    public class ConsolePixel
    {
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgorundColor { get; set; }
        public char Character { get; set; }
    }
}
