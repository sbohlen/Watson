using System.Collections.Generic;

namespace WinnerSelector
{
    public class CandidateListBuilder
    {
        private readonly IDataInterpreter _interpreter;
        private readonly IDataFileReader _reader;

        public CandidateListBuilder(IDataFileReader reader, IDataInterpreter interpreter)
        {
            _reader = reader;
            _interpreter = interpreter;
        }


        public IEnumerable<Candidate> Build(string pathToFile)
        {
            IEnumerable<string> data = _reader.ReadFile(pathToFile);
            IEnumerable<string> names = _interpreter.ConvertData(data);

            foreach (string name in names)
            {
                yield return new Candidate(name);
            }
        }
    }
}