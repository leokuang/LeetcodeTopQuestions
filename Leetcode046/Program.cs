/*
 * Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
   
   Example 1:
   
   Input: nums = [1,2,3]
   Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
   
   Example 2:
   
   Input: nums = [0,1]
   Output: [[0,1],[1,0]]
   
   Example 3:
   
   Input: nums = [1]
   Output: [[1]]
   
   
   Constraints:
   
   1 <= nums.length <= 6
   -10 <= nums[i] <= 10
   All the integers of nums are unique.
   
 */

namespace Leetcode046
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Permute(new int[] { 1, 2, 3 });
        }

        public static IList<IList<int>> Permute(int[] nums) 
        {
            var res = new List<IList<int>>();
            var len = nums.Length;

            if (len == 0)
            {
                return res;
            }

            var used = new bool[len];
            var path = new List<int>();

            Dfs(nums, len, 0, path, used, res);

            return res;
        }

        private static void Dfs(int[] nums, int len, int depth, IList<int> path, bool[] used, IList<IList<int>> res)
        {
            if (depth == len)
            {
                res.Add(new List<int>(path));
                return;
            }

            for (var i = 0; i < len; i++)
            {
                if (!used[i])
                {
                    path.Add(nums[i]);
                    used[i] = true;

                    Dfs(nums, len, depth + 1, path, used, res);

                    used[i] = false;
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}