// https://leetcode.cn/problems/4ueAj6/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR029;
public class Solution
{
    /// <summary>
    /// 在循环有序链表中插入一个节点，保持链表有序性
    /// </summary>
    public Node Insert(Node? head, int value)
    {
        if (head is null)
        {
            head = new(value);
            head.next = head;
            return head;
        }

        Node node = head;
        do
        {
            if (node.val <= value && value <= node.next!.val)
                break;
            if (node.val > node.next!.val &&
                (node.val <= value || value <= node.next.val))
                break;
            node = node.next!;
        } while (node != head);

        node.next = new(value, node.next!);
        return head;
    }
}
public class Node
{
    public int val;
    public Node? next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
        next = null;
    }

    public Node(int _val, Node _next)
    {
        val = _val;
        next = _next;
    }
}
