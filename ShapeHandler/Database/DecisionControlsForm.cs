using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShapeHandler.Database.Input;

namespace ShapeHandler.Database
{
    public partial class DecisionControlsForm : Form
    {
        private static int _shapeID;
        public DecisionControlsForm(int shapeID)
        {
            _shapeID = shapeID;
            InitializeComponent();
        }

        private void optionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = optionsComboBox.SelectedIndex;
            switch (selected)
            {
                case 0:
                    ButtonAttributesForm buttonAttributesForm = new ButtonAttributesForm(_shapeID, 1);
                    buttonAttributesForm.ShowDialog();
                    break;
            }
            
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void controlsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
