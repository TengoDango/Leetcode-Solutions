// https://leetcode.cn/problems/xx4gT2/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR076;
public class Solution
{
    /// <summary>
    /// 第 k 大的元素
    /// </summary>
    public int FindKthLargest(int[] nums, int k)
    {
        return FindKthLargest(nums.AsSpan(), k);
    }
    int FindKthLargest(Span<int> nums, int k)
    {
        // 基于快速排序中的 partition 步骤
        if (nums.Length == 1) return nums[0];
        var p = Partition(nums);
        var i = p + 1; // nums[p] 第 i 大
        if (k == i) return nums[p];
        if (k < i) return FindKthLargest(nums[..p], k);
        else return FindKthLargest(nums[(p + 1)..], k - i);
    }
    /// <summary>
    /// 逆序快速排序的 partition
    /// </summary>
    int Partition(Span<int> nums)
    {
        int x = nums[^1];
        int i = 0;
        for (int j = 0; j < nums.Length - 1; j++)
        {
            if (nums[j] > x)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
            }
        }
        (nums[^1], nums[i]) = (nums[i], nums[^1]);
        return i;
    }
}