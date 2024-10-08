using Microsoft.Office.Tools.Ribbon;

namespace ShapeHandler
{
    partial class TestGenerator : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public TestGenerator()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void HandleTestGenerationClick(object sender, RibbonControlEventArgs e)
        {
            ShapeDetector.CreateGraph();
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestGenerator));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.TestGenerationButton = this.Factory.CreateRibbonButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabData";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabData";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.TestGenerationButton);
            this.group1.Label = "Test Generation";
            this.group1.Name = "group1";
            this.group1.Position = this.Factory.RibbonPosition.AfterOfficeId("GroupAdvancedDataLinking");
            // 
            // TestGenerationButton
            // 
            this.TestGenerationButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.TestGenerationButton.Image = ((System.Drawing.Image)(resources.GetObject("TestGenerationButton.Image")));
            this.TestGenerationButton.Label = "Generate Tests";
            this.TestGenerationButton.Name = "TestGenerationButton";
            this.TestGenerationButton.ShowImage = true;
            this.TestGenerationButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.HandleTestGenerationClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TestGenerator
            // 
            this.Name = "TestGenerator";
            this.RibbonType = "Microsoft.Visio.Drawing";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.TestGenerator_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TestGenerationButton;
        private System.Windows.Forms.ImageList imageList1;
    }


    partial class ThisRibbonCollection
    {
        internal TestGenerator TestGenerator
        {
            get { return this.GetRibbon<TestGenerator>(); }
        }
    }
}
