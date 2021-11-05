using MorsEmail.Models;
using MorsEmail.Views.AccountControls;
using System;

namespace MorsEmail.Views
{
    public class LoginView
    {
        public LoginView(MorsEmailAccounts Accounts)
        {
            bool accountMatched = false;
            string email = "";
            string password = "";

            ConsoleKey input;
            do
            {
                Header();
                Menu();
                input = Console.ReadKey().Key;
                if (input == ConsoleKey.D1)
                {
                    Header();
                    Console.Write("E-mail: ");
                    email = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();
                    if (Accounts.GETUser(email, password) != null)
                    {
                        accountMatched = true;
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Incorrect E-mail or Password !\n\nPress any key to continue . . .");
                    Console.ReadKey();
                }
            } while (input != ConsoleKey.X && accountMatched != true);

            
            if (accountMatched)
            {
                Console.Clear();
                new HomeView(Accounts.GETUser(email, password), Accounts);
            }

        }
        private void Header()
        {
            Console.Clear();
            string header =
@"
  __  __            ___            _ _   _              _      
 |  \/  |___ _ _ __| __|_ __  __ _(_) | | |   ___  __ _(_)_ _  
 | |\/| / _ \ '_(_-< _|| '  \/ _` | | | | |__/ _ \/ _` | | ' \ 
 |_|  |_\___/_| /__/___|_|_|_\__,_|_|_| |____\___/\__, |_|_||_|
                                                  |___/        
";
            Console.WriteLine(header);
        }

        private void Menu()
        {
            Console.WriteLine(@"1 ) Login

x ) Back
");
        }
    }

}
