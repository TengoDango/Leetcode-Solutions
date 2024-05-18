// https://leetcode.cn/problems/MPnaiL/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR014;
public class Solution
{
    /// <summary>
    /// 判断是否存在 s1 的排列为 s2 的子串
    /// </summary>
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        // 滑动窗口
        int[] count = new int[26];
        for (int i = 0; i < s1.Length; i++)
        {
            count[s1[i] - 'a']--;
            count[s2[i] - 'a']++;
        }
        if (count.All(c => c == 0)) return true;

        int left = 0, right = s1.Length;
        while (right < s2.Length)
        {
            count[s2[left] - 'a']--;
            count[s2[right] - 'a']++;
            if (count.All(c => c == 0)) return true;
            left++; right++;
        }
        return false;
    }
}