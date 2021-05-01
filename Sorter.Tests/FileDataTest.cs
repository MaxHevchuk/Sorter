using NUnit.Framework;

namespace Sorter.Tests
{
    public class FileDataTest
    {
        [Test]
        public void OpenSampleTest()
        {
            const string path = @"..\..\..\..\Sorter\res\sample_num.txt";
            const string expected = "54 121 -90 10 8 23 121 10";
            Assert.AreEqual(expected, FileData.OpenSample(path));
        }
    }
}