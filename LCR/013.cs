// https://leetcode.cn/problems/O4NDxx/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR013;
public class NumMatrix
{
    int[,] prefixSum;
    public NumMatrix(int[][] matrix)
    {
        // 记录前缀和，从而将区域和计算复杂度降低到 O(1)
        prefixSum = new int[matrix.Length + 1, matrix[0].Length + 1];
        for (int i = 1; i <= matrix.Length; i++)
            for (int j = 1; j <= matrix[0].Length; j++)
                prefixSum[i, j]
                    = prefixSum[i - 1, j]
                    + prefixSum[i, j - 1]
                    - prefixSum[i - 1, j - 1]
                    + matrix[i - 1][j - 1];
    }
    /// <summary>
    /// 计算指定区域矩阵的和
    /// </summary>
    /// <param name="row1">最小行</param>
    /// <param name="col1">最小列</param>
    /// <param name="row2">最大行</param>
    /// <param name="col2">最大列</param>
    /// <returns></returns>
    public int SumRegion(int row1, int col1, int row2, int col2)
        => prefixSum[row2 + 1, col2 + 1]
         - prefixSum[row1, col2 + 1]
         - prefixSum[row2 + 1, col1]
         + prefixSum[row1, col1];
}