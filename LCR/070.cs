// https://leetcode.cn/problems/skFtm2/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR070;
public class Solution
{
    /// <summary>
    /// 找出只出现一次的元素, 其他元素连续出现两次
    /// </summary>
    public int SingleNonDuplicate(int[] nums)
    {
        // 二分查找, 考察偶数索引
        int left = 0, right = nums.Length / 2;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (nums[2 * mid] == nums[2 * mid + 1])
                left = mid + 1;
            else if (mid != 0 && nums[2 * mid] == nums[2 * mid - 1])
                right = mid;
            else
                return nums[2 * mid];
        }
        return nums[^1];
    }
}