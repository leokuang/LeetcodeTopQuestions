/*
 * Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
   
   Example 1:
   
   Input: haystack = "sadbutsad", needle = "sad"
   Output: 0
   Explanation: "sad" occurs at index 0 and 6.
   The first occurrence is at index 0, so we return 0.
   
   Example 2:
   
   Input: haystack = "leetcode", needle = "leeto"
   Output: -1
   Explanation: "leeto" did not occur in "leetcode", so we return -1.
   
   
   Constraints:
   
   1 <= haystack.length, needle.length <= 10^4
   haystack and needle consist of only lowercase English characters.
 */

using System.Globalization;

namespace Leetcode028
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static int StrStr(string haystack, string needle) 
        {
            if (haystack.Length < needle.Length)
            {
                return -1;
            }
            
            int i = 0;
            int j = 0;
            var next = new int[needle.Length];

            ComputeNextArray(needle, next);

            while (i < haystack.Length)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }

                if (j == needle.Length)
                {
                    return i - j;
                }
                else if (i < haystack.Length && haystack[i] != needle[j])
                {
                    if (j > 0)
                    {
                        j = next[j - 1];
                    }
                    else // j == 0
                    {
                        i++;
                    }
                }
            }

            return -1;
        }

        public static void ComputeNextArray(string needle, int[] next)
        {
            var len = 0;
            var i = 1;

            next[0] = 0;

            while (i < needle.Length)
            {
                if (needle[len] == needle[i])
                {
                    len++;
                    next[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = next[len - 1];
                    }
                    else
                    {
                        next[i] = len; // len is 0
                        i++;
                    }
                }
            }
        }
    }
}