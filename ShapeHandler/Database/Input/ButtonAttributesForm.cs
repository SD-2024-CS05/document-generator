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
        }

        private void AnchorAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UpdateShapeData()
        {
            // get all the image elements
            var imageElements = iHtmlButtonElementBindingSource.List.Cast<IHtmlButtonElement>().ToList();

            // id isn't bound so need to grab it from the datagridview
            foreach (var imageElement in imageElements)
            {
                var row = ButtonDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.DataBoundItem == imageElement);
                if (row != null)
                {
                    imageElement.Id = row.Cells["IdColumn"].Value.ToString();
                }
            }
            Elements = imageElements;
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
            iHtmlButtonElementBindingSource.Add(_document.CreateElement<IHtmlButtonElement>());
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            iHtmlButtonElementBindingSource.RemoveCurrent();
        }
    }
}
