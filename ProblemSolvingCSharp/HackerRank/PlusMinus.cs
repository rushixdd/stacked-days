namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class PlusMinus
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private void plusMinus(List<int> arr)
    {
        int positive = 0, zero = 0, negative = 0;

        foreach(int ele in arr)
        {
            if (ele < 0)
            {
                negative++;
            }
            else if (ele > 0)
            {
                positive++;
            }
            else
            {
                zero++;
            }
        }

        double total = arr.Count;
        Console.WriteLine((positive / total).ToString("F6"));
        Console.WriteLine((negative / total).ToString("F6"));
        Console.WriteLine((zero / total).ToString("F6"));
    }
}
