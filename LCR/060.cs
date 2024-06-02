// https://leetcode.cn/problems/g5c51o/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR060;
public class Solution
{
    /// <summary>
    /// 获取前 k 个高频元素
    /// </summary>
    public int[] TopKFrequent(int[] nums, int k)
    {
        // 以频率相反数作为优先级, 频率越高越靠前
        Dictionary<int, int> priority = [];
        foreach (var num in nums)
            priority[num] = priority.GetValueOrDefault(num) - 1;
        PriorityQueue<int, int> heap = new(
            from item in priority select (item.Key, item.Value));
        int[] ans = new int[k];
        for (int i = 0; i < k; i++)
            ans[i] = heap.Dequeue();
        return ans;
    }
}