using GameBase.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class GameController
    {
        private Renderer renderer = new Renderer();
        public void Run()
        {
            Console.Title = "PacMan Console";
            while (true)
            {
                Intro();
                Game(renderer);
            }
        }

        private void Intro()
        {
            new IntroScene().Run();
        }

        private void Game(Renderer renderer)
        {
            var s = new GameScene(Constant.WindowXSize, Constant.WindowYSize, renderer);
            s.Load("Resource/map.txt");

            var sw = new Stopwatch();
            while (s.transition == TransitionType.None)
            {
                sw.Start();
                s.Tick();
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                sw.Reset();
                var target = (elapsed > Constant.GameLoopDelay) ? 0 : Constant.GameLoopDelay - elapsed;
                Task.Delay(TimeSpan.FromMilliseconds(target)).Wait();
            }

            if (s.transition == TransitionType.Finish)
                Finish();
            else
                Dead();
        }

        private void Finish()
        {
            new FinishScene().Run();
        }

        private void Dead()
        {
            new DeadScene().Run();
        }
    }
}
