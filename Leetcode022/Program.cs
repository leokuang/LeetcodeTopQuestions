/*
 * 22. Generate Parentheses
   Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
   
   Example 1:
   
   Input: n = 3
   Output: ["((()))","(()())","(())()","()(())","()()()"]
   
   Example 2:
   
   Input: n = 1
   Output: ["()"]
   
   
   Constraints:
   
   1 <= n <= 8
 */

using System.Collections;
using System.Text;

namespace Leetcode022
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var result = GenerateParenthesis(2);
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            var ans = new List<string>();
            Backtrack(ans, new StringBuilder(), 0, 0, n);
            return ans;
        }

        public static void Backtrack(List<string> ans, StringBuilder cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur.ToString());
            }

            if (open < max)
            {
                cur.Append('(');
                Backtrack(ans, cur, open + 1, close, max);
                cur.Remove(cur.Length - 1, 1);
            }

            if (close < open)
            {
                cur.Append(')');
                Backtrack(ans, cur, open, close + 1, max);
                cur.Remove(cur.Length - 1, 1);
            }
        }
    }
}