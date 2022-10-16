/*
    118. Pascal's Triangle    

    Given an integer numRows, return the first numRows of Pascal's triangle.

    In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

    Example 1:

    Input: numRows = 5
    Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]

    Example 2:

    Input: numRows = 1
    Output: [[1]]
 */

namespace Leetcode118
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public IList<IList<int>> Generate(int numRows) 
        {
            var list = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                var row = new List<int>();

                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(list[i - 1][j - 1] + list[i - 1][j]);
                    }
                }

                list.Add(row);
            }
            return list;
        }
    }
}