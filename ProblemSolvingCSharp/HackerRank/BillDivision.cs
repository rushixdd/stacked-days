namespace ProblemSolvingCSharp.HackerRank
{
    [TestClass]
    public class BillDivision
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        private void bonAppetit(List<int> bill, int k, int b)
        {
            int annaShare = (bill.Sum() - bill[k]) / 2;
            Console.WriteLine(b == annaShare ? "Bon Appetit" : b - annaShare);
        }
    }
}
