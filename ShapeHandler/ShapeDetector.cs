using Visio = Microsoft.Office.Interop.Visio;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;
using ShapeHandler.ShapeTransformation;
using System;
using ShapeHandler.Database;
using System.Windows.Forms;

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            // Uncomment for local testing
            //ShapeDetector.CreateGraphFromFlowchart(Globals.ShapeDetector.Application);
            this.Application.DocumentOpened += new Visio.EApplication_DocumentOpenedEventHandler(Application_DocumentOpened);
        }

        private void Application_DocumentOpened(Visio.Document doc)
        {
            this.Application.ActiveDocument.ShapeAdded += new Microsoft.Office.Interop.Visio.EDocument_ShapeAddedEventHandler(ActiveDocument_ShapeAdded);
        }

        private void ActiveDocument_ShapeAdded(Visio.IVShape shape)
        {
            // Show the form when the specific shape is added
            //this.Application.ActivePage.Shapes[1].AddRow((short)VisSectionIndices.visSectionProp, (short)VisRowIndices.visRowFirst, (short)VisRowTags.visTagDefault);

            //ShapeDataForm.Instance.Show();
            ShapeDataForm shapeDataForm = new ShapeDataForm(shape.ID);
            shapeDataForm.ShowDialog();
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {
            
        }

        public static HtmlGraph CreateGraphFromFlowchart(Visio.Application application)
        {
            Page page = application.ActivePage;
            HtmlGraph htmlGraph = ShapeReader.ConvertShapesToGraph(page.Shapes);
            // TODO: Implement
            return htmlGraph;
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
