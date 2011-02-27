using System.Collections.Generic;

namespace WinnerSelector
{
    public class CandidateListBuilder
    {
        private readonly IDataToNameConverter _toNameConverter;
        private readonly IDataFileReader _reader;

        public CandidateListBuilder(IDataFileReader reader, IDataToNameConverter toNameConverter)
        {
            _reader = reader;
            _toNameConverter = toNameConverter;
        }


        public IEnumerable<Candidate> Build(string pathToFile)
        {
            IEnumerable<string> data = _reader.ReadFile(pathToFile);
            IEnumerable<Name> names = _toNameConverter.Convert(data);

            foreach (Name name in names)
            {
                yield return new Candidate(name);
            }
        }
    }
}