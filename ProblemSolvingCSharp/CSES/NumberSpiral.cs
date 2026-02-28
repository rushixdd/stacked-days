using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingCSharp.CSES
{
    [TestClass]
    public class NumberSpiral
    {
        [TestMethod]
        public void TestNumberInSpiral()
        {
            Assert.AreEqual(1, numberInSpiral(1, 1));
            Assert.AreEqual(2, numberInSpiral(1, 2));
            Assert.AreEqual(3, numberInSpiral(2, 2));
            Assert.AreEqual(4, numberInSpiral(2, 1));
            Assert.AreEqual(7, numberInSpiral(3, 3));
            Assert.AreEqual(15, numberInSpiral(4, 2));
            Assert.AreEqual(17, numberInSpiral(5, 1));
            Assert.AreEqual(21, numberInSpiral(5, 5));
            Assert.AreEqual(8, numberInSpiral(2, 3));
            Assert.AreEqual(16, numberInSpiral(4, 1));
        }

        public long numberInSpiral(long y, long x)
        {
            long n = Math.Max(y, x);
            long start = (n - 1) * (n - 1);

            if (n % 2 == 0)
            {
                if (x == n)
                    return start + y;
                else
                    return start + n + (n - x);
            }
            else
            {
                if (y == n)
                    return start + x;
                else
                    return start + n + (n - y);
            }
        }
    }
}
