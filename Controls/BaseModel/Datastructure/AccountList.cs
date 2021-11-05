using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MorsEmail.Models.BaseModel;
using MorsEmail.Datastructures;


namespace MorsEmail.Models
{
    public class AccountList : SinglyLinkedList
    {
        internal void PopulateAccountFriendList(Dictionary<string, Tuple<Account, List<string>>> accDict)
        {
            Node curr = this.head;
            while(curr != null)
            {
                string currAccEmail = curr.account.Email;
                if(accDict[currAccEmail].Item2.Count >= 0)
                {
                    foreach (string email in accDict[currAccEmail].Item2)
                    {
                        curr.account.PUTFriend(accDict[email].Item1);
                    }
                }
                curr = curr.next;
            }
        }
        internal bool FindExistingAccount(string email, string password)
        {
            Node curr = this.head;
            while (curr != null)
            {
                if(curr.account.Email == email && curr.account.Password == password)
                {
                    return true;
                }
                curr = curr.next;
            }
            return false;
        }

        internal List<string> ListAccounts()
        {
            Node curr = this.head;

            List<string> listOfAccount = new List<string>();
            while (curr != null)
            {
                listOfAccount.Add(curr.account.Email);
                curr = curr.next;
            }

            return listOfAccount;
        }
    }
}
