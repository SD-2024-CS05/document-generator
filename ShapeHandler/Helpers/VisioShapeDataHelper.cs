using AngleSharp.Html.Dom;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// Adds shape data to the specified shape.
        /// </summary>
        /// <param name="shapeId">The ID of the shape.</param>
        /// <param name="schema">The schema to add to the shape.</param>
        /// <param name="label">The label for the shape data. Default is "Input 1".</param>
        public static void AddShapeData(int shapeId, string schema, string label = "Input 1")
        {
            _activeShape = Globals.ShapeDetector.Application.ActivePage.Shapes.get_ItemFromID(shapeId);
            // check first if there is a row available
            short rowPlacement = _activeShape.get_RowCount((short)Visio.VisSectionIndices.visSectionProp) == 0
                ? (short)Visio.VisRowIndices.visRowFirst
                : (short)Visio.VisRowIndices.visRowLast;

            try
            {
                _activeShape.AddRow(
                    (short)Visio.VisSectionIndices.visSectionProp,
                    rowPlacement,
                    (short)Visio.VisRowTags.visTagDefault);
                SetShapeData(Visio.VisCellIndices.visCustPropsLabel, label);
                SetShapeData(Visio.VisCellIndices.visCustPropsValue, schema);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Retrieves the shape data for the specified shape.
        /// </summary>
        /// <param name="shapeId">The ID of the shape.</param>
        /// <returns>A dictionary containing the shape data.</returns>
        public static Dictionary<string, object> GetShapeData(int shapeId)
        {
            var shapeData = new Dictionary<string, object>();
            try
            {
                _activeShape = Globals.ShapeDetector.Application.ActivePage.Shapes.get_ItemFromID(shapeId);
            }
            catch (Exception)
            {
                return shapeData;
            }

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

        /// <summary>
        /// Gets the node type of the specified shape.
        /// </summary>
        /// <param name="shapeId">The ID of the shape.</param>
        /// <returns>The node type of the shape.</returns>
        public static NodeType GetNodeType(int shapeId)
        {
            // node type is the first row of the shape data
            var shapeData = GetShapeData(shapeId);
            if (shapeData.ContainsKey("Node Type"))
            {
                try
                {
                    if (NodeType.TryParse(shapeData["Node Type"].ToString(), true, out NodeType nodeType))
                    {
                        return nodeType;
                    }

                    return NodeType.None;
                }
                catch (Exception)
                {
                    return NodeType.None;
                }
            }
            return NodeType.None;
        }

        /// <summary>
        /// Retrieves the HTML elements associated with the specified shape.
        /// </summary>
        /// <param name="shapeId">The ID of the shape.</param>
        /// <returns>A list of HTML elements associated with the shape.</returns>
        public static List<IHtmlElement> GetHtmlElements(int shapeId)
        {
            var shapeData = GetShapeData(shapeId);
            var htmlElements = new List<IHtmlElement>();
            // skip the first row since it is the node type
            foreach (var data in shapeData.Skip(1))
            {
                try
                {
                    var htmlElement = JsonConvert.DeserializeObject<IHtmlElement>(data.Value.ToString(), new HtmlElementSerializer());
                    if (htmlElement != null)
                    {
                        htmlElements.Add(htmlElement);
                    }
                }
                catch { }
            }
            return htmlElements;
        }

        /// <summary>
        /// Gets the node type of the specified HTML element.
        /// </summary>
        /// <param name="htmlElement">The HTML element.</param>
        /// <returns>The node type of the HTML element.</returns>
        public static NodeType GetHtmlElementNodeType(IHtmlElement htmlElement)
        {
            switch (htmlElement)
            {
                case IHtmlButtonElement _:
                    return NodeType.Button;
                case IHtmlAnchorElement _:
                    return NodeType.Anchor;
                case IHtmlInputElement _:
                    return NodeType.Input;
                case IHtmlImageElement _:
                    return NodeType.Image;
                case IHtmlSelectElement _:
                    return NodeType.Select;
                default:
                    return NodeType.HtmlElement;
            }
        }

        /// <summary>
        /// Checks if rows exist in the shape data for the specified shape.
        /// </summary>
        /// <param name="shapeId">The ID of the shape.</param>
        /// <returns>True if rows exist, otherwise false.</returns>
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
