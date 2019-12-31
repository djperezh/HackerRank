using System;
using System.Collections.Generic;
using System.Reflection;

namespace HackerRank
{
    public static class StringUtil
    {
        public static void IndexOfTest()
        {
            var input = "aabrabracadabrabracadabracadabracadabr";
            var result = IndexOf(input, "abracadabra");
            
            Console.WriteLine(input);
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            
        }

        public static List<int> IndexOf(string input, string pattern)
        {
            if (input == null || input.Length == 0)
            {
                return null;
            }

            var arr = input.ToCharArray();
            var ft = new List<int>();
            for (var i = 0; i < input.Length - pattern.Length; i++)
            {
                if (arr[i] == pattern[0] && input.Substring(i, pattern.Length) == pattern)
                {
                    ft.Add(i);
                }
            }

            return ft;
        }
    }
}