// https://leetcode.cn/problems/7p8L0Z/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR084;
public class Solution
{
    /// <summary>
    /// 列举全排列
    /// </summary>
    /// <param name="nums">
    /// 任意数组
    /// </param>
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        // 构造计数字典
        Dictionary<int, int> counterDict = [];
        foreach (var num in nums)
            counterDict[num] = counterDict.GetValueOrDefault(num) + 1;
        var counter = (
            from item in counterDict
            select new int[] { item.Key, item.Value }
            ).ToArray();

        permutations.Clear();
        current.Clear();
        DFS(counter, nums.Length);
        return permutations;
    }
    List<IList<int>> permutations = [];
    List<int> current = [];
    void DFS(int[][] counter, int length)
    {
        if (current.Count == length)
        {
            permutations.Add(current.ToList());
            return;
        }
        for (int i = 0; i < counter.Length; i++)
        {
            // counter[i] = [value, count]
            if (counter[i][1] == 0) continue;
            current.Add(counter[i][0]);
            counter[i][1]--;
            DFS(counter, length);
            counter[i][1]++;
            current.RemoveAt(current.Count - 1);
        }
    }
}