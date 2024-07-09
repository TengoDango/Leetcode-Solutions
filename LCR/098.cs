// https://leetcode.cn/problems/2AoeFn/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR098;
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        var f = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                if (i == 0 || j == 0)
                {
                    f[i, j] = 1;
                    continue;
                }
                f[i, j] = f[i - 1, j] + f[i, j - 1];
            }
        return f[m - 1, n - 1];
    }
}