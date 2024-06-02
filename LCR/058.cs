// https://leetcode.cn/problems/fi9suh/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR058;
/// <summary>
/// 不重叠区间的插入
/// </summary>
public class MyCalendar
{
    /// <summary>
    /// 若插入的区间与已有的区间不重叠，则直接插入;
    /// 否则，返回 false
    /// </summary>
    public bool Book(int start, int end)
    {
        // 业务逻辑，O(n^2) 时间
        foreach ((int left, int right) in calendar)
        {
            // 判断区间重叠
            if (left < end && start < right)
                return false;
        }
        // 区间不重叠，插入
        calendar.Add((start, end));
        return true;
    }
    List<(int, int)> calendar = [];
}