using System;
using System.Collections.Generic;

namespace HackerRank
{
    class HackerRack
    {
        static void Main(string[] args)
        {
            // testPermute();
            // testIsValid();
            // SteadyGene.TestGetSteadyGeneLength();
            // SumTriplet.isTripletFoundTest();
            // HackerRank.Permute.PermuteStringTest();
            // Sorting.MergeSortTest();
            // StringUtil.IndexOfTest();
            CoinChange.CoinChangeTest();
        }

        private static void testPermute()
        {
            string input = "012";
            List<string> permutations = Permute(input.ToCharArray(), 0, input.Length - 1, new List<string>());
            //Console.WriteLine("TOTAL: " + permutations.Count);

            HashSet<string> result = new HashSet<string>(permutations); //.ToArray();
            foreach (var item in permutations)
            {
                Console.WriteLine(item);
            }
        }

        public static List<string> Permute(char[] str, int ini, int end, List<string> result)
        {
            if (ini == end)
            {
                result.Add(new string(str));
            }
            for (int i = ini; i <= end; i++)
            {
                str = Swap(str, ini, i);
                result = Permute(str, ini + 1, end, result);
                str = Swap(str, ini, i);
            }
            return result;
        }

        private static char[] Swap(char[] str, int i, int j)
        {
            char tmp = str[i];
            str[i] = str[j];
            str[j] = tmp;
            return str;
        }

        private static void testIsValid()
        {
            //var s = "aabbccddeefghi";
            var s = "ibfdgaeadiaefgbhbdghhhbgdfgeiccbiehhfcggchgghadhdhagfbahhddgghbdehidbibaeaagaeeigffcebfbaieggabcfbiiedcabfihchdfabifahcbhagccbdfifhghcadfiadeeaheeddddiecaicbgigccageicehfdhdgafaddhffadigfhhcaedcedecafeacbdacgfgfeeibgaiffdehigebhhehiaahfidibccdcdagifgaihacihadecgifihbebffebdfbchbgigeccahgihbcbcaggebaaafgfedbfgagfediddghdgbgehhhifhgcedechahidcbchebheihaadbbbiaiccededchdagfhccfdefigfibifabeiaccghcegfbcghaefifbachebaacbhbfgfddeceababbacgffbagidebeadfihaefefegbghgddbbgddeehgfbhafbccidebgehifafgbghafacgfdccgifdcbbbidfifhdaibgigebigaedeaaiadegfefbhacgddhchgcbgcaeaieiegiffchbgbebgbehbbfcebciiagacaiechdigbgbghefcahgbhfibhedaeeiffebdiabcifgccdefabccdghehfibfiifdaicfedagahhdcbhbicdgibgcedieihcichadgchgbdcdagaihebbabhibcihicadgadfcihdheefbhffiageddhgahaidfdhhdbgciiaciegchiiebfbcbhaeagccfhbfhaddagnfieihghfbaggiffbbfbecgaiiidccdceadbbdfgigibgcgchafccdchgifdeieicbaididhfcfdedbhaadedfageigfdehgcdaecaebebebfcieaecfagfdieaefdiedbcadchabhebgehiidfcgahcdhcdhgchhiiheffiifeegcfdgbdeffhgeghdfhbfbifgidcafbfcd";
            var result = isValid(s);
            Console.WriteLine(result);
        }

        private static string isValid(string s) {
            if (s.Length == 1)
            {
                return "YES";
            }

            // build freq table (O[n])
            var freq = new Dictionary<char, long>();
            foreach (var c in s)
            {
                if (freq.ContainsKey(c))
                {
                    freq[c]++;
                }
                else
                {
                    freq.Add(c, 1);
                }
            }

            // build ocurrences table (O[n])
            var ocur = new Dictionary<long, long>();
            foreach (var f in freq)
            {
                var ocurrences = f.Value;
                if (ocur.ContainsKey(ocurrences))
                {
                    ocur[ocurrences]++;
                }
                else
                {
                    ocur.Add((long)ocurrences, (long)1);
                }
            }

            // all chars has the same counter
            if (ocur.Count == 1)
            {
                return "YES";
            }
            // multiple chars has different counters
            if (ocur.Count > 2)
            {
                return "NO";
            }

            // multiple chars but they have either X or Y number of ocurrencies (O[n])
            long previousCounter = 0;
            long previousVal = -1;
            foreach (var entry in ocur)
            {
                if (previousVal == -1)
                {
                    previousVal = (long)entry.Key;
                    previousCounter = (long)entry.Value;
                }
                else
                {
                    if ((previousCounter == 1 && previousVal == 1) || 
                        (entry.Value == 1 && entry.Key == 1))
                    {
                        return "YES";
                    }
                
                    
                    // if the ocurrences difference is > 1
                    // then chaging 1 char is not enough) OR
                    // there are multiple chars with 1 ocurrence difference
                    if (previousCounter != 1 && entry.Value != 1 || Math.Abs(previousVal - entry.Key) != 1)
                    {
                        return "NO";
                    }
                }
            }

            return "YES";
        }
    }
}