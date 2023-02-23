namespace HW_3_Praktika__1_LinkedList
{
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        public BNode<T> Root { get; set; }

        public bool Add(T data)
        {
            BNode<T> before = null;
            BNode<T> after = Root;

            while (after != null)
            {
                before = after;
                if (data.CompareTo(after.Value) < 0)
                {
                    after = after.Left;
                }
                else if (data.CompareTo(after.Value) > 0)
                {
                    after = after.Right;
                }
                else
                {
                    return false;
                }
            }

            BNode<T> newNode = new BNode<T>();
            newNode.Value = data;

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                if (data.CompareTo(before.Value) < 0)
                {
                    before.Left = newNode;
                }
                else
                {
                    before.Right = newNode;
                }
            }

            return true;
        }

        public BNode<T> Search(BNode<T> root, int key)
        {
            if (root == null)
            {
                return Root;
            }
            else if (key.CompareTo(Root.Value) == 0)
            {
                return Root;
            }
            else if (key.CompareTo(Root.Value) < 0)
            {
                return Search(Root.Left, key);
            }
            else
            {
                return Search(Root.Right, key);
            }
        }

        public void TraverseInOrder(BNode<T> parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.Left);
                Console.Write(parent.Value + " - ");
                TraverseInOrder(parent.Right);
            }
        }

        public void TraversePreOrder(BNode<T> parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Value + " - ");
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
        }

        public void TraversePostOrder(BNode<T> parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.Left);
                TraversePostOrder(parent.Right);
                Console.Write(parent.Value + " - ");
            }
        }
    }
}
