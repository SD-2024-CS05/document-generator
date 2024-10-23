using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Visio;

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
        public static Graph CreateGraph()
        {
            Console.WriteLine("Creating Graph");

            // get all pages
            List<short> pageIndexes = new List<short>();

            foreach (Page page in Globals.ShapeDetector.Application.ActiveDocument.Pages)
            {
                pageIndexes.Add(page.Index);
            }

            // combine all pages into one graph
            Graph graph = CombineGraphPages(pageIndexes);

            Console.WriteLine("Graph Created");

            return graph;
        }

        /// <summary>
        /// Makes a graph of the given page
        /// </summary>
        /// <param name="pageIndex">Index of the page to graph</param>
        /// <returns></returns>
        private static Graph GetGraphOfPage(int pageIndex)
        {
            Graph graph = new Graph();
            Page page = Globals.ShapeDetector.Application.ActiveDocument.Pages[pageIndex];

            foreach (Shape shape in page.Shapes)
            {
                string name = shape.Name;
                if (shape.Name.Contains("Start/End"))
                {
                }
                WebElement element;
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
        private static Graph CombineGraphPages(List<short> pageIndexes)
        {
            Graph graph = new Graph();
            foreach (short pageIndex in pageIndexes)
            {
                Graph pageGraph = GetGraphOfPage(pageIndex);
                graph.CombineGraphs(pageGraph);
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
