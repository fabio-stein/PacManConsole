using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class Renderer
    {
        private readonly int originalX = Constant.WindowXSize;
        private readonly int originalY = Constant.WindowYSize;
        private int scaleX = Constant.WindowXScale;
        private int scaleY = Constant.WindowYScale;

        public Renderer()
        {
            var ySize = originalY * scaleY + 1;
            var xSize = originalX * scaleX + 1;

            Console.SetWindowSize(xSize, ySize);
            Console.SetBufferSize(xSize, ySize);
            Console.CursorVisible = false;
            Console.Clear();
        }

        public void Render(LinkedList<EntityBase>[,] grid)
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < this.originalY; y++)
            {
                for (int x = 0; x < this.originalX; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First.Value;
                    Console.ForegroundColor = item.pixel.ForegroundColor;
                    Console.BackgroundColor = item.pixel.BackgroundColor;
                    Console.Write(item.character);

                    //Scale X
                    if (x < this.originalX - 1)
                    {
                        var nextItem = grid[y, x + 1].First.Value;
                        if (!(item.smoothRender && nextItem.smoothRender && item.character == nextItem.character))
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        for (int s = 0; s < scaleX - 1; s++)
                            Console.Write(' ');
                    }
                }

                //Finish line
                Console.WriteLine();

                //Scale Y
                if (y < this.originalY - 1)
                {
                    for (int s = 0; s < scaleY - 1; s++)
                    {
                        for (int x = 0; x < this.originalX; x++)
                        {
                            var entities = grid[y, x];
                            var item = entities.First.Value;
                            var nextItem = grid[y + 1, x].First.Value;

                            //1 color pixel + (scaleX -1) black pixels
                            if (item.smoothRender && nextItem.smoothRender && item.character == nextItem.character)
                            {
                                Console.ForegroundColor = item.pixel.ForegroundColor;
                                Console.BackgroundColor = item.pixel.BackgroundColor;
                                Console.Write(' ');
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(new string(' ', this.scaleX - 1));
                            }
                            else
                            {
                                //(scaleX) black pixels only
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(new string(' ', this.scaleX));
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }
        }

        public static void Clear()
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, 0);
        }

    }
}
