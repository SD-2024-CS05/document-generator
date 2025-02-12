using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeHandler.Database.Input
{
    public partial class StartEndForm : Form
    {
        public bool IsStart { get; private set; } = false;

        public StartEndForm()
        {
            InitializeComponent();
        }

        private void StartEndForm_Load(object sender, EventArgs e)
        {

        }

        private void StartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsStart = StartCheckBox.Checked;
            this.Close();
        }
    }
}
