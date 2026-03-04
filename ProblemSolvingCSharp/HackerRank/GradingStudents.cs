// <copyright file="GradingStudents.cs" company="rushixdd">
// Copyright (c) rushixdd. All rights reserved.
// </copyright>

namespace ProblemSolvingCSharp.HackerRank
{
    [TestClass]
    public class GradingStudents
    {
        [TestMethod]
        public void TestMethod()
        {
        }

        private List<int> gradingStudents(List<int> grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] >= 38 && grades[i] % 5 >= 3)
                {
                    grades[i] = grades[i] + 5 - (grades[i] % 5);
                }
            }

            return grades;
        }
    }
}
