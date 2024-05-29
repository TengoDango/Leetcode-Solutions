// https://leetcode.cn/problems/H8086Q/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR042;
/// <summary>
/// 最近请求计数器
/// </summary>
public class RecentCounter
{
    Queue<int> queue = [];

    /// <summary>
    /// 在时间 t 添加一个新请求
    /// 并返回 [t-3000, t] 内发生的请求数
    /// </summary>
    public int Ping(int t)
    {
        queue.Enqueue(t);
        while (queue.Peek() < t - 3000) queue.Dequeue();
        return queue.Count;
    }
}