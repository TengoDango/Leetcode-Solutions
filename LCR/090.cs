// https://leetcode.cn/problems/PzWKhm/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR090;
public class Solution
{
    // 题述限制下, 首尾不能同时偷窃
    // 那么对 [..^1], [1..] 分别计算, 取较大值即可

    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];
        return int.Max(
            Rob(nums.AsSpan(..^1)),
            Rob(nums.AsSpan(1..)));
    }
    int Rob(ReadOnlySpan<int> nums)
    {
        // 同 LCR-089
        int[] maxdp = [0, 0, 0];
        foreach (int x in nums)
        {
            maxdp[0] = maxdp[1]; maxdp[1] = maxdp[2];
            maxdp[2] = int.Max(maxdp[1], maxdp[0] + x);
        }
        return maxdp[2];
    }
}