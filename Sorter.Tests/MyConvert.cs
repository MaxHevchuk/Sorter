using NUnit.Framework;

namespace Sorter.Tests
{
    public class MyConvertTest
    {
        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("1 2 3 4 5", MyConvert.ToString(
                new[] {1, 2, 3, 4, 5},
                DataType.NumberDecimal,
                " "));
        }

        [Test]
        public void ToIntArrayTest()
        {
            Assert.AreEqual(new[] {1, 2, 3, 4, 5}, MyConvert.ToIntArray(
                new[] {"1", "2", "3", "4", "5"},
                DataType.NumberDecimal));
        }
    }
}