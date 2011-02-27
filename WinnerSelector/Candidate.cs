namespace WinnerSelector
{
    public class Candidate
    {
        public Candidate(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}