/*
 242. Valid Anagram
   
   Given two strings s and t, return true if t is an anagram of s, and false otherwise.
   
   An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
   
   Example 1:
   
   Input: s = "anagram", t = "nagaram"
   Output: true
   
   Example 2:
   
   Input: s = "rat", t = "car"
   Output: false
 */

using System.Collections;
using System.Collections.Immutable;

namespace Leetcode242
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = IsAnagram("anagram", "nagaram");
        }

        public static bool IsAnagram(string s, string t) 
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var sChars = s.ToCharArray().ToList();
            var tChars = t.ToCharArray().ToList();

            sChars.Sort();
            tChars.Sort();

            for (var i = 0; i < sChars.Count; i++)
            {
                if (sChars[i] != tChars[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}