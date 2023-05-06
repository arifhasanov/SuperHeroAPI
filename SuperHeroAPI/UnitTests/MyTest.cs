using NUnit.Framework;

namespace SuperHeroAPI.UnitTests;

[TestFixture]
public class MyTest
{
    [Test]
    public void TestNumberOne()
    {
        int result = 1 + 2;
        Assert.AreEqual(3, result);
    }
}
