// https://leetcode.cn/problems/2VG8Kg/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR008;
public class Solution
{
    /// <summary>
    /// 寻找和 >= target 的最短连续子数组
    /// </summary>
    /// <param name="nums">
    /// 正数数组
    /// </param>
    /// <returns>
    /// 子数组长度，不存在则返回 0
    /// </returns>
    public int MinSubArrayLen(int target, int[] nums)
    {
        int minLength = int.MaxValue;
        // 由于数组元素为正，可以优化为滑动窗口
        int start = 0, stop = 0;
        int sum = 0;

        while (stop < nums.Length)
        {
            sum += nums[stop];
            stop++;
            if (sum >= target)
            {
                while (sum - nums[start] >= target)
                {
                    sum -= nums[start];
                    start++;
                }
                minLength = Math.Min(minLength, stop - start);
            }
        }

        return minLength == int.MaxValue ? 0 : minLength;
    }
}