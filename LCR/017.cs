// https://leetcode.cn/problems/M1oyTv/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR017;
public class Solution
{
    /// <summary>
    /// 寻找 s 中覆盖 t 的最短子串
    /// </summary>
    /// <returns>子串</returns>
    public string MinWindow(string s, string t)
    {
        // 还是滑动窗口，有完没完

        Dictionary<char, int> differ = [];
        for (int i = 0; i < t.Length; i++)
            differ[t[i]] = differ.GetValueOrDefault(t[i]) - 1;

        int minStart = 0, minLength = 0;
        int start = 0, stop = 0;
        while (stop < s.Length)
        {
            if (differ.Values.All(v => v >= 0))
            {
                if (minLength == 0 || stop - start < minLength)
                {
                    minLength = stop - start;
                    minStart = start;
                }
                differ[s[start]]--;
                start++;
            }
            else
            {
                differ[s[stop]] = differ.GetValueOrDefault(s[stop]) + 1;
                stop++;
            }
        }
        // 尾处理
        while (differ.Values.All(v => v >= 0))
        {
            if (minLength == 0 || stop - start < minLength)
            {
                minLength = stop - start;
                minStart = start;
            }
            differ[s[start]]--;
            start++;
        }

        return s.Substring(minStart, minLength);
    }
}