// https://leetcode.cn/problems/UHnkqh/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR024_1;
public class Solution
{
    /// <summary>
    /// 反转链表
    /// </summary>
    /// <returns>
    /// 反转后的头节点
    /// </returns>
    public ListNode? ReverseList(ListNode? head)
    {
        // 迭代

        ListNode? prev = null;
        ListNode? current = head;
        while (current is not null)
        {
            ListNode? next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        return prev;
    }
}