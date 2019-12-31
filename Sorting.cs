using System;

namespace HackerRank
{
    public static class Sorting
    {
        public static void MergeSortTest()
        {
            var input = new long[] {4, 7, 1, 4, -2, 0, 5, 9, -1, 12303479849857};
            var result = MergeSort(input);
            foreach (var n in result)
            {
                Console.Write(n + ",");
            }
        }

        public static long[] MergeSort(long[] input)
        {
            if (input == null || input.Length < 2)
            {
                return input;
            }

            var aLength = input.Length / 2;
            var bLength = input.Length - aLength;
            var a = new long[aLength];
            var b = new long[bLength];

            for (var i = 0; i < aLength; i++)
            {
                a[i] = input[i];
            }
            for (var i = 0; i < bLength; i++)
            {
                b[i] = input[i + aLength];
            }

            a = MergeSort(a);
            b = MergeSort(b);
            
            return Merge(a, b);
        }

        private static long[] Merge(long[] a, long[] b)
        {
            var result = new long[a.Length + b.Length];
            var aIndex = 0;
            var bIndex = 0;
            var resultIndex = 0;
            
            while (aIndex < a.Length && bIndex < b.Length)
            {
                if (a[aIndex] == b[bIndex])
                {
                    result[resultIndex++] = a[aIndex++];
                    result[resultIndex++] = b[bIndex++];
                }
                else
                {
                    if (a[aIndex] < b[bIndex])
                    {
                        result[resultIndex++] = a[aIndex++];
                    }
                    else
                    {
                        result[resultIndex++] = b[bIndex++];
                    }
                }
            }

            for (var i = aIndex; i < a.Length; i++)
            {
                result[resultIndex++] = a[aIndex++];
            }
            for (var i = bIndex; i < b.Length; i++)
            {
                result[resultIndex++] = b[bIndex++];
            }
            
            return result;
        }
    }
}