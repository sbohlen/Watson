using System;
using System.Collections.Generic;
using NUnit.Framework;
using WinnerSelector;

namespace WinnerSelectorTests
{
    [TestFixture]
    public class Given_A_List_of_Candidates
    {
        private CandidateSelector _selector;
        private int _candidateCount;

        [SetUp]
        public void When_Selecting_A_Candidate()
        {
            var candidates = new List<Candidate>();

            //create 50 candidates
            _candidateCount = 50;
            for (int i = 0; i < _candidateCount; i++)
            {
                candidates.Add(new Candidate(new Name(string.Format("Person{0}Firstname", i), string.Format("Person{0}Lastname", i))));
            }

            _selector = new CandidateSelector(candidates);
        }

        [Test]
        public void Can_Select_One()
        {
            var winner = _selector.Pick();
            Assert.That(winner, Is.Not.Null);
        }

        [Test]
        public void Can_Report_When_Candidate_Pool_Is_Exhausted()
        {
            //pick enough times to ensure the pool is exhausted
            for (int i = 0; i < _candidateCount; i++)
            {
                _selector.Pick();
            }

            //this line should throw since we can know that there are no longer any remaining candidates
            Assert.Throws<NoCandidatesFromWhichToSelect>(() => _selector.Pick());
        }
    }
}