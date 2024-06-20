// https://leetcode.cn/problems/jJ0w9p/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR072;
public class Solution
{
    // MySqrt(2 ^ 31 - 1) + 1
    const int MaxSqrt = 46341;

    /// <summary>
    /// floor(sqrt(x))
    /// </summary>
    public int MySqrt(int x)
    {
        int left = 0, right = MaxSqrt;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (mid * mid == x)
                return mid;
            else if (mid * mid < x)
                left = mid + 1;
            else
                right = mid;
        }
        return left - 1;
    }
}