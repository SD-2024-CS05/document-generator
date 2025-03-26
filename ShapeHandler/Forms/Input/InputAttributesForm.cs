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
    public partial class InputAttributesForm : Form
    {
        private IDocument _document;

        public List<IHtmlInputElement> Elements { get; private set; } = new List<IHtmlInputElement>();

        public InputAttributesForm()
        {
            InitializeComponent();
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            _document = document;

            iHtmlInputElementBindingSource.Add(_document.CreateElement<IHtmlInputElement>());

            InputDataGridView.CellContentClick += new DataGridViewCellEventHandler(InputAddClasses);
        }

        private void InputAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            // get all the image elements
            List<IHtmlInputElement> inputElements = iHtmlInputElementBindingSource.List.Cast<IHtmlInputElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (IHtmlInputElement inputElement in inputElements)
            {
                DataGridViewRow row = InputDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == inputElement);
                if (row != null)
                {
                    inputElement.Id = row.Cells["IdColumn"]?.Value?.ToString();

                    // get the classes for the input element
                    string classes = row.Cells["InputClassesColumn"]?.Value?.ToString();
                    if (!string.IsNullOrEmpty(classes))
                    {
                        foreach (string className in classes.Split(','))
                        {
                            inputElement.ClassList.Add(className);
                        }
                    }
                }
            }
            Elements = inputElements;
        }

        private void InputAddClasses(object sender, DataGridViewCellEventArgs e)
        {
            if (InputDataGridView.CurrentCell.ColumnIndex == InputClassesColumn.Index)
            {
                ClassListForm form = new ClassListForm();
                form.ShowDialog();
                if (form.Classes.Count > 0)
                {
                    string classes = string.Join(",", form.Classes);
                    InputDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlInputElementBindingSource.List.Count > 0)
            {
                UpdateShapeData();
            }
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            iHtmlInputElementBindingSource.Add(_document.CreateElement<IHtmlInputElement>());
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            iHtmlInputElementBindingSource.RemoveCurrent();
        }
    }
}
