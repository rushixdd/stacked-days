
namespace ProblemSolvingCSharp.HackerRank
{
    [TestClass]
    public class ElectronicsShop
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        private int GetMoneySpent(int[] keyboards, int[] drives, int b)
        {
            Array.Sort(keyboards);
            Array.Sort(drives);

            int i = 0;
            int j = drives.Length - 1;
            int maxSpend = -1;

            while (i < keyboards.Length && j >= 0)
            {
                int sum = keyboards[i] + drives[j];
                if (sum > b)
                {
                    j--;
                }
                else
                {
                    maxSpend = Math.Max(maxSpend, sum);
                    i++;
                }
            }

            return maxSpend;
        }
    }
}
