using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class NumberLineJumps
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(kangaroo(0, 2, 5, 3));
    }

    private string kangaroo(int x1, int v1, int x2, int v2)
    {
        return x1 == x2 ? "YES" : v1 == v2 ? "NO" : (x2 - x1) % (v1 - v2) == 0 && (x2 - x1) / (v1 - v2) >= 0 ? "YES" : "NO";
    }
}
