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
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                var split = item.Split(",".ToCharArray());

                string firstname = string.Empty;
                string lastname = string.Empty;

                if (split.Length > 1)
                {
                    firstname = split[0];
                    lastname = split[1];
                }
                else
                {
                    firstname = item;
                    lastname = "not found";
                }

                yield return new Name(firstname, lastname);
            }
        }
    }
}