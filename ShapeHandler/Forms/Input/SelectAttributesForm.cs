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
        }

        private void SelectAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            // get all the image elements
            var selectElements = iHtmlSelectElementBindingSource.List.Cast<IHtmlSelectElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (var selectElement in selectElements)
            {
                var selectRow = SelectDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == selectElement);
                if (selectRow != null)
                {
                    selectElement.Id = selectRow.Cells["IdColumn"]?.Value?.ToString();
                }

                // get options for select element
                var selectOptions = iHtmlOptionElementBindingSource.List.Cast<IHtmlOptionElement>().ToList();

                foreach (var selectOption in selectOptions)
                {
                    var optionRow = OptionDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == selectOption);
                    if (optionRow != null)
                    {
                        selectOption.Id = optionRow.Cells["OptionIdColumn"]?.Value?.ToString();

                        // parents are not bound, so there is a column called SelectIdColumn that contains the id of the parent select element
                        var parentSelectId = optionRow.Cells["SelectIdColumn"]?.Value?.ToString();
                        var parentSelect = selectElements.FirstOrDefault(s => s.Id == parentSelectId);
                        parentSelect.AddOption(selectOption);

                    }
                }

            }
            Elements = selectElements;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (iHtmlSelectElementBindingSource.List.Count > 0)
            {
                UpdateShapeData();
            }
            this.Close();
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
                var selectIds = SelectDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[SelectIdColumn.Index].Value?.ToString()).Distinct().ToList();
                var selectColumn = (DataGridViewComboBoxColumn)OptionDataGridView.Columns["SelectIdColumn"];
                selectColumn.Items.Clear();
                selectColumn.Items.AddRange(selectIds.ToArray());
            }
        }

        private void SelectDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // update the combobox list items with all of the select ids
            var selectIds = SelectDataGridView.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[SelectIdColumn.Index].Value?.ToString()).Distinct().ToList();
            var selectColumn = (DataGridViewComboBoxColumn)OptionDataGridView.Columns["SelectIdColumn"];
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
