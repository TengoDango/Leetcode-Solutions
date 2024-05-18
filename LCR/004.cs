// https://leetcode.cn/problems/WGki4K/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR004;
public class Solution
{
    /// <summary>
    /// 寻找只出现一次的数字
    /// 
    /// 除某个数字只出现一次外，其他数字都出现了三次
    /// </summary>
    public int SingleNumber(int[] nums)
    {
        HashSet<int> answer = [], deprecated = [];
        foreach (var number in nums)
        {
            if (deprecated.Contains(number)) continue;
            if (answer.Contains(number))
            {
                answer.Remove(number);
                deprecated.Add(number);
            }
            else answer.Add(number);
        }
        return answer.Single();
    }
}