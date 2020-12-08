using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Game
{
    public class IntroScene
    {
        public void Run()
        {
            Renderer.Clear();
            Console.WriteLine(@"




            $$$$$$$\                           $$\      $$\                     
            $$  __$$\                          $$$\    $$$ |                    
            $$ |  $$ |$$$$$$\   $$$$$$$\       $$$$\  $$$$ | $$$$$$\  $$$$$$$\  
            $$$$$$$  |\____$$\ $$  _____|      $$\$$\$$ $$ | \____$$\ $$  __$$\ 
            $$  ____/ $$$$$$$ |$$ /            $$ \$$$  $$ | $$$$$$$ |$$ |  $$ |
            $$ |     $$  __$$ |$$ |            $$ |\$  /$$ |$$  __$$ |$$ |  $$ |
            $$ |     \$$$$$$$ |\$$$$$$$\       $$ | \_/ $$ |\$$$$$$$ |$$ |  $$ |
            \__|      \_______| \_______|      \__|     \__| \_______|\__|  \__|
                                                                     
                                                                   
                                ──▒▒▒▒▒────▄████▄─────
                                ─▒─▄▒─▄▒──███▄█▀──────
                                ─▒▒▒▒▒▒▒─▐████──█──█──
                                ─▒▒▒▒▒▒▒──█████▄──────
                                ─▒─▒─▒─▒───▀████▀─────          

                                Press any key to start
");
            Console.ReadKey();
        }
    }
}
