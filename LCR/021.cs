// https://leetcode.cn/problems/SLwz0R/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR021;
public class Solution
{
    /// <summary>
    /// 删除倒数第 n 个节点
    /// </summary>
    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        // 目标索引：L - n
        // 双指针实现一趟扫描

        ListNode? tail = head;
        for (int i = 0; i < n; i++)
            tail = tail!.next;

        // 如果 tail 为 null，说明删除的是头节点
        if (tail is null) return head.next;

        // 删除一个节点需要它的前驱节点
        ListNode prev = head;
        while (tail!.next != null)
        {
            tail = tail.next;
            prev = prev.next!;
        }
        prev.next = prev.next!.next;

        return head;
    }
}