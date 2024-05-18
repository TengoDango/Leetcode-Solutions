// https://leetcode.cn/problems/xoh6Oh/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR001;
public class Solution
{
    /// <summary>
    /// 不使用 * / %，求商 a / b；
    /// 
    /// 如果除法结果溢出，则返回 2^31 − 1
    /// </summary>
    public int Divide(int a, int b)
    {
        // 判断溢出
        if (a == int.MinValue && b == -1) return int.MaxValue;

        // 规范化为 a,b < 0
        bool sign = false;
        if (a > 0) { a = -a; sign = !sign;}
        if (b > 0) { b = -b; sign = !sign;}

        int quotient = DivideNormal(a, b);
        return sign ? -quotient : quotient;
    }
    /// <summary>
    /// 两负数除法
    /// </summary>
    int DivideNormal(int a, int b)
    {
        int quotient = 0;
        while (a <= b)
        {
            // 维持 qb = q * b, |a| >= |qb|
            int q = 1, qb = b;
            // qb 未溢出而 qb*2 溢出时，有 qb (mod 2^32) >= 0
            while (a <= qb && qb < 0)
            {
                a -= qb;
                quotient += q;
                // q 指数增长试探
                q += q;
                qb += qb;
            }
        }
        return quotient;
    }
}