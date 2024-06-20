// https://leetcode.cn/problems/US1pGT/?envType=study-plan-v2&envId=coding-interviews-special


namespace Leetcode.LCR064;
public class MagicDictionary
{
    Trie trie = new();

    /// <summary>
    /// 添加一些单词
    /// </summary>
    /// <param name="dictionary"></param>
    public void BuildDict(string[] dictionary)
    {
        foreach (var word in dictionary)
            trie.Insert(word);
    }
    /// <summary>
    /// 判断是否与某个单词相差恰好一个字符
    /// </summary>
    public bool Search(string searchWord)
        => trie.Search(searchWord);

    class Trie
    {
        bool isEnd = false;
        Dictionary<char, Trie> children = [];

        /// <summary>
        /// 插入一个字符串, 同 LCR-062
        /// </summary>
        public void Insert(ReadOnlySpan<char> word)
        {
            if (word.Length == 0)
            {
                // 字符串结束
                isEnd = true;
                return;
            }
            var c = word[0];
            // 向对应字母的子树递归插入
            if (!children.ContainsKey(c))
                children.Add(c, new());
            children[c].Insert(word[1..]);
        }
        /// <summary>
        /// 查找单词是否存在, 加入一个修改标记,
        /// 如果一个单词存在, 其修改标记必须为 true
        /// </summary>
        public bool Search(ReadOnlySpan<char> word, bool modified = false)
        {
            if (word.Length == 0)
                return isEnd && modified;
            var ch = word[0];
            if (modified)
            {
                // 已修改过, 则不能再尝试其他字符
                if (children.TryGetValue(ch, out var child))
                    return child.Search(word[1..], modified);
                return false;
            }
            // 可以尝试所有字符
            foreach (var key in children.Keys)
            {
                if (key == ch && children[key].Search(word[1..]))
                    return true;
                if (key != ch && children[key].Search(word[1..], true))
                    return true;
            }
            return false;
        }
    }
}