// https://leetcode.cn/problems/M99OJA/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR086;
public class Solution
{
    /// <summary>
    /// 列举字符串分割, 使得分割中每个子串都是回文串
    /// </summary>
    public string[][] Partition(string s)
    {
        var ranges = FindAllParlindromes(s);
        current.Clear();
        rangePartitions.Clear();
        DFS(ranges, 0);
        return RangePartitionsToSubstrings(s);
    }

    /// <summary>
    /// 寻找所有回文子串
    /// </summary>
    List<int>[] FindAllParlindromes(string s)
    {
        // start: int  -->  List<length: int>
        var ranges = new List<int>[s.Length];
        for (int center = 0; center < s.Length; center++)
        {
            ranges[center] = [1];
            int count; // 以 center 为中心的子串个数

            // 考察奇数长度 (>= 3) 的子串
            count = int.Min(center, s.Length - center - 1);
            for (int i = 1; i <= count; i++)
                if (s[center - i] == s[center + i])
                    ranges[center - i].Add(i * 2 + 1);
                else break;

            // 考察偶数长度 (>= 2) 的子串
            count = int.Min(center + 1, s.Length - center - 1);
            for (int i = 1; i <= count; i++)
                if (s[center - i + 1] == s[center + i])
                    ranges[center - i + 1].Add(i * 2);
                else break;
        }
        return ranges;
    }

    List<(int Start, int Length)> current = [];
    List<List<(int Start, int Length)>> rangePartitions = [];
    void DFS(List<int>[] ranges, int start)
    {
        if (start == ranges.Length)
        {
            rangePartitions.Add(current.ToList());
            return;
        }
        // start: int  -->  List<length: int>
        foreach (int length in ranges[start])
        {
            current.Add((start, length));
            DFS(ranges, start + length);
            current.RemoveAt(current.Count - 1);
        }
    }

    /// <summary>
    /// 区间分割转为字符串分割
    /// </summary>
    string[][] RangePartitionsToSubstrings(string s)
    {
        return (
            from rangePartition in rangePartitions
            select (
            from range in rangePartition
            select s.Substring(range.Start, range.Length)
            ).ToArray()
            ).ToArray();
    }
}