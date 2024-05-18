// https://leetcode.cn/problems/w3tCBm/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR003;
public class Solution
{
    /// <summary>
    /// 计算 0 到 n 之间的每个数字的二进制表示中 1 的个数，并输出一个数组
    /// </summary>
    public int[] CountBits(int n)
    {
        int[] answer = new int[n + 1];

        // 利用动态规划将复杂度优化为 O(n)
        for (int i = 1; i <= n; i++)
            answer[i] = answer[i / 2] + BitCount(i % 2);

        return answer;
    }
    /// <summary>
    /// n 的二进制表示中 1 的个数
    /// </summary>
    int BitCount(int n)
    {
        // return int.PopCount(n);

        int count = 0;
        while (n != 0)
        {
            if (n % 2 == 1) count++;
            n /= 2;
        }
        return count;
    }
}
