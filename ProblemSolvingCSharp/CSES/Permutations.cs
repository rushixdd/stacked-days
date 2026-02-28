using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingCSharp.CSES
{
    [TestClass]
    public class Permutations
    {
        [TestMethod]
        public void TestGeneratePermutations()
        {
            GeneratePermutations(2);  // Output: NO SOLUTION
            GeneratePermutations(3);  // Output: NO SOLUTION
            GeneratePermutations(4);  // Output: 4 2 3 1
            GeneratePermutations(5);  // Output: 5 3 1 4 2
            GeneratePermutations(6);  // Output: 6 4 2 5 3 1
        }

        public void GeneratePermutations(int i)
        {
            if (i <= 3)
            {
                Console.WriteLine("NO SOLUTION");
                return;
            }
            else
            {
                List<int> result = new List<int>();
                for (int j = i; j >= 1; j--)
                {
                    if (j % 2 == 0)
                    {
                        result.Add(j);
                    }
                }
                for (int j = i; j >= 1; j--)
                {
                    if (j % 2 == 1)
                    {
                        result.Add(j);
                    }
                }

                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
