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

            CustomConsole.Initialize(xSize, ySize);
            CustomConsole.CursorVisible = false;
            CustomConsole.Clear();
        }

        public void Render(LinkedList<EntityBase>[,] grid)
        {
            CustomConsole.SetCursorPosition(0, 0);

            for (int y = 0; y < this.originalY; y++)
            {
                for (int x = 0; x < this.originalX; x++)
                {
                    var entities = grid[y, x];
                    var item = entities.First.Value;
                    CustomConsole.ForegroundColor = item.pixel.ForegroundColor;
                    CustomConsole.BackgroundColor = item.pixel.BackgroundColor;
                    CustomConsole.Write(item.character);

                    //Scale X
                    if (x < this.originalX - 1)
                    {
                        var nextItem = grid[y, x + 1].First.Value;
                        if (!(item.smoothRender && nextItem.smoothRender && item.character == nextItem.character))
                        {
                            CustomConsole.ForegroundColor = ConsoleColor.Black;
                            CustomConsole.BackgroundColor = ConsoleColor.Black;
                        }
                        for (int s = 0; s < scaleX - 1; s++)
                            CustomConsole.Write(' ');
                    }
                }

                //Finish line
                CustomConsole.WriteLine();

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
                                CustomConsole.ForegroundColor = item.pixel.ForegroundColor;
                                CustomConsole.BackgroundColor = item.pixel.BackgroundColor;
                                CustomConsole.Write(' ');
                                CustomConsole.ForegroundColor = ConsoleColor.Black;
                                CustomConsole.BackgroundColor = ConsoleColor.Black;
                                CustomConsole.Write(new string(' ', this.scaleX - 1));
                            }
                            else
                            {
                                //(scaleX) black pixels only
                                CustomConsole.ForegroundColor = ConsoleColor.Black;
                                CustomConsole.BackgroundColor = ConsoleColor.Black;
                                CustomConsole.Write(new string(' ', this.scaleX));
                            }
                        }
                        CustomConsole.WriteLine();
                    }
                }

            }
        }

        public static void Clear()
        {
            CustomConsole.Clear();
        }

    }
}
