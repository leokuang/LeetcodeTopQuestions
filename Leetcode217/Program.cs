/*
 217. Contains Duplicate
   
   Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
   
   Example 1:
   
   Input: nums = [1,2,3,1]
   Output: true
   
   Example 2:
   
   Input: nums = [1,2,3,4]
   Output: false
   
   Example 3:
   
   Input: nums = [1,1,1,3,3,4,3,2,4,2]
   Output: true
 */
namespace Leetcode217
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public bool ContainsDuplicate(int[] nums) 
        {
            Array.Sort(nums);

            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
        public bool ContainsDuplicate1(int[] nums)
        {
            var numDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!numDict.ContainsKey(nums[i]))
                {
                    numDict.Add(nums[i], 0);
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}