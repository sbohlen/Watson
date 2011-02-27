using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WinnerSelector;

namespace WinnerSelectorTests
{
    [TestFixture]
    public class Given_A_Collection_of_Data
    {
        private IEnumerable<Name> _results;

        [SetUp]
        public void When_Parsing()
        {
            var converter = new CommaDelimitedDataToNameConverter();

            var data = new List<string>() { "First,Person", "Second,Person", "Third,Person", "Fourth", string.Empty };

            _results = converter.Convert(data);
        }

        [Test]
        public void Can_Convert_To_Assignable_Names()
        {
            Assert.That(_results.ElementAt(0), Is.EqualTo(new Name("First", "Person")));
            Assert.That(_results.ElementAt(1), Is.EqualTo(new Name("Second", "Person")));
            Assert.That(_results.ElementAt(2), Is.EqualTo(new Name("Third", "Person")));
        }

        [Test]
        public void Can_Convert_All_Data_Elements()
        {
            Assert.That(_results.Count(), Is.EqualTo(4));
        }

        [Test]
        public void Can_Ignore_Empty_Data()
        {
            Assert.That(!_results.Contains(new Name(string.Empty, string.Empty)));
        }

        [Test]
        public void Can_Replace_Missing_Lastname()
        {
            Assert.That(_results.ElementAt(3), Is.EqualTo(new Name("Fourth", "n/a")));
        }
    }
}