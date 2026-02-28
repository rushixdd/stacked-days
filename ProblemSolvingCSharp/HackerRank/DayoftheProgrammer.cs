namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class DayoftheProgrammer
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.Write(this.dayOfProgrammer(1918));
    }

    private string dayOfProgrammer(int year)
    {
        if (year == 1918)
        {
            return $"26.09.{year}";
        }

        bool isLeap = year < 1918
            ? year % 4 == 0
            : year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);

        int day = isLeap ? 12 : 13;

        return $"{day}.09.{year}";
    }
}
