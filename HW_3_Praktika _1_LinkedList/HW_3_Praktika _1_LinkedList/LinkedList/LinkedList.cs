using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Praktika__1_LinkedList
{
    public class LinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }
        public int Count { get; set; }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T>? currentNode = Head;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddFirst(Node<T> nodeAddFirst)
        {
            if (Head == null)
            {
                Head = nodeAddFirst;
            }
            else
            {
                nodeAddFirst.Next = Head;
                Head.Previous = nodeAddFirst;
                Head = nodeAddFirst;
            }

            Count++;
        }

        public void AddFirst(T valueToAdd)
        {
            var node = new Node<T>(valueToAdd);
            AddFirst(node);
        }

        public void AddLast(Node<T> nodeAddLast)
        {
            var lastNode = GetLastNode();

            if (Head == null)
            {
                AddFirst(nodeAddLast);
            }

            if (lastNode is not null)
            {
                lastNode.Next = nodeAddLast;
                nodeAddLast.Previous = lastNode;

                return;
            }

            Count++;
        }

        public void AddLast(T valueToAdd)
        {
            var node = new Node<T>(valueToAdd);
            AddLast(node);
        }

        public Node<T>? GetLastNode()
        {
            if (Head is null)
            {
                return default;
            }

            var aux = Head;

            while (aux is not null)
            {
                if (aux.Next is null)
                {
                    return aux;
                }

                aux = aux.Next;
            }

            return default;
        }

        public void AddAfter(Node<T> nodeToAdd, T valueToFind)
        {
            var find = Find(valueToFind);

            if (find is not null)
            {
                var next = find.Next;

                nodeToAdd.Next = next;
                find.Next = nodeToAdd;

                if (next?.Previous is not null)
                {
                    next.Previous = nodeToAdd;
                }

                nodeToAdd.Previous = find;

                Count++;

                return;
            }

            AddLast(nodeToAdd);
        }

        public void AddAfter(T valueToFind, T valueToAdd)
        {
            var nodeToAdd = new Node<T>(valueToAdd);
            AddAfter(nodeToAdd, valueToFind);
        }

        public Node<T> Find(T nodeSearch)
        {
            var f = Head;
            while (f != null)
            {
                if (EqualityComparer<T>.Default.Equals(f.Value, nodeSearch))
                {
                    return f;
                }

                f = f.Next;
            }

            return default;
        }

        public void Remove(T value)
        {
            var find = Find(value);

            if (find == null)
            {
                return;
            }

            var next = find.Next;
            var prev = find.Previous;

            if (prev != null)
            {
                prev.Next = next;
            }

            if (next != null)
            {
                next.Previous = prev;
            }

            Count--;
        }

        public void Display()
        {
            foreach (var item in this)
            {
                Console.WriteLine($" => {item.Value}");
            }
        }
    }
}
