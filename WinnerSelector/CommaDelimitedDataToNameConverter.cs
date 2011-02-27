using System;
using System.Collections.Generic;

namespace WinnerSelector
{
    public class CommaDelimitedDataToNameConverter : IDataToNameConverter
    {
        public IEnumerable<Name> Convert(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                var split = item.Split(",".ToCharArray());
                
                //var corrected = item.Replace("\t", Environment.NewLine);
                yield return new Name(split[0], split[1]);
            }
        }
    }
}