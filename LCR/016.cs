// https://leetcode.cn/problems/wtcaE1/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR016;
public class Solution
{
    /// <summary>
    /// 无重复字符的最长子串的长度
    /// </summary>
    public int LengthOfLongestSubstring(string s)
    {
        // 滑动窗口
        HashSet<char> substring = [];
        int maxLength = 0;

        int left = 0, right = 0;
        while (right < s.Length)
        {
            char c = s[right];
            if (!substring.Contains(c))
            {
                substring.Add(c);
                maxLength = Math.Max(maxLength, substring.Count);
                right++;
            }
            else
            {
                substring.Remove(s[left]);
                left++;
            }
        }

        return maxLength;
    }
}