namespace ProblemSolvingCSharp.Gemini;

public class StudentRoster
{
    private readonly List<string> _students = new List<string>();

    public void AddStudent(string name)
    {
        _students.Add(name);
    }

    public void RemoveStudent(string name)
    {
        _students.Remove(name);
    }

    public List<string> GetSortedRoster()
    {
        var sortedRoster = new List<string>(_students);
        sortedRoster.Sort();
        return sortedRoster;
    }
}

[TestClass]
public class StudentRosterManagement
{
    [TestMethod]
    public void Roster_PerformsAddRemoveAndSort_Correctly()
    {
        // Arrange
        var roster = new StudentRoster();

        // Act
        roster.AddStudent("Charlie");
        roster.AddStudent("Alice");
        roster.AddStudent("Bob");
        roster.RemoveStudent("Charlie");

        List<string> sortedRoster = roster.GetSortedRoster();

        // Assert
        var expectedRoster = new List<string> { "Alice", "Bob" };
        CollectionAssert.AreEqual(expectedRoster, sortedRoster);
    }
}
