// https://leetcode.cn/problems/aseY1I/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR005_1;
public class Solution
{
    /// <summary>
    /// 计算两个不相交单词的长度乘积最大值
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public int MaxProduct(string[] words)
    {
        // 记录每个单词标识对应的最长单词长度
        Dictionary<int, int> lengths = [];
        foreach (var word in words)
        {
            int tag = GetTag(word);
            if (lengths.TryGetValue(tag, out int length))
                lengths[tag] = Math.Max(length, word.Length);
            else
                lengths[tag] = word.Length;
        }

        var query = from item1 in lengths
                    from item2 in lengths
                    where (item1.Key & item2.Key) == 0
                    select item1.Value * item2.Value;
        return query.DefaultIfEmpty().Max();
    }
    /// <summary>
    /// 单词标识：第 i 个比特位表示是否包含字母 'a'+i
    /// 若两个标识的按位与结果为 0，则两个单词不包含相同的字母
    /// </summary>
    int GetTag(string word)
    {
        int tag = 0;
        foreach (var c in word)
            tag |= 1 << (c - 'a');
        return tag;
    }
}