// https://leetcode.cn/problems/D0F0SV/description/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR104;
public class Solution
{
    // f(x): 和为 x 的组合个数
    // OUTPUT = f(target)

    // f(0) := 1, f(-) := 0
    // f(x) := SUM{ f(x-ai) }

    /// <summary>
    /// 统计元素组合为目标值的组合个数
    /// 元素可出现任意次, 不同排列顺序视为不同组合
    /// </summary>
    /// <param name="nums">无重复正元素</param>
    public int CombinationSum4(int[] nums, int target)
    {
        var f = new int[target + 1];
        f[0] = 1;
        for (int x = 1; x <= target; x++)
        {
            foreach (var a in nums)
                if (x >= a) f[x] += f[x - a];
        }
        return f[target];
    }
}