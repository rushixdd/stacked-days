namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class WordFrequencyCounter
{
    [TestMethod]
    public void CountWordFrequencies_WithSimpleSentence_ReturnsCorrectCounts()
    {
        //Arrange
        string text = "The quick brown fox jumps over the lazy dog.";
        var expectedCounts = new Dictionary<string, int>
        {
            { "The", 2 },
            { "quick", 1 },
            { "brown", 1 },
            { "fox", 1 },
            { "jumps", 1 },
            { "over", 1 },
            { "lazy", 1 },
            { "dog", 1 }
        };
        // Act
        Dictionary<string, int> actualCounts = CountWordFrequencies(text);

        // Assert
        Assert.AreEqual(expectedCounts.Count, actualCounts.Count);
        Assert.AreEqual(2, actualCounts["the"]);
        Assert.AreEqual(1, actualCounts["fox"]);
    }

    private Dictionary<string, int> CountWordFrequencies(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        char[] delimiters = { ' ','.', ',','\n', '\t'};
        string[] split = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        foreach(string x in split)
        {
            if (!wordCount.ContainsKey(x))
            {
                wordCount.Add(x, 1);
            }
            else
            {
                wordCount[x] = wordCount.GetValueOrDefault(x) + 1;
            }
        }

        return wordCount;
    }
}
