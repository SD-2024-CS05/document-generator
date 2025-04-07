using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Visio;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using ShapeHandler.Database.StartEnd;
using ShapeHandler.Database;
using ShapeHandler.Objects;
using System.Windows.Forms;
using System;

namespace ShapeHandler
{
    public partial class TestGenerator
    {
        private void TestGenerator_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void EditNodeControl_Click(object sender, RibbonControlEventArgs e)
        {
            Selection selection = Globals.ShapeDetector.Application.ActiveWindow.Selection;
            if (selection != null && selection.Count == 1)
            {
                Shape shape = selection.PrimaryItem;
                NodeType shapeType = VisioShapeDataHelper.GetNodeType(shape.ID);
                switch (shapeType)
                {
                    case NodeType.DataInput:
                        ShapeDataForm shapeDataForm = new ShapeDataForm(shape.ID);
                        shapeDataForm.ShowDialog();
                        break;
                    case NodeType.StartEnd:
                        string url = VisioShapeDataHelper.GetShapeData(shape.ID)["URL"].ToString();
                        StartEndForm startEndForm = new StartEndForm(url);
                        startEndForm.ShowDialog();
                        VisioShapeDataHelper.UpdateRow(shape.ID, "URL", startEndForm.URL);
                        break;
                    case NodeType.Decision:
                        DecisionControlsForm decisionControlsForm = new DecisionControlsForm(shape.ID);
                        decisionControlsForm.ShowDialog();
                        break;
                    case NodeType.Page:
                        url = VisioShapeDataHelper.GetShapeData(shape.ID)["URL"].ToString();
                        StartEndForm pageUrlForm = new StartEndForm(url);
                        pageUrlForm.ShowDialog();
                        VisioShapeDataHelper.UpdateRow(shape.ID, "URL", pageUrlForm.URL); ;
                        break;
                    default:
                        MessageBox.Show("You must select a valid shape.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("You must select one shape.");
            }
        }
    }
}
