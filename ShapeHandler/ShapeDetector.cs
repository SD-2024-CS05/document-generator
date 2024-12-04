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

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private ShapeDataForm shapeForm = new ShapeDataForm();
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            // Uncomment for local testing
            //ShapeDetector.CreateGraphFromFlowchart(Globals.ShapeDetector.Application);
            this.Application.DocumentOpened += new Visio.EApplication_DocumentOpenedEventHandler(Application_DocumentOpened);
            shapeForm.Text = "VSTO Add-in Form";
        }

        private void Application_DocumentOpened(Visio.Document doc)
        {
            this.Application.ActiveDocument.ShapeAdded += new Microsoft.Office.Interop.Visio.EDocument_ShapeAddedEventHandler(ActiveDocument_ShapeAdded);
        }

        private void ActiveDocument_ShapeAdded(Visio.IVShape shape)
        {
            // Show the form when the specific shape is added
            shapeForm.Show();
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {
            
        }

        public static HtmlGraph CreateGraphFromFlowchart(Visio.Application application)
        {
            HtmlGraph graph = new HtmlGraph();

            // TODO: Implement

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
