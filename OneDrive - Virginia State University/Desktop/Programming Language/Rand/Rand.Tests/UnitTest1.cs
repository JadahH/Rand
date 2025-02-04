namespace Rand.Tests;

using Xunit;
using RandomGenerators;
using System;
using System.Text.RegularExpressions;


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
 double mean = 50;
        double stdDev = 10;
        int sampleSize = 10000;

        double sum = 0;
        double sumSq = 0;

        for (int i = 0; i < sampleSize; i++)
        {
            double num = RandomFunctions.GenerateNormalRandom(mean, stdDev);
            sum += num;
            sumSq += num * num;
        }

        double sampleMean = sum / sampleSize;
        double sampleStdDev = Math.Sqrt((sumSq / sampleSize) - (sampleMean * sampleMean));

        Assert.InRange(sampleMean, mean - 2, mean + 2); // Mean should be close
        Assert.InRange(sampleStdDev, stdDev - 2, stdDev + 2); // Std Dev should be close
    }

    [Fact]
    public void TestPasswordGeneration()
    {
        int length = 10;
        string password = RandomFunctions.GeneratePassword(length);

        Assert.Equal(length, password.Length);
        Assert.Matches(@"^[A-Za-z0-9_]+$", password); // Ensure valid characters
    }

    [Fact]
    public void TestColorGeneration()
    {
        var (hex, rgb) = RandomFunctions.GenerateRandomColor();

        Assert.Matches(@"^#[0-9A-Fa-f]{6}$", hex); // Hex format check

        Assert.InRange(rgb.Item1, 0, 255); // R
        Assert.InRange(rgb.Item2, 0, 255); // G
        Assert.InRange(rgb.Item3, 0, 255); // B

        string expectedHex = $"#{rgb.Item1:X2}{rgb.Item2:X2}{rgb.Item3:X2}";
        Assert.Equal(expectedHex, hex); // Check if hex matches RGB
    }
}
    }
}