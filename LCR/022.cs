// https://leetcode.cn/problems/c32eOV/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR022;
public class Solution
{
    /// <summary>
    /// 检测链表是否有环，如果有环，返回环的起始节点
    /// </summary>
    public ListNode? DetectCycle(ListNode? head)
    {
        // 设环长度为 C，则两个索引 i,j 在环上同一点等价于
        // i = j (mod C), 且 i,j >= L-C
        // L-C 即为环的起始索引

        ListNode? slow = head, fast = head;

        try
        {
            do
            {
                slow = slow!.next;
                fast = fast!.next!.next;
            } while (slow != fast);
        }
        catch
        {
            // 如果有环，则 slow, fast 必会在环上相遇
            return null;
        }

        // 设 slow 索引为 x，则有
        // x = 2*x (mod C), 于是 x = C
        // s+x 与 x 相交等价于 s >= L-C

        fast = head;
        while (fast != slow)
        {
            fast = fast!.next;
            slow = slow!.next;
        }
        return slow;
    }
}