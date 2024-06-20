// https://leetcode.cn/problems/N6YdxV/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR068;
public class Solution
{
    /// <summary>
    /// 二分查找插入位置
    /// </summary>
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target)
                left = mid + 1;
            else right = mid;
        }
        // 没有搜索到, 此时必有 left == right
        return left;
    }
}