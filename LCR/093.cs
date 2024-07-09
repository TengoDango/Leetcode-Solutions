// https://leetcode.cn/problems/Q91FMA/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR093;
public class Solution
{
    // dp[i,j]: 以 arr[i] 和 arr[j] 结尾的子序列长度
    // OUTPUT = dp.Max()

    // dp[j,k] = dp[i,j] + 1, 若 arr[i] + arr[j] == arr[k], i < j < k

    /// <summary>
    /// 最长斐波那契子序列长度
    /// </summary>
    public int LenLongestFibSubseq(int[] arr)
    {
        int n = arr.Length;
        var dp = new int[n, n];
        int maxdp = 0;

        // 用双指针优化
        for (int k = 0; k < n; k++)
        {
            int i = 0, j = k - 1;
            while (i < j)
            {
                int sum = arr[i] + arr[j];
                if (sum < arr[k]) i++;
                else if (sum > arr[k]) j--;
                else
                {
                    dp[j, k] = int.Max(3, dp[i, j] + 1);
                    maxdp = int.Max(maxdp, dp[j,k]);
                    i++; j--;
                }
            }
        }
        return maxdp;
    }
}