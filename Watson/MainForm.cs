using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinnerSelector;

namespace Watson
{
    public partial class Watson : Form
    {
        private readonly CandidateListBuilder _candidateListBuilder;
        private CandidateSelector _candidateSelector;
        private ICanTalk _speaker;

        public Watson(CandidateListBuilder candidateListBuilder, ICanTalk speaker)
        {
            InitializeComponent();
            _candidateListBuilder = candidateListBuilder;
            _speaker = speaker;
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
            txtTheWinner.Text = string.Empty;

            string response;
            
            try
            {
                Candidate winner = _candidateSelector.Pick();
                response = string.Format("{0}{1}{2}", winner.Name.Firstname, Environment.NewLine,
                                           winner.Name.Lastname);
            }
            catch (NoCandidatesFromWhichToSelect)
            {
                response = "Sorry, no potential winners left!";
            }

            txtTheWinner.Text = response;

            //have to start the text-to-speech engine on a different thread else it introduces unacceptable delay into the UI update thread
            new Task(() => _speaker.Speak(response)).Start();
        }
    }
}