using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Database.Input;

namespace ShapeHandler.Database
{
    public partial class ShapeDataForm : Form
    {
        private static int _shapeID;
        private static ShapeDataForm _shapeDataForm = null;

        public ShapeDataForm(int shapeID)
        {
            InitializeComponent();
            _shapeID = shapeID;
        }

        private static IDictionary<string, string> GetControls(Shape shape)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();
            short iRow = (short)VisRowIndices.visRowFirst;
            while (
                shape.get_CellsSRCExists
                (
                    (short)VisSectionIndices.visSectionProp,
                    iRow,
                    (short)VisCellIndices.visCustPropsValue,
                    0
                ) < 0)
            {
                string label = shape.get_CellsSRC(
                        (short)VisSectionIndices.visSectionProp,
                        iRow,
                        (short)VisCellIndices.visCustPropsLabel
                    ).get_ResultStr(VisUnitCodes.visNoCast);
                string value = shape.get_CellsSRC(
                        (short)VisSectionIndices.visSectionProp,
                        iRow,
                        (short)VisCellIndices.visCustPropsValue
                    ).get_ResultStr(VisUnitCodes.visNoCast);
                if (label.StartsWith("Input"))
                    properties.Add(label, value);
                iRow++;
            }
            return properties;
        }

        private void ShapeDataForm_Load(object sender, EventArgs e)
        {
            IDictionary<string, string> controls = GetControls(Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID]);
            if (controls.Count > 0)
            {
                foreach (KeyValuePair<string, string> control in controls)
                {
                    Label label = new Label();
                    label.Text = control.Key;
                    TextBox textBox = new TextBox();
                    textBox.Text = control.Value;
                    this.Controls.Add(label);
                    this.Controls.Add(textBox);
                }
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    int count = Controls.OfType<Label>().ToList().Count;
                    int y;
                    if (count != 0)
                        y = Controls.OfType<Label>().ToList().Last().Location.Y + 45;
                    else
                        y = 20;
                    Label label = new Label
                    {
                        Name = "controlLabel_" + (count + 1),
                        Text = "Input " + (count + 1),
                        AutoSize = true,
                        //Size = new Size(100, 32),
                        Location = new Point(20, y),
                        Margin = new Padding(4, 0, 4, 0)
                    };
                    ComboBox comboBox = new ComboBox
                    {
                        Name = "controlOptionsComboBox_" + (count + 1),
                        Size = new Size(160, 40),
                        Margin = new Padding(4),
                        Location = new Point(135, y),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    comboBox.Items.AddRange(new object[] {
                        "<input>",
                        "<button>",
                        "<select>",
                        "<a>",
                        "<img>"
                    });
                    Button attributesButton = new Button
                    {
                        Location = new Point(303, y),
                        Margin = new Padding(4),
                        Name = "controlAttributes_" + (count + 1),
                        Size = new Size(79, 41),
                        TabIndex = 15,
                        Text = "...",
                        UseVisualStyleBackColor = true
                    };
                    attributesButton.Click += new EventHandler(ControlAttributes_Click);
                    Button deleteButton = new Button
                    {
                        Name = "deleteControl_" + (count + 1),
                        Location = new Point(390, y),
                        Margin = new Padding(4),
                        Size = new Size(105, 40),
                        Text = "Delete",
                    };
                    deleteButton.Click += new EventHandler(DeleteControlButton_Click);
                    Controls.Add(label);
                    Controls.Add(comboBox);
                    Controls.Add(attributesButton);
                    Controls.Add(deleteButton);
                }
            }
        }

        public static ShapeDataForm Instance
        {
            get
            {
                if (_shapeDataForm == null)
                {
                    _shapeDataForm = new ShapeDataForm(_shapeID);
                }
                return _shapeDataForm;
            }
        }

        private void ShapeDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _shapeDataForm = null;
        }

        private void ControlAttributes_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = int.Parse(button.Name.Split('_')[1]);
            ComboBox lol = (ComboBox)Controls.Find("controlOptionsComboBox_" + index, true)[0];
            if (lol.SelectedItem != null)
            {
                var htmlElement = lol.SelectedItem.ToString();
                InputForm inputForm = new InputForm(_shapeID, index);
                ButtonAttributesForm buttonAttributesForm = new ButtonAttributesForm(_shapeID, index);
                switch (htmlElement)
                {
                    case "<input>": inputForm.ShowDialog(); break;
                    case "<button>": buttonAttributesForm.ShowDialog(); break;
                    case "<select>": inputForm.ShowDialog(); break;
                    case "<a>": inputForm.ShowDialog(); break;
                    case "<image>": inputForm.ShowDialog(); break;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _shapeDataForm.Close();
        }

        private void DeleteControlButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = int.Parse(button.Name.Split('_')[1]);
            Controls.Remove(Controls.Find("controlLabel_" + index, true)[0]);
            Controls.Remove(Controls.Find("controlOptionsComboBox_" + index, true)[0]);
            Controls.Remove(Controls.Find("controlAttributes_" + index, true)[0]);
            Controls.Remove(button);

            int lol = 0;
            //Rearranging the Location controls.
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn != addControlButton && btn != okayButton && btn != cancelButton && btn.Name.Split('_')[0] != "controlAttributes")
                {
                    int controlIndex = int.Parse(btn.Name.Split('_')[1]);
                    if (controlIndex > index)
                    {
                        Label label = (Label)Controls.Find("controlLabel_" + controlIndex, true)[0];
                        ComboBox comboBox = (ComboBox)Controls.Find("controlOptionsComboBox_" + controlIndex, true)[0];
                        Button attributes = (Button)Controls.Find("controlAttributes_" + controlIndex, true)[0];
                        label.Top = label.Top - 30;
                        comboBox.Top = comboBox.Top - 30;
                        attributes.Top = attributes.Top - 30;
                        btn.Top = btn.Top - 30;
                        label.Name = "controlLabel_" + (index + lol);
                        label.Text = "Input " + (index + lol);
                        label.Name = "controlOptionsComboBox_" + (index + lol);
                        attributes.Name = "controlAttributes_" + (index + lol);
                        btn.Name = "deleteControl_" + (index + lol);
                        lol++;
                    }
                }
            }
        }

        private void AddControlButton_Click(object sender, EventArgs e)
        {
            int count = Controls.OfType<Label>().ToList().Count;
            int y;
            if (count != 0)
                y = Controls.OfType<Label>().ToList().Last().Location.Y + 45;
            else
                y = 20;
            Label label = new Label
            {
                Name = "controlLabel_" + (count + 1),
                Text = "Input " + (count + 1),
                AutoSize = true,
                //Size = new Size(100, 32),
                Location = new Point(20, y),
                Margin = new Padding(4, 0, 4, 0)
            };
            ComboBox comboBox = new ComboBox
            {
                Name = "controlOptionsComboBox_" + (count + 1),
                Size = new Size(160, 40),
                Margin = new Padding(4),
                Location = new Point(135, y),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBox.Items.AddRange(new object[] {
                        "<input>",
                        "<button>",
                        "<select>",
                        "<a>",
                        "<img>"
                    });
            Button attributesButton = new Button
            {
                Name = "controlAttributes_" + (count + 1),
                Location = new Point(303, y),
                Margin = new Padding(4),
                Size = new Size(79, 41),
                TabIndex = 15,
                Text = "...",
                UseVisualStyleBackColor = true
            };
            attributesButton.Click += new System.EventHandler(this.ControlAttributes_Click);
            Button deleteButton = new Button
            {
                Name = "deleteControl_" + (count + 1),
                Location = new Point(390, y),
                Margin = new Padding(4),
                Size = new Size(105, 40),
                Text = "Delete",
            };
            deleteButton.Click += new EventHandler(DeleteControlButton_Click);
            Controls.Add(label);
            Controls.Add(comboBox);
            Controls.Add(attributesButton);
            Controls.Add(deleteButton);
        }
    }
}