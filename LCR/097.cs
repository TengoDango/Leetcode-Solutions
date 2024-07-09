// https://leetcode.cn/problems/21dk04/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR097;
public class Solution
{
    // f[i,j]: s[:i] 子序列中 t[:j] 出现的次数
    // OUTPUT = f[m,n]

    // f[i,0] = f[0,j] = 0
    // f[i+1,j+1] = f[i,j+1] + (f[i,j] if s[i] == t[j])

    /// <summary>
    /// s 的子序列中 t 出现的次数
    /// </summary>
    public int NumDistinct(string s, string t)
    {
        int m = s.Length, n = t.Length;
        var f = new int[m + 1, n + 1];

        for (int i = 0; i < m; i++)
            f[i, 0] = 1;
        for (int j = 0; j < n; j++)
            for (int i = 0; i < m; i++)
                f[i + 1, j + 1] = f[i, j + 1] + (s[i] == t[j] ? f[i, j] : 0);

        return f[m, n];
    }
}