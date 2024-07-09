// https://leetcode.cn/problems/NUPfPr/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR101;
public class Solution
{
    /// <summary>
    /// 判断能否分割为两个元素和相等的子集
    /// </summary>
    public bool CanPartition(int[] nums)
    {
        // 记忆化搜索
        int sum = nums.Sum();
        if (int.IsOddInteger(sum) || nums.Length < 2)
            return false;
        cache.Clear();
        return DFS(nums, nums.Length - 1, sum / 2);
    }
    Dictionary<(int index, int target), bool> cache = [];
    bool DFS(int[] a, int i, int target)
    {
        if (i == -1 || target <= 0) return i == -1 && target == 0;
        if (cache.TryGetValue((i, target), out bool result))
            return result;
        result = DFS(a, i - 1, target - a[i]) || DFS(a, i - 1, target);
        cache.Add((i, target), result);
        return result;
    }
}