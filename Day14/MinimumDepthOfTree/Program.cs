using System;
using System.Collections.Generic;

namespace MinimumDepthOfTree
{
    public class Node
    {
        public int Data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.Data = data;
        }
    }

    public class Tree
    {
        public Node root;

        public async Task AddNodes(List<int?> values)
        {
            Queue<Node> queue = new Queue<Node>();
            root = new Node(values[0].Value);
            queue.Enqueue(root);

            int i = 1;
            while (i < values.Count)
            {
                Node current =  queue.Dequeue();

                if (values[i] != null)
                {
                    current.left = new Node(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < values.Count && values[i] != null)
                {
                    current.right = new Node(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }
        }

        public async Task<int> MinimumDepth(Node currNode)
        {
            if (currNode == null)
                return 0;

            if (currNode.left == null && currNode.right == null)
                return 1;

            if (currNode.left == null)
                return 1 + await MinimumDepth(currNode.right);

            if (currNode.right == null)
                return 1 +  await MinimumDepth(currNode.left);

            return 1 + Math.Min(await MinimumDepth(currNode.left), await MinimumDepth(currNode.right));
        }
    }

    public class Program
    {
        static async Task Main(string[] args)
        {
            Tree tree = new Tree();
            //List<int?> values = new List<int?> { 3, 9, 20, null, null, 15, 7 };
            List<int?> values = new List<int?> { 2, null, 3, null, 4, null, 5, null, 6 };

            await tree.AddNodes(values);

            Console.WriteLine("Minimum Depth of the tree:");
            Console.WriteLine(tree.MinimumDepth(tree.root).Result);
        }
    }
}
