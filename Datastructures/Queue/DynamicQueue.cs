using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorsEmail.Datastructures
{
    public class DynamicQueue<T>
    {
        private List<T> queue { get; set; }
        
        public DynamicQueue()
        {
            queue = new List<T>();
        }
        public void Enqueue(T c)
        {
            queue = queue.Prepend(c).ToList();
        }
        public T Dequeue()
        {
            T c = queue.Last();
            queue.RemoveAt(queue.Count - 1);
            return c;
        }
        public T Peek()
        {
            return queue.Last();
        }
        public bool isEmpty()
        {
            return queue.Count == 0 ? true : false;
        }
        
    }
}
