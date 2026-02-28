using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingCSharp.HackerRank
{
    [TestClass]
    public class SimpleArraySum
    {
        private int simpleArraySum(List<int> ar)
        {
            int sum = 0;
            foreach (int ele in ar)
            {
                sum += ele;
            }

            return sum;
        }
    }
}
