// https://leetcode.cn/problems/RQku0D/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR019;
public class Solution
{
    /// <summary>
    /// 判断回文串 (可以删除最多一个字符)
    /// </summary>
    public bool ValidPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            if (s[i] != s[j])
                return IsPalindrome(s, i, j - 1)
                    || IsPalindrome(s, i + 1, j);
        return true;
    }
    bool IsPalindrome(string s, int left, int right)
    {
        for (; left < right; left++, right--)
            if (s[left] != s[right]) return false;
        return true;
    }
}