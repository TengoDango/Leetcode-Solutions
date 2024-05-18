// https://leetcode.cn/problems/WGki4K/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR004_EX;
public class Solution
{
    /// <summary>
    /// 寻找只出现一次的数字
    /// 
    /// 除某个数字只出现一次外，其他数字都出现了三次
    /// </summary>
    public int SingleNumber(int[] nums)
    {
        int singleNumber = 0;

        // 位运算，如果某位上 1 出现的次数不是 3 的倍数，
        // 那么只出现一次的数字在该位上就是 1
        int mask = 1;
        for (int i = 0; i < 32; i++)
        {
            int sum = 0;
            foreach (int num in nums)
                if ((num & mask) != 0)
                    sum++;

            if (sum % 3 != 0)
                singleNumber |= mask;

            mask <<= 1;
        }

        return singleNumber;
    }
}