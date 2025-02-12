using AngleSharp.Html.Dom;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
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
            else
            {
                _activeShape.AddRow(
                    (short)Visio.VisSectionIndices.visSectionProp,
                    (short)Visio.VisRowIndices.visRowLast,
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

        public static Dictionary<string, object> GetShapeData(int shapeId)
        {
            var shapeData = new Dictionary<string, object>();
            _activeShape = Globals.ShapeDetector.Application.ActivePage.Shapes[shapeId];

            int rowCount = _activeShape.get_RowCount((short)Visio.VisSectionIndices.visSectionProp);
            for (int i = 0; i < rowCount; i++)
            {
                string label = _activeShape.get_CellsSRC(
                    (short)Visio.VisSectionIndices.visSectionProp,
                    (short)i,
                    (short)Visio.VisCellIndices.visCustPropsLabel).ResultStrU["Value"];

                string value = _activeShape.get_CellsSRC(
                    (short)Visio.VisSectionIndices.visSectionProp,
                    (short)i,
                    (short)Visio.VisCellIndices.visCustPropsValue).ResultStrU["Value"];

                shapeData[label] = value;
            }

            return shapeData;
        }

        public static List<IHtmlElement> GetHtmlElements(int shapeId)
        {
            var shapeData = GetShapeData(shapeId);
            var htmlElements = new List<IHtmlElement>();
            foreach (var data in shapeData)
            {
                try
                {
                    var htmlElement = JsonConvert.DeserializeObject<IHtmlElement>(data.Value.ToString(), new HtmlElementSerializer());
                    if (htmlElement != null)
                    {
                        htmlElements.Add(htmlElement);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return htmlElements;
        }

        public static bool CheckIfRowsExist(int shapeId)
        {
            _activeShape = Globals.ShapeDetector.Application.ActivePage.Shapes[shapeId];
            return _activeShape.get_RowCount((short)Visio.VisSectionIndices.visSectionProp) != 0;
        }

        private static void SetShapeData(Visio.VisCellIndices cellIndex, string value)
        {
            _activeShape.get_CellsSRC(
                (short)Visio.VisSectionIndices.visSectionProp,
                (short)Visio.VisRowIndices.visRowLast,
                (short)cellIndex
            ).FormulaU = FormatVal(value);
        }

        private static string FormatVal(string val)
        {
            return "\"" + val.Replace("\"", "\"\"") + "\"";
        }

    }
}
