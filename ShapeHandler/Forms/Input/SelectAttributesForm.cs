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
    public partial class SelectAttributesForm : Form
    {
        private IDocument _document;

        public List<IHtmlSelectElement> Elements { get; private set; } = new List<IHtmlSelectElement>();

        public SelectAttributesForm()
        {
            InitializeComponent();
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            _document = document;
            iHtmlSelectElementBindingSource.Add(_document.CreateElement<IHtmlSelectElement>());

            SelectDataGridView.CellContentClick += new DataGridViewCellEventHandler(SelectElementRowAddClassesClicked);
            OptionDataGridView.CellContentClick += new DataGridViewCellEventHandler(OptionElementRowAddClassesClicked);
        }

        private void SelectAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            // get all the image elements
            List<IHtmlSelectElement> selectElements = iHtmlSelectElementBindingSource.List.Cast<IHtmlSelectElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (IHtmlSelectElement selectElement in selectElements)
            {
                DataGridViewRow selectRow = SelectDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == selectElement);
                if (selectRow != null)
                {
                    selectElement.Id = selectRow.Cells["IdColumn"]?.Value?.ToString();
                }

                // get the classes for the select element
                string selectClasses = selectRow.Cells["SelectClassesColumn"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(selectClasses))
                {
                    foreach (string selectClass in selectClasses.Split(','))
                    {
                        selectElement.ClassList.Add(selectClass);
                    }
                }

                // get options for select element
                List<IHtmlOptionElement> selectOptions = iHtmlOptionElementBindingSource.List.Cast<IHtmlOptionElement>().ToList();

                foreach (IHtmlOptionElement selectOption in selectOptions)
                {
                    DataGridViewRow optionRow = OptionDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == selectOption);
                    if (optionRow != null)
                    {
                        selectOption.Id = optionRow.Cells["OptionIdColumn"]?.Value?.ToString();

                        string optionClasses = optionRow.Cells["OptionClassesColumn"]?.Value?.ToString();
                        if (!string.IsNullOrEmpty(optionClasses))
                        {
                            foreach (string optionClass in optionClasses.Split(','))
                            {
                                selectOption.ClassList.Add(optionClass);
                            }
                        }

                        // parents are not bound, so there is a column called SelectIdColumn that contains the id of the parent select element
                        string parentSelectId = optionRow.Cells["SelectIdColumn"]?.Value?.ToString();
                        IHtmlSelectElement parentSelect = selectElements.FirstOrDefault(s => s.Id == parentSelectId);
                        parentSelect.AddOption(selectOption);

                    }
                }

            }
            Elements = selectElements;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlSelectElementBindingSource.List.Count > 0)
            {
                UpdateShapeData();
            }
            Close();
        }

        private void SelectElementRowAddClassesClicked(object sender, EventArgs e)
        {
            if (SelectDataGridView.CurrentCell.ColumnIndex == SelectClassesColumn.Index)
            {
                // open the class list form
                ClassListForm classListForm = new ClassListForm();
                classListForm.ShowDialog();

                if (classListForm.Classes.Count > 0)
                {
                    string classes = string.Join(",", classListForm.Classes);
                    SelectDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void OptionElementRowAddClassesClicked(object sender, EventArgs e)
        {
            if (OptionDataGridView.CurrentCell.ColumnIndex == OptionClassesColumn.Index)
            {
                // open the class list form
                ClassListForm classListForm = new ClassListForm();
                classListForm.ShowDialog();
                if (classListForm.Classes.Count > 0)
                {
                    string classes = string.Join(",", classListForm.Classes);
                    OptionDataGridView.CurrentCell.Value = classes;
                }
            }
        }

        private void AddSelectButton_Click(object sender, EventArgs e)
        {
            iHtmlSelectElementBindingSource.Add(_document.CreateElement<IHtmlSelectElement>());
        }

        private void RemoveSelectButton_Click(object sender, EventArgs e)
        {
            iHtmlSelectElementBindingSource.RemoveCurrent();
        }

        private void RemoveOptionButton_Click(object sender, EventArgs e)
        {
            iHtmlOptionElementBindingSource.RemoveCurrent();
        }

        private void AddOptionButton_Click(object sender, EventArgs e)
        {
            iHtmlOptionElementBindingSource.Add(_document.CreateElement<IHtmlOptionElement>());
        }

        private void SelectDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SelectIdColumn.Index)
            {
                // update the combobox list items with all of the select ids
                List<string> selectIds = SelectDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[SelectIdColumn.Index].Value?.ToString()).Distinct().ToList();
                DataGridViewComboBoxColumn selectColumn = (DataGridViewComboBoxColumn)OptionDataGridView.Columns["SelectIdColumn"];

                if (selectColumn != null && selectColumn.Items != null)
                {
                    selectColumn.Items.Clear();
                    selectColumn.Items.AddRange(selectIds.ToArray());
                }
            }
        }

        private void SelectDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // update the combobox list items with all of the select ids
            List<string> selectIds = SelectDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[SelectIdColumn.Index].Value?.ToString()).Distinct().ToList();
            DataGridViewComboBoxColumn selectColumn = (DataGridViewComboBoxColumn)OptionDataGridView.Columns["SelectIdColumn"];
            selectColumn.Items.Clear();
            selectColumn.Items.AddRange(selectIds.ToArray());

            // remove any select-ids from options that no longer exist
            foreach (DataGridViewRow row in OptionDataGridView.Rows)
            {
                if (!selectIds.Contains(row.Cells["SelectIdColumn"].Value?.ToString()))
                {
                    row.Cells["SelectIdColumn"].Value = null;
                }
            }
        }
    }
}
