namespace ProblemSolvingCSharp;

[TestClass]
public class CatsandaMouse
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private string catAndMouse(int x, int y, int z)
    {
        if (Math.Abs(z - x) == Math.Abs(z - y))
        {
            return "Mouse C";
        }
        else if (Math.Abs(z - x) < Math.Abs(z - y))
        {
            return "Cat A";
        }

        return "Cat B";
    }
}
