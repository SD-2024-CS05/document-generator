using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShapeHandler.Database.Decision
{
    public partial class ConditionsForm : Form
    {
        public Conditions Conditions { get; private set; } = null;
        private List<HtmlNode> _elementNodes;
        private int _conditionCount = 1;
        private int _elementCount = 1;

        public ConditionsForm(List<HtmlNode> elementNodes)
        {
            InitializeComponent();
            _elementNodes = elementNodes;
            FillElementItems(ElementComboBox1);
            FillOperatorItems(OperatorComboBox1);
        }

        private void FillOperatorItems(ComboBox combo)
        {
            foreach (var op in Enum.GetNames(typeof(LogicalOperator)))
            {
                combo.Items.Add(op);
            }
        }

        private void FillElementItems(ComboBox combo)
        {
            foreach (var node in _elementNodes)
            {
                if (!string.IsNullOrEmpty(node.Element.Id))
                {
                    combo.Items.Add(node.Element.Id);
                }
                else
                {
                    combo.Items.Add(node.Element.OuterHtml);
                }
            }
        }

        private HtmlNode GetHtmlNodeById(string id)
        {
            return _elementNodes.FirstOrDefault(n => n.Element.Id == id);
        }

        private HtmlNode GetHtmlNodeByOuterHtml(string outerHtml)
        {
            return _elementNodes.FirstOrDefault(n => n.Element.OuterHtml == outerHtml);
        }

        private void UpdateShapeData()
        {
            Conditions = new Conditions();
            List<string> nodeIds = new List<string>();

            var currCond = Conditions;
            // should be ELEMENT OP ELEMENT OP ELEMENT OP ELEMENT
            // all nodeIds in the same level of Condition are presumed to be connected via an AND operator
            // if the operator is anything else, the innerCondition should be created with the operator and the current NodeId
            // e.g. EL1 AND EL2 OR EL3 AND EL4 would be represented as:
            // { "operator": "OR", "nodeIds": ["EL1", "EL2"], "innerCondition": { "operator": "AND", "nodeIds": ["EL3", "EL4"] } }

            for (int i = 1; i <= _conditionCount; i++)
            {
                var elementCombo = this.Controls.Find("ElementComboBox" + i, true).FirstOrDefault() as ComboBox;
                var operatorCombo = this.Controls.Find("OperatorComboBox" + i, true).FirstOrDefault() as ComboBox;

                // add until an operator isn't AND
                var selectedItem = elementCombo.SelectedItem as string;

                if (!string.IsNullOrEmpty(selectedItem))
                {
                    var node = GetHtmlNodeById(selectedItem) ?? GetHtmlNodeByOuterHtml(selectedItem);
                    nodeIds.Add(node.Id);
                }

                // last operator won't have text associated with it
                if (operatorCombo == null || string.IsNullOrEmpty(operatorCombo.SelectedItem as string))
                {
                    break;
                }

                var op = (LogicalOperator)Enum.Parse(typeof(LogicalOperator), operatorCombo.SelectedItem as string);
                if (op != LogicalOperator.AND)
                {
                    currCond.Operator = op;
                    currCond.NodeIds = nodeIds;
                    nodeIds = new List<string>();
                    currCond.InnerConditions = new Conditions();
                    currCond = currCond.InnerConditions;
                }
            }
            currCond.NodeIds = nodeIds;
        }

        private void OperatorComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            AddElementComboBox(combo);
        }

        private void AddElementComboBox(ComboBox operatorBox)
        {
            ComboBox newElementComboBox = new ComboBox();
            newElementComboBox.Name = "ElementComboBox" + ++_elementCount;

            int newX = operatorBox.Location.X + operatorBox.Width + 6;
            int newY = operatorBox.Location.Y;

            // Check if the end of the new ComboBox would go past the GroupBox width + margin
            if (newX + newElementComboBox.Width > this.Width - 50)
            {
                newX = 13;
                newY += 30;
            }

            // Check if the bottom of the new ComboBox would interfere with the Save/Close button
            if (newY + newElementComboBox.Height > SaveButton.Location.Y - 10)
            {
                // remove the last operator combobox to indicate that nothing more may be added
                this.Controls.Remove(operatorBox);
                return; // Do not add the ComboBox if it interferes
            }

            newElementComboBox.Location = new Point(newX, newY);
            newElementComboBox.Size = new Size(121, 21);
            FillElementItems(newElementComboBox);
            this.Controls.Add(newElementComboBox);
            AddOperatorComboBox(newElementComboBox);
        }

        private void AddOperatorComboBox(ComboBox elementBox)
        {
            ComboBox newOperatorComboBox = new ComboBox();
            newOperatorComboBox.Name = "OperatorComboBox" + ++_conditionCount;

            // Check if the end of the new ComboBox would go past the GroupBox width + margin
            int newX = elementBox.Location.X + elementBox.Width + 6;
            int newY = elementBox.Location.Y;

            if (newX + newOperatorComboBox.Width > this.Width - 50)
            {
                newX = 13;
                newY += 30;
            }

            newOperatorComboBox.Location = new Point(newX, newY);
            newOperatorComboBox.Size = new Size(50, 21);
            FillOperatorItems(newOperatorComboBox);
            newOperatorComboBox.SelectionChangeCommitted += new EventHandler(OperatorComboBox1_SelectionChangeCommitted);
            this.Controls.Add(newOperatorComboBox);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.UpdateShapeData();
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
