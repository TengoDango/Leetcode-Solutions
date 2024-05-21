// https://leetcode.cn/problems/569nqc/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR035;
public class Solution
{
    /// <summary>
    /// 计算两个时间点的最小时间差 (分钟)
    /// </summary>
    public int FindMinDifference(IList<string> timePoints)
    {
        var minutes = (from time in timePoints
                    select GetMinutes(time))
                    .ToArray();
        Array.Sort(minutes);

        int minDiff = int.MaxValue;
        for (int i = 0; i < minutes.Length; i++)
        {
            if (i > 0)
                minDiff = Math.Min(minDiff, minutes[i] - minutes[i - 1]);
            else
                minDiff = Math.Min(minDiff, minutes.First() + 24 * 60 - minutes.Last());
        }
        return minDiff;
    }
    /// <param name="time">"HH:MM"</param>
    int GetMinutes(string time)
        => int.Parse(time[0..2]) * 60 + int.Parse(time[3..5]);
}