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

namespace ShapeHandler.Database.Decision
{
    public partial class ConnectionForm : Form
    {
        private DecisionNode _decisionNode;
        public Connection Connection { get; private set; } = null;
        public ConnectionForm(DecisionNode decisionNode)
        {
            InitializeComponent();
            _decisionNode = decisionNode;
            FillSubmissionItems();
        }

        private void FillSubmissionItems()
        {
            foreach (var node in _decisionNode.SubmissionNodes)
            {
                if (!string.IsNullOrEmpty(node.Element.Id))
                {
                    SubmissionComboBox.Items.Add(node.Element.Id);
                }
                else
                {
                    SubmissionComboBox.Items.Add(node.Element.OuterHtml);
                }
            }
        }

        private void UpdateShapeData()
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            this.Close();
        }
    }
}
