namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class BreakingtheRecords
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(breakingRecords(new List<int>([10, 5, 20, 20, 4, 5, 2, 25, 1])));
    }

    private List<int> breakingRecords(List<int> scores)
    {
        int minBreak = 0;
        int maxBreak = 0;
        int min = scores[0];
        int max = scores[0];

        for (int i = 1; i < scores.Count; i++)
        {
            if (scores[i] < min)
            {
                min = scores[i];
                minBreak++;
            }
            else if (scores[i] > max)
            {
                max = scores[i];
                maxBreak++;
            }
        }

        return new List<int> { maxBreak, minBreak };
    }
}
