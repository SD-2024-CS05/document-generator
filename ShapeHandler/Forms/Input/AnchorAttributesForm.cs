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
            var anchorElements = iHtmlAnchorElementBindingSource.List.Cast<IHtmlAnchorElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (var anchorElement in anchorElements)
            {
                var row = AnchorDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == anchorElement);
                if (row != null)
                {
                    anchorElement.Id = row.Cells["IdColumn"]?.Value?.ToString();

                    var classes = row.Cells["AnchorClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (var className in classes.Split(','))
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
                var classListForm = new ClassListForm();
                classListForm.ShowDialog();
                if (classListForm.Classes.Count > 0)
                {
                    var classes = string.Join(",", classListForm.Classes);
                    AnchorDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlAnchorElementBindingSource.Count > 0)
            {
                UpdateShapeData();
            }
            this.Close();
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
