namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class Staircase
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private void staircase(int n)
    {
        for(int i = 1; i <= n;i++)
        {
            Console.Write(new string(' ', n - i));
            Console.Write(new string('#', i));
            Console.WriteLine();
        }
    }
}
