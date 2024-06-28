// https://leetcode.cn/problems/VvJkup/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR083;
public class Solution
{
    /// <summary>
    /// 列举全排列
    /// </summary>
    /// <param name="nums">
    /// 无重复数组
    /// </param>
    public IList<IList<int>> Permute(int[] nums)
    {
        permutations.Clear();
        DFS(nums, 0);
        return permutations;
    }
    List<IList<int>> permutations = [];
    void DFS(int[] nums, int i)
    {
        if (i == nums.Length)
        {
            permutations.Add(nums.ToList());
            return;
        }
        for (int j = i; j < nums.Length; j++)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
            DFS(nums, i + 1);
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
    }
}