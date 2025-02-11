using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.Office.Interop.Visio;
using Newtonsoft.Json;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using Visio = Microsoft.Office.Interop.Visio;

namespace ShapeHandler.Database
{
    public partial class InputForm : Form
    {

        public List<IHtmlInputElement> Elements { get; private set; } = new List<IHtmlInputElement>();

        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
        }

        private void InputForm_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void UpdateShapeData()
        {
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            IHtmlInputElement input = document.CreateElement("input") as IHtmlInputElement;
            input.Type = typeTextBox.Text;
            input.Id = idTextBox.Text;
            input.Name = nameTextBox.Text;
            input.Value = valueTextBox.Text;
            input.Minimum = minTextBox.Text;
            input.Maximum = maxTextBox.Text;

            var classList = classesTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var className in classList)
            {
                input.ClassList.Add(className);
            }

            Elements.Add(input);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            Close();
        }
    }
}
