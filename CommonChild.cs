using System.Collections.Generic;

namespace HackerRank
{
    /*
     * Sample Input 1

AA
BB

Sample Output 1

0

Explanation 1

and

have no characters in common and hence the output is 0.

Sample Input 2

SHINCHAN
NOHARAAA

Sample Output 2

3

Explanation 2

The longest string that can be formed between
and while maintaining the order is

.

Sample Input 3

ABCDEF
FBDAMN

Sample Output 3

2

Explanation 3
is the longest child of the given strings.
     */
    public static class CommonChild
    {
        static int commonChild(string s1, string s2) 
        {
            int result = 0;
            if (s1 == null || s2 == null)
            {
                return result;
            }
            Dictionary<char, List<int>> s2dic = 
                new Dictionary<char, List<int>>();
            for (int i = 0; i < s2.Length; i++)
            {
                char c = s2[i];
                if (s2dic.ContainsKey(c))
                {
                    s2dic[c].Add(i); // add index in the existing entry
                }
                else
                {
                    s2dic.Add(c, new List<int>{i}); // new entry
                }
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (s2dic.ContainsKey(s1[i]))
                {
                    int tmp = GetCount(s1, i, s2dic);
                    if (result < tmp)
                    {
                        result = tmp;
                        break;
                    }
                }
            }
            return result;
        }

        static int GetCount(string s1, int i, Dictionary<char, List<int>> s2dic)
        {
            int result = 0;
            int s2index = -1;
            for (int s1index = i; s1index < s1.Length; s1index++)
            {
                char c = s1[s1index];
                int tmp = GetNewIndex(s2dic[c], s2index);
                if (tmp != -1)
                {
                    s2index = tmp + 1;
                    result++;
                }
            }
            return result;
        }

        private static int GetNewIndex(
            List<int> indexes, int s2index)
        {
            int result = -1;
            foreach(int number in indexes)
            {
                if (number > s2index)
                {
                    return number;
                }
            }
            return result;
        }    
    }
}