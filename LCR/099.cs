// https://leetcode.cn/problems/0i0mDW/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR099;
public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        var f = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                f[i, j] = (i, j) switch
                {
                    (0, 0) => grid[0][0],
                    (0, _) => grid[0][j] + f[0, j - 1],
                    (_, 0) => grid[i][0] + f[i - 1, 0],
                    _ => int.Min(f[i - 1, j], f[i, j - 1]) + grid[i][j],
                };
        return f[m - 1, n - 1];
    }
}