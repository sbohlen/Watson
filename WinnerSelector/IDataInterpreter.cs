using System.Collections.Generic;

namespace WinnerSelector
{
    public interface IDataInterpreter
    {
        IEnumerable<string> ConvertData(IEnumerable<string> data);
    }
}