using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorsEmail.Datastructures
{
    public class SimpleStack<T>
    {
        public List<T> stack { get; set; }

        public SimpleStack()
        {
            stack = new List<T>();
        }

        public void Push(T data)
        {
            stack.Add(data);
        }
        public T Pop()
        {
            T val = stack.Last();
            stack.RemoveAt(stack.Count - 1);
            return val;
        }

        public T Peek()
        {
            return stack.Last();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

       

    }
}
