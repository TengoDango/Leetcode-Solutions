// https://leetcode.cn/problems/nZZqjQ/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR073;
public class Solution
{
    public int MinEatingSpeed(int[] piles, int hour)
    {
        // 二分查找
        // 最少每小时吃一个, 最多每小时吃一堆
        int min = 1, max = piles.Max();
        while (min <= max)
        {
            int speed = (min + max) / 2;
            int time = EatingTime(piles, speed);
            if (time <= hour)
                max = speed - 1;
            else
                min = speed + 1;
        }
        return min;
    }
    int EatingTime(int[] piles, int speed)
    {
        int sum = 0;
        foreach (int pile in piles)
        {
            // ceil(pile / speed)
            sum += (pile - 1) / speed + 1;
        }
        return sum;
    }
}