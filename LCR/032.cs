// https://leetcode.cn/problems/dKk3P7/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR032;
public class Solution
{
    /// <summary>
    /// 判断两个字符串是否互为字母异位词
    /// </summary>
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        Dictionary<char, int> differ = [];
        bool isEqual = true;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[i]) continue;
            isEqual = false;
            differ[s[i]] = differ.GetValueOrDefault(s[i]) + 1;
            differ[t[i]] = differ.GetValueOrDefault(t[i]) - 1;
        }
        return !isEqual && differ.Values.All(v => v == 0);
    }
}