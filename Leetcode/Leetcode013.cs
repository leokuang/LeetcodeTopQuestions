
namespace Leetcode013
{
    public class Leetcode013
    {
        public static void Main()
        {
            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }
	
        public static int RomanToInt(string s) 
        {
            var ramanDict = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var result = 0;
            var length = s.Length;

            for (int i = 0; i < length; i++)
            {
                var value = ramanDict[s[i]];

                if (i < length - 1 && value < ramanDict[s[i + 1]])
                {
                    result -= value;
                }
                else
                {
                    result += value;
                }
            }

            return result;
        }
    }
    
}

