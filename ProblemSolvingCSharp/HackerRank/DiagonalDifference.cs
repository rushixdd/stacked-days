namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class DiagonalDifference
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private int diagonalDifference(List<List<int>> arr)
    {
        int ltrDiagonal = 0, rtlDiagonal = 0;
        for (int i=0; i < arr.Count; i++)
        {
            ltrDiagonal += arr[i][i];
        }

        for (int i = 0; i < arr.Count; i++)
        {
            rtlDiagonal += arr[i][arr.Count - i - 1];
        }

        return Math.Abs(ltrDiagonal - rtlDiagonal);
    }
}
