// https://leetcode.cn/problems/LGjMqU/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR026;
public class Solution
{
    /// <summary>
    /// 重排链表
    /// </summary>
    public void ReorderList(ListNode head)
    {
        // 业务逻辑

        List<ListNode> list = [];
        while (head is not null)
        {
            list.Add(head);
            head = head.next!;
        }
        for (int i = 0, j = list.Count - 1; i < j; i++, j--)
        {
            list[i].next = list[j];
            list[j].next = list[i + 1];
        }
        list[list.Count / 2].next = null;
    }
}