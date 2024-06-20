// https://leetcode.cn/problems/uUsW3B/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR080;
public class Solution
{
    /// <summary>
    /// 列举 1,...,n 中 k 个数的组合
    /// </summary>
    public IList<IList<int>> Combine(int n, int k)
    {
        // 回溯法
        combines = [];
        current = [];
        DFS(1, n, k);
        return combines;
    }
    List<IList<int>> combines = [];
    List<int> current = [];
    /// <summary>
    /// 从 m,...,n 中取 k 个数
    /// </summary>
    void DFS(int m, int n, int k)
    {
        if (k == 0)
        {
            combines.Add(new List<int>(current));
            return;
        }
        for (int i = m; i <= n - k + 1; i++)
        {
            current.Add(i);
            DFS(i + 1, n, k - 1);
            current.RemoveAt(current.Count - 1);
        }
    }
}