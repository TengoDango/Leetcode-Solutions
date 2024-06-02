// https://leetcode.cn/problems/jBjn9C/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR059;
/// <summary>
/// 维护第 k 大元素
/// </summary>
public class KthLargest
{
    int capacity;
    PriorityQueue<int, int> minHeap;

    /// <summary>
    /// 初始化
    /// </summary>
    public KthLargest(int k, int[] nums)
    {
        capacity = k;
        minHeap = new();
        foreach (var num in nums)
            Add(num);
    }
    /// <summary>
    /// 添加元素
    /// </summary>
    public int Add(int val)
    {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > capacity)
            minHeap.Dequeue();
        return minHeap.Peek();
    }
}