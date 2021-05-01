using NUnit.Framework;

namespace Sorter.Tests
{
    public class DataCheckerTest
    {
        [Test]
        public void CheckForCorrectTest()
        {
            Assert.AreEqual(true, DataChecker.CheckForCorrect("abc def hij", DataType.StringEnglish, " "));
        }
    }
}