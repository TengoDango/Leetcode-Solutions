// https://leetcode.cn/problems/7WqeDu/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR057;
public class Solution
{
    /// <summary>
    /// 判断是否存在不同索引 i,j，使得
    /// |nums[i] - nums[j]| <= t，|i - j| <= k
    /// </summary>
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
        // 使用桶排序思想，将 x 放入编号为 floor(x / (t+1)) 的桶中
        // 同时维护一个滑动窗口
        Dictionary<int, long> backet = []; // id -> value, value 取 long 以防止溢出
        for (int i = 0; i < nums.Length; i++)
        {
            int id = ID(nums[i], t);
            // 若两个数 id 相同，它们一定满足给定条件
            if (backet.ContainsKey(id)) return true;
            // 相邻 id 的两个数也可能满足条件
            if (backet.TryGetValue(id - 1, out var value)
                && nums[i] - value <= t)
                return true;
            if (backet.TryGetValue(id + 1, out value)
                && value - nums[i] <= t)
                return true;
            // 更新滑动窗口
            backet.Add(id, nums[i]);
            if (i >= k)
                backet.Remove(ID(nums[i - k], t));
        }
        return false;
    }
    int ID(int x, int t) => (int)(x < 0 ? (x + 1) / (t + 1L) - 1 : x / (t + 1L));
}