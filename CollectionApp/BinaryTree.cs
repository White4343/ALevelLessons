namespace CollectionApp
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; private set; }
        public Node<T> Left { get; private set; } = null!;
        public Node<T> Right { get; private set; } = null!;

        public Node(T value) => Value = value;

        public void Add(T newValue)
        {
            if (newValue.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(newValue);
                }
                else
                {
                    Left.Add(newValue);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(newValue);
                }
                else
                {
                    Right.Add(newValue);
                }
            }
        }

        public IEnumerable<T> InOrderTraversal()
        {
            if (Left != null)
            {
                foreach (T value in Left.InOrderTraversal())
                {
                    yield return value;
                }
            }

            yield return Value;

            if (Right != null)
            {
                foreach (T value in Right.InOrderTraversal())
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            yield return Value;

            if (Left != null)
            {
                foreach (T value in Left.PreOrderTraversal())
                {
                    yield return value;
                }
            }

            if (Right != null)
            {
                foreach (T value in Right.PreOrderTraversal())
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            if (Left != null)
            {
                foreach (T value in Left.PostOrderTraversal())
                {
                    yield return value;
                }
            }

            if (Right != null)
            {
                foreach (T value in Right.PostOrderTraversal())
                {
                    yield return value;
                }
            }

            yield return Value;
        }
    }

    public class BinaryTree<T> where T : IComparable<T>
    {
        private int count = 0;

        public int Count { 
            get => count;
        }

        public Node<T> Root { get; private set; } = null!;

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                Root.Add(value);
            }

            count++;
        }

        public IEnumerable<T> InOrderTraversal()
        {
            if (Root != null)
            {
                foreach (T value in Root.InOrderTraversal())
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            if (Root != null)
            {
                foreach (T value in Root.PreOrderTraversal())
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            if (Root != null)
            {
                foreach (T value in Root.PostOrderTraversal())
                {
                    yield return value;
                }
            }
        }

        public void CountTree()
        {
            if (Root != null)
            {

            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }
    }
}
