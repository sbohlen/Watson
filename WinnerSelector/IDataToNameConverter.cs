using System.Collections.Generic;

namespace WinnerSelector
{
    public interface IDataToNameConverter
    {
        IEnumerable<Name> Convert(IEnumerable<string> data);
    }
}