/*
 125. Valid Palindrome

   A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
   
   Given a string s, return true if it is a palindrome, or false otherwise.
   
   
   
   Example 1:
   
   Input: s = "A man, a plan, a canal: Panama"
   Output: true
   Explanation: "amanaplanacanalpanama" is a palindrome.

   Example 2:
   
   Input: s = "race a car"
   Output: false
   Explanation: "raceacar" is not a palindrome.
   
   Example 3:
   
   Input: s = " "
   Output: true
   Explanation: s is an empty string "" after removing non-alphanumeric characters.
   Since an empty string reads the same forward and backward, it is a palindrome.
 */

using System.Text;

namespace Leetcode125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public bool IsPalindrome(string s) 
        {
            int n = s.Length;
            int left = 0;
            int right = n - 1;

            
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }

                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (left < right)
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }

                    left++;
                    right--;
                }

            }

            return true;
        }

        public bool IsPalindrome1(string s) 
        {
            StringBuilder sgood = new StringBuilder();
            int length = s.Length;
            for (int i = 0; i < length; i++) {
                char ch = s[i];
                if (char.IsLetterOrDigit(ch)) {
                    sgood.Append(char.ToLower(ch));
                }
            }
            int n = sgood.Length;
            int left = 0, right = n - 1;
            while (left < right) {
                if (char.ToLower(sgood[left]) != char.ToLower(sgood[right])) {
                    return false;
                }
                ++left;
                --right;
            }
            return true;

        }
    }
}