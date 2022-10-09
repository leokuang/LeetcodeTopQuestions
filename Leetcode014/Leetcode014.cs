/*
   Write a function to find the longest common prefix string amongst an array of strings.
   
   If there is no common prefix, return an empty string "".

   Example:

   Input: strs = ["flower","flow","flight"]
   Output: "fl"
 */

namespace Leetcode014
{
    public class Leetcode014
    {
        public static void Main()
        {
            var result = LongestCommonPrefix1(new[] {"flower", "flow", "flight"});
            var result2 = LongestCommonPrefix2(new[] {"flower", "flow", "flight"});
            var result3 = LongestCommonPrefix3(new[] {"flower", "flow", "flight"});
            var result4 = LongestCommonPrefix4(new[] {"flower", "flow", "flight"});
        }

        public static string LongestCommonPrefix1(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return string.Empty;
            }

            var prefix = strs[0];
            var count = strs.Length;

            for (var i = 1; i < count; i++)
            {
                prefix = LongestCommonPrefix1(prefix, strs[i]);
                if (prefix.Length == 0)
                {
                    break;
                }
            }

            return prefix;
        }

        private static string LongestCommonPrefix1(string str1, string str2)
        {
            var length = Math.Min(str1.Length, str2.Length);
            var index = 0;
            while (index < length && str1[index] == str2[index])
            {
                index++;
            }

            return str1.Substring(0, index);
        }

        public static string LongestCommonPrefix2(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return string.Empty;
            }

            int length = strs[0].Length;
            int count = strs.Length;
            for (int i = 0; i < length; i++)
            {
                var c = strs[0][i];

                for (int j = 1; j < count; j++)
                {
                    if (i == strs[j].Length || !strs[j][i].Equals(c))
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return strs[0];
        }

        public static string LongestCommonPrefix3(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return LongestCommonPrefix3(strs, 0, strs.Length - 1);
            }
        }

        private static string LongestCommonPrefix3(string[] strs, int start, int end)
        {
            if (start == end)
            {
                return strs[start];
            }
            else
            {
                var mid = start + (end - start) / 2;
                var lcpLeft = LongestCommonPrefix3(strs, start, mid);
                var lcpRight = LongestCommonPrefix3(strs, mid + 1, end);
                return CommonPrefix(lcpLeft, lcpRight);
            }
        }

        private static string CommonPrefix(string lcpLeft, string lcpRight)
        {
            var minLength = Math.Min(lcpLeft.Length, lcpRight.Length);
            
            for (var i = 0; i < minLength; i++)
            {
                if (lcpLeft[i] != lcpRight[i])
                {
                    return lcpLeft.Substring(0, i);
                }
            }

            return lcpLeft.Substring(0, minLength);
        }

        public static string LongestCommonPrefix4(string[] strs) 
        {
            if (strs == null || strs.Length == 0)
            {
                return string.Empty;
            }
            var minLength = Int32.MaxValue;
            foreach (var str in strs)
            {
                minLength = Math.Min(minLength, str.Length);
            }

            int low = 0;
            int high = minLength;

            while (low < high)
            {
                int mid = low + (high - low + 1) / 2;

                if (IsCommonPrefix(strs, mid))
                {
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return strs[0].Substring(0, low);
        }

        private static bool IsCommonPrefix(string[] strs, int length)
        {
            string str0 = strs[0].Substring(0, length);
            int count = strs.Length;
            for (int i = 1; i < count; i++)
            {
                var str = strs[i];

                for (int j = 0; j < length; j++)
                {
                    if (!str0[j].Equals(str[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

}

