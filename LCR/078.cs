// https://leetcode.cn/problems/vvXgSW/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR078;
public class Solution
{
    /// <summary>
    /// 合并若干升序链表
    /// </summary>
    public ListNode? MergeKLists(ListNode[] lists)
    {
        ListNode dummy = new();
        ListNode tail = dummy;

        // 使用堆来提取链表头中的最小值
        PriorityQueue<ListNode, int> heap = new();
        foreach (var list in lists)
            if (list is not null)
                heap.Enqueue(list, list.val);

        ListNode p;
        while (heap.Count > 0)
        {
            p = heap.Dequeue();
            if (p.next is not null)
                heap.Enqueue(p.next, p.next.val);

            tail.next = p;
            tail = p;
        }

        return dummy.next;
    }
}