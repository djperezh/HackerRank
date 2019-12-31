using System.Collections.Generic;

namespace HackerRank
{
    public static class SparseArrays
    {
        static int[] matchingStrings(string[] strings, string[] queries) {
            Dictionary<string, int> freq = new Dictionary<string, int>();
            // O(n)
            foreach (string s in strings)
            {
                if (freq.ContainsKey(s))
                {
                    freq[s] += 1; 
                }
                else
                {
                    freq.Add(s, 1);
                }
            }

            int[] result = new int[queries.Length];
            // O(n)
            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = freq.ContainsKey(queries[i]) ? freq[queries[i]] : 0;
            }

            return result;
        }
    }
}