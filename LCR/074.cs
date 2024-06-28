// https://leetcode.cn/problems/SsGoHC/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR074;
public class Solution
{
    /// <summary>
    /// 合并区间数组为无重叠区间数组
    /// </summary>
    public int[][] Merge(int[][] intervals)
    {
        // 以左边界为键进行排序
        Array.Sort(intervals, Comparer<int[]>.Create(
            (r1, r2) => r1[0].CompareTo(r2[0])));

        List<int[]> merged = [];
        int[] current = intervals[0];

        foreach (var interval in intervals)
        {
            // 必有 current[0] <= interval[0]
            if (current[1] < interval[0])
            {
                // 两区间不相交
                merged.Add(current);
                current = interval;
            }
            else
            {
                // 两区间相交
                current[1] = int.Max(current[1], interval[1]);
            }
        }
        merged.Add(current);
        return merged.ToArray();
    }
}