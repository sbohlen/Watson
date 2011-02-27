namespace WinnerSelector
{
    public class Candidate
    {
        public Candidate(Name name)
        {
            Name = name;
        }

        public Name Name { get; private set; }
    }
}