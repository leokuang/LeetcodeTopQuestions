/*
 * 17. Letter Combinations of a Phone Number
   Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
   
   A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
   
   1:[]
   2:[abc]
   3:[def]
   4:[ghi]
   5:[jkl]
   6:[mno]
   7:[pqrs]
   8:[tuv]
   9:[wxyz]
   
   Example 1:
   
   Input: digits = "23"
   Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
   
   Example 2:
   
   Input: digits = ""
   Output: []
   
   Example 3:
   
   Input: digits = "2"
   Output: ["a","b","c"]
   
   
   Constraints:
   
   0 <= digits.length <= 4
   digits[i] is a digit in the range ['2', '9'].
 */

using System.Text;

namespace Leetcode017
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public IList<string> LetterCombinations(string digits) 
        {
            var combinations = new List<string>();

            if (digits.Length == 0)
            {
                return combinations;
            }

            var phoneMap = new Dictionary<char, string>
            {
                ['2'] = "abc",
                ['3'] = "def",
                ['4'] = "ghi",
                ['5'] = "jkl",
                ['6'] = "mno",
                ['7'] = "pqrs",
                ['8'] = "tuv",
                ['9'] = "wxyz"
            };

            BackTrack(combinations, phoneMap, digits, 0, new StringBuilder());

            return combinations;
        }

        public void BackTrack(IList<string> combinations, Dictionary<char, string> phoneMap, string digits, int index, StringBuilder combination)
        {
            if (index == digits.Length)
            {
                combinations.Add(combination.ToString());
            }
            else
            {
                var digit = digits[index];
                var letters = phoneMap[digit];
                var lettersCount = letters.Length;

                for (var i = 0; i < lettersCount; i++)
                {
                    combination.Append(letters[i]);
                    BackTrack(combinations, phoneMap, digits, index + 1, combination);
                    combination.Remove(index, 1);
                }
            }
        }
    }
}