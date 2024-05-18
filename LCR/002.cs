// https://leetcode.cn/problems/JFETK5/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR002;
public class Solution
{
    /// <summary>
    /// 计算两个二进制串的和，结果以二进制串表示
    /// </summary>
    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1, j = b.Length - 1;
        Stack<char> c = [];

        int carry = 0;
        // 从低位到高位逐位相加，并处理进位
        while (i >= 0 || j >= 0 || carry != 0)
        {
            // 读取当前位
            int bitA = i < 0 ? 0 : a[i] - '0';
            int bitB = j < 0 ? 0 : b[j] - '0';

            // 位相加并计算进位
            int bitC = bitA + bitB + carry;
            carry = bitC / 2;
            bitC %= 2;

            // 将当前位和加入结果
            c.Push((char)('0' + bitC));
            i--; j--;
        }

        // 按栈遍历顺序 (LIFO) 遍历刚好可得结果
        return string.Concat(c);
    }
}