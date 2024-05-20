// https://leetcode.cn/problems/3u1WK4/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR023;
public class Solution
{
    /// <summary>
    /// 寻找两个链表的交点，无交点则返回 null
    /// </summary>
    public ListNode? GetIntersectionNode(ListNode? headA, ListNode? headB)
    {
        // tricky

        ListNode? nodeA = headA, nodeB = headB;
        while (nodeA != nodeB)
        {
            nodeA = nodeA is null ? headB : nodeA.next;
            nodeB = nodeB is null ? headA : nodeB.next;
        }
        return nodeA;
    }
}