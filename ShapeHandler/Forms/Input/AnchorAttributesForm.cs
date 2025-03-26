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
    public partial class AnchorAttributesForm : Form
    {
        private IDocument _document;

        public List<IHtmlAnchorElement> Elements { get; private set; } = new List<IHtmlAnchorElement>();

        public AnchorAttributesForm()
        {
            InitializeComponent();
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            _document = document;

            iHtmlAnchorElementBindingSource.Add(_document.CreateElement<IHtmlAnchorElement>());

            AnchorDataGridView.CellContentClick += new DataGridViewCellEventHandler(AddClasses);
        }

        private void AnchorAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            // get all the image elements
            List<IHtmlAnchorElement> anchorElements = iHtmlAnchorElementBindingSource.List.Cast<IHtmlAnchorElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (IHtmlAnchorElement anchorElement in anchorElements)
            {
                DataGridViewRow row = AnchorDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == anchorElement);
                if (row != null)
                {
                    anchorElement.Id = row.Cells["IdColumn"]?.Value?.ToString();

                    string classes = row.Cells["AnchorClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (string className in classes.Split(','))
                        {
                            anchorElement.ClassList.Add(className);
                        }
                    }
                }
            }
            Elements = anchorElements;
        }

        private void AddClasses(object sender, DataGridViewCellEventArgs e)
        {
            if (AnchorDataGridView.CurrentCell.ColumnIndex == AnchorClassesColumn.Index)
            {
                ClassListForm classListForm = new ClassListForm();
                classListForm.ShowDialog();
                if (classListForm.Classes.Count > 0)
                {
                    string classes = string.Join(",", classListForm.Classes);
                    AnchorDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlAnchorElementBindingSource.Count > 0)
            {
                UpdateShapeData();
            }
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            iHtmlAnchorElementBindingSource.Add(_document.CreateElement<IHtmlAnchorElement>());
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            iHtmlAnchorElementBindingSource.RemoveCurrent();
        }
    }
}
