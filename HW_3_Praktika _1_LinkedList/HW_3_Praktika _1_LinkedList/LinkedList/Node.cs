using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Praktika__1_LinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        // public Node<T>? _next;
        // public Node<T>? _previous;
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
}
