using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using Microsoft.Office.Interop.Visio;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;

namespace ShapeHandler.Database.Input
{
    public partial class AnchorAttributesForm : Form
    {
        private static int _shapeID;
        private static int _inputNum;

        public AnchorAttributesForm(int shapeID, int inputNum)
        {
            _shapeID = shapeID;
            _inputNum = inputNum;
            InitializeComponent();
        }

        private void AnchorAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            IHtmlAnchorElement anchor = document.CreateElement("a") as IHtmlAnchorElement;
            anchor.Id = idTextBox.Text;
            anchor.Href = hrefTextBox.Text;
            anchor.Download = downloadTextBox.Text;
            anchor.Target = targetTextBox.Text;
            var output = JsonConvert.SerializeObject(anchor, new HtmlElementSerializer());
            output = output.Replace("\"", "\"\"");
            VisioShapeDataHelper.AddShapeData(_shapeID, output, "Input " + _inputNum);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            this.Close();
        }
    }
}
