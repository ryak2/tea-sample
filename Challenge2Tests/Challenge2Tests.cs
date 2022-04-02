using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge2Tests;

[TestClass]
public partial class Challenge2Tests
{
    [TestMethod]
    public void Challenge2_MaxDistance_ReturnsCorrectResultForSample1()
    {
        string input = "gbcjbdha";
        int result = Challenge2.Challenge2.MaxDistance(input);

        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Challenge2_MaxDistance_ReturnsCorrectResultForEmptyString()
    {
        string input = "";
        int result = Challenge2.Challenge2.MaxDistance(input);

        Assert.AreEqual(0, result);
    }

    /// <summary>
    /// Not a proper unit test, but showing off the O(n) runtime.
    /// </summary>
    [TestMethod]
    public void Challenge2_MaxDistance_ReturnsCorrectResultForExtremelyLongString()
    {
        // String is 2.4 million characters long
        string input = GetPerformanceTestingString();
        int result = Challenge2.Challenge2.MaxDistance(input);

        Assert.AreEqual(24, result);
    }

    [TestMethod]
    public void Challenge2_GetDistanceBetween_ReturnsCorrectResult()
    {
        char c1 = 'c';
        char c2 = 'k';
        int result = Challenge2.Challenge2.GetDistanceBetween(c1, c2);

        Assert.AreEqual(7, result);
    }

        [TestMethod]
    public void Challenge2_GetDistanceBetween_OnlyReturnsPositiveDifferences()
    {
        char c1 = 'k';
        char c2 = 'c';
        int result = Challenge2.Challenge2.GetDistanceBetween(c1, c2);

        Assert.AreEqual(0, result);
    }
}