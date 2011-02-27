using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Watson
{
    public partial class Watson : Form
    {
        private IEnumerable<string> _items;
        private readonly Random _generator = new Random();

        public Watson()
        {
            InitializeComponent();
        }

        private void LoadAndParseDataFile()
        {
            var data = ParseCsv("data.txt");
            _items = ProcessData(data);

        }

        private IEnumerable<string> ProcessData(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                var corrected = item.Replace("\t", Environment.NewLine);
                yield return corrected;
            }
            
        }

        private List<string> ParseCsv(string path)
        {
            var data = new List<string>();

            try
            {
                using (var readFile = new StreamReader(path))
                {
                    string line;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return data;
        }

        private void SetInitialControlState()
        {
            txtTheWinner.Clear();
        }

        private void Watson_Load(object sender, EventArgs e)
        {
            SetInitialControlState();
            LoadAndParseDataFile();
        }

        private void btnSelectWinner_Click(object sender, EventArgs e)
        {
            txtTheWinner.Text = _items.ElementAt(_generator.Next(1, _items.Count()));
        }
    }
}