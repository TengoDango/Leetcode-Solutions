// https://leetcode.cn/problems/aseY1I/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR005_2;
public class Solution
{
    /// <summary>
    /// 计算两个不相交单词的长度乘积最大值
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public int MaxProduct(string[] words)
    {
        // 使用数组存储以尝试削减时间至 0.5*(n^2)
        int[] tags = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
            tags[i] = GetTag(words[i]);

        //return (
        //    from i in Enumerable.Range(0, words.Length)
        //    from j in Enumerable.Range(0, i)
        //    where (tags[i] & tags[j]) == 0
        //    select words[i].Length * words[j].Length
        //    ).DefaultIfEmpty().Max();

        int maxProduct = 0;
        for (int i = 0; i < words.Length; i++)
            for (int j = 0; j < i; j++)
                if ((tags[i] & tags[j]) == 0)
                    maxProduct = Math.Max(
                        maxProduct, words[i].Length * words[j].Length);
        return maxProduct;
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