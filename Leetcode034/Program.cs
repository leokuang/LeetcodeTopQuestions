/*
 * 34. Find First and Last Position of Element in Sorted Array
    Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

    If target is not found in the array, return [-1, -1].

    You must write an algorithm with O(log n) runtime complexity.

    Example 1:

    Input: nums = [5,7,7,8,8,10], target = 8
    Output: [3,4]

    Example 2:

    Input: nums = [5,7,7,8,8,10], target = 6
    Output: [-1,-1]

    Example 3:

    Input: nums = [], target = 0
    Output: [-1,-1]
     

    Constraints:

    0 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9
    nums is a non-decreasing array.
    -10^9 <= target <= 10^9
 */

namespace Leetcode034
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int[] SearchRange(int[] nums, int target)
        {
            var leftIndex = BinarySearch(nums, target, true);
            var rightIndex = BinarySearch(nums, target, false) - 1;

            if (leftIndex <= rightIndex && rightIndex < nums.Length && nums[leftIndex] == target &&
                nums[rightIndex] == target)
            {
                return new[] { leftIndex, rightIndex };
            }

            return new[] { -1, -1 };
        }

        public int BinarySearch(int[] nums, int target, bool include)
        {
            var l = 0;
            var r = nums.Length - 1;
            var ans = nums.Length;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;

                if (nums[mid] > target || (include && nums[mid] >= target))
                {
                    r = mid - 1;
                    ans = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return ans;

        }
    }
}