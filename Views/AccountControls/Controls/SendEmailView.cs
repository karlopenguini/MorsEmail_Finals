using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Models;

namespace MorsEmail.Views.AccountControls
{
    class SendEmailView
    {
        public SendEmailView(string Email, MorsEmailAccounts Accounts, List<string> FriendList)
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Header();
                Menu();
                input = Console.ReadKey().Key;

                if(input == ConsoleKey.D1)
                {
                    Console.Clear();
                    Composing(Email, Accounts);
                    Console.Write("Friend Email Address: ");
                    string friendEmail = Console.ReadLine();

                    if (Accounts.GETUserFriends(Email).Contains(friendEmail))
                    {
                        MorseCrypto encryptor = new MorseCrypto();

                        Console.Write("Caption: ");
                        string caption = Console.ReadLine() + "\n";
                        Console.Write("Message Box:\n");
                        string message = Console.ReadLine();

                        message = caption + message;
                        string encrypted = encryptor.Encrypt(message) != null ? encryptor.Encrypt(message) : "Your message has not been sent, it may have contain characters that is not recognized by the encryptor.";

                        Messenger.Send(Email, friendEmail, encrypted);
                        Success();
                        Console.Clear();
                        return;
                    }

                }

            } while (input != ConsoleKey.X);
        }

        private void Header()
        {
            string header =
@"
   ___                               ___            _ _ 
  / __|___ _ __  _ __  ___ ___ ___  | __|_ __  __ _(_) |
 | (__/ _ \ '  \| '_ \/ _ (_-</ -_) | _|| '  \/ _` | | |
  \___\___/_|_|_| .__/\___/__/\___| |___|_|_|_\__,_|_|_|
                |_|                                     
";
            Console.WriteLine(header);
        }

        private void Menu()
        {
            string menu =
@"

1 ) Compose Email

X ) Back

";
            Console.WriteLine(menu);
        }

        private void Composing(string userEmail, MorsEmailAccounts Accounts)
        {
            string composing =

@"
  _____                         _             ____           _ __  ____                   
 / ___/__  __ _  ___  ___  ___ (_)__  ___ _  / __/_ _  ___ _(_) / / __/__  ____           
/ /__/ _ \/  ' \/ _ \/ _ \(_-</ / _ \/ _ `/ / _//  ' \/ _ `/ / / / _// _ \/ __/ _   _   _ 
\___/\___/_/_/_/ .__/\___/___/_/_//_/\_, / /___/_/_/_/\_,_/_/_/ /_/  \___/_/   (_) (_) (_)
              /_/                   /___/                                                 
";
            Console.WriteLine(composing);

            foreach(string friend in Accounts.GETUserFriends(userEmail))
            {
                Console.WriteLine($"-> {friend}");
            }
            Console.WriteLine("\n\n");
        }

        private void Success()
        {
            string success =
@"
   ____           _ __               __    __
  / __/_ _  ___ _(_) / ___ ___ ___  / /_  / /
 / _//  ' \/ _ `/ / / (_-</ -_) _ \/ __/ /_/ 
/___/_/_/_/\_,_/_/_/ /___/\__/_//_/\__/ (_)  
                                       
Press any key to continue . . .

";
            Console.WriteLine(success);
            Console.ReadKey();
        }
    }
}
