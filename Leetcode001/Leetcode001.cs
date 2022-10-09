/*
    1. Two Sum
    
    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    You can return the answer in any order.

    Example:

    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

 */
namespace Leetcode001
{
    public class Leetcode001
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = TwoSum(new int[] {1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1}, 11);
        }

        

        public static int[] TwoSum(int[] nums, int target) 
        {
            var numberDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numberDict.ContainsKey(target - nums[i]))
                {
                    return new int[] { numberDict[target - nums[i]], i };
                }

                numberDict[nums[i]] = i;
            }

            return new int[] {0, 0};
        }
    }
}