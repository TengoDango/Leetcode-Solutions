// https://leetcode.cn/problems/TVdhkn/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR079;
public class Solution
{
    /// <summary>
    /// 列举所有子集
    /// </summary>
    public IList<IList<int>> Subsets(int[] nums)
    {
        // 回溯法经典题
        subsets = [];
        current = [];
        DFS(nums, 0);
        return subsets;
    }
    List<IList<int>> subsets = [];
    List<int> current = [];
    void DFS(int[] nums, int index)
    {
        if (index == nums.Length)
        {
            subsets.Add(new List<int>(current));
            return;
        }
        DFS(nums, index + 1);
        current.Add(nums[index]);
        DFS(nums, index + 1);
        current.RemoveAt(current.Count - 1);
    }
}