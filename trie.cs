public class Trie
{
    private Dictionary<char, node> root;
    /** Initialize your data structure here. */
    public Trie()
    {
        root = new Dictionary<char, node>();
    }

    /** Inserts a word into the trie. */
    public void Insert(string word)
    {

        if (!root.ContainsKey(word.ElementAt(0)))
            root.Add(word.ElementAt(0), new node(word.ElementAt(0)));
        node cur = root[word.ElementAt(0)];
        for (int i = 1; i < word.Length; i++)
        {
            char ch = word.ElementAt(i);
            if (!cur.children.ContainsKey(ch))
                cur.children.Add(ch, new node(ch));

            cur = cur.children[ch];
        }
        cur.isWord = true;
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        if (!root.ContainsKey(word.ElementAt(0)))
            return false;
        node cur = root[word.ElementAt(0)];
        for (int i = 1; i < word.Length; i++)
        {
            char ch = word.ElementAt(i);
            if (!cur.children.ContainsKey(ch))
                return false;
            cur = cur.children[ch];
        }
        return cur.isWord;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string word)
    {
        if (!root.ContainsKey(word.ElementAt(0)))
            return false;
        node cur = root[word.ElementAt(0)];
        for (int i = 1; i < word.Length; i++)
        {
            char ch = word.ElementAt(i);
            if (!cur.children.ContainsKey(ch))
                return false;
            cur = cur.children[ch];
        }
        return true;
    }

    class node
    {
        internal char ch;
        internal bool isWord;
        internal Dictionary<char, node> children;
        internal node(char c)
        {
            ch = c;
            isWord = false;
            children = new Dictionary<char, node>();
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */