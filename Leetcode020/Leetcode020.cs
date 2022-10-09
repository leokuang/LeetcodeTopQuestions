/*
   20. Valid Parentheses

   Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
   
   An input string is valid if:
   
   Open brackets must be closed by the same type of brackets.
   Open brackets must be closed in the correct order.
   Every close bracket has a corresponding open bracket of the same type.

   Example:

   Input: s = "()[]{}"
   Output: true
 */

namespace Leetcode020
{
    public class Leetcode020
    {
        public static void Main(int[] args)
        {
            var result = IsValid("()[]{}");
        }

        public static bool IsValid(string s)
        {
            int n = s.Length;
            if (n % 2 == 1)
            {
                return false;
            }

            Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            Stack<char> stk = new Stack<char>();
            foreach (char c in s)
            {
                if (pairs.ContainsKey(c))
                {
                    if (!stk.Any() || stk.Pop() != pairs[c])
                    {
                        return false;
                    }
                }
                else
                {
                    stk.Push(c);
                }
            }

            return !stk.Any();
        }
    }

}

