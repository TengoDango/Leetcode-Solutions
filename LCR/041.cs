// https://leetcode.cn/problems/qIsx9U/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR041;
/// <summary>
/// 有限容量队列
/// </summary>
public class MovingAverage(int capacity)
{
    int[] queue = new int[capacity];
    int tail = -1, size = 0;
    long sum = 0;

    /// <summary>
    /// 加入一个元素，并计算平均值
    /// </summary>
    public double Next(int value)
    {
        tail = (tail + 1) % capacity;
        if (size == capacity)
        {
            sum = sum - queue[tail] + value;
            queue[tail] = value;
        }
        else
        {
            size++;
            sum += value;
            queue[tail] = value;
        }
        return (double)sum / size;
    }
}