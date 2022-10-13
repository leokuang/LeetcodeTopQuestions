/*
   Given the root of a binary tree, return the inorder traversal of its nodes' values.
   
   Example 1:
   Input: root = [1,null,2,3]
   Output: [1,3,2]

   Example 2:
   
   Input: root = []
   Output: []

   Example 3:
   
   Input: root = [1]
   Output: [1]
 */

using System.Collections;
using System.Runtime.InteropServices;

namespace Leetcode094
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public static IList<int> InorderTraversal1(TreeNode root)
        {
            var result = new List<int>();
            InOrder(root, result);
            return result;
        }

        public static void InOrder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left, result);
            result.Add(root.val);
            InOrder(root.right, result);
        }

        public static IList<int> InorderTraversal2(TreeNode root)
        {
            var result = new List<int>();

            if (root == null)
            {
                return new List<int>();
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (stack.Any() || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                    result.Add(root.val);
                    root = root.right;
                }
            }

            return result;
        }
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