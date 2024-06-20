// https://leetcode.cn/problems/0H97ZC/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR075;
public class Solution
{
    /// <summary>
    /// 按如下规则对 arr1 排序:
    /// 在 arr2 中出现的元素, 按照 arr2 中的相对顺序排序;
    /// 未在 arr2 中出现的元素, 顺序排在最后面
    /// </summary>
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        RelativeCompare comparer = new(arr2);
        Array.Sort(arr1, comparer);
        return arr1;
    }
    class RelativeCompare : IComparer<int>
    {
        Dictionary<int, int> order;
        public RelativeCompare(int[] array)
        {
            order = [];
            for (int i = 0; i < array.Length; i++)
                order.Add(array[i], i);
        }
        public int Compare(int x, int y)
        {
            bool containsX = order.ContainsKey(x);
            bool containsY = order.ContainsKey(y);
            return (containsX, containsY) switch
            {
                (true, true) => order[x] - order[y],
                (true, false) => -1,
                (false, true) => 1,
                (false, false) => x - y,
            };
        }
    }
}