namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class AppleandOrange
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
    {
        int appleCount = apples.Count(apple => a + apple >= s && a + apple <= t);
        int orangeCount = oranges.Count(orange => b + orange >= s && b + orange <= t);

        Console.WriteLine(appleCount);
        Console.WriteLine(orangeCount);
    }
}
