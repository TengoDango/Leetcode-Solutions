// https://leetcode.cn/problems/QTMn0o/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR010;
public class Solution
{
    /// <summary>
    /// 和为 k 的子数组个数
    /// </summary>
    public int SubarraySum(int[] nums, int k)
    {
        int count = 0;

        // 记录前缀和，转化为两数之和问题
        // Key: 不包含当前元素的前缀和
        // Value: 出现次数
        Dictionary<int, int> prefixSum = [];
        prefixSum[0] = 1;

        int prefix = 0;
        foreach (var num in nums)
        {
            prefix += num;
            count += prefixSum.GetValueOrDefault(prefix - k);
            prefixSum[prefix] = prefixSum.GetValueOrDefault(prefix) + 1;
        }

        return count;
    }
}