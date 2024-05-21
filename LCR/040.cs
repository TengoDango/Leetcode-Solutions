// https://leetcode.cn/problems/PLYXKQ/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR040;
public class Solution
{
    /// <summary>
    /// 给定元素为 0 或 1 的二维平面，
    /// 寻找只包含 1 的最大矩形的面积
    /// </summary>
    public int MaximalRectangle(string[] matrix)
    {
        /*
          0 0 1 1 1      0 0 1 1 1      3 (1, 1, 1)
          0 1 1 1 1  =>  0 1 2 2 2  =>  6 (2, 2, 2)  =>  6
          1 1 1 0 0      1 2 3 0 0      4 (2, 3)
        */

        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;

        int[][] heightMatrix = new int[matrix.Length][];
        heightMatrix[0] = matrix[0].Select(c => c - '0').ToArray();
        for (int i = 1; i < matrix.Length; i++)
        {
            heightMatrix[i] = new int[matrix[i].Length];
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == '0')
                    heightMatrix[i][j] = 0;
                else
                    heightMatrix[i][j] = heightMatrix[i - 1][j] + 1;
            }
        }
        return (
            from heights in heightMatrix
            select LargestRectangleArea(heights)
            ).Max();
    }
    /// <summary>
    /// 寻找柱状图中最大矩形
    /// </summary>
    /// <returns>
    /// 最大矩形的面积
    /// </returns>
    int LargestRectangleArea(int[] heights)
    {
        // 同 LCR-039

        int[] left = new int[heights.Length];
        int[] right = new int[heights.Length];

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

        var queryArea = from i in Enumerable.Range(0, heights.Length)
                        select heights[i] * (right[i] - left[i] + 1);
        return queryArea.Max();
    }
}