// https://leetcode.cn/problems/iIQa4I/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR038;
public class Solution
{
    /// <summary>
    /// 生成一个列表，表示要想观测到更高的气温，至少需要等待的天数
    /// 如果气温在这之后都不会升高，该位置为 0
    /// </summary>
    public int[] DailyTemperatures(int[] temperatures)
    {
        // 单调栈
        Stack<(int Index, int Value)> stack = [];
        int[] answer = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            int value = temperatures[i];
            while (stack.Count > 0 && stack.Peek().Value < value)
            {
                var item = stack.Pop();
                answer[item.Index] = i - item.Index;
            }
            stack.Push((i, value));
        }

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            answer[item.Index] = 0;
        }

        return answer;
    }
}