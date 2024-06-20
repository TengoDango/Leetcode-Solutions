// https://leetcode.cn/problems/cuyjEf/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR071;
public class Solution
{
    double[] p;
    public Solution(int[] w)
    {
        // p[i] 为 0 <= j < i 的累积概率和
        p = new double[w.Length + 1];
        for (int i = 0; i < w.Length; i++)
            p[i + 1] = p[i] + w[i];
        for (int i = 0; i < w.Length; i++)
            p[i] /= p[^1];
    }
    /// <summary>
    /// 按权重数组随机选取索引
    /// </summary>
    public int PickIndex()
    {
        // x in [0,1)
        double x = Random.Shared.NextDouble();
        // 二分查找 x
        int left = 0, right = p.Length;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (p[mid] < x)
                left = mid + 1;
            else
                right = mid;
        }
        // 结束时 left == right, 且 p[left] > x
        return left - 1;
    }
}