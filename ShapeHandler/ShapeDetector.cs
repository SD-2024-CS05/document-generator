using Microsoft.Office.Interop.Visio;
using ShapeHandler.Database;
using ShapeHandler.Database.Decision;
using ShapeHandler.Database.StartEnd;
using ShapeHandler.Objects;
using ShapeHandler.ShapeTransformation;
using System;
using System.Windows.Forms;
using Visio = Microsoft.Office.Interop.Visio;

namespace ShapeHandler
{
    public partial class ShapeDetector
    {
        private Visio.Document _activeDocument = null;
        private bool _hasStartNode = false;
        private bool _hasEndNode = false;

        private void ShapeDetector_Startup(object sender, System.EventArgs e)
        {
            // Uncomment for local testing
            //ShapeDetector.CreateGraphFromFlowchart(Globals.ShapeDetector.Application);
            this.Application.DocumentOpened += new Visio.EApplication_DocumentOpenedEventHandler(Application_DocumentOpened);
            this.Application.DocumentCreated += new Visio.EApplication_DocumentCreatedEventHandler(Application_DocumentCreated);
            this.Application.BeforeDocumentSave += new Visio.EApplication_BeforeDocumentSaveEventHandler(Application_DocumentSave);
            this.Application.BeforeDocumentSaveAs += new Visio.EApplication_BeforeDocumentSaveAsEventHandler(Application_DocumentSave);
        }

        private void Application_DocumentSave(Visio.Document doc)
        {
            ShapeReader.SaveNodeMappingToDocument(doc);
        }

        private void Application_DocumentCreated(Visio.Document doc)
        {
            var stencilPath = FileManager.GetFilePath("Resources/CS05-stencil.vssx");

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
                    ShapeReader.LoadNodeMappingFromDocument(_activeDocument);
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
            var shapeType = VisioShapeDataHelper.GetNodeType(shape.ID);

            switch (shapeType)
            {
                case NodeType.DataInput:
                    ShapeDataForm shapeDataForm = new ShapeDataForm(shape.ID);
                    shapeDataForm.ShowDialog();
                    break;
                case NodeType.StartEnd:
                    HandleStartEndNode(shape);
                    break;
                case NodeType.Decision:
                    DecisionControlsForm decisionControlsForm = new DecisionControlsForm(shape.ID);
                    decisionControlsForm.ShowDialog();
                    break;
                case NodeType.Connection:
                    HandleConnectionNode(shape);
                    break;
                case NodeType.UserProcess:
                    break;
                case NodeType.BackgroundProcess:
                    break;
                case NodeType.Page:
                    StartEndForm pageUrlForm = new StartEndForm();
                    pageUrlForm.ShowDialog();
                    VisioShapeDataHelper.AddShapeData(shape.ID, pageUrlForm.URL, "URL");
                    break;
                default:
                    break;
            }
        }

        private void HandleStartEndNode(Visio.IVShape shape)
        {
            if (!_hasStartNode)
            {
                _hasStartNode = true;
                StartEndForm startEndForm = new StartEndForm();
                startEndForm.ShowDialog();
                VisioShapeDataHelper.AddShapeData(shape.ID, startEndForm.URL, "URL");
                VisioShapeDataHelper.AddShapeData(shape.ID, true.ToString(), "IsStart");
                MessageBox.Show("Start node added");
            }
            else if (!_hasEndNode)
            {
                _hasEndNode = true;
                StartEndForm startEndForm = new StartEndForm();
                startEndForm.ShowDialog();
                VisioShapeDataHelper.AddShapeData(shape.ID, startEndForm.URL, "URL");
                VisioShapeDataHelper.AddShapeData(shape.ID, false.ToString(), "IsStart");

                MessageBox.Show("End node added");
            }
            else
            {
                MessageBox.Show("There can only be one start and end node");
                shape.Delete();
            }
        }

        private void HandleConnectionNode(Visio.IVShape shape)
        {
            var decisionId = ShapeReader.IsConnectionFromDecisionNode((Shape)shape);

            if (decisionId == -1)
            {
                return;
            }

            bool validDecision = ShapeReader.IsValidDecisionConnection((Shape)shape);
            Shape decisionShape = Globals.ShapeDetector.Application.ActivePage.Shapes.get_ItemFromID(decisionId);

            DecisionNode decisionNode = ShapeReader.GetBoundDecisionNode((Shape)shape);
            DataInputNode dataInputNode = ShapeReader.GetBoundDataInputNode(decisionShape);

            // if the decision node is not valid or the decision node is null
            if (!validDecision || decisionNode == null)
            {
                MessageBox.Show("Invalid connection");
                shape.Delete();
                return;
            }

            ConnectionForm connectionForm = new ConnectionForm(shape.ID, decisionNode, dataInputNode);
            connectionForm.ShowDialog();

            // if connection not saved
            if (connectionForm.Connection == null)
            {
                MessageBox.Show("Connection not saved");
                shape.Delete();
            }
        }

        private void ShapeDetector_Shutdown(object sender, System.EventArgs e)
        {

        }

        public static HtmlGraph CreateGraphFromFlowchart(Visio.Application application)
        {
            Page page = application.ActivePage;
            HtmlGraph htmlGraph = ShapeReader.ConvertShapesToGraph(page.Shapes);
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
