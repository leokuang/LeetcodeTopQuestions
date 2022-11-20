/*
 387. First Unique Character in a String
   
   Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.
   
   Example 1:
   
   Input: s = "leetcode"
   Output: 0
   
   Example 2:
   
   Input: s = "loveleetcode"
   Output: 2
   
   Example 3:
   
   Input: s = "aabb"
   Output: -1
 */

namespace Leetcode387
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = FirstUniqChar3("loveleetcode");
        }

        public static int FirstUniqChar(string s) 
        {
            var dict = new Dictionary<char, int>();
            
            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else 
                    dict[c]++;
            }

            foreach (var v in dict)
            {
                if (v.Value == 1)
                {
                    return s.IndexOf(v.Key);
                }
            }

            return -1;
        }

        public static int FirstUniqChar2(string s) 
        {
            var dict = new Dictionary<char, int>();
            
            var index = 0;

            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, index);
                }
                else
                {
                    dict[c] = -1;
                }

                index++;
            }

            foreach (var v in dict)
            {
                if (v.Value != -1)
                {
                    return v.Value;
                }
            }

            return -1;
        }

        public static int FirstUniqChar3(string s)
        {
            var position = new Dictionary<char, int>();
            var queue = new Queue<Pair>();

            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                char ch = s[i];

                if (!position.ContainsKey(ch))
                {
                    position.Add(ch, i);
                    queue.Enqueue(new Pair(ch, i));
                }
                else
                {
                    position[ch] = -1;
                    while (queue.Any() && position[queue.Peek().ch] == -1)
                    {
                        queue.Dequeue();
                    }
                }
            }

            return queue.Any() ? queue.Dequeue().pos : -1;
        }

        public class Pair
        {
            public char ch;
            public int pos;

            public Pair(char ch, int pos)
            {
                this.ch = ch;
                this.pos = pos;
            }
        }
    }
}