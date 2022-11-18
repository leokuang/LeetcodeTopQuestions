/*
 283. Move Zeroes
   
   Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
   
   Note that you must do this in-place without making a copy of the array.
   
   
   Example 1:
   
   Input: nums = [0,1,0,3,12]
   Output: [1,3,12,0,0]
   
   Example 2:
   
   Input: nums = [0]
   Output: [0]
   
   
   Follow up: Could you minimize the total number of operations done?
 */

namespace Leetcode283
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public void MoveZeroes(int[] nums) 
        {
            var right = 0;
            var left = 0;
            var n = nums.Length;

            while (right < n)
            {
                if (nums[right] != 0)
                {
                    Swap(nums, right, left);
                    left++;
                }

                right++;
            }
        }

        private void Swap(int[] nums, int left, int right)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
        }
    }
}