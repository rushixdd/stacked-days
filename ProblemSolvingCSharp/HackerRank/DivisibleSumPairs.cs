namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class DivisibleSumPairs
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private int divisibleSumPairs(int n, int k, List<int> ar)
    {
        int count = 0;
        int[] remainderFreq = new int[k];

        foreach (var value in ar)
        {
            int remainder = value % k;
            int complement = (k - remainder) % k;

            count += remainderFreq[complement];
            remainderFreq[remainder]++;
        }

        return count;
    }
}
