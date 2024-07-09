// https://leetcode.cn/problems/omKAoA/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR094;
public class Solution
{
    // dp[i]: 子串 s[..i] 的最小分割次数
    // OUTPUT = dp[n]

    // dp[0] = -1
    // dp[i] = min(dp[j])+1, 对所有 s[j..i] 为回文串的 j < i

    /// <summary>
    /// 分割为回文子串的最小分割次数
    /// </summary>
    public int MinCut(string s)
    {
        int n = s.Length;
        var palindromes = GetPalindromes(s);
        var dp = new int[n + 1];
        dp[0] = -1;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = int.MaxValue;
            foreach (int j in palindromes[i])
            {
                dp[i] = int.Min(dp[i], dp[j]);
            }
            dp[i]++;
        }
        return dp[n];
    }
    /// <returns>
    /// end -> List[start]
    /// </returns>
    List<int>[] GetPalindromes(string s)
    {
        int n = s.Length;
        var palindromes = new List<int>[n + 1];
        for (int i = 0; i <= n; i++)
            palindromes[i] = [];
        for (int i = 0; i < n; i++)
        {
            int j = 0;
            while (i - j >= 0 && i + j < n && s[i - j] == s[i + j])
            {
                palindromes[i + j + 1].Add(i - j);
                j++;
            }
            j = 0;
            while (i - j >= 0 && i + j + 1 < n && s[i - j] == s[i + j + 1])
            {
                palindromes[i + j + 2].Add(i - j);
                j++;
            }
        }
        return palindromes;
    }
}