using HW_3_Praktika__1_LinkedList;

namespace HW_3_Praktika__1_LinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(5);
            list.AddLast(6);
            list.AddLast(8);
            list.AddAfter(6, 7);
            list.Remove(2);
            list.Display();
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(10);
            tree.Add(11);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(22);
            tree.Add(7);
            tree.Add(18);
            tree.Add(9);
            tree.TraversePreOrder(tree.Root);
            Console.WriteLine();
            tree.TraversePostOrder(tree.Root);
            Console.WriteLine();
            tree.TraverseInOrder(tree.Root);
        }
    }
}