namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class DrawingBook
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(this.pageCount(6, 5));
    }

    private int pageCount(int n, int p)
    {
        if (p == 1 || p == n)
        {
            return 0;
        }

        int fromFront = p / 2;
        int fromBack = (n / 2) - (p / 2);


        return Math.Min(fromBack, fromFront);
    }
}
