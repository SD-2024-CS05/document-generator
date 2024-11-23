using Visio = Microsoft.Office.Interop.Visio;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Objects;
using ShapeHandler.ShapeTransformation;

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
