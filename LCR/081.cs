// https://leetcode.cn/problems/Ygoe9J/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR081;
public class Solution
{
    /// <summary>
    /// 列举 candidates 所有元素组合 (可重复), 使得和为 target
    /// </summary>
    /// <param name="candidates">
    /// 无重复正整数数组
    /// </param>
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        combinations.Clear();
        current.Clear();
        DFS(candidates, 0, target);
        return combinations;
    }
    List<IList<int>> combinations = [];
    List<int> current = [];
    void DFS(int[] nums, int index, int target)
    {
        if (target == 0)
        {
            combinations.Add([.. current]);
            return;
        }
        if (index == nums.Length) return;

        int length = current.Count;
        while (target >= 0)
        {
            DFS(nums, index + 1, target);
            target -= nums[index];
            current.Add(nums[index]);
        }
        current.RemoveRange(length, current.Count - length);
    }
}