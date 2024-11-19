using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;
using ShapeHandler.Identity;
using ShapeHandler.Database;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            // Uncomment for local testing
            //ShapeDetector.CreateGraphFromFlowchart(Globals.ShapeDetector.Application);
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {
        }

        public static HtmlGraph CreateGraphFromFlowchart(Visio.Application application)
        {
            Page page = application.ActivePage;
            IDictionary<string, IDictionary<string, string>> shapesFromVisio = FetchShapesFromVisio(page.Shapes);
            HtmlGraph graph = new HtmlGraph();
            // TODO: Implement
            return null;
        }

        /// <summary>
        /// Intakes shapes from Visio
        /// </summary>
        /// <param name="shapes">Visio shapes</param>
        /// <returns>Inner dictionary with shapes and their properties</returns>
        private static IDictionary<string, IDictionary<string, string>> FetchShapesFromVisio(Shapes shapes)
        {
            IDictionary<string, IDictionary<string, string>> shapeData = new Dictionary<string, IDictionary<string, string>>();
            foreach (Shape shape in shapes)
            {
                IDictionary<string, string> properties = ReadShapeData(shape);
                shapeData[shape.Text] = properties;
            }
            return shapeData;
        }

        /// <summary>
        /// Reads shape data from a given Visio shape
        /// </summary>
        /// <param name="shape">Visio shape</param>
        /// <returns>Dictionary of a shape data's labels as keys and values as values</returns>
        private static IDictionary<string, string> ReadShapeData(Shape shape)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();
            short iRow = (short)VisRowIndices.visRowFirst;
            while (shape.get_CellsSRCExists(
                (short)VisSectionIndices.visSectionProp,
                iRow,
                (short)VisCellIndices.visCustPropsValue,
                (short)0) != 0)
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
                properties.Add(label, value);
                iRow++;
            }
            return properties;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ShapeDetector_Startup);
            this.Shutdown += new System.EventHandler(ShapeDetector_Shutdown);
        }

        #endregion
    }
}
