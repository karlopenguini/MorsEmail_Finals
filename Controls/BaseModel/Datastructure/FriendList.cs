using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Datastructures;
namespace MorsEmail.Models
{
    public class FriendList : SinglyLinkedList
    {
        internal List<string> ListFriends()
        {
            Node curr = this.head;
            List<string> friends = new List<string>();
            while (curr != null)
            {
                friends.Add(curr.account.Email);
                curr = curr.next;
            }
            return friends;
        }
    }
}
