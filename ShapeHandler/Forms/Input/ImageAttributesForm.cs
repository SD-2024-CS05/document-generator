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
using ShapeHandler.Forms;

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

            ImageDataGridView.CellContentClick += new DataGridViewCellEventHandler(ImageAddClasses);
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

                    // get the classes for the image element
                    var classes = row.Cells["ImageClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (var className in classes.Split(','))
                        {
                            imageElement.ClassList.Add(className);
                        }
                    }
                }
            }
            Elements = imageElements;
        }

        private void ImageAddClasses(object sender, EventArgs e)
        {
            if (ImageDataGridView.CurrentCell.ColumnIndex == ImageClassesColumn.Index)
            {
                var form = new ClassListForm();
                form.ShowDialog();
                if (form.Classes.Count > 0)
                {
                    var classes = string.Join(",", form.Classes);
                    ImageDataGridView.CurrentCell.Value = classes;
                }
            }
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
