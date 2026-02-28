namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class SubarrayDivision
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(birthday(new List<int> { 1, 2, 1, 3, 2 }, 3, 2));
    }

    private int birthday(List<int> s, int d, int m)
    {
        int numberOfWays = 0;
        for (int i = 0; i <= s.Count - m; i++)
        {
            int sum = 0;
            for (int j = i; j < i + m; j++)
            {
                sum += s[j];
            }

            if (sum == d)
            {
                numberOfWays++;
            }
        }

        return numberOfWays;
    }
}
