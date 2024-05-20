// https://leetcode.cn/problems/UHnkqh/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR024_2;
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
        // 递归

        if (head is null || head.next is null) return head;

        ListNode next = head.next;
        ListNode? newHead = ReverseList(next);
        next.next = head;
        head.next = null;

        return newHead;
    }
}