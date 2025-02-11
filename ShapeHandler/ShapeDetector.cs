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
        private Visio.Document _activeDocument = null;
        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            // Uncomment for local testing
            //ShapeDetector.CreateGraphFromFlowchart(Globals.ShapeDetector.Application);
            this.Application.DocumentOpened += new Visio.EApplication_DocumentOpenedEventHandler(Application_DocumentOpened);
            this.Application.DocumentCreated += new Visio.EApplication_DocumentCreatedEventHandler(Application_DocumentCreated);
        }

        private void Application_DocumentCreated(Visio.Document doc)
        {
            var stencilPath = FileManager.GetFilePath("Stencil/CS05-stencil.vssx");

            if (!string.IsNullOrEmpty(stencilPath))
            {
                this.Application.Documents.OpenEx(stencilPath, (short)VisOpenSaveArgs.visOpenDocked);
            }
            else
            {
                MessageBox.Show("Could not find the stencil");
            }
            Application_DocumentOpened(doc);
        }

        private void Application_DocumentOpened(Visio.Document doc)
        {
            if (_activeDocument != this.Application.ActiveDocument)
            {
                _activeDocument = this.Application.ActiveDocument;
                try
                {
                    _activeDocument.ShapeAdded += new Visio.EDocument_ShapeAddedEventHandler(ActiveDocument_ShapeAdded);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void ActiveDocument_ShapeAdded(Visio.IVShape shape)
        {
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
