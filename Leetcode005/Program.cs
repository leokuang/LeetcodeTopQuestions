/*
 5. Longest Palindromic Substring
   
   Given a string s, return the longest palindromic substring in s.
   
   Example 1:
   
   Input: s = "babad"
   Output: "bab"
   Explanation: "aba" is also a valid answer.
   
   Example 2:
   
   Input: s = "cbbd"
   Output: "bb"
   
   
   Constraints:
   
   1 <= s.length <= 1000
   s consist of only digits and English letters.
 */

using System.Text;

namespace Leetcode005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = LongestPalindrome2("bb");
        }

        public string LongestPalindrome(string s) 
        {
            var len = s.Length;

            if (len < 2)
            {
                return s;
            }

            var maxLen = 1;
            var begin = 0;

            // dp[i][j] means whether s[i..j] is palindrome
            bool[,] dp = new bool[len,len];

            // initial dp[i][j]
            for (int i = 0; i < len; i++)
            {
                dp[i,i] = true;
            }

            char[] charArray = s.ToCharArray();

            for (var length = 2; length <= len; length++)
            {
                for (int leftIndex = 0; leftIndex < len; leftIndex++)
                {
                    var rightIndex = length + leftIndex - 1;

                    // Over the right edge then break
                    if (rightIndex >= len)
                    {
                        break;
                    }

                    if (charArray[leftIndex] != charArray[rightIndex])
                    {
                        dp[leftIndex, rightIndex] = false;
                    }
                    else
                    {
                        if (rightIndex - leftIndex < 3)
                        {
                            dp[leftIndex, rightIndex] = true;
                        }
                        else
                        {
                            dp[leftIndex, rightIndex] = dp[leftIndex + 1, rightIndex - 1];
                        }
                    }

                    // if dp[leftIndex, rightIndex] == true, then s[i..j] is palindrome,
                    // then we will record max length and start point
                    if (dp[leftIndex, rightIndex] && rightIndex - leftIndex + 1 > maxLen)
                    {
                        maxLen = rightIndex - leftIndex + 1;
                        begin = leftIndex;
                    }

                }
            }

            return s.Substring(begin, maxLen);
        }

        public static string LongestPalindrome2(string s)
        {
            if (s == null || s.Length < 1)
            {
                return "";
            }

            if (s.Length == 1)
            {
                return s;
            }

            var start = 0;
            var end = 0;
            
            for (int i = 0; i < s.Length; i++)
            {
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);

                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }

            }

            return s.Substring(start, end - start + 1);
        }

        // Must be very careful about edge conditions: left >= 0 and right < length ***
        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && 
                   right < s.Length && 
                   s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }

        public static string LongestPalindrome3(string s)
        {
            var start = 0;
            var end = -1;

            var t = new StringBuilder("#");

            for (var i = 0; i < s.Length; i++)
            {
                t.Append(s[i]);
                t.Append("#");
            }

            t.Append("#");
            s = t.ToString();

            var arm_len = new List<int>();
            var right = -1;
            var j = -1;

            for (var i = 0; i < s.Length; i++)
            {
                int cur_arm_len;

                if (right >= i)
                {
                    var i_sym = j * 2 - i;
                    var min_arm_len = Math.Min(arm_len[i_sym], right - i);
                    cur_arm_len = Expand(s, i - min_arm_len, i + min_arm_len);
                }
                else
                {
                    cur_arm_len = Expand(s, i, i);
                }

                arm_len.Add(cur_arm_len);

                if (i + cur_arm_len > right)
                {
                    j = i;
                    right = i + cur_arm_len;
                }

                if (cur_arm_len * 2 + 1 > end - start)
                {
                    start = i - cur_arm_len;
                    end = i + cur_arm_len;
                }
            }

            var ans = new StringBuilder();
            for (var i = start; i < end; i++)
            {
                if (s[i] != '#')
                {
                    ans.Append(s[i]);
                }
            }
            return ans.ToString();

        }

        private static int Expand(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return (right - left - 2) / 2;
        }
    }
}