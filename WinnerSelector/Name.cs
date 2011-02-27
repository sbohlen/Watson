using Proteus.Domain.Foundation;

namespace WinnerSelector
{
    public class Name : ValueObjectBase<Name>
    {
        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Fullname
        {
            get { return string.Format("{0} {1}", Firstname, Lastname); }
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
    }
}