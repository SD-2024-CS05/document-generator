using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ShapeHandler.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            List<IHtmlButtonElement> buttonElements = iHtmlButtonElementBindingSource.List.Cast<IHtmlButtonElement>().ToList();
            foreach (IHtmlButtonElement buttonElement in buttonElements)
            {
                DataGridViewRow row = ButtonDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == buttonElement);
                if (row != null)
                {
                    buttonElement.Id = row.Cells["IdColumn"]?.Value?.ToString();

                    string classes = row.Cells["ButtonClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (string className in classes.Split(','))
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
                ClassListForm classListForm = new ClassListForm();
                classListForm.ShowDialog();
                if (classListForm.Classes.Count > 0)
                {
                    string classes = string.Join(",", classListForm.Classes);
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