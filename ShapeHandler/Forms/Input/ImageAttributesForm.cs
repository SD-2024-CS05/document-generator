using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShapeHandler.Database.Input
{
    public partial class ImageAttributesForm : Form
    {
        private IDocument _document;

        public List<IHtmlImageElement> Elements { get; private set; } = new List<IHtmlImageElement>();

        public ImageAttributesForm()
        {
            InitializeComponent();
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            _document = document;

            iHtmlImageElementBindingSource.Add(_document.CreateElement<IHtmlImageElement>());
        }

        private void ImageAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            // get all the image elements
            var imageElements = iHtmlImageElementBindingSource.List.Cast<IHtmlImageElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (var imageElement in imageElements)
            {
                var row = ImageDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == imageElement);
                if (row != null)
                {
                    imageElement.Id = row.Cells["IdColumn"]?.Value?.ToString();
                }
            }
            Elements = imageElements;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlImageElementBindingSource.List.Count > 0)
            {
                UpdateShapeData();
            }
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            iHtmlImageElementBindingSource.Add(_document.CreateElement<IHtmlImageElement>());
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            iHtmlImageElementBindingSource.RemoveCurrent();
        }
    }
}
