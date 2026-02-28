namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class SalesbyMatch
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(this.sockMerchant(9, new List<int>() { 10, 20, 20, 10, 10, 30, 50, 10, 20 }));
    }

    private int sockMerchant(int n, List<int> ar)
    {
        Dictionary<int, int> sockCount = new Dictionary<int, int>();
        string s;
        int pairs = 0;
        foreach (int sock in ar)
        {
            if (sockCount.ContainsKey(sock))
            {
                sockCount[sock]++;
            }
            else
            {
                sockCount[sock] = 1;
            }
        }

        foreach (var sock in sockCount)
        {
            pairs += sock.Value / 2;
        }

        return pairs;
    }

    private int sockMerchantLINQ(int n, List<int> ar)
    {
        return ar
        .GroupBy(x => x)
        .Sum(g => g.Count() / 2);
    }
}
