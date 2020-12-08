using GameBase.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new GameController().Run();
        }
    }
}
