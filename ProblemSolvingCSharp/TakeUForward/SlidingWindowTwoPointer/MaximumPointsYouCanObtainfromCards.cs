// <copyright file="MaximumPointsYouCanObtainfromCards.cs" company="rushixdd">
// Copyright (c) rushixdd. All rights reserved.
// </copyright>

namespace ProblemSolvingCSharp.TakeUForward.SlidingWindowTwoPointer
{
    /// <summary>
    /// Provides unit tests for verifying the logic that calculates the maximum points obtainable from a set of cards
    /// according to specific game rules.
    /// </summary>
    /// <remarks>This test class is intended to ensure the correctness of algorithms that determine the
    /// optimal score achievable in card-based scenarios. Use this class to validate various edge cases and typical
    /// gameplay situations.</remarks>
    [TestClass]
    public class MaximumPointsYouCanObtainfromCards
    {
        /// <summary>
        /// Executes a unit test to verify the behavior of the MaxScore method with a sample input array and element
        /// count.
        /// </summary>
        /// <remarks>This test outputs the result of the MaxScore calculation to the console. Ensure that
        /// the MaxScore method is implemented and accessible before running this test.</remarks>
        [TestMethod]
        public void TestMethod()
        {
            Console.WriteLine(this.MaxScore([5, 4, 1, 8, 7, 1, 3], 3));
        }

        private int MaxScore(List<int> cardScore, int k)
        {
            int totalSum = 0;
            foreach (int score in cardScore)
            {
                totalSum += score;
            }

            if (k == cardScore.Count)
            {
                return totalSum;
            }

            int windowSize = cardScore.Count - k;

            int windowSum = 0;
            for (int i = 0; i < windowSize; i++)
            {
                windowSum += cardScore[i];
            }

            int minSum = windowSum;

            for (int i = windowSize; i < cardScore.Count; i++)
            {
                windowSum = windowSum - cardScore[i - windowSize] + cardScore[i];
                minSum = Math.Min(minSum, windowSum);
            }

            return totalSum - minSum;
        }
    }
}
