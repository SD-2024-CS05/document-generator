using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Creates a Graph of the active Visio Document
        /// </summary>
        /// <returns></returns>
        public static HtmlGraph CreateGraph()
        {
            Console.WriteLine("Creating Graph");

            // get all pages
            List<short> pageIndexes = new List<short>();

            foreach (Page page in Globals.ShapeDetector.Application.ActiveDocument.Pages)
            {
                pageIndexes.Add(page.Index);
            }

            // combine all pages into one graph
            HtmlGraph graph = CombineGraphPages(pageIndexes);

            Console.WriteLine("Graph Created");

            return graph;
        }

        /// <summary>
        /// Makes a graph of the given page
        /// </summary>
        /// <param name="pageIndex">Index of the page to graph</param>
        /// <returns></returns>
        private static HtmlGraph GetGraphOfPage(int pageIndex)
        {
            HtmlGraph graph = new HtmlGraph();
            Page page = Globals.ShapeDetector.Application.ActiveDocument.Pages[pageIndex];

            foreach (Shape shape in page.Shapes)
            {
                string name = shape.Name;
                if (shape.Name.Contains("Start/End"))
                {
                }
                FlowchartNode element;
                //switch (name)
                //{
                //    case "Anchor":
                //        element = new Anchor(shape);
                //        break;
                //    case "Button":
                //        element = new Button(shape);
                //        break;
                //    case "Input":
                //        element = new Input(shape);
                //        break;
                //    case "Image":
                //        element = new Image(shape);
                //        break;
                //    case "Span":
                //        element = new Span(shape);
                //        break;
                //    case "Select":
                //        element = new Select(shape);
                //        break;
                //    default:
                //        break;
                //}
            }
            return graph;
        }

        /// <summary>
        /// Combines all the graphs of the pages into one graph
        /// </summary>
        /// <param name="pageIndexes">List of page indices to graph</param>
        /// <returns>Graph Object</returns>
        private static HtmlGraph CombineGraphPages(List<short> pageIndexes)
        {
            HtmlGraph graph = new HtmlGraph();
            foreach (short pageIndex in pageIndexes)
            {
                HtmlGraph pageGraph = GetGraphOfPage(pageIndex);
            }

            return graph;
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
