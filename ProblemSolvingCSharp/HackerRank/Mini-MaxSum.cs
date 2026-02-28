namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class Mini_MaxSum
{
    [TestMethod]
    public void TestMiniMaxSum()
    {
        List<int> arr = new List<int>([256741038,623958417,467905213,714532089,938071625]);
        miniMaxSum(arr);
    }

    private void miniMaxSum(List<int> arr)
    {
        int min = arr[0], max = arr[0]; long sum=0;

        foreach(int a in arr)
        {
            if (a < min)
            {
                min = a;
            }
            else if (a > max)
            {
                max = a;
            }

            sum += a;
        }

        Console.WriteLine((sum - max) + " " + (sum - min));
    }
}
