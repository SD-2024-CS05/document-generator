using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ShapeHandler.Forms;
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

            ImageDataGridView.CellContentClick += new DataGridViewCellEventHandler(ImageAddClasses);
        }

        private void ImageAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            // get all the image elements
            List<IHtmlImageElement> imageElements = iHtmlImageElementBindingSource.List.Cast<IHtmlImageElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (IHtmlImageElement imageElement in imageElements)
            {
                DataGridViewRow row = ImageDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == imageElement);
                if (row != null)
                {
                    imageElement.Id = row.Cells["IdColumn"]?.Value?.ToString();

                    // get the classes for the image element
                    string classes = row.Cells["ImageClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (string className in classes.Split(','))
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
                ClassListForm form = new ClassListForm();
                form.ShowDialog();
                if (form.Classes.Count > 0)
                {
                    string classes = string.Join(",", form.Classes);
                    ImageDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlImageElementBindingSource.List.Count > 0)
            {
                UpdateShapeData();
            }
            Close();
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
