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
using AngleSharp;
using Microsoft.Office.Interop.Visio;
using AngleSharp.Html.Dom;

namespace ShapeHandler.Database.Input
{
    public partial class AnchorAttributesForm : Form
    {
        private static int _shapeID;

        private IDocument _document;

        public AnchorAttributesForm(int shapeId)
        {
            _shapeID = shapeId;
            InitializeComponent();

            BrowsingContext context = new BrowsingContext(Configuration.Default);
            _document = context.OpenNewAsync().Result;

            IHtmlAnchorElement anchor = _document.CreateElement("a") as IHtmlAnchorElement;

            iHtmlAnchorElementBindingSource.Add(anchor);
        }

        private void AnchorAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;

            // get all anchor elements added, note that not all the columns are bound to the data source
            var anchors = iHtmlAnchorElementBindingSource.List.OfType<IHtmlAnchorElement>().ToList();

            foreach (var anchor in anchors)
            {
                var gridRow = anchorAttributeDataGrid.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.DataBoundItem == anchor);
                if (gridRow != null)
                {
                    anchor.Id = gridRow.Cells["idDataGridViewTextBoxColumn"].Value?.ToString();
                    anchor.Target = gridRow.Cells["targetDataGridViewTextBoxColumn"].Value?.ToString();
                    anchor.ClassName = gridRow.Cells["classesDataGridViewTextBoxColumn"].Value?.ToString();
                }
            }

            return;
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

        private void AddAnchorButton_Click(object sender, EventArgs e)
        {
            var newAnchor = _document.CreateElement("a") as IHtmlAnchorElement;
            iHtmlAnchorElementBindingSource.Add(newAnchor);
        }

        private void RemoveAnchorButton_Click(object sender, EventArgs e)
        {
            if (iHtmlAnchorElementBindingSource.Current is IHtmlAnchorElement selectedAnchor 
                && selectedAnchor != null)
            {
                iHtmlAnchorElementBindingSource.Remove(selectedAnchor);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
