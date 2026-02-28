// <copyright file="LongestSubstringWithoutRepeatingCharacters.cs" company="rushixdd">
// Copyright (c) rushixdd. All rights reserved.
// </copyright>

namespace ProblemSolvingCSharp.LeetCode;

/// <summary>
/// Longest Substring Without Repeating Characters Test Class.
/// </summary>
[TestClass]
public class LongestSubstringWithoutRepeatingCharacters
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private int LengthOfLongestSubstring(string s)
    {
        return 0;
    }

    class Solution
    {
        public int lengthOfLongestSubstring(String s)
        {
            int n = s.Length;
            if (n == 0)
            {
                return 0;
            }

            int res = 0;
            int[] lastIndex = new int[256];
            Array.Fill(lastIndex, -1);
            int i = 0;

            for (int j = 0; j < n; j++)
            {
                i = Math.Max(i, lastIndex[s[i]] + 1);
                res = Math.Max(res, j - i + 1);
                lastIndex[s[j]] = j;
            }

            return res;
        }
    }
}
