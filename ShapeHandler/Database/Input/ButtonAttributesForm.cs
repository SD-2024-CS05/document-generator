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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShapeHandler.Database.Input
{
    public partial class ButtonAttributesForm : Form
    {
        public ButtonAttributesForm()
        {
            InitializeComponent();
        }

        private void ButtonAttributesForm_Closing(object sender, FormClosingEventArgs e)
        {
            StringBuilder schema = new StringBuilder("{");
            schema.Append("{\"\"type\"\": \"\"" + typeTextBox.Text + "\"\", ");
            schema.Append("\"\"form\"\": \"\"" + formTextBox.Text + "\"\", ");
            schema.Append("\"\"form_action\"\": \"\"" + formActionTextBox.Text + "\"\", ");
            schema.Append("\"\"form_method\"\": \"\"" + formMethodTextBox.Text + "\"\", ");
            schema.Append("\"\"name\"\": \"\"" + nameTextBox.Text + "\"\"}}");
            Globals.ShapeDetector.Application.ActivePage.Shapes[1].get_CellsSRC(
                (short)VisSectionIndices.visSectionProp,
                (short)VisRowIndices.visRowFirst,
                (short)VisCellIndices.visCustPropsLabel
            ).FormulaU = "\"" + "Input 1" + "\"";
            Globals.ShapeDetector.Application.ActivePage.Shapes[1].get_CellsSRC(
                    (short)VisSectionIndices.visSectionProp,
                    (short)VisRowIndices.visRowFirst,
                    (short)VisCellIndices.visCustPropsValue
                ).FormulaU = "\"" + schema + "\"";
        }
    }
    }
}
