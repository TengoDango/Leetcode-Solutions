// https://leetcode.cn/problems/XagZNi/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR037;
public class Solution
{
    /// <summary>
    /// 寻找碰撞后的剩余行星
    /// 碰撞规则略
    /// </summary>
    public int[] AsteroidCollision(int[] asteroids)
    {
        // 将原数组作为栈
        int top = -1;
        int i = 0;
        while (i < asteroids.Length)
        {
            if (top == -1 || !(asteroids[i] < 0 && asteroids[top] > 0))
            {
                // 直接入栈即可
                top++;
                asteroids[top] = asteroids[i];
                i++;
                continue;
            }
            int collision = asteroids[i] + asteroids[top];
            if (collision < 0)
            {
                // 左小右大，出栈，右继续尝试碰撞
                top--;
            }
            else if (collision > 0)
            {
                // 左大右小
                i++;
            }
            else
            {
                // 相等，出栈
                top--;
                i++;
            }
        }
        return asteroids[..(top + 1)];
    }
}