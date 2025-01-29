using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Visio;
using Visio = Microsoft.Office.Interop.Visio;

namespace ShapeHandler.Database
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void InputForm_Closing(object sender, FormClosingEventArgs e)
        {
            StringBuilder schema = new StringBuilder("{");
            schema.Append("\"\"type\"\": \"\"" + typeTextBox.Text + "\"\", ");
            schema.Append("\"\"id\"\": \"\"" + idTextBox.Text + "\"\", ");
            schema.Append("\"\"name\"\": \"\"" + nameTextBox.Text + "\"\", ");
            schema.Append("\"\"value\"\": \"\"" + valueTextBox.Text + "\"\", ");
            schema.Append("\"\"min\"\": \"\"" + minTextBox.Text + "\"\", ");
            schema.Append("\"\"max\"\": \"\"" + maxTextBox.Text + "\"\", ");
            schema.Append("\"\"class\"\": \"\"" + classTextBox.Text + "\"\", ");
            schema.Append("\"\"style\"\": \"\"" + styleTextBox.Text + "\"\", ");
            schema.Append("\"\"placeholder\"\": \"\"" + placeholderTextBox.Text + "\"\"}");
            Globals.ShapeDetector.Application.ActivePage.Shapes[1].get_CellsSRC(
                (short)VisSectionIndices.visSectionProp,
                (short)VisRowIndices.visRowLast,
                (short)VisCellIndices.visCustPropsLabel
            ).FormulaU = "\"" + "Input 1" + "\"";
            Globals.ShapeDetector.Application.ActivePage.Shapes[1].get_CellsSRC(
                    (short)VisSectionIndices.visSectionProp,
                    (short)VisRowIndices.visRowLast,
                    (short)VisCellIndices.visCustPropsValue
                ).FormulaU = "\"" + schema + "\"";
        }
    }
}
