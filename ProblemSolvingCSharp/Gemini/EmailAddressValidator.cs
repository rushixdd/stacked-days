using System.Text.RegularExpressions;
namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class EmailAddressValidator
{
    [TestMethod]
    public void IsValidEmail_WithVariousEmails_ReturnsCorrectly()
    {
        // Assert
        Assert.IsTrue(IsValidEmail("test@example.com"));
        Assert.IsTrue(IsValidEmail("user.name+alias@domain.co.uk"));
        Assert.IsTrue(IsValidEmail("user-name@sub.domain.org"));

        // Assert
        Assert.IsFalse(IsValidEmail("test@example"));
        Assert.IsFalse(IsValidEmail("test.example.com"));
        Assert.IsFalse(IsValidEmail("@example.com"));
        Assert.IsFalse(IsValidEmail("test@.com"));
        Assert.IsFalse(IsValidEmail("test with space@example.com"));
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern); ;
    }
}
