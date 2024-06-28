// https://leetcode.cn/problems/GzCJIP/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR088;
public class Solution
{
    /// <summary>
    /// 花费 cost[i] 后, 可以前进 1 或 2 个索引
    /// </summary>
    /// <param name="cost">Length >= 2</param>
    public int MinCostClimbingStairs(int[] cost)
    {
        // 可以优化为 O(1) 额外空间

        // 记录到达索引 i 的最小花费
        var result = new int[cost.Length + 1];
        // 初始时可以选择索引 0 或 1
        result[0] = 0; result[1] = 0;

        // 动态规划, result[i]= min(
        // result[i-2] + cost[i-2],
        // result[i-1] + cost[i-1])
        for (int i = 2; i <= cost.Length; i++)
        {
            result[i] = int.Min(
                result[i - 2] + cost[i - 2],
                result[i - 1] + cost[i - 1]);
        }
        return result[cost.Length];
    }
}