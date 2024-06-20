// https://leetcode.cn/problems/qn8gGX/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR061;
public class Solution
{
    /// <summary>
    /// 获取前 k 个和最小的数对
    /// </summary>
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        // 堆排序
        PriorityQueue<IList<int>, int> minHeap = new();
        // 考虑数组有序性, 只取 i + j < k 的数对即可
        for (int i = 0; i < k; i++)
        {
            if (i >= nums1.Length) break;
            for (int j = 0; j < k - i; j++)
            {
                if (j >= nums2.Length) break;
                minHeap.Enqueue([nums1[i], nums2[j]], nums1[i] + nums2[j]);
            }
        }

        List<IList<int>> pairs = [];
        for (int i = 0; i < k; i++)
        {
            if (minHeap.Count == 0) break;
            pairs.Add(minHeap.Dequeue());
        }
        return pairs;
    }
}