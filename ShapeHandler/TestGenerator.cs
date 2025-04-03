using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Visio;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using ShapeHandler.Database.StartEnd;
using ShapeHandler.Database;
using ShapeHandler.Objects;
using System.Windows.Forms;

namespace ShapeHandler
{
    public partial class TestGenerator
    {
        private void TestGenerator_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void EditNodeControl_Click(object sender, RibbonControlEventArgs e)
        {
            var shapes = Globals.ShapeDetector.Application.ActiveWindow.Selection;
            Shape shape = null;
            try
            {
                foreach (Shape selection in shapes)
                {
                    shape = selection;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("You must select a shape.");
            }
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
    }
}
