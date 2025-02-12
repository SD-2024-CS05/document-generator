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
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace ShapeHandler.Database.Input
{
    public partial class ButtonAttributesForm : Form
    {
        private IDocument _document;
        public ButtonAttributesForm()
        {
            InitializeComponent();
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            _document = context.OpenNewAsync().Result;

            IHtmlButtonElement button = _document.CreateElement("button") as IHtmlButtonElement;
            iHtmlButtonElementBindingSouce.Add(button);
        }

        private void ButtonAttributesForm_Closing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            BrowsingContext context = new BrowsingContext(Configuration.Default);
            IDocument document = context.OpenNewAsync().Result;
            IHtmlButtonElement button = document.CreateElement("button") as IHtmlButtonElement;
            //button.Type = typeTextBox.Text;
            //button.Id = idTextBox.Text;
            //button.Name = nameTextBox.Text;
            ////button.Form = formTextBox.Text;
            //button.FormAction = formActionTextBox.Text;
            //button.FormMethod = formMethodTextBox.Text;
            //button.Value = valueTextBox.Text;
            //var classList = classTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var className in classList)
            //{
            //     button.ClassList.Add(className);
            //}
            //////// GET OUTPUT
            ////var output = button.OuterHtml;
            ////// OR UPDATE/USE CUSTOM SERIALIZATION (UPDATE TO YOUR NEEDS)
            //var output = JsonConvert.SerializeObject(button, new HtmlElementSerializer());
            //output = output.Replace("\"", "\"\"");
            ////var output = HtmlElementSerializer.WriteJson(button);
            //VisioShapeDataHelper.AddShapeData(_shapeID, output, "Input " + _inputNum);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IHtmlButtonElement button = _document.CreateElement("button") as IHtmlButtonElement;
            iHtmlButtonElementBindingSouce.Add(button);
        }
    }
}