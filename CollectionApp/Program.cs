namespace CollectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tree
            var tree = new BinaryTree<int>();

            foreach (var value in new[] { 8, 5, 6, 4, 1, 2, 11, 22, 33, 44, 100 })
                tree.Add(value);

            Console.WriteLine("In-Order Traversal:");
            foreach (int value in tree.InOrderTraversal())
            {
                Console.Write(value + " ");
            }

            Console.WriteLine("\nPre-Order Traversal:");
            foreach (int value in tree.PreOrderTraversal())
            {
                Console.Write(value + " ");
            }

            Console.WriteLine("\nPost-Order Traversal:");
            foreach (int value in tree.PostOrderTraversal())
            {
                Console.Write(value + " ");
            }

            Console.WriteLine("\nCount tree: " + tree.Count);

            // list

            var list = new CircularLinkedList<int>();

            foreach (var value in new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })
                list.Add(value);

            Console.WriteLine("\nCirc. link. list:");
            list.Print();

            list.Remove(1);

            Console.WriteLine("\nCirc. link. list after remove:");
            list.Print();

            Console.WriteLine("\n");

            Console.WriteLine(list[0]);
        }
    }
}