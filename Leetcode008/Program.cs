/*
 * 8. String to Integer (atoi)
   Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
   
   The algorithm for myAtoi(string s) is as follows:
   
   Read in and ignore any leading whitespace.
   Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
   Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
   Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
   If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
   Return the integer as the final result.
   Note:
   
   Only the space character ' ' is considered a whitespace character.
   Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.
   
   
   Example 1:
   
   Input: s = "42"
   Output: 42
   Explanation: The underlined characters are what is read in, the caret is the current reader position.
   Step 1: "42" (no characters read because there is no leading whitespace)
   ^
   Step 2: "42" (no characters read because there is neither a '-' nor '+')
   ^
   Step 3: "42" ("42" is read in)
   ^
   The parsed integer is 42.
   Since 42 is in the range [-2^31, 2^31 - 1], the final result is 42.
   
   Example 2:
   
   Input: s = "   -42"
   Output: -42
   Explanation:
   Step 1: "   -42" (leading whitespace is read and ignored)
   ^
   Step 2: "   -42" ('-' is read, so the result should be negative)
   ^
   Step 3: "   -42" ("42" is read in)
   ^
   The parsed integer is -42.
   Since -42 is in the range [-2^31, 2^31 - 1], the final result is -42.
   
   Example 3:
   
   Input: s = "4193 with words"
   Output: 4193
   Explanation:
   Step 1: "4193 with words" (no characters read because there is no leading whitespace)
   ^
   Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
   ^
   Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
   ^
   The parsed integer is 4193.
   Since 4193 is in the range [-2^31, 2^31 - 1], the final result is 4193.
   
   
   Constraints:
   
   0 <= s.length <= 200
   s consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'.
   
 */

using System.Reflection.Metadata;

namespace Leetcode008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = MyAtoi("-91283472332");
        }

        public static int MyAtoi(string s)
        {
            var automation = new Automation();

            for (var i = 0; i < s.Length; i++)
            {
                automation.Get(s[i]);
            }

            return (int)(automation.sign * automation.ans);
        }

        internal class Automation
        {
            public int sign = 1;
            public long ans = 0;
            private string state = "start";

            private Dictionary<string, string[]> table = new Dictionary<string, string[]>()
            {
                ["start"] = new [] { "start", "signed", "in_number", "end" },
                ["signed"] = new [] {"end", "end", "in_number", "end" },
                ["in_number"] = new [] { "end", "end", "in_number", "end" },
                ["end"] = new []{ "end", "end", "end", "end" }
            };

            public void Get(char c)
            {
                state = table[state][Get_col(c)];

                if (string.Equals("in_number", state))
                {
                    ans = ans * 10 + c - '0';

                    // Should be very careful this edge condition. Both of results are Math.Min
                    ans = sign == 1 ? Math.Min(ans, (long)(int.MaxValue)) : Math.Min(ans, -(long)(int.MinValue));
                }
                else if (string.Equals("signed", state))
                {
                    sign = c == '+' ? 1 : -1;
                }
            }

            private int Get_col(char c)
            {
                if (c == ' ')
                {
                    return 0;
                }

                if (c == '+' || c == '-')
                {
                    return 1;
                }

                if (char.IsDigit(c))
                {
                    return 2;
                }

                return 3;
            }
        }
    }
}