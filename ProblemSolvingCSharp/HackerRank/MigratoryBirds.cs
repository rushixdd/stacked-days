namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class MigratoryBirds
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private int migratoryBirds(List<int> arr)
    {
        var freq = new Dictionary<int, int>();

        int maxBirdId = int.MaxValue;
        int maxCount = 0;

        foreach (int id in arr)
        {
            if (!freq.TryAdd(id, 1))
            {
                freq[id]++;
            }

            int count = freq[id];

            if (count > maxCount || (count == maxCount && id < maxBirdId))
            {
                maxCount = count;
                maxBirdId = id;
            }
        }

        return maxBirdId;
    }
}
