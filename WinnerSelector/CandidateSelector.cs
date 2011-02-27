using System;
using System.Collections.Generic;
using System.Linq;

namespace WinnerSelector
{
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
            if (_candidates.Count == 0)
            {
                throw new NoCandidatesFromWhichToSelect();
            }
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