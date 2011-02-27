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
            Assert.That(!_results.Contains(new Name(string.Empty, "not found")));
        }

        [Test]
        public void Can_Replace_Missing_Lastname()
        {
            Assert.That(_results.ElementAt(3), Is.EqualTo(new Name("Fourth", "not found")));
        }
    }

    [TestFixture]
    public class Given_A_Name
    {
        private Name _name;

        [SetUp]
        public void When_Setting_First_and_Last_Names()
        {
            _name = new Name("First", "Last");
        }


        [Test]
        public void Can_Return_Fullname()
        {
            Assert.That(_name.Fullname, Is.EqualTo("First Last"));
        }
    }
}