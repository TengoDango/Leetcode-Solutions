// https://leetcode.cn/problems/FortPu/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR030;
/// <summary>
/// O(1) 时间插入、删除和获取随机元素的数据结构
/// </summary>
public class RandomizedSet
{
    Dictionary<int, int> dict = [];
    List<int> list = [];

    public RandomizedSet() { }

    /// <summary>
    /// 插入元素，元素已存在则返回 false
    /// </summary>
    public bool Insert(int value)
    {
        if (dict.ContainsKey(value)) return false;
        dict.Add(value, list.Count);
        list.Add(value);
        return true;
    }

    /// <summary>
    /// 删除元素，元素不存在则返回 false
    /// </summary>
    public bool Remove(int value)
    {
        if (!dict.ContainsKey(value)) return false;
        int index = dict[value];
        dict.Remove(value);
        if (index != list.Count - 1)
        {
            int last = list.Last();
            list[index] = last;
            dict[last] = index;
        }
        list.RemoveAt(list.Count - 1);
        return true;
    }

    /// <summary>
    /// 随机返回一个元素
    /// </summary>
    public int GetRandom()
        => list[Random.Shared.Next(list.Count)];
}