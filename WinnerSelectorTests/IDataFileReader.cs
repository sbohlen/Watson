using System.Collections.Generic;

namespace WinnerSelectorTests
{
    public interface IDataFileReader
    {
        IEnumerable<string> ReadFile(string pathToFile);
    }
}