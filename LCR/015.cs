// https://leetcode.cn/problems/VabMRr/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR015;
public class Solution
{
    /// <summary>
    /// 寻找 s 中所有 p 的排列
    /// </summary>
    /// <returns>
    /// 子串的起始索引列表
    /// </returns>
    public IList<int> FindAnagrams(string s, string p)
    {
        // 同 LCR-014

        List<int> indexes = [];
        if (p.Length > s.Length) return indexes;

        // 滑动窗口
        int[] differ = new int[26];
        for (int i = 0; i < p.Length; i++)
        {
            differ[s[i] - 'a']++;
            differ[p[i] - 'a']--;
        }
        if (differ.All(d => d == 0)) indexes.Add(0);

        int left = 0, right = p.Length;
        while (right < s.Length)
        {
            differ[s[left] - 'a']--;
            differ[s[right] - 'a']++;
            left++; right++;
            if (differ.All(d => d == 0)) indexes.Add(left);
        }

        return indexes;
    }
}