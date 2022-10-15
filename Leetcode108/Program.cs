/*
 Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.
   
   A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one.
   
   
   
   Example 1:

   Input: nums = [-10,-3,0,5,9]
   Output: [0,-3,9,-10,null,5]
   Explanation: [0,-10,5,null,-3,null,9] is also accepted:

    Example 2:

    Input: nums = [1,3]
    Output: [3,1]
    Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.
 */

namespace Leetcode108
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Helper1(nums, 0, nums.Length - 1);

        }

        public TreeNode Helper1(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null!;
            }

            var mid = (left + right) / 2;

            var root = new TreeNode(nums[mid]);
            root.left = Helper1(nums, left, mid - 1);
            root.right = Helper1(nums, mid + 1, right);

            return root;
        }

        public TreeNode Helper2(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null!;
            }

            var mid = (left + right + 1) / 2;

            var root = new TreeNode(nums[mid]);
            root.left = Helper2(nums, left, mid - 1);
            root.right = Helper2(nums, mid + 1, right);

            return root;
        }

        public TreeNode Helper3(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null!;
            }

            var random = new Random();

            var mid = (left + right + random.Next(0, 2));

            var root = new TreeNode(nums[mid]);
            root.left = Helper3(nums, left, mid - 1);
            root.right = Helper3(nums, mid + 1, right);

            return root;
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