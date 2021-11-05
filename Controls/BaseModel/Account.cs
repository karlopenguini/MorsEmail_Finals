using MorsEmail.Datastructures;
using System.Collections.Generic;
using System;
using System.IO;

namespace MorsEmail.Models.BaseModel
{
    public class Account
    {

        public Account(string email, string password)
        {
            Email = email;
            Password = password;
            Friends = new FriendList();
        }


        public string Email { get; set; }
        public string Password { get; set; }
        public FriendList Friends { get; set; }

        public void POSTFriend(Account friend)
        {
            Friends.Append(new Node(friend));

            string accountDataFs = $@".\accounts\{Email}\data.txt";
            try
            {
                using (StreamWriter sw = File.AppendText(accountDataFs))
                {
                    sw.WriteLine(friend.Email);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        public void PUTFriend(Account friend)
        {
            Friends.Append(new Node(friend));
        }
        public void DELETEFriend(string email)
        {
            Friends.Delete(email);
            string line = null;
            using (StreamReader reader = new StreamReader("C:\\input"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\output"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, email) == 0)
                            continue;
                        writer.WriteLine(line);
                    }
                }
            }
        }
        public List<string> GETFriends()
        {
            return Friends.ListFriends();
        }
    }
}
