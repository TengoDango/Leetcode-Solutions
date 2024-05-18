// https://leetcode.cn/problems/ZVAVXX/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR009;
public class Solution
{
    /// <summary>
    /// 乘积小于 k 的连续子数组个数
    /// </summary>
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        // 滑动窗口
        int count = 0;
        int left = 0, product = 1;
        for (int right = 0; right < nums.Length; right++)
        {
            product *= nums[right];
            while (left <= right && product >= k)
            {
                product /= nums[left];
                left++;
            }
            count += right - left + 1;
        }
        return count;
    }
}