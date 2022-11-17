/*
 268. Missing Number
   
   Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
   
   Example 1:
   
   Input: nums = [3,0,1]
   Output: 2
   Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.
   
   Example 2:
   
   Input: nums = [0,1]
   Output: 2
   Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.
   
   Example 3:
   
   Input: nums = [9,6,4,2,3,5,7,0,1]
   Output: 8
   Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.
   
   
   Follow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?
 */
namespace Leetcode268
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MissingNumber(new int[]{0, 1});
        }

        // Using SORT method
        public static int MissingNumber(int[] nums)
        {
            var numsList = nums.ToList();
            var n = nums.Length;

            numsList.Sort();

            for (var i = 0; i < n; i++)
            {
                if (i != numsList[i])
                {
                    return i;
                }
            }

            return n;
        }

        // Using HashSet to do it 
        public int MissingNumber2(int[] nums)
        {
            var set = new HashSet<int>();
            var n = nums.Length;
            var missing = n;

            for (var i = 0; i < n; i++)
            {
                set.Add(nums[i]);
            }

            for (var i = 0; i < n; i++)
            {
                if (!set.Contains(i))
                {
                    missing = i;
                    break;
                }
            }

            return missing;
        }

        // Using XOR method
        public int MissingNumber3(int[] nums)
        {
            var xor = 0;
            var n = nums.Length;

            for (var i = 0; i < n; i++)
            {
                xor ^= nums[i];
            }

            // Notice at here, i should be <= n because xor default is 0
            for (var i = 0; i <= n; i++)
            {
                xor ^= i;
            }

            return xor;
        }

        // Using math method directly
        public int MissingNumber4(int[] nums)
        {
            var n = nums.Length;
            var arrSume = 0;

            for (var i = 0; i < n; i++)
            {
                arrSume += nums[i];
            }

            var total = n * (1 + n) / 2;

            return total - arrSume;

        }

    }
    
}