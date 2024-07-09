// https://leetcode.cn/problems/ZL6zAn/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR105;
public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        this.grid = grid;
        m = grid.Length;
        n = grid[0].Length;
        int max = 0;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                max = int.Max(max, DFS(i, j));
        return max;
    }

    int[][] grid = null!;
    int m, n;
    int DFS(int i, int j)
    {
        if (i < 0 || j < 0 || i >= m || j >= n || grid[i][j] == 0) return 0;
        grid[i][j] = 0;
        return 1 + DFS(i - 1, j) + DFS(i + 1, j) + DFS(i, j - 1) + DFS(i, j + 1);
    }
}