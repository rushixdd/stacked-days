namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class AVeryBigSum
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private long aVeryBigSum(List<long> ar)
    {
        long sum = 0;
        foreach(long ele in ar)
        {
            sum += ele;
        }

        return sum;
    }
}
