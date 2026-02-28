// <copyright file="TwoSum.cs" company="rushixdd">
// Copyright (c) rushixdd. All rights reserved.
// </copyright>

namespace ProblemSolvingCSharp.LeetCode;

/// <summary>
/// Two Sum problem  Test class.
/// </summary>
[TestClass]
public class TwoSum
{
    /// <summary>
    /// Test Method.
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine(this.Twosum([3, 3], 6));
    }

    private int[] Twosum(int[] nums, int target)
    {
        Dictionary<int, int> complements = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int comp = target - nums[i];
            if (complements.ContainsKey(comp))
            {
                return [complements[comp], i];
            }

            complements.Add(nums[i], i);
        }

        return [-1, -1];
    }
}
