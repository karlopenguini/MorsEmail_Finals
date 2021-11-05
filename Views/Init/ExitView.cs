using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorsEmail.Views.Init
{
    public class ExitView
    {
        public ExitView()
        {
            Console.Clear();
            string message =
@"
___________.__                   __                                             
\__    ___/|  |__ _____    ____ |  | __  ___.__. ____  __ __                 
  |    |   |  |  \\__  \  /    \|  |/ / <   |  |/  _ \|  |  \                
  |    |   |   Y  \/ __ \|   |  \    <   \___  (  <_> )  |  /                   
  |____|   |___|  (____  /___|  /__|_ \  / ____|\____/|____/                    
                \/     \/     \/     \/  \/                                     
  _____                           .__                                           
_/ ____\___________   __ __  _____|__| ____    ____                             
\   __\/  _ \_  __ \ |  |  \/  ___/  |/    \  / ___\                            
 |  | (  <_> )  | \/ |  |  /\___ \|  |   |  \/ /_/  >                           
 |__|  \____/|__|    |____//____  >__|___|  /\___  /                            
                                                                           
   _____                      ___________              .__.__              __   
  /     \   ___________  _____\_   _____/ _____ _____  |__|  |             \ \  
 /  \ /  \ /  _ \_  __ \/  ___/|    __)_ /     \\__  \ |  |  |     ______   \ \ 
/    Y    (  <_> )  | \/\___ \ |        \  Y Y  \/ __ \|  |  |__  /_____/   / / 
\____|__  /\____/|__|  /____  >_______  /__|_|  (____  /__|____/           /_/  
        \/                  \/        \/      \/     \/                         

PRESS ANY KEY TO EXIT

";
            Console.WriteLine(message);
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
