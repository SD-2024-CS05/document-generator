using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Visio;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using ShapeHandler.Database.StartEnd;
using ShapeHandler.Database;
using ShapeHandler.Objects;

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
            foreach (Shape selection in shapes)
            {
                shape = selection;
            }
            NodeType shapeType = VisioShapeDataHelper.GetNodeType(shape.ID);
            switch (shapeType)
            {
                case NodeType.DataInput:
                    ShapeDataForm shapeDataForm = new ShapeDataForm(shape.ID);
                    shapeDataForm.ShowDialog();
                    break;
                //case NodeType.StartEnd:
                //    HandleStartEndNode(shape);
                //    break;
                case NodeType.Decision:
                    DecisionControlsForm decisionControlsForm = new DecisionControlsForm(shape.ID);
                    decisionControlsForm.ShowDialog();
                    break;
                //case NodeType.Connection:
                //    HandleConnectionNode(shape);
                //    break;
                case NodeType.UserProcess:
                    break;
                case NodeType.BackgroundProcess:
                    break;
                case NodeType.Page:
                    //StartEndForm pageUrlForm = new StartEndForm();
                    //pageUrlForm.ShowDialog();
                    //VisioShapeDataHelper.AddShapeData(shape.ID, pageUrlForm.URL, "URL");
                    break;
                default:
                    break;
            }
        }
    }
}
