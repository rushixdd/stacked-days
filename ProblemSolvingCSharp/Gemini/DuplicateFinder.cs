namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class DuplicateFinder
{
    [TestMethod]
    public void FindDuplicates_WhenDuplicatesExist_ReturnsCorrectSet()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 5, 2, 8, 3, 5, 3, 3 };
        var expectedDuplicates = new HashSet<int> { 2, 3, 5 };

        // Act
        HashSet<int> actualDuplicates = FindDuplicates(numbers);

        // Assert
        CollectionAssert.AreEquivalent(expectedDuplicates.ToList(), actualDuplicates.ToList());
    }

    private HashSet<int> FindDuplicates(List<int> arr)
    {
        HashSet<int> duplicates = new HashSet<int>();
        HashSet<int> elements = new HashSet<int>();
        foreach(var ele in arr)
        {
            if (!elements.Add(ele))
            {
                duplicates.Add(ele);
            }
        }

        return duplicates;
    }
}
