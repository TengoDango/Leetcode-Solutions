// https://leetcode.cn/problems/qJnOS7/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR095;
public class Solution
{
    // f[i,j]: 子串 s[..i] 和 t[..j] 的最长公共子序列长度
    // OUTPUT = f[m,n]

    // f[0,j] = f[i,0] = 0
    // 若 s[i] == t[j], 则 f[i+1,j+1] = f[i,j] + 1
    // 若 s[i] != t[j], 则 f[i+1,j+1] = max(f[i+1,j], f[i,j+1])

    /// <summary>
    /// 最长公共子序列长度
    /// </summary>
    public int LongestCommonSubsequence(string s, string t)
    {
        int m = s.Length, n = t.Length;
        var f = new int[m + 1, n + 1];
        for (int sum = 0; sum < m + n - 1; sum++)
        {
            for (int i = 0; i < m; i++)
            {
                int j = sum - i;
                if (j < 0 || j >= n) continue;

                f[i + 1, j + 1] = s[i] == t[j]
                    ? f[i, j] + 1
                    : int.Max(f[i + 1, j], f[i, j + 1]);
            }
        }
        return f[m, n];
    }
}