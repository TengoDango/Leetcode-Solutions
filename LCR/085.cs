// https://leetcode.cn/problems/IDBivT/?envType=study-plan-v2&envId=coding-interviews-special

using System.Text;

namespace Leetcode.LCR085;
public class Solution
{
    /// <summary>
    /// 生成 n 对括号的有效组合
    /// </summary>
    public IList<string> GenerateParenthesis(int n)
    {
        parenthesis.Clear();
        current.Clear();
        DFS(n, 0);
        return parenthesis;
    }
    List<string> parenthesis = [];
    StringBuilder current = new();
    void DFS(int left, int right)
    {
        if (left == 0 && right == 0)
        {
            parenthesis.Add(current.ToString());
            return;
        }
        if (left > 0)
        {
            current.Append('(');
            DFS(left - 1, right + 1);
            current.Remove(current.Length - 1, 1);
        }
        if (right > 0)
        {
            current.Append(')');
            DFS(left, right - 1);
            current.Remove(current.Length - 1, 1);
        }
    }
}