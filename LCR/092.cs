// https://leetcode.cn/problems/cyJERH/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR092;
public class Solution
{
    // 记翻转后比特串为 s'
    // a[i]: s'[i] 为 0 时, s[0..(i+1)] 的最少翻转次数
    // b[i]: s'[i] 为 1 时, ...

    // a[-1] = b[-1] = 0
    // a[i] = a[i-1] + (1 if s[i] == 1)
    // b[i] = min(a[i-1], b[i-1]) + (1 if s[i] == 0)

    public int MinFlipsMonoIncr(string s)
    {
        int a = 0, b = 0;
        foreach (char bit in s)
        {
            b = int.Min(a, b);
            if (bit == '0') b++;
            else a++;
        }
        return int.Min(a, b);
    }
}