// https://leetcode.cn/problems/8Zf90G/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR036;
public class Solution
{
    /// <summary>
    /// 逆波兰表达式求值
    /// </summary>
    public int EvalRPN(string[] tokens)
    {
        // 用栈操作运算：遇到数字则入栈
        // 遇到算符则取出栈顶两个数字进行计算，并将结果压入栈中

        Stack<int> stack = [];
        foreach (var token in tokens)
        {
            int a, b;
            switch ((token))
            {
                case "+":
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a + b);
                    break;
                case "-":
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a - b);
                    break;
                case "*":
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a * b);
                    break;
                case "/":
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a / b);
                    break;
                default:
                    stack.Push(int.Parse(token));
                    break;
            }
        }
        return stack.Pop();
    }
}