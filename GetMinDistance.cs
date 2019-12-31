using System.Collections.Generic;

namespace HackerRank
{
    public static class GetMinDistance
    {
        // Complete the minimumDistances function below.
        public static int MinimumDistances(int[] a) {
            if (a == null || a.Length == 0)
            {
                return -1;
            }

            int response = -1;
            // build dictionary: int, indexes[]
            Dictionary<int, Queue<int>> indexes = getIndexes(a);

            // for each entry in dictionary
            foreach (KeyValuePair<int, Queue<int>> entry in indexes)
            {
                if (entry.Value.Count > 1)
                {
                    // get min distance based on the indexes
                    int tmp = getMinDistance(entry.Value);
    
                    // compare and update Min distance response
                    if (response == -1 || tmp < response)
                    {
                        response = tmp;
                    }
                }
            }

            return response;
        }

        static Dictionary<int, Queue<int>> getIndexes(int[] a)
        {
            Dictionary<int, Queue<int>> indexes = 
                new Dictionary<int, Queue<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                int number = a[i];
                if (indexes.ContainsKey(number))
                {
                    indexes[number].Enqueue(i);
                }
                else
                {
                    Queue<int> q = new Queue<int>();
                    q.Enqueue(i);
                    indexes.Add(number, q);
                }
            }

            return indexes;
        }

        static int getMinDistance(Queue<int> a)
        {
            int response = -1;
            int previous = a.Dequeue();

            while (a.Count > 0)
            {
                int current = a.Dequeue();
                int tmp = current - previous;
                if (response == -1 || tmp < response)
                {
                    response = tmp;
                }
                previous = current;
            }

            return response;
        }
    }
}