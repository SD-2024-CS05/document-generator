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

namespace ShapeHandler.Database.Input
{
    public partial class AnchorAttributesForm : Form
    {
        public AnchorAttributesForm()
        {
            InitializeComponent();
        }

        private void AnchorAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StringBuilder schema = new StringBuilder("{");
            schema.Append("{\"\"type\"\": \"\"" + typeTextBox.Text + "\"\", ");
            schema.Append("{\"\"id\"\": \"\"" + typeTextBox.Text + "\"\", ");
            schema.Append("\"\"href\"\": \"\"" + hrefTextBox.Text + "\"\", ");
            schema.Append("\"\"rel\"\": \"\"" + relTextBox.Text + "\"\"}}");
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
