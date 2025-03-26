using Newtonsoft.Json;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShapeHandler.Database.Decision
{
    public partial class ConnectionForm : Form
    {
        private int _shapeId;
        private DecisionNode _decisionNode;
        private DataInputNode _dataInputNode;
        public Connection Connection { get; private set; } = null;
        public ConnectionForm(int shapeId, DecisionNode decisionNode, DataInputNode dataInputNode)
        {
            InitializeComponent();
            _shapeId = shapeId;
            _decisionNode = decisionNode;
            _dataInputNode = dataInputNode;
            FillSubmissionItems();

            if (_dataInputNode == null)
            {
                AddConditionButton.Enabled = false;
            }
        }

        private void FillSubmissionItems()
        {
            foreach (HtmlNode node in _decisionNode.SubmissionNodes)
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

            // add default "None" option
            SubmissionComboBox.Items.Add("NONE");
        }

        private void UpdateShapeData()
        {
            if (Connection == null)
            {
                Connection = new Connection("");
            }
            UpdateSubmissionId();
            UpdateUrl();

            // serialize connection
            string connectionJson = JsonConvert.SerializeObject(Connection, new ConnectionSerializer());
            VisioShapeDataHelper.AddShapeData(_shapeId, connectionJson, "Connection");
        }

        private void UpdateSubmissionId()
        {
            string selectedSubmission = SubmissionComboBox.SelectedItem as string;
            HtmlNode selectedNode = _decisionNode.SubmissionNodes.FirstOrDefault(x =>
            x.Element.Id == selectedSubmission ||
            x.Element.OuterHtml == selectedSubmission);

            if (selectedNode != null)
            {
                Connection.SubmissionId = selectedNode.Id;
            }
        }

        private void UpdateUrl()
        {
            Connection.URL = UrlTextBox.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            Close();
        }
        private void AddConditionButton_Click(object sender, EventArgs e)
        {
            System.Collections.Generic.List<HtmlNode> htmlElements = _dataInputNode.DataInputNodes;
            ConditionsForm conditionForm = new ConditionsForm(htmlElements);
            conditionForm.ShowDialog();

            if (Connection == null)
            {
                Connection = new Connection("");
            }
            if (conditionForm.Conditions != null)
            {
                Connection.Conditions = conditionForm.Conditions;
            }
        }
    }
}
