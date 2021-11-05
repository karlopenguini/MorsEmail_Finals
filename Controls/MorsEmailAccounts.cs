using MorsEmail.Models.BaseModel;
using System;
using System.IO;
using System.Collections.Generic;

namespace MorsEmail.Models
{
    public class MorsEmailAccounts
    {
        public AccountRepo Accounts { get; set; }
        public MorsEmailAccounts()
        {
            Accounts = new AccountRepo();
        }

        public List<string> GETUsers()
        {
            return Accounts.GetAccounts();
        }

        public void POSTAccount(string email, string password)
        {
            Accounts.AddNewAccount(new Account(email,password));
        }
        private Account GETAccount(string email)
        {
            return Accounts.GetAccount(email);
        }
        public Account GETUser(string email, string password)
        {
            if (Accounts.AUTHLogin(email, password))
            {
                return GETAccount(email);
            }

            return null;
        }
        public void POSTFriend(string currEmail, string friendEmail)
        {
            GETAccount(currEmail).POSTFriend(GETAccount(friendEmail));
        }
        public void DELETEFriend(string currEmail, string unfriendEmail)
        {
            GETAccount(currEmail).DELETEFriend(unfriendEmail);
        }
        public List<string> GETUserFriends(string currEmail)
        {
            return GETAccount(currEmail).GETFriends();
        }
        
        public List<string> GETInboxAddresses(string currEmail)
        {
            string path = $@".\accounts\{currEmail}\inbox";
            string[] paths = Directory.GetDirectories(path);

            List<string> addresses = new List<string>();
            
            foreach(string dpath in paths)
            {
                string[] split = dpath.Split('\\');
                
                addresses.Add(split[split.Length - 1]);
            }

            return addresses;

        }
        public List<string> GETOutboxAddresses(string currEmail)
        {
            string path = $@".\accounts\{currEmail}\outbox";
            string[] paths = Directory.GetDirectories(path);

            List<string> addresses = new List<string>();

            foreach (string dpath in paths)
            {
                string[] split = dpath.Split('\\');

                addresses.Add(split[split.Length - 1]);
            }

            return addresses;

        }
    }
}
