// https://leetcode.cn/problems/ms70jA/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR067;
public class Solution
{
    /// <summary>
    /// 寻找数组中两个数, 使得异或值最大
    /// </summary>
    /// <returns>
    /// 最大异或值
    /// </returns>
    public int FindMaximumXOR(int[] nums)
    {
        // 以比特串形式建立字典树, 利用字典树进行搜索
        Trie trie = new();
        foreach (var num in nums)
            trie.Insert(num);
        return trie.MaxXor();
    }
    const int MaxMask = 1 << 30;
    class Trie
    {
        Trie? zero, one;

        /// <summary>
        /// 插入比特串
        /// </summary>
        public void Insert(int value)
        {
            Trie node = this;
            for (int mask = MaxMask; mask != 0; mask >>=1)
            {
                bool zeroBit = (value & mask) == 0;
                if (zeroBit)
                {
                    node.zero ??= new();
                    node = node.zero;
                }
                else
                {
                    node.one ??= new();
                    node = node.one;
                }
            }
        }
        /// <summary>
        /// 最大异或值
        /// </summary>
        public int MaxXor()
        {
            Trie node = this;
            for (int mask = MaxMask; mask != 0; mask >>= 1)
            {
                if (node.zero is not null && node.one is not null)
                    return MaxXor(node.zero, node.one, mask);
                node = (node.zero ?? node.one)!;
            }
            return 0;
        }
        /// <param name="zeroMask">结果是否 +mask</param>
        static int MaxXor(Trie p, Trie q, int mask, bool zeroMask = false)
        {
            if (mask == 0) return 0;

            int max = 0;
            // 判断当前位是否可以为 1
            if (p.zero is not null && q.one is not null)
                max = MaxXor(p.zero, q.one, mask >> 1);
            if (p.one is not null && q.zero is not null)
                max = Math.Max(max, MaxXor(p.one, q.zero, mask >> 1));
            // 如果当前位可以为 1, 就不需要继续计算
            if (max != 0) return zeroMask ? max : max + mask;

            max = MaxXor((p.zero ?? p.one)!, (q.zero ?? q.one)!, mask >> 1, true);
            return zeroMask ? max : max + mask;
        }
    }
}