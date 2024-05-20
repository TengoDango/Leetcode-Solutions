// https://leetcode.cn/problems/a7VOhD/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR020;
public class Solution
{
    /// <summary>
    /// 回文子串的个数
    /// </summary>
    public int CountSubstrings(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
            count += CountEvenPalindromes(s, i)
                   + CountOddPalindromes(s, i);
        return count;
    }
    /// <summary>
    /// 以索引 i 和 i+1 为中心的回文子串的个数
    /// </summary>
    int CountEvenPalindromes(string s, int i)
    {
        int count = 0;
        while (i - count >= 0 && i + 1 + count < s.Length
            && s[i - count] == s[i + 1 + count])
            count++;
        return count;
    }
    /// <summary>
    /// 以索引 i 为中心的回文子串的个数
    /// </summary>
    int CountOddPalindromes(string s, int i)
    {
        int count = 1;
        while (i - count >= 0 && i + count < s.Length
            && s[i - count] == s[i + count])
            count++;
        return count;
    }
}