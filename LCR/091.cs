// https://leetcode.cn/problems/JEj789/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR091;
public class Solution
{
    // red[i]: i 号房子刷成红色时, 粉刷 0 到 i 号的最小花费
    // blue[i], green[i] 同理
    // OUTPUT = max(red[^1], blue[^1], green[^1])

    // red[0] = costs[0][0]
    // red[i+1] = min(blue[i], green[i]) + costs[i+1][0]

    public int MinCost(int[][] costs)
    {
        int n = costs.Length;
        int[] red = new int[n];
        int[] blue = new int[n];
        int[] green = new int[n];

        red[0] = costs[0][0];
        blue[0] = costs[0][1];
        green[0] = costs[0][2];

        for (int i = 0; i < n - 1; i++)
        {
            red[i + 1] = int.Min(blue[i], green[i]) + costs[i + 1][0];
            blue[i + 1] = int.Min(red[i], green[i]) + costs[i + 1][1];
            green[i + 1] = int.Min(blue[i], red[i]) + costs[i + 1][2];
        }

        return int.Min(int.Min(red[n - 1], blue[n - 1]), green[n - 1]);
    }
}