using System.Collections.Generic;

namespace WinnerSelector
{
    public interface IDataFileReader
    {
        IEnumerable<string> ReadFile(string pathToFile);
    }
}