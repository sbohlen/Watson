using System;
using System.Collections.Generic;

namespace WinnerSelector
{
    public class DataInterpreter : IDataInterpreter
    {
        public IEnumerable<string> ConvertData(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                var corrected = item.Replace("\t", Environment.NewLine);
                yield return corrected;
            }
        }
    }
}