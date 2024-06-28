// https://leetcode.cn/problems/4sjJUc/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR082;
public class Solution
{
    /// <summary>
    /// 列举 candidates 所有元素组合 (最多使用一次), 使得和为 target
    /// </summary>
    /// <param name="candidates">
    /// 可重复正整数数组
    /// </param>
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        // 构造计数字典
        Dictionary<int, int> counter = [];
        foreach (int x in candidates)
            counter[x] = counter.GetValueOrDefault(x) + 1;
        // 为了回溯, 把计数字典转为列表
        var counterList = counter.ToArray();

        combinations.Clear();
        current.Clear();
        DFS(counterList, 0, target);
        return combinations;
    }
    List<IList<int>> combinations = [];
    List<int> current = [];
    void DFS(KeyValuePair<int, int>[] counter, int index, int target)
    {
        if (target == 0)
        {
            combinations.Add([.. current]);
            return;
        }
        if (index == counter.Length) return;

        int length = current.Count;
        var (value, count) = counter[index];
        for (int i = 0; i <= count; i++)
        {
            DFS(counter, index + 1, target);
            target -= value;
            if (target < 0) break;
            current.Add(value);
        }
        current.RemoveRange(length, current.Count - length);
    }
}