using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class Permute
    {
        public static void PermuteStringTest()
        {
            var input = "cats";
            var result = PermuteString(input);
            foreach (var p in result)
            {
                Console.WriteLine(p);
            }
        }

        public static HashSet<string> PermuteString(string input)
        {
            if (input == null)
            {
                return null;
            }

            if (input.Length <= 2)
            {
                return new HashSet<string> { input };
            }

            var result = new HashSet<string>();
            Permutation(input, 0, input.Length - 1, result);
            return result;
        }

        private static void Permutation(string input, int ini, int end, HashSet<string> result)
        {
            if (ini == end)
            {
                result.Add(input);
                return;
            }

            for (var i = ini; i <= end; i++)
            {
                input = Swap(input, ini, i);
                Permutation(input, ini + 1, end, result);
                input = Swap(input, ini, i);
            }
        }

        private static string Swap(string input, int i, int j)
        {
            var arr = input.ToCharArray();
            var tmp = arr[j];
            arr[j] = arr[i];
            arr[i] = tmp;
            return new string(arr);
        }
    }
}