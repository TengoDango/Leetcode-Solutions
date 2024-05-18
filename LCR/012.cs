// https://leetcode.cn/problems/tvdfij/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR012;
public class Solution
{
    /// <summary>
    /// 寻找最小索引，使得左侧所有元素相加的和等于右侧所有元素相加的和
    /// 
    /// (不存在则返回 -1)
    /// </summary>
    public int PivotIndex(int[] nums)
    {
        int sum = nums.Sum();

        int prefix = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // sum == prefix + nums[i] + postfix
            if (sum == prefix * 2 + nums[i])
                return i;
            prefix += nums[i];
        }

        return -1;
    }
}