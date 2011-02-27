using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinnerSelector;

namespace Watson
{
    public partial class Watson : Form
    {
        private readonly CandidateListBuilder _candidateListBuilder;
        private CandidateSelector _candidateSelector;

        public Watson(CandidateListBuilder candidateListBuilder)
        {
            InitializeComponent();
            _candidateListBuilder = candidateListBuilder;
        }

        private void PrepareForSelection()
        {
            IEnumerable<Candidate> candidates = _candidateListBuilder.Build("data.txt");
            _candidateSelector = new CandidateSelector(candidates);
        }

        private void SetInitialControlState()
        {
            txtTheWinner.Clear();
        }

        private void Watson_Load(object sender, EventArgs e)
        {
            SetInitialControlState();
            PrepareForSelection();
        }

        private void btnSelectWinner_Click(object sender, EventArgs e)
        {
            try
            {
                Candidate winner = _candidateSelector.Pick();
                txtTheWinner.Text = string.Format("{0}{1}{2}", winner.Name.Firstname, Environment.NewLine,
                                                  winner.Name.Lastname);
            }
            catch (NoCandidatesFromWhichToSelect)
            {
                txtTheWinner.Text = "Sorry, no potential winners left!";
            }
        }
    }
}