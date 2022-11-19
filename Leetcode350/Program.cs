namespace Leetcode350
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            var result2 = Intersect2(new int[] { 4,9,5 }, new int[] { 9,4,9,8,4 });
        }

        public static int[] Intersect(int[] nums1, int[] nums2) 
        {
            var m = nums1.Length >= nums2.Length ? nums1 : nums2;
            var n = nums1.Length < nums2.Length ? nums1: nums2;

            var dict = new Dictionary<int, int>();

            foreach (var i in m)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, 1);
                }
                else
                {
                    dict[i]++;
                }
            }

            var k = 0;

            foreach (var i in n)
            {
                if (dict.ContainsKey(i) && dict[i] > 0)
                {
                    m[k] = i;
                    dict[i]--;
                    k++;
                }
            }


            return m.Take(k).ToArray();
        }

        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            var m = nums1.ToList();
            var n = nums2.ToList();

            m.Sort();
            n.Sort();

            var i = 0;
            var j = 0;
            var k = 0;

            while (i < m.Count && j < n.Count)
            {
                if(m[i] > n[j])
                {
                    j++;
                }
                else if (m[i] < n[j])
                {
                    i++;
                }
                else
                {
                    m[k] = m[i];
                    k++;
                    i++;
                    j++;
                }
            }

            return m.Take(k).ToArray();
        }
    }
}