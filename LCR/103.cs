// https://leetcode.cn/problems/gaM7Ch/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR103;
public class Solution
{
    // f(x): 凑成 x 的最小硬币数
    // OUTPUT = f(amount)

    // f(0) = 0, default = inf
    // f(x) = min{ f(x - c) } + 1

    public int CoinChange(int[] coins, int amount)
    {
        var f = new int[amount + 1];
        for (int x = 1; x <= amount; x++)
        {
            f[x] = int.MaxValue;
            foreach (var coin in coins)
            {
                if (x - coin >= 0 && f[x - coin] < f[x])
                    f[x] = f[x - coin];
            }
            if (f[x] != int.MaxValue) f[x]++;
        }
        return f[amount] == int.MaxValue ? -1 : f[amount];
    }
}