/*
 101. Symmetric Tree

    Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

    Example 1:

    Input: root = [1,2,2,3,4,4,3]
    Output: true

    Example 2:

    Input: root = [1,2,2,null,3,null,3]
    Output: false
 */

namespace Leetcode101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public bool IsSymmetric(TreeNode root)
        {
            return Check(root, root);
        }

        public bool Check(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            return p.val == q.val
                   && Check(p.left, q.right)
                   && Check(p.right, q.left);
        }

        public bool IsSymmetric1(TreeNode root)
        {
            return Check1(root, root);
        }

        public bool Check1(TreeNode p, TreeNode q)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(p);
            queue.Enqueue(p);

            while (queue.Any())
            {
                p = queue.Dequeue();
                q = queue.Dequeue();

                if (p == null && q == null)
                {
                    continue;
                }

                if ((p == null || q == null) || (p.val != q.val))
                {
                    return false;
                }

                queue.Enqueue(p.left);
                queue.Enqueue(q.right);

                queue.Enqueue(p.right);
                queue.Enqueue(q.left);
            }

            return true;
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