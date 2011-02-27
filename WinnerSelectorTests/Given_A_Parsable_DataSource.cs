using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            _stringsToReturn = new List<string>() {"First Person", "Second Person"};
            reader.Stub(r => r.ReadFile(pathToFile)).Return(_stringsToReturn);

            var listBuilder = new CandidateListBuilder(reader);

            _candidates = listBuilder.Build(pathToFile);
        }

        [Test]
        public void Can_Return_List_Of_Candidates()
        {
            Assert.That(_candidates.Count(), Is.EqualTo(_stringsToReturn.Count()));
        }
    }


    public class DataFileReader : IDataFileReader
    {
        public IEnumerable<string> ReadFile(string pathToFile)
        {
            var data = new List<string>();

            using (var readFile = new StreamReader(pathToFile))
            {
                string line;

                while ((line = readFile.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }

            return data;
        }
    }
}
