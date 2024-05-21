// https://leetcode.cn/problems/lwyVBB/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR034;
public class Solution
{
    /// <summary>
    /// 判断单词序列是否按指定字母表排序
    /// </summary>
    public bool IsAlienSorted(string[] words, string order)
    {
        Dictionary<char, int> key = [];
        for (int i = 0; i < order.Length; i++)
            key[order[i]] = i;

        for (int i = 1; i < words.Length; i++)
            if (StringCompare(words[i - 1], words[i], key) > 0)
                return false;
        return true;
    }
    int StringCompare(string s1, string s2, Dictionary<char, int> key)
    {
        int length = Math.Min(s1.Length, s2.Length);
        for (int i = 0; i < length; i++)
        {
            if (key[s1[i]] < key[s2[i]]) return -1;
            if (key[s1[i]] > key[s2[i]]) return 1;
        }
        return s1.Length - s2.Length;
    }
}