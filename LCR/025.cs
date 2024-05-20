// https://leetcode.cn/problems/lMSNwu/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR025;
public class Solution
{
    /// <summary>
    /// 模拟加法运算
    /// </summary>
    /// <param name="l1">Big Endian 链表</param>
    /// <param name="l2">Big Endian 链表</param>
    /// <returns>Big Endian 链表</returns>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // 转化为 little endian
        Stack<int> num1 = [], num2 = [];
        while (l1 is not null)
        {
            num1.Push(l1.val);
            l1 = l1.next!;
        }
        while (l2 is not null)
        {
            num2.Push(l2.val);
            l2 = l2.next!;
        }

        // 模拟加法运算
        ListNode head = null!;
        int carry = 0;
        while (num1.Count > 0 || num2.Count > 0 || carry > 0)
        {
            int sum = carry;
            if (num1.TryPop(out int digit1))
                sum += digit1;
            if (num2.TryPop(out int digit2))
                sum += digit2;
            carry = sum / 10;
            head = new(sum % 10, head);
        }

        return head;
    }
}