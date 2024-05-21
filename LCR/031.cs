// https://leetcode.cn/problems/OrIXps/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR031;
public class LRUCache(int capacity)
{
    Dictionary<int, LinkedListNode<(int Key, int Value)>> cache = [];
    LinkedList<(int Key, int Value)> order = [];
    int capacity = capacity;

    /// <summary>
    /// 若缓存中存在 key，返回其 value，否则返回 -1
    /// </summary>
    public int Get(int key)
    {
        if (!cache.TryGetValue(key, out var node))
            return -1;
        // 更新 key 的时序
        order.Remove(node);
        order.AddLast(node);
        return node.Value.Value;
    }

    /// <summary>
    /// 若缓存中存在 key，则更新其 value
    /// 若缓存中不存在 key，则将 key 插入到缓存中，并设置其 value
    /// </summary>
    public void Put(int key, int value)
    {
        if (cache.TryGetValue(key, out var node))
        {
            cache.Remove(node.Value.Key);
            order.Remove(node);
        }
        if (cache.Count == capacity)
        {
            cache.Remove(order.First().Key);
            order.RemoveFirst();
        }
        order.AddLast((key, value));
        cache[key] = order.Last!;
    }
}