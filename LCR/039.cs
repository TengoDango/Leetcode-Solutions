// https://leetcode.cn/problems/0ynMMM/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR039;
public class Solution
{
    /// <summary>
    /// 寻找柱状图中最大矩形
    /// </summary>
    /// <returns>
    /// 最大矩形的面积
    /// </returns>
    public int LargestRectangleArea(int[] heights)
    {
        // 可以找到最高处为索引 i 的矩形的最大宽度

        // 最高处为索引 i 的矩形的最左边界索引
        int[] left = new int[heights.Length];
        // 最高处为索引 i 的矩形的最右边界索引
        int[] right = new int[heights.Length];

        // 由单调栈可以找到最高处为索引 i 的矩形的左右边界
        Stack<int> stack = [];
        for (int i = 0; i < heights.Length; i++)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                stack.Pop();
            left[i] = stack.TryPeek(out int leftIndex) ? leftIndex + 1 : 0;
            stack.Push(i);
        }
        stack.Clear();
        for (int i = heights.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                stack.Pop();
            right[i] = stack.TryPeek(out int rightIndex) ? rightIndex - 1 : heights.Length - 1;
            stack.Push(i);
        }

        // 由左右边界，直接遍历取最大面积即可
        var queryArea = from i in Enumerable.Range(0, heights.Length)
                        select heights[i] * (right[i] - left[i] + 1);
        return queryArea.Max();
    }
}