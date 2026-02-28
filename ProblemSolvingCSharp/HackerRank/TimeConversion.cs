using System.Text;

namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class TimeConversion
{
    [TestMethod]
    public void TestTimeConversion()
    {
        Console.WriteLine(timeConversion("07:05:45AM"));
    }

    private string timeConversion(string s)
    {
        int hour = int.Parse(s.Substring(0, 2));
        string minuteSecond = s.Substring(2, 6);
        string period = s.Substring(8, 2);

        if (period == "AM" && hour == 12) hour = 0;
        if (period == "PM" && hour != 12) hour += 12;

        return $"{hour:D2}{minuteSecond}";

    }
}
