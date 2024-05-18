// https://leetcode.cn/problems/kLl5u1/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR006;
public class Solution
{
    /// <summary>
    /// 在有序数组中寻找两个数，使得它们的和等于目标值。
    /// 返回两个数对应的索引
    /// </summary>
    public int[] TwoSum(int[] numbers, int target)
    {
        // 根据数组单调性可以优化为双指针
        int left = 0, right = numbers.Length - 1;
        while (left < right)
        {
            int sum = numbers[left] + numbers[right];
            if (sum == target) return [left, right];
            if (sum < target) left++;
            else right--;
        }
        return [];
    }
}