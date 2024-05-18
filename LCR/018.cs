// https://leetcode.cn/problems/XltzEq/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR018;
public class Solution
{
    /// <summary>
    /// 判断回文串，只考虑字母和数字，忽略大小写
    /// </summary>
    public bool IsPalindrome(string s)
    {
        s = s.ToUpperInvariant();
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (!char.IsAsciiLetterOrDigit(s[left]))
            { left++; continue; }
            if (!char.IsAsciiLetterOrDigit(s[right]))
            { right--; continue; }

            if (s[left] != s[right]) return false;
            left++; right--;
        }
        return true;
    }
}