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
        private IEnumerable<string> _results;

        [SetUp]
        public void When_Parsing()
        {
            var interpreter = new TabDelimitedDataInterpreter();

            var data = new List<string>() { "First\tPerson", "Second\tPerson", "Third\tPerson" };

            _results = interpreter.ConvertData(data);
        }

        [Test]
        public void Can_Convert_To_Assignable_Names()
        {
            Assert.That(_results.ElementAt(0), Is.EqualTo(string.Format("First{0}Person", Environment.NewLine)));
            Assert.That(_results.ElementAt(1), Is.EqualTo(string.Format("Second{0}Person", Environment.NewLine)));
            Assert.That(_results.ElementAt(2), Is.EqualTo(string.Format("Third{0}Person", Environment.NewLine)));
        }

        [Test]
        public void Can_Convert_All_Data_Elements()
        {
            Assert.That(_results.Count(), Is.EqualTo(3));
        }
    }
}