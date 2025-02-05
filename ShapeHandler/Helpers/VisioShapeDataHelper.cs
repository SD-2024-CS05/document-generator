using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visio = Microsoft.Office.Interop.Visio;

namespace ShapeHandler.Objects
{
    public static class VisioShapeDataHelper
    {
        private static Visio.Shape _activeShape;
        public static void AddShapeData(int shapeId, string schema, string label = "Input 1")
        {
            _activeShape = Globals.ShapeDetector.Application.ActivePage.Shapes[shapeId];
            // check first if there is a row available
            if (_activeShape.get_RowCount((short)Visio.VisSectionIndices.visSectionProp) == 0)
            {
                _activeShape.AddRow(
                    (short)Visio.VisSectionIndices.visSectionProp,
                    (short)Visio.VisRowIndices.visRowFirst, 
                    (short)Visio.VisRowTags.visTagDefault);
            }
            try
            {
                SetShapeData(Visio.VisCellIndices.visCustPropsLabel, label);
                SetShapeData(Visio.VisCellIndices.visCustPropsValue, schema);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
            }
        }

        private static void SetShapeData(Visio.VisCellIndices cellIndex, string value)
        {

            _activeShape.get_CellsSRC(
                (short)Visio.VisSectionIndices.visSectionProp,
                (short)Visio.VisRowIndices.visRowFirst,
                (short)cellIndex
            ).FormulaU = FormatVal(value);
        }

        private static string FormatVal(string val)
        {
            return "\"" + val + "\"";
        }
    }
}
