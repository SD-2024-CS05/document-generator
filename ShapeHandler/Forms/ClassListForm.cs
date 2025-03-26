using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShapeHandler.Forms
{
    public partial class ClassListForm : Form
    {

        public List<string> Classes { get; private set; } = new List<string>();

        public ClassListForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // each class is entered on a new line 

            List<string> classes = ClassesTextBox.Text
                .Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
            Classes = classes;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
