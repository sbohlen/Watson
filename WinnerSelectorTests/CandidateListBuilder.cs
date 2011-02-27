using System;
using System.Collections.Generic;
using System.IO;

namespace WinnerSelectorTests
{
    public class CandidateListBuilder
    {
        private readonly string _pathToFile;
        private IDataFileReader _reader;

        public CandidateListBuilder(string pathToFile, IDataFileReader reader)
        {
            _pathToFile = pathToFile;
            _reader = reader;
        }


        private IEnumerable<string> ConvertDataToNames(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                var corrected = item.Replace("\t", Environment.NewLine);
                yield return corrected;
            }

        }

      


        public IEnumerable<Candidate> Build()
        {
            var data = _reader.ReadFile(_pathToFile);
            var names = ConvertDataToNames(data);

            foreach (var name in names)
            {
                yield return new Candidate(name);
            }


        }
    }
}