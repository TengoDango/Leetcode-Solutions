// https://leetcode.cn/problems/IY6buf/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR096;
public class Solution
{
    // f[i,j]: 子串 s3[..i+j] 是否为 s1[..i] 和 s2[..j] 的交错排列
    // OUTPUT = f[m,n]

    // f[0,0] = true
    // 若 f[i,j] 且 s1[i] == s3[i+j], 则 f[i+1,j] = true
    // 若 f[i,j] 且 s2[j] == s3[i+j], 则 f[i,j+1] = true

    /// <summary>
    /// 判断 s3 是否为 s1 和 s2 的交错排列
    /// </summary>
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length) return false;

        int m = s1.Length, n = s2.Length;
        var f = new bool[m + 1, n + 1];
        f[0, 0] = true;

        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i != m && f[i, j] && s1[i] == s3[i + j])
                    f[i + 1, j] = true;
                if (j != n && f[i, j] && s2[j] == s3[i + j])
                    f[i, j + 1] = true;
            }
        }
        return f[m, n];
    }
}