using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Models.BaseModel;

namespace MorsEmail.Datastructures
{
    public class Node : IDisposable
    {
        public Account account { get; set; }
        public Node next { get; set; }

        public Node(Account _person)
        {
            account = _person;
            next = null;
        }

        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }
    }
}
