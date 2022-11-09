/*
 171. Excel Sheet Column Number
   
   Given a string columnTitle that represents the column title as appears in an Excel sheet, return its corresponding column number.
   
   For example:
   
   A -> 1
   B -> 2
   C -> 3
   ...
   Z -> 26
   AA -> 27
   AB -> 28 
   ...
   
   Example 1:
   
   Input: columnTitle = "A"
   Output: 1
   
   Example 2:
   
   Input: columnTitle = "AB"
   Output: 28
   
   Example 3:
   
   Input: columnTitle = "ZY"
   Output: 701
 */
namespace Leetcode171
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int TitleToNumber(string columnTitle) 
        {
            var result = 0;

            var multiply = 1;

            for (var i = columnTitle.Length - 1; i >= 0; i--)
            {
                var value = columnTitle[i] - 'A' + 1;
                result += multiply * value;
                multiply *= 26;
            }
        
            return result;
        }
    }
}