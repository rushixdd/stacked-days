namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class ComparetheTriplets
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private List<int> compareTriplets(List<int> a, List<int> b)
    {
        List<int> points = new List<int>(2);
        int x=0, y = 0;
        for(int i=0; i<a.Count; i++)
        {
            if (a[i] > b[i])
            {
                x++;
            }
            else if (a[i] < b[i])
            {
                y++;
            }
        }
        points.Add(x);
        points.Add(y);

        return points;
    }
}
