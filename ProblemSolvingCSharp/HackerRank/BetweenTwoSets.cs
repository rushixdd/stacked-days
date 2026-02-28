// <copyright file="BetweenTwoSets.cs" company="rushixdd">
// Copyright (c) rushixdd. All rights reserved.
// </copyright>

namespace ProblemSolvingCSharp.HackerRank;

[TestClass]
public class BetweenTwoSets
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    private int getTotalX(List<int> a, List<int> b)
    {
        int lcmA = this.LCMArray(a);
        int gcdB = this.GCDArray(b);

        int count = 0;
        for (int multiple = lcmA; multiple <= gcdB; multiple += lcmA)
        {
            if (gcdB % multiple == 0)
            {
                count++;
            }
        }

        return count;

    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private int LCM(int a, int b)
    {
        return (a / this.GCD(a, b)) * b;
    }

    private int GCDArray(List<int> arr)
    {
        int result = arr[0];

        for (int i = 1; i < arr.Count; i++)
        {
            result = this.GCD(result, arr[i]);
        }

        return result;
    }

    private int LCMArray(List<int> arr)
    {
        int result = arr[0];

        for (int i = 1; i < arr.Count; i++)
        {
            result = this.LCM(result, arr[i]);
        }

        return result;
    }
}
