using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Validation;
using System.Threading.Tasks;

using MorsEmail.Models;

namespace MorsEmail.Views
{
    public class RegisterView
    {
        public RegisterView(MorsEmailAccounts Accounts)
        {
            string Email = "";
            do
            {
                Header();
                Console.Write("MorsEmail UserID: ");

                Email = Console.ReadLine();
            } while (!ValidateCredentials.AuthEmail(Email));
            Email += "@morse.com";
            string Password = "";
            do
            {
                Header();
                Console.WriteLine($"MorsEmail UserID: {Email}");
                Console.Write("MorsEmail Password: ");

                Password = Console.ReadLine();
            } while (!ValidateCredentials.AuthPassword(Password));

            Accounts.POSTAccount(Email, Password);

            Success(Email, Password);

            return;
        }
        private void Header()
        {
            Console.Clear();
            string header =
@"
  ___          _    _               _                      _   
 | _ \___ __ _(_)__| |_ ___ _ _    /_\  __ __ ___ _  _ _ _| |_ 
 |   / -_) _` | (_-<  _/ -_) '_|  / _ \/ _/ _/ _ \ || | ' \  _|
 |_|_\___\__, |_/__/\__\___|_|   /_/ \_\__\__\___/\_,_|_||_\__|
         |___/                                                 

";
            Console.WriteLine(header);
        }

        private void Success(string email, string password)
        {
            Console.Clear();
            string message =
$@"
    _                      _     ___          _    _                  _   _ 
   /_\  __ __ ___ _  _ _ _| |_  | _ \___ __ _(_)__| |_ ___ _ _ ___ __| | | |
  / _ \/ _/ _/ _ \ || | ' \  _| |   / -_) _` | (_-<  _/ -_) '_/ -_) _` | |_|
 /_/ \_\__\__\___/\_,_|_||_\__| |_|_\___\__, |_/__/\__\___|_| \___\__,_| (_)
                                        |___/                               

E-mail Address: {email}
Password : {password}

Press any key to continue . . .
";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
