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
                        Text = "Input " + (count + 1),
                        AutoSize = true,
                        //Size = new Size(100, 32),
                        Location = new Point(20, y),
                        Margin = new Padding(4, 0, 4, 0)
                    };
                    ComboBox comboBox = new ComboBox
                    {
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
                        Name = "AddElement",
                        Size = new Size(79, 41),
                        TabIndex = 15,
                        Text = "...",
                        UseVisualStyleBackColor = true
                        //Click += new System.EventHandler(this.AddElement_Click);
                    };
                    Button deleteButton = new Button
                    {
                        Location = new Point(390, y),
                        Margin = new Padding(4),
                        Size = new Size(105, 40),
                        Text = "Delete",
                    };
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

        private void AddElement_Click(object sender, EventArgs e)
        {
//             if (HTMLOptions.SelectedItem != null) {
//                 var htmlElement = HTMLOptions.SelectedItem.ToString();
//                 InputForm inputForm = new InputForm();
//                 AnchorAttributesForm anchorAttributesForm = new AnchorAttributesForm();
//                 switch (htmlElement)
//                 {
//                     case "<input>": inputForm.ShowDialog(); break;
//                     case "<button>": inputForm.ShowDialog(); break;
//                     case "<select>": inputForm.ShowDialog(); break;
//                     case "<a>": anchorAttributesForm.ShowDialog(); break;
//                     case "<image>": inputForm.ShowDialog(); break;
//                 }
            }
            //if (HTMLOptions.SelectedItem != null) {
            //    var htmlElement = HTMLOptions.SelectedItem.ToString();
            //    InputForm inputForm = new InputForm(_shapeID);
            //    ButtonAttributesForm buttonAttributesForm = new ButtonAttributesForm();
            //    switch (htmlElement)
            //    {
            //        case "<input>": inputForm.ShowDialog(); break;
            //        case "<button>": buttonAttributesForm.ShowDialog(); break;
            //        case "<select>": inputForm.ShowDialog(); break;
            //        case "<a>": inputForm.ShowDialog(); break;
            //        case "<image>": inputForm.ShowDialog(); break;
            //    }
            //}
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _shapeDataForm.Close();
        }

        private void DeleteControlButton_Click(object sender, EventArgs e)
        {
            //Globals.ShapeDetector.Application.ActivePage.Cells
            foreach (Control label in Controls.OfType<Label>().ToList())
            {
                Controls.Remove(label);
            }
        }

        private void addControlButton_Click(object sender, EventArgs e)
        {
            int count = Controls.OfType<Label>().ToList().Count;
            int y;
            if (count != 0)
                y = Controls.OfType<Label>().ToList().Last().Location.Y + 45;
            else
                y = 20;
            Label label = new Label
            {
                Text = "Input " + (count + 1),
                AutoSize = true,
                //Size = new Size(100, 32),
                Location = new Point(20, y),
                Margin = new Padding(4, 0, 4, 0)
            };
            ComboBox comboBox = new ComboBox
            {
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
                Name = "AddElement",
                Size = new Size(79, 41),
                TabIndex = 15,
                Text = "...",
                UseVisualStyleBackColor = true
                //Click += new System.EventHandler(this.AddElement_Click);
            };
            Button deleteButton = new Button
            {
                Location = new Point(390, y),
                Margin = new Padding(4),
                Size = new Size(105, 40),
                Text = "Delete",
                //Click += EventHandler(DeleteControlButton_Click)
            };
            Controls.Add(label);
            Controls.Add(comboBox);
            Controls.Add(attributesButton);
            Controls.Add(deleteButton);
        }
    }
}