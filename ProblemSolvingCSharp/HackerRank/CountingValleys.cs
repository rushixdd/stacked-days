namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class CountingValleys
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(this.countingValleys(8, "UDDDUDUU"));
    }

    private int countingValleys(int steps, string path)
    {
        int valleys = 0;
        int altitude = 0;

        foreach (char step in path)
        {
            if (step == 'U')
            {
                altitude++;
                if (altitude == 0)
                {
                    valleys++;
                }
            }
            else
            {
                altitude--;
            }
        }

        return valleys;
    }
}
