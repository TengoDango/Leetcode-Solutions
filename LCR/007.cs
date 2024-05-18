// https://leetcode.cn/problems/1fGaJU/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR007;
public class Solution
{
    /// <summary>
    /// 寻找所有不重复的三数组合使得和为 0
    /// </summary>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        List<IList<int>> answer = [];
        for (int i = 0; i < nums.Length; i++)
        {
            // 排除重复情况
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            // 寻找所有两数组合使得和为目标值
            // 由 LCR-006 改写
            int left = i+1, right = nums.Length - 1;
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    answer.Add([nums[i], nums[left], nums[right]]);
                    while (left < right && nums[left] == nums[left + 1])
                        left++;
                    while (left < right && nums[right] == nums[right - 1])
                        right--;
                    // 注意边界处理
                    left++; right--;
                }
                else if (sum < 0) left++;
                else right--;
            }
        }

        return answer;
    }
}