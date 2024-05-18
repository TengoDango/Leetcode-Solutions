// https://leetcode.cn/problems/A1NYOS/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR011;
public class Solution
{
    /// <summary>
    /// 寻找含有相同数量的 0 和 1 的最长连续子数组
    /// </summary>
    /// <param name="nums">
    /// 只含有 0 和 1 的数组
    /// </param>
    /// <returns>
    /// 子数组的长度
    /// </returns>
    public int FindMaxLength(int[] nums)
    {
        // 题述条件等价于 子数组元素和为 0 (将 0 视为 -1)
        // 问题转化为子数组元素和为 0 的最长连续子数组
        // 见 LCR-010

        Dictionary<int, int> prefixSumToIndex = [];
        prefixSumToIndex[0] = -1;

        int prefixSum = 0;
        int maxLength = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i] == 0 ? -1 : 1;
            if (prefixSumToIndex.TryGetValue(prefixSum, out int index))
                maxLength = Math.Max(maxLength,
                    i - index);
            else prefixSumToIndex.Add(prefixSum, i);
        }

        return maxLength;
    }
}