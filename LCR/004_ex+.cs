// https://leetcode.cn/problems/WGki4K/?envType=study-plan-v2&envId=coding-interviews-special

using System.Security.Cryptography;

namespace Leetcode.LCR004_EXPLUS;
public class Solution
{
    /// <summary>
    /// 寻找只出现一次的数字
    /// 
    /// 除某个数字只出现一次外，其他数字都出现了三次
    /// </summary>
    public int SingleNumber(int[] nums)
    {
        // 邪道++ 位运算，模 3 加 0/1
        // 用 b a 表示累加结果，i 表示加数 0/1
        // 则可以构造状态转换函数 f(b,a,i) -> (b,a)

        int a = 0, b = 0;
        foreach (var i in nums)
        {
            a = (a ^ i) & ~b;
            b = (b ^ i) & ~a;
        }
        return a;
    }
}