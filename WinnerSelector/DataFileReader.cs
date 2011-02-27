using System.Collections.Generic;
using System.IO;

namespace WinnerSelector
{
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