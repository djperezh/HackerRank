using System;

public static class CoinChange
{
    public static void CoinChangeTest()
    {
        var result = CoinChange.GetAllPosibleComboOfCoins(4, new []{1, 2, 3});
        Console.WriteLine(result);
        var result2 = CoinChange.GetMinNumberOfCoins(30, new []{25, 15, 1});
        Console.WriteLine(result2);
    }


    public static int GetAllPosibleComboOfCoins(int amount, int[] coins)
    {
        var memoization = new int[amount + 1];
        memoization[0] = 1;

        for (var coinsIndex = 0; coinsIndex < coins.Length; coinsIndex++)
        {
            var currentDenomination = coins[coinsIndex];
            for (var currentAmount = 1; currentAmount <= amount; currentAmount++)
            {
                if (currentDenomination <= currentAmount)
                {
                    memoization[currentAmount] += memoization[currentAmount - currentDenomination];
                }
            }
        }

        return memoization[amount];
    }
    public static int GetMinNumberOfCoins(int amount, int[] coins)
    {
        var memoization = new int[amount + 1];
        memoization[0] = 0;
        for (var i = 1; i < amount + 1; i++)
        {
            memoization[i] = int.MaxValue;
        }

        for (var currentAmount = 1; currentAmount <= amount; currentAmount++)
        {
            for (var coinsIndex = 0; coinsIndex < coins.Length; coinsIndex++)
            {
                var currentDenomination = coins[coinsIndex];
                if (currentDenomination <= currentAmount &&
                    memoization[currentAmount - currentDenomination] != int.MaxValue &&
                    memoization[currentAmount - currentDenomination] + 1 < memoization[currentAmount])
                {
                        memoization[currentAmount] = memoization[currentAmount - currentDenomination] + 1;
                }
            }
        }

        return memoization[amount];
    }
    public static int GetMinCoinsChangeCounter(int amount, int[] denominations)
    {
        var minCoinsCounter = new int[amount + 1];

        for (var i = 1; i <= amount; i++)
        {
            minCoinsCounter[i] = GetChangeCombination(i, denominations, 0, 0, minCoinsCounter);
        }

        return minCoinsCounter[amount];
    }

    private static int GetChangeCombination(int amount, int[] denominations, int index, int counter, int[] minCoinsCounter)
    {
        if (amount == 0)
        {
            return counter;
        }

        if (minCoinsCounter[amount] != 0)
        {
            return counter + minCoinsCounter[amount];
        }

        //  $30, denom: 25, 15, 1 (expected = 2 -> 2x15)
        for (var i = index; i < denominations.Length; i++)
        {
            if (amount >= denominations[i])
            {
                var times = amount / denominations[i];
                var tmpAmount = denominations[i] * times;
                // minCoinsCounter[tmpAmount] = times;
                amount -= tmpAmount;
                // counter += times;

                counter += GetChangeCombination(amount, denominations, index + 1, counter + times, minCoinsCounter);
                break;
            }
        }

        return counter;
    }
}