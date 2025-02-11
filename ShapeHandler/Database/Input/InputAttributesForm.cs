﻿using System;
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
        }

        private void AnchorAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            // get all the image elements
            var inputElements = iHtmlInputElementBindingSource.List.Cast<IHtmlInputElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (var inputElement in inputElements)
            {
                var row = InputDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == inputElement);
                if (row != null)
                {
                    inputElement.Id = row.Cells["IdColumn"].Value.ToString();
                }
            }
            Elements = inputElements;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            this.Close();
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
