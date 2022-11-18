﻿/*
 26. Power of Three
   
   Given an integer n, return true if it is a power of three. Otherwise, return false.
   
   An integer n is a power of three, if there exists an integer x such that n == 3^x.
   
   Example 1:
   
   Input: n = 27
   Output: true
   Explanation: 27 = 3^3
   
   Example 2:
   
   Input: n = 0
   Output: false
   Explanation: There is no x where 3^x = 0.
   
   Example 3:
   
   Input: n = -1
   Output: false
   Explanation: There is no x where 3^x = (-1).
 */

namespace Leetcode326
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public bool IsPowerOfThree(int n) 
        {
            while (n != 0 && n % 3 == 0)
            {
                n /= 3;
            }

            return n == 1;

        }

        // for 32-bits max of power of 3 is 3^19=1162261467
        public bool IsPowerOfThree1(int n)
        {
            return n > 0 && 1162261467 % n == 0;
        }
    }
}