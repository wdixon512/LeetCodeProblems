using LeetCodeProblems.Helpers;

namespace LeetCodeProblems.Problems.LongestWordChain;

public class LongestWordChain
{
    /* Thoughts:
     * - Maybe sorting the array by word length will help with finding the next word faster?
     * - Build a dictionary of words and their length for fast lookup during algorithm
     * - Heuristics with known longest word chain already while iterating through starting words
     * - Heuristics with longest possible chain given list of words?
     */
    public int LongestStrChain(string[] words)
    {
        var dict = BuildStringDict(words);

        var sortedWords = words.OrderBy(w => w.Length);

        var longestFoundChain = 0;
        var longestChainForWord = 0;
        var dpdict = new Dictionary<string, int>();

        foreach (var word in sortedWords)
        {
            longestChainForWord = word.FindLongestChain(dict, dpdict);

            if (longestChainForWord > longestFoundChain)
            {
                longestFoundChain = longestChainForWord;

                if (IsLongestPossibleWordChain(longestChainForWord, dict))
                {
                    break;
                }
            }
        }

        return longestFoundChain;
    }



    /*
     * Builds an arry of <int, string[]> from a list of words, where the key is the string length and the value is all of the words of that length.
     */
    private Dictionary<int, List<string>> BuildStringDict(string[] words)
    {
        var dict = new Dictionary<int, List<string>>();
        foreach (var word in words)
        {
            if (!dict.ContainsKey(word.Length))
            {
                dict[word.Length] = new List<string>();
            }

            dict[word.Length].Add(word);
        }

        return dict;
    }

    private bool IsLongestPossibleWordChain(int chainLength, Dictionary<int, List<string>> dict)
        => dict.Keys.Count == chainLength;
}
