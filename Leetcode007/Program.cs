/*
 7. Reverse Integer
   Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
   
   Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
   
   Example 1:
   
   Input: x = 123
   Output: 321
   
   Example 2:
   
   Input: x = -123
   Output: -321
   
   Example 3:
   
   Input: x = 120
   Output: 21
   
   
   Constraints:
   
   -2^31 <= x <= 2^31 - 1
 */
namespace Leetcode007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Reverse(123);
        }

        public static int Reverse(int x)
        {
            var rev = 0;

            while (x != 0)
            {
                if (rev < int.MinValue / 10 || rev > int.MinValue / 10)
                {
                    return 0;
                }

                var digit = x % 10;
                rev = rev * 10 + digit;
                x /= 10;
            }

            return rev;
        }
    }
}