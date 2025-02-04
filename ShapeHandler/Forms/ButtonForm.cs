using AngleSharp;
using AngleSharp.Html;
using AngleSharp.Html.Dom;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visio = Microsoft.Office.Interop.Visio;


namespace ShapeHandler.Forms
{
    public partial class ButtonForm : Form
    {
        private int _shapeId;
        public ButtonForm(int shapeId)
        {
            _shapeId = shapeId;
            InitializeComponent();
        }

        private void ButtonForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TypeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var document = context.OpenNewAsync().Result;
            var buttonElement = document.CreateElement("button") as IHtmlButtonElement;
            buttonElement.Type = TypeTextBox.Text;
            buttonElement.Id = IdTextBox.Text;
            buttonElement.Name = NameTextBox.Text;
            buttonElement.Value = ValueTextBox.Text;
            buttonElement.IsDisabled = DisabledCheckBox.Checked;

            var classItems = ClassTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in classItems)
            {
                buttonElement.ClassList.Add(item);
            }

            VisioShapeDataHelper.AddShapeData(_shapeId,
                buttonElement.OuterHtml,
                "Button 1");
        }
    }
}
