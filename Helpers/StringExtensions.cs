namespace LeetCodeProblems.Helpers;

public static class StringExtensions
{
    public static bool IsPredecessorOf(this string str1, string str2)
    {
        // our indexer into word1
        var j = 0;
        for (var i = 0; i < str2.Length; i++)
        {
            // if we're looking at the last char in str2, we're good
            if (j == str2.Length - 1)
            {
                return true;
            }

            // We encountered a mismatch in characters
            if (str2[i] != str1[j])
            {
                // if our word1 indexer is ever more than 1 different than our word2 indexer, 
                if (i - j == 1)
                {
                    return false;
                }

                continue;
            }
            j++;
        }

        return true;
    }

    public static int FindLongestChain(
        this string str,
        Dictionary<int, List<string>> dict,
        Dictionary<string, int> dpdict)
    {
        // Find the possible words that could be next in the chain (by length)
        var possibleWords = str.FindPossibleNextWords(dict);

        if (possibleWords.Count == 0)
        {
            dpdict[str] = 1;
            return 1;
        }

        if (dpdict.TryGetValue(str, out var value))
        {
            return value;
        }

        var longestChain = 1;
        var longestChainWord = string.Empty;

        foreach (var word in possibleWords)
        {
            if (str.IsPredecessorOf(word))
            {
                var wordLongestChain = 1 + word.FindLongestChain(dict, dpdict);

                if (wordLongestChain > longestChain)
                {
                    dpdict[str] = wordLongestChain;
                    longestChain = wordLongestChain;
                    longestChainWord = word;
                }
            }
        }

        return longestChain;
    }

    /*
     * Will find a list of viable next words given a starting word.
     */
    public static List<string> FindPossibleNextWords(this string word, Dictionary<int, List<string>> dict)
    {
        var nextWordLength = word.Length + 1;

        if (!dict.ContainsKey(nextWordLength))
        {
            return new List<string>();
        }

        return dict[nextWordLength];
    }
}
