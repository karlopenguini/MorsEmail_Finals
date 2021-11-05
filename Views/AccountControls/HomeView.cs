using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Models.BaseModel;
using MorsEmail.Models;

namespace MorsEmail.Views.AccountControls
{
    public class HomeView
    {
        public HomeView(Account User, MorsEmailAccounts Accounts)
        {

            List<string> UserFriends = User.GETFriends();

            ConsoleKey input;
            do
            {
                Welcome(User);
                Menu();
                input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        new AddFriendView(User.Email, Accounts, UserFriends);
                        break;
                    case ConsoleKey.D2:
                        new SendEmailView(User.Email, Accounts, UserFriends);
                        break;
                    case ConsoleKey.D3:
                        new InboxView(User.Email, Accounts);
                        break;
                    case ConsoleKey.D4:
                        new OutboxView(User.Email, Accounts);
                        break;
                }
            } while (input != ConsoleKey.D5);
            Console.Clear();
            Logout();
            Console.ReadKey();
        }
        
        private void Welcome(Account User)
        {
            Console.Clear();
            string header =
$@"
  _      __    __                     __
 | | /| / /__ / /______  __ _  ___   / /
 | |/ |/ / -_) / __/ _ \/  ' \/ -_) /_/ 
 |__/|__/\__/_/\__/\___/_/_/_/\__/ (_)  

            {User.Email}
                                       
";
            Console.WriteLine(header);
        }

        private void Menu()
        {
            string menu =
@"
1 ) Add Friend

2 ) Send Email To Friend

3 ) View Inbox

4 ) View Outbox

5 ) Logout
";
            Console.WriteLine(menu);
        }
    
        private void Logout()
        {
            string logout =
@"
   __                  _                       __            
  / /  ___  ___ ____ _(_)__  ___ _  ___  __ __/ /_           
 / /__/ _ \/ _ `/ _ `/ / _ \/ _ `/ / _ \/ // / __/ _   _   _ 
/____/\___/\_, /\_, /_/_//_/\_, /  \___/\_,_/\__/ (_) (_) (_)
          /___//___/       /___/                             

Press any key to return to hero page
";
            Console.WriteLine(logout);
        }
    }
}
