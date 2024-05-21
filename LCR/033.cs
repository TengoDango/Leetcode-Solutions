// https://leetcode.cn/problems/sfvd7V/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR033;
public class Solution
{
    /// <summary>
    /// 字母异位词分组
    /// </summary>
    public IList<IList<string>> GroupAnagrams(string[] words)
    {
        Dictionary<string, IList<string>> groups = [];

        foreach (string word in words)
        {
            string key = SortString(word);
            if (!groups.ContainsKey(key)) groups.Add(key, []);
            groups[key].Add(word);
        }

        return groups.Values.ToList();
    }
    string SortString(string s) => string.Concat(s.Order());
}