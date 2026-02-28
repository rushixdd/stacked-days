namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class BirthdayCakeCandles
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private int birthdayCakeCandles(List<int> candles)
    {
        int numOfCandles = 0, tallest = candles[0]; 

        foreach(int candle in candles)
        {
            if (candle == tallest)
            {
                numOfCandles++;
            }
            if (candle > tallest)
            {
                tallest = candle;
                numOfCandles = 1;
            }
        }

        return numOfCandles;
    }
}
