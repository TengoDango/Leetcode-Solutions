// https://leetcode.cn/problems/7WHec2/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR077;
public class Solution
{
    /// <summary>
    /// 链表排序
    /// </summary>
    public ListNode? SortList(ListNode? list)
    {
        // 使用归并排序达到时间复杂度 O(nlogn) 空间复杂度 O(1)
        if (list is null) return null;
        if (list.next is null) return list;
        // 至少有两个节点
        var list2 = SplitList(list);
        list = SortList(list)!;
        list2 = SortList(list2)!;
        return MergeList(list, list2);
    }
    /// <summary>
    /// 将链表由中点截为两个链表
    /// </summary>
    ListNode SplitList(ListNode list)
    {
        // 快慢指针获取中点
        ListNode? slow = list, fast = list;
        while (true)
        {
            fast = fast!.next;
            if (fast is null) break;
            fast = fast.next;
            if (fast is null) break;
            slow = slow!.next;
        }
        // 截断为两个链表
        var list2 = slow!.next;
        slow.next = null;
        return list2!;
    }
    /// <summary>
    /// 合并两个链表
    /// </summary>
    ListNode MergeList(ListNode? list1, ListNode? list2)
    {
        ListNode dummy = new(); // dummy.next == head
        ListNode tail = dummy;
        while (list1 is not null || list2 is not null)
        {
            if (list2 is null || list1 is not null && list1.val < list2.val)
            {
                tail.next = list1;
                tail = tail.next!;
                list1 = list1!.next;
            }
            else
            {
                tail.next = list2;
                tail = tail.next!;
                list2 = list2!.next;
            }
        }
        return dummy.next!;
    }
}