// https://leetcode.cn/problems/aMhZSa/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR027;
public class Solution
{
    /// <summary>
    /// 判断回文链表
    /// </summary>
    public bool IsPalindrome(ListNode head)
    {
        List<int> values = [];
        while (head != null)
        {
            values.Add(head.val);
            head = head.next!;
        }
        int i = 0, j = values.Count - 1;
        while (i < j)
        {
            if (values[i] != values[j])
                return false;
            i++; j--;
        }
        return true;
    }
}