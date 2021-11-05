using MorsEmail.Datastructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MorsEmail.Models.BaseModel
{
    public class AccountRepo
    {
        private readonly string accountsPath = @".\accounts";
        internal AccountList Accounts { get; set; }
        internal AccountRepo()
        {
            Accounts = new AccountList();
            InitAccounts();
        }
        private void InitAccounts()
        {
            Dictionary<string, Tuple<Account, List<string>>> AccountDict = new Dictionary<string, Tuple<Account, List<string>>>();

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(accountsPath));
            foreach (string dir in dirs)
            {

                string data_txt = dir + @"\data.txt";
                List<string> accountData = File.ReadAllLines(data_txt).ToList();

                string email = accountData[0];
                string password = accountData[1];
                List<string> listOfFriends = new List<string>();

                if (accountData.Count >= 3)
                {
                    for (int i = 2; i < accountData.Count; i++)
                    {
                        listOfFriends.Add(accountData.ElementAt(i));
                    }
                }

                Account acc = new Account(email, password);

                Accounts.Append(new Node(acc));
                AccountDict.Add(email, (acc, listOfFriends).ToTuple());
            }

            Accounts.PopulateAccountFriendList(AccountDict);
        }

        internal void AddNewAccount(Account newAcc)
        {

            Accounts.Append(new Node(newAcc));
            InitDirectories(newAcc.Email, newAcc);

        }
        private void InitDirectories(string email, Account acc)
        {
            string pathMain = $@".\accounts\{email}";
            try
            {

                if (Directory.Exists(pathMain))
                {

                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathMain);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathMain));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string accountDataFs = $@".\accounts\{email}\data.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(accountDataFs))
                {
                    sw.WriteLine(acc.Email);
                    sw.WriteLine(acc.Password);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string pathInbox = $@".\accounts\{email}\inbox";
            try
            {

                if (Directory.Exists(pathInbox))
                {

                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathInbox);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathInbox));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string pathOutbox = $@".\accounts\{email}\outbox";
            try
            {

                if (Directory.Exists(pathOutbox))
                {

                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathOutbox);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathOutbox));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        internal Account GetAccount(string email)
        {
            return (Accounts.Search(email).account);
        }

        internal bool AUTHLogin(string email, string password)
        {
            return Accounts.FindExistingAccount(email, password);
        }

        internal List<string> GetAccounts()
        {
            return(Accounts.ListAccounts());
        }
        
        internal List<string> GetAccountFriends(string email)
        {
            return GetAccount(email).GETFriends();
        }
  
    
    }
}
