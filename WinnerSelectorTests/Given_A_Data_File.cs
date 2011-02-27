using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WinnerSelectorTests
{
    [TestFixture]
    public class Given_A_Data_File
    {
        private IEnumerable<string> _lines;

        [SetUp]
        public void When_Reading_The_File()
        {
            var pathToFile = "data.txt";
            var reader = new DataFileReader();
            _lines = reader.ReadFile(pathToFile);
        }

        [Test]
        public void Can_Return_Entire_File()
        {
            Assert.That(_lines.Count(), Is.EqualTo(6));
        }
    }
}