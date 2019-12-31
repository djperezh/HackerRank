using System;
using System.Collections.Generic;

namespace HackerRank
{
    public static class SumTriplet
    {
        public static void isTripletFoundTest()
        {
            isTripletFound(new [] { 8, 2, -3, 4, 5, -1, 2, 3, 11, 5}, 15);
        }

        public static bool isTripletFound(int[] input, int targetSum)
        {
            var result = false;
            if (input == null || input.Length < 3)
            {
                return false;
            }

            // O(n^2)
            var targetList = new Dictionary<int, List<int[]>>();
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var tmp = input[i] + input[j];
                    var indexesPair = new[] {i, j};
                    if (targetList.ContainsKey(tmp))
                    {
                        targetList[tmp].Add(indexesPair);
                    }
                    else
                    {
                        targetList.Add(tmp, new List<int[]> { indexesPair });
                    }
                }
            }
            
            // O(n*m)
            for (var i = 0; i < input.Length; i++)
            {
                var tmp = targetSum - input[i];
                if (targetList.ContainsKey(tmp))
                {
                    foreach (var indexesPairList in targetList[tmp])
                    {
                        if (indexesPairList[0] > i && indexesPairList[1] > i)
                        {
                            Console.WriteLine($"Triplet: [{input[i]}, {input[indexesPairList[0]]}, {input[indexesPairList[1]]}]");
                            Console.WriteLine($">>> Indexes: [{i}, {indexesPairList[0]}, {indexesPairList[1]}]");
                            Console.WriteLine();
                            result = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}