using System;
using System.Windows.Forms;

namespace ShapeHandler.Database.StartEnd
{
    public partial class StartEndForm : Form
    {
        public string URL { get; private set; } = "";

        public StartEndForm()
        {
            InitializeComponent();
        }
        public StartEndForm(string url)
        {
            InitializeComponent();
            UrlTextBox.Text = url;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            URL = UrlTextBox.Text;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
