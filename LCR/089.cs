// https://leetcode.cn/problems/Gu0c2T/description/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR089;
public class Solution
{
    // dp[i]: 最后偷窃 i 的情况的最高金额
    // maxdp[i]: max(dp[0],...,dp[i])
    // OUTPUT = maxdp.Last()

    // dp[0] = nums[0], dp[1] = nums[1]
    // dp[i] = maxdp[i-2] + nums[i]
    // maxdp[0] = nums[0]
    // maxdp[i] = max(maxdp[i-1], dp[i])

    // 简化:
    // maxdp[-i] = 0
    // maxdp[i] = max(maxdp[i-1], maxdp[i-2] + nums[i])

    public int Rob(int[] nums)
    {
        // 优化
        int[] maxdp = [0, 0, 0];
        foreach (int x in nums)
        {
            // 移动窗口
            maxdp[0] = maxdp[1]; maxdp[1] = maxdp[2];
            // 计算递推
            maxdp[2] = int.Max(maxdp[1], maxdp[0] + x);
        }
        return maxdp[2];
    }
}