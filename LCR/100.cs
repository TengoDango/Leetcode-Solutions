// https://leetcode.cn/problems/IlPe0q/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR100;
public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        var f = new int[n][];
        f[0] = [triangle[0][0]];
        for (int k = 1; k < n; k++)
        {
            f[k] = new int[k + 1];
            f[k][0] = f[k - 1][0] + triangle[k][0];
            f[k][k] = f[k - 1][k - 1] + triangle[k][k];
            for (int i = 1; i < k; i++)
            {
                f[k][i] = int.Min(f[k - 1][i - 1], f[k - 1][i]) + triangle[k][i];
            }
        }
        return f[n - 1].Min();
    }
}