// https://leetcode.cn/problems/YaVDxD/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR102;
public class Solution
{
    /// <summary>
    /// 将各元素乘 1 或 -1, 相加得 target 的情况个数
    /// </summary>
    public int FindTargetSumWays(int[] nums, int target)
    {
        // 设乘 -1 的元素和为 neg, 则
        // (sum - neg) - neg == target
        // 问题等价于寻找子序列元素和为 neg = (sum - target) / 2
        int sum = nums.Sum();
        if (sum - target < 0 || (sum - target) % 2 != 0)
            return 0;
        int neg = (sum - target) / 2;
        int n = nums.Length;

        // f[i, t]: nums[..i] 和为 t 的子序列个数
        // f[i+1, t] = f[i, t] + f[i, t-nums[i]]
        var f = new int[n + 1, neg + 1];
        f[0, 0] = 1;
        for (int i = 0; i < n; i++)
        {
            for (int t = 0; t <= neg; t++)
            {
                f[i + 1, t] = f[i, t] +
                    (t < nums[i] ? 0 : f[i, t - nums[i]]);
            }
        }
        return f[n, neg];
    }
}