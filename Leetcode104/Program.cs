/*
 104. Maximum Depth of Binary Tree

    Given the root of a binary tree, return its maximum depth.

    A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

    Example 1:

    Input: root = [3,9,20,null,null,15,7]
    Output: 3

    Example 2:

    Input: root = [1,null,2]
    Output: 2
 */

using System.IO.Pipes;

namespace Leetcode104
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int MaxDepth1(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                var leftHeight = MaxDepth1(root.left);
                var rightHeight = MaxDepth1(root.right);
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public int MaxDepth2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var ans = 0;

            while (queue.Any())
            {
                var size = queue.Count;

                while (size > 0)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                    size--;
                }

                ans++;
            }

            return ans;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}