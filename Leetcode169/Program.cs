/*
 169. Majority Element
   Given an array nums of size n, return the majority element.
   
   The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.
   
   
   Example 1:
   
   Input: nums = [3,2,3]
   Output: 3
   
   Example 2:
   
   Input: nums = [2,2,1,1,1,2,2]
   Output: 2
   
   
   Constraints:
   
   n == nums.length
   1 <= n <= 5 * 10^4
   -10^9 <= nums[i] <= 10^9
   
   
   Follow-up: Could you solve the problem in linear time and in O(1) space?
 */
namespace Leetcode169
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 });
        }

        public static int MajorityElement(int[] nums) 
        {
            var max = Int32.MinValue;
            var result = 0;

            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict[num] = 1;
                }
                else
                {
                    dict[num]++;
                }
            }

            foreach (var d in dict)
            {
                if (d.Value > max)
                {
                    max = d.Value;
                    result = d.Key;
                }
            }

            return result;
        }

        public static int MajorityElement2(int[] nums)
        {
            var numList = nums.ToList();
            numList.Sort();

            return numList[numList.Count / 2];
        }

        public static int MajorityElement3(int[] nums)
        {
            var mid = nums.Length / 2;

            while (true)
            {
                var candidate = nums[new Random().Next(0, nums.Length)];

                if (CountOccurences(nums, candidate) > mid)
                {
                    return candidate;
                }
            }
        }

        private static int CountOccurences(int[] nums, int num)
        {
            var count = 0;

            foreach (var i in nums)
            {
                if (i == num)
                {
                    count++;
                }
            }

            return count;
        }

        public static int MajorityElement4(int[] nums)
        {
            int count = 0;
            int candidate = 0;

            foreach (var num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }

                count += (num == candidate) ? 1 : -1;
            }

            return candidate;
        }

        public int MajorityElement5(int[] nums)
        {
            return MajorityElementRec(nums, 0, nums.Length - 1);
        }

        private int CountInRange(int[] nums, int num, int lo, int hi)
        {
            int count = 0;
            for (var i = lo; i <= hi; i++)
            {
                if (nums[i] == num)
                {
                    count++;
                }
            }

            return count;
        }

        private int MajorityElementRec(int[] nums, int lo, int hi)
        {
            // base case; the only element in an array of size 1 is the majority element
            if (lo == hi)
            {
                return nums[lo];
            }

            // recurse on left and right halves of this slice
            var mid = (hi - lo) / 2 + lo;
            var left = MajorityElementRec(nums, lo, mid);
            var right = MajorityElementRec(nums, mid + 1, hi);

            // if the two halves agree on the majority element, return it
            if (left == right)
            {
                return left;
            }

            // otherwise, count each element and return the "winner"
            int leftCount = CountInRange(nums, left, lo, hi);
            int rightCount = CountInRange(nums, right, lo, hi);

            return leftCount > rightCount ? left : right;
        }
    }
}