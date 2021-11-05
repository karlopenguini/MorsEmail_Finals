using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MorsEmail.Models;
using MorsEmail.Datastructures;

namespace MorsEmail.Views.AccountControls
{
    class OutboxView
    {
        public OutboxView(string Email, MorsEmailAccounts Accounts)
        {
            ConsoleKey input;
            do
            {
                Console.Clear();
                Header();
                Menu();
                input = Console.ReadKey().Key;
                string toRead = "";
                List<string> friends;
                if (input == ConsoleKey.D1)
                {
                    do
                    {
                        Console.Clear();
                        friends = ChooseFriend(Accounts.GETOutboxAddresses(Email));

                        Console.Write("Friend Address: ");
                        toRead = Console.ReadLine();

                        if (friends.Contains(toRead))
                        {

                            ViewMessages(Email, toRead);

                            Console.ReadKey();
                            break;
                        }

                    } while (!friends.Contains(toRead));

                }
            } while (input != ConsoleKey.X);
        }
        private void Header()
        {

            string Header =
@"
 __   ___                                   ___       _   _               _ 
 \ \ / (_)_____ __ __  _  _ ___ _  _ _ _   / _ \ _  _| |_| |__  _____ __ | |
  \ V /| / -_) V  V / | || / _ \ || | '_| | (_) | || |  _| '_ \/ _ \ \ / |_|
   \_/ |_\___|\_/\_/   \_, \___/\_,_|_|    \___/ \_,_|\__|_.__/\___/_\_\ (_)
                       |__/                                                                            
";
            Console.WriteLine(Header);
        }

        private void Menu()
        {
            Console.WriteLine(@"1 ) View Outbox
x ) Exit");
        }

        private List<string> ChooseFriend(List<string> addresses)
        {
            string choose =
@"
  _______                       ____    _             __
 / ___/ /  ___  ___  ___ ___   / __/___(_)__ ___  ___/ /
/ /__/ _ \/ _ \/ _ \(_-</ -_) / _// __/ / -_) _ \/ _  / 
\___/_//_/\___/\___/___/\__/ /_/ /_/ /_/\__/_//_/\_,_/  
                                                        
";
            List<string> avail = new List<string>();
            Console.WriteLine(choose);
            foreach (string email in addresses)
            {
                Console.WriteLine($"-> {email}");
                avail.Add(email);
            }


            return avail;

        }
        private void ViewMessages(string currEmail, string friendEmail)
        {
            Console.Clear();
            SimpleStack<string> messages = MessageViewer.GETMessages(currEmail, friendEmail, "outbox");

            while (!messages.IsEmpty())
            {
                string fpath = messages.Pop();
                string encryptedMessage = File.ReadAllText(fpath);

                DisplayMessage(currEmail, friendEmail, encryptedMessage);

            }
        }
        private void DisplayMessage(string currEmail, string friendEmail, string encryptedMessage)
        {
            MorseCrypto decryptor = new MorseCrypto();

            string messageDecrypted = decryptor.Decrypt(encryptedMessage);

            string[] messageSplit = messageDecrypted.Split('\n');

            string caption = messageSplit[0];
            string body = messageSplit[1];

            Console.WriteLine(
$@"------------------------------------------------------------------------------------------------------------------

From: {currEmail}
To: {friendEmail}

Caption: {caption}

{body}

------------------------------------------------------------------------------------------------------------------


");

        }
    }
}
