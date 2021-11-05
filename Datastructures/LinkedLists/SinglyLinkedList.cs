using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Models;

namespace MorsEmail.Datastructures
{
    public class SinglyLinkedList
    {
        public Node head;

        public void Append(Node newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node curr = head;
                while(curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = newNode;
            }
        }

        public void Delete(string email)
        {
            Node curr = head;
            Node prevNode = null;

            
            if(curr.account.Email == email)
            {
                head = curr.next;
                curr.Dispose();
                return;
            }


            while(email != curr.account.Email)
            {
                prevNode = curr;
                curr = curr.next;
            }
            prevNode.next = curr.next;
            curr.Dispose();
        }
        
        public Node Search(string email)
        {
            Node curr = head;

            while(curr.account.Email != email)
            {
                curr = curr.next;
            }
            return curr;
        }
    }
}
