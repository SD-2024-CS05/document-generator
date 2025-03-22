using System;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp;
using System.Collections.Generic;
using System.Linq;
using ShapeHandler.Forms;

namespace ShapeHandler.Database.Input
{
    public partial class ButtonAttributesForm : Form
    {
        private IDocument _document;
        public List<IHtmlButtonElement> Elements { get; private set; } = new List<IHtmlButtonElement>();
        public ButtonAttributesForm()
        {
            InitializeComponent();
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            _document = document;

            iHtmlButtonElementBindingSource.Add(_document.CreateElement<IHtmlButtonElement>());

            ButtonDataGridView.CellContentClick += new DataGridViewCellEventHandler(AddClasses);
        }

        private void ButtonAttributesForm_Closing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            var buttonElements = iHtmlButtonElementBindingSource.List.Cast<IHtmlButtonElement>().ToList();
            foreach (var buttonElement in buttonElements)
            {
                var row = ButtonDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == buttonElement);
                if (row != null)
                {
                    buttonElement.Id = row.Cells["IdColumn"]?.Value?.ToString();

                    var classes = row.Cells["ButtonClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (var className in classes.Split(','))
                        {
                            buttonElement.ClassList.Add(className);
                        }
                    }
                }
            }
            Elements = buttonElements;
        }

        private void AddClasses(object sender, DataGridViewCellEventArgs e)
        {
            if (ButtonDataGridView.CurrentCell.ColumnIndex == ButtonClassesColumn.Index)
            {
                var classListForm = new ClassListForm();
                classListForm.ShowDialog();
                if (classListForm.Classes.Count > 0)
                {
                    var classes = string.Join(",", classListForm.Classes);
                    ButtonDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlButtonElementBindingSource.List.Count > 0)
            {
                UpdateShapeData();
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            iHtmlButtonElementBindingSource.Add(_document.CreateElement<IHtmlButtonElement>());
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            iHtmlButtonElementBindingSource.RemoveCurrent();
        }
    }
}