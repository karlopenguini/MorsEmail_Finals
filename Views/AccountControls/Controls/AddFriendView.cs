using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MorsEmail.Views.AccountControls.Controls.Validation;

using MorsEmail.Models;


namespace MorsEmail.Views.AccountControls
{
    class AddFriendView
    {
        public AddFriendView(string Email, MorsEmailAccounts Accounts, List<string> FriendList)
        {
            string emailToAdd= "";
            List<string> availableAccounts = AvailableAccounts(Email,Accounts,FriendList);

            do
            {
                AddFriendMenu(Email, Accounts, availableAccounts);
                Console.Write("MorsEmail Address to Add as Friend: ");
                emailToAdd = Console.ReadLine();

            } while (!ControlValidation.InAvailableAccounts(emailToAdd, availableAccounts));

            Accounts.POSTFriend(Email, emailToAdd);
            Success(Email, emailToAdd);
            
        }

        public void AddFriendMenu(string currEmail, MorsEmailAccounts Accounts, List<string> availableAccounts)
        {
            Console.Clear();
            string header =
@"

    _      _    _   ___    _             _ 
   /_\  __| |__| | | __| _(_)___ _ _  __| |
  / _ \/ _` / _` | | _| '_| / -_) ' \/ _` |
 /_/ \_\__,_\__,_| |_||_| |_\___|_||_\__,_|

";
            Console.WriteLine(header);

            foreach (string accEmail in availableAccounts)
            {
                Console.WriteLine($"-> {accEmail}");
            }
        }

        public List<string> AvailableAccounts(string currEmail, MorsEmailAccounts Accounts, List<string> FriendList)
        {
            List<string> availableAccounts = new List<string>();
            List<string> accounts = Accounts.GETUsers();

            foreach (string accEmail in accounts)
            {
                if (accEmail == currEmail || FriendList.Contains(accEmail))
                {
                    continue;
                }
                else
                {
                    availableAccounts.Add(accEmail);
                }
            }
            return availableAccounts;
        }
        
        public void Success(string email, string emailToAdd)
        {
            Console.Clear();
            string success =
$@"
   ____                           __
  / __/_ _____________ ___ ___   / /
 _\ \/ // / __/ __/ -_|_-<(_-<  /_/ 
/___/\_,_/\__/\__/\__/___/___/ (_)  

       {email} -- ADDED --> {emailToAdd}

Press any key to continue . . .              
";
            Console.WriteLine(success);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
