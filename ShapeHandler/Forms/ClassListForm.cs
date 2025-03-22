using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var classes = ClassesTextBox.Text
                .Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
            Classes = classes;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
