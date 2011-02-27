using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using WinnerSelector;

namespace WinnerSelectorTests
{
    [TestFixture]
    public class Given_A_Parsable_DataSource
    {
        private IEnumerable<Candidate> _candidates;
        private List<string> _stringsToReturn;

        [SetUp]
        public void When_Reading_The_List()
        {
            string pathToFile = "data.txt";

            IDataFileReader reader = MockRepository.GenerateStub<IDataFileReader>();
            _stringsToReturn = new List<string>() { "First,Person", "Second,Person" };
            reader.Stub(r => r.ReadFile(pathToFile)).Return(_stringsToReturn);

            var listBuilder = new CandidateListBuilder(reader, new CommaDelimitedDataToNameConverter());

            _candidates = listBuilder.Build(pathToFile);
        }

        [Test]
        public void Can_Return_List_Of_Candidates()
        {
            Assert.That(_candidates.Count(), Is.EqualTo(_stringsToReturn.Count()));
        }
    }


    [TestFixture]
    public class Given_A_List_of_Candidates
    {
        private Candidate _winner;
        private CandidateSelector _selector;

        [SetUp]
        public void When_Selecting_A_Candidate()
        {
            var candidates = new List<Candidate>();

            //create 50 candidates
            for (int i = 0; i < 50; i++)
            {
                candidates.Add(new Candidate(new Name(string.Format("Person{0}Firstname", i), string.Format("Person{0}Lastname", i))));
            }

            _selector = new CandidateSelector(candidates);
            _winner = _selector.Pick();

        }

        [Test]
        public void Can_Select_One()
        {
            Assert.That(_winner, Is.Not.Null);
        }
    }

    public class CandidateSelector
    {
        private readonly IList<Candidate> _candidates;
        private readonly Random _randomGenerator;

        public CandidateSelector(IEnumerable<Candidate> candidates)
        {
            _candidates = new List<Candidate>(candidates);
            _randomGenerator = new Random();
        }

        public Candidate Pick()
        {
            int index = GetRandomValue(_candidates.Count());

            var winner = _candidates.ElementAt(index);
            _candidates.Remove(winner);

            return winner;
        }

        private int GetRandomValue(int maxValue)
        {
            return _randomGenerator.Next(maxValue);
        }
    }
}
