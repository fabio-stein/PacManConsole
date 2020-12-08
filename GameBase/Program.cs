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

            var s = new Scene(21, 15);
            s.Load("Resource/map.txt");

            var sw = new Stopwatch();
            var delay = 400;
            while (true)
            {
                sw.Start();
                s.Tick();
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                sw.Reset();
                var target = (elapsed > delay) ? 0 : delay - elapsed;
                Task.Delay(TimeSpan.FromMilliseconds(target)).Wait();
            }
        }
    }
}
