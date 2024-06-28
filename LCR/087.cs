// https://leetcode.cn/problems/0on3uN/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR087;
public class Solution
{
    /// <summary>
    /// 列举复原出的所有有效 IP 地址
    /// </summary>
    /// <param name="s">数字字符串</param>
    /// <returns>点分 IP 地址</returns>
    public IList<string> RestoreIpAddresses(string s)
    {
        IpAddresses.Clear();
        DFS(s, []);
        return IpAddresses;
    }

    List<string> IpAddresses = [];
    void DFS(ReadOnlySpan<char> s, List<int> ip)
    {
        // 复原出有效 IP 地址的情况
        if (s.Length == 0 && ip.Count == 4)
        {
            IpAddresses.Add(string.Join('.', ip));
            return;
        }
        // 确认复原失败的情况
        if (s.Length == 0 || ip.Count == 4)
            return;
        // 以 0 开头因而该分节只能为 0 的情况
        if (s[0] == '0')
        {
            ip.Add(0);
            DFS(s[1..], ip);
            ip.RemoveAt(ip.Count - 1);
            return;
        }
        // 以非零开头的一般情况
        int section = 0;
        foreach (char digit in s)
        {
            section = section * 10 + digit - '0';
            if (section > 255) return;
            ip.Add(section);
            s = s[1..];
            DFS(s, ip);
            ip.RemoveAt(ip.Count - 1);
        }
    }
}