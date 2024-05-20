// https://leetcode.cn/problems/LGjMqU/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR026_EX;
public class Solution
{
    /// <summary>
    /// 重排链表
    /// </summary>
    public void ReorderList(ListNode head)
    {
        // 优化至 O(1) 空间复杂度
        if (head is null || head.next is null) return;

        // 1. 找到链表中点
        var middle = MiddleNode(head);

        // 2. 反转链表中点后的部分
        var head2 = middle.next!;
        middle.next = null;
        head2 = ReverseList(head2);

        // 3. 合并两个链表
        MergeList(head, head2);
    }
    /// <summary>
    /// 找到链表的中间节点
    /// 
    /// 具体说是索引为 (L-1)/2 的节点
    /// </summary>
    ListNode MiddleNode(ListNode head)
    {
        ListNode slow = head, fast = head;
        while (true)
        {
            fast = fast.next!;
            if (fast is null) break;
            fast = fast.next!;
            if (fast is null) break;
            slow = slow.next!;
        }
        return slow;
    }
    /// <summary>
    /// 反转链表
    /// </summary>
    ListNode ReverseList(ListNode head)
    {
        ListNode prev = null!;
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
    /// <summary>
    /// 合并两个链表
    /// </summary>
    void MergeList(ListNode head1, ListNode head2)
    {
        ListNode? node1 = head1, node2 = head2;
        while (node1 is not null && node2 is not null)
        {
            ListNode? next1 = node1.next, next2 = node2.next;
            node1.next = node2;
            node2.next = next1;
            node1 = next1;
            node2 = next2;
        }
    }
}