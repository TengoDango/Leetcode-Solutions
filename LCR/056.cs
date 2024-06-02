// https://leetcode.cn/problems/opLdQZ/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR056;
public class Solution
{
    /// <summary>
    /// 判断搜索树中是否存在两个节点，它们的和等于 target
    /// </summary>
    public bool FindTarget(TreeNode root, int target)
    {
        // 转化为两数之和 - 有序数组 (LCR-006)
        List<int> array = [];
        UpdateList(root, array);
        return FindTarget(array, target);
    }
    void UpdateList(TreeNode? node, List<int> array)
    {
        if (node is null) return;
        UpdateList(node.left, array);
        array.Add(node.val);
        UpdateList(node.right, array);
    }
    bool FindTarget(List<int> array, int target)
    {
        int left = 0, right = array.Count - 1;
        while (left < right)
        {
            int sum = array[left] + array[right];
            if (sum == target) return true;
            if (sum < target) left++;
            else right--;
        }
        return false;
    }
}