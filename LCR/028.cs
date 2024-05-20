// https://leetcode.cn/problems/Qv1Da2/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR028;
public class Solution
{
    /// <summary>
    /// 展开一个多级双链表
    /// </summary>
    public Node? Flatten(Node? head)
    {
        if (head is null) return null;

        Stack<Node> stack = [];
        var node = head;

        while (true)
        {
            if (node.child is not null)
            {
                if (node.next is not null)
                    stack.Push(node.next);
                node.next = node.child;
                node.next.prev = node;
                node.child = null;
            }
            if (node.next is null)
            {
                if (stack.Count == 0) break;
                node.next = stack.Pop();
                node.next.prev = node;
            }
            node = node.next;
        }

        return head;
    }
}
public class Node
{
    public int val;
    public Node? prev;
    public Node? next;
    public Node? child;
}
