using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MorsEmail.Models;

namespace MorsEmail.Views.Init
{
    public class HeroView
    {
        public HeroView(MorsEmailAccounts Accounts)
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                ShowMenu();
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        LoginView login = new LoginView(Accounts);

                        break;
                    case ConsoleKey.D2:
                        RegisterView register = new RegisterView(Accounts);

                        break;
                    case ConsoleKey.X:
                        ExitView exit = new ExitView();
                        break;
                }

            } while (input != ConsoleKey.X);
        }
        private void ShowMenu()
        {
            Console.Clear();
            string menu =
@"
   _____                      ___________              .__.__   
  /     \   ___________  _____\_   _____/ _____ _____  |__|  |  
 /  \ /  \ /  _ \_  __ \/  ___/|    __)_ /     \\__  \ |  |  |  
/    Y    (  <_> )  | \/\___ \ |        \  Y Y  \/ __ \|  |  |__
\____|__  /\____/|__|  /____  >_______  /__|_|  (____  /__|____/
        \/                  \/        \/      \/     \/         

1 ) Login

2 ) Register

x ) Exit

Press key to select
";
            Console.WriteLine(menu);
        }
    }
}
