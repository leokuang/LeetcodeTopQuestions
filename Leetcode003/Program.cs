/*
 3. Longest Substring Without Repeating Characters
   Given a string s, find the length of the longest substring without repeating characters.
   
   Example 1:
   
   Input: s = "abcabcbb"
   Output: 3
   Explanation: The answer is "abc", with the length of 3.
   
   Example 2:
   
   Input: s = "bbbbb"
   Output: 1
   Explanation: The answer is "b", with the length of 1.
   
   Example 3:
   
   Input: s = "pwwkew"
   Output: 3
   Explanation: The answer is "wke", with the length of 3.
   Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
   
   
   Constraints:
   
   0 <= s.length <= 5 * 10^4
   s consists of English letters, digits, symbols and spaces.
 */
namespace Leetcode003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int LengthOfLongestSubstring(string s)
        {
            var occ = new HashSet<char>();
            var rk = -1;
            var ans = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (i != 0)
                {
                    occ.Remove(s[i - 1]);
                }

                while (rk + 1 < s.Length && !occ.Contains(s[rk + 1]))
                {
                    occ.Add(s[rk + 1]);
                    rk++;
                }

                ans = Math.Max(ans, rk - i + 1);
            }

            return ans;
        }
    }
}