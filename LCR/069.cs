// https://leetcode.cn/problems/B1IidL/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR069;
public class Solution
{
    /// <summary>
    /// 寻找山脉数组的峰顶索引
    /// </summary>
    public int PeakIndexInMountainArray(int[] arr)
    {
        // 对二分情况分类讨论即可
        return FindPeek(arr, 0, arr.Length - 1);
    }
    int FindPeek(int[] array, int left, int right)
    {
        // 递归结束条件
        if (left == right) return left;
        if (left == right - 1)
            return array[left] < array[right] ? right : left;
        // 二分查找可能的峰值索引, 考虑不同情况
        int mid = (left + right) / 2;
        if (array[mid] < array[right])
            return FindPeek(array, mid + 1, right);
        if (array[left] > array[mid])
            return FindPeek(array, left, mid - 1);
        int peek = mid;
        int lpeek = FindPeek(array, left, mid - 1);
        int rpeek = FindPeek(array, mid + 1, right);
        if (array[peek] < array[lpeek])
            peek = lpeek;
        if (array[peek] > array[rpeek])
            peek = rpeek;
        return peek;
    }
}