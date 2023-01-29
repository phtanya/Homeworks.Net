using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Praktika__1_LinkedList
{
    public class BNode<T>
    {
        public BNode()
        {
        }

        public BNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public T Value { get; set; }

        public BNode<T>? Left { get; set; }

        public BNode<T>? Right { get; set; }
    }
}
