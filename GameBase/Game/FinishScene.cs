using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Game
{
    public class FinishScene
    {
        public void Run()
        {
            Renderer.Clear();
            Console.WriteLine(@"
 /$$$$$$$$/$$                        /$$             /$$     /$$               
|__  $$__| $$                       | $$            |  $$   /$$/               
   | $$  | $$$$$$$  /$$$$$$ /$$$$$$$| $$   /$$       \  $$ /$$/$$$$$$ /$$   /$$
   | $$  | $$__  $$|____  $| $$__  $| $$  /$$/        \  $$$$/$$__  $| $$  | $$
   | $$  | $$  \ $$ /$$$$$$| $$  \ $| $$$$$$/          \  $$| $$  \ $| $$  | $$
   | $$  | $$  | $$/$$__  $| $$  | $| $$_  $$           | $$| $$  | $| $$  | $$
   | $$  | $$  | $|  $$$$$$| $$  | $| $$ \  $$          | $$|  $$$$$$|  $$$$$$/
   |__/  |__/  |__/\_______|__/  |__|__/  \__/          |__/ \______/ \______/ 
                                                                               

You finished this game!
Feel free to modify the source code at https://github.com/fabio-stein/PacManConsole
Get in contact with me at https://www.linkedin.com/in/fabio-stein/


================================================.
     .-.   .-.     .--.                         |
    | OO| | OO|   / _.-' .-.   .-.  .-.   .''.  |
    |   | |   |   \  '-. '-'   '-'  '-'   '..'  |
    '^^^' '^^^'    '--'                         |
===============.  .-.  .================.  .-.  |
               | |   | |                |  '-'  |
               | |   | |                |       |
               | ':-:' |                |  .-.  |
               |  '-'  |                |  '-'  |
==============='       '================'       |
");
            Console.ReadLine();
        }
    }
}
