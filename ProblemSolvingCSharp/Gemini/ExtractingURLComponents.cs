using System.Text.RegularExpressions;

namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class ExtractingURLComponents
{
    [TestMethod]
    public void ParseUrl_WithValidUrl_ExtractsAllComponents()
    {
        // Arrange
        string url = "https://www.example.com/path/to/page?query=123";

        // Act
        Match match = ParseUrl(url);

        // Assert
        Assert.IsTrue(match.Success, "The regex should successfully match the URL.");
        Assert.AreEqual("https", match.Groups["protocol"].Value);
        Assert.AreEqual("www.example.com", match.Groups["domain"].Value);
        Assert.AreEqual("/path/to/page?query=123", match.Groups["path"].Value);
    }

    private Match ParseUrl(string url)
    {
        string urlGroupPattern = @"^(?<protocol>https?)://(?<domain>[^/]+)(?<path>/.*)$";
        return Regex.Match(url, urlGroupPattern);
    }
}
