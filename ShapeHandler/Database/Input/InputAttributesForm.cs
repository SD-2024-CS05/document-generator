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

namespace ShapeHandler.Database.Input
{
    public partial class InputAttributesForm : Form
    {
        private static int _shapeID;
        private static int _inputNum;

        public InputAttributesForm(int shapeID)
        {
            _shapeID = shapeID;
            InitializeComponent();
        }

        public InputAttributesForm(int shapeID, int inputNum)
        {
            _shapeID = shapeID;
            _inputNum = inputNum;
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            var lol = _inputNum;
            //if (VisioShapeDataHelper.CheckIfRowsExist(_shapeID))
            //{
            //    IDictionary<string, string> attriutes = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(
            //        //Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID].get_CellsSRC(
            //        //    (short)VisSectionIndices.visSectionProp,
            //        //    (short)VisRowIndices.visRowLast,
            //        //    (short)VisCellIndices.visCustPropsValue
            //        //).get_ResultStr(VisUnitCodes.visNoCast)
            //        Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID]
            //        .Cells["Input " + _inputNum.ToString()]
            //        .ResultStr[VisCellIndices.visCustPropsValue]
            //    );
            //    typeTextBox.Text = attributes["type"];
            //    idTextBox.Text = attributes["id"];
            //    nameTextBox.Text = attributes["name"];
            //    valueTextBox.Text = attributes["value"];
            //    minTextBox.Text = attributes["min"];
            //    maxTextBox.Text = attributes["max"];
            //    classesTextBox.Text = attributes["class"];
            //}
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
            var output = JsonConvert.SerializeObject(input, new HtmlElementSerializer());
            output = output.Replace("\"", "\"\"");
            VisioShapeDataHelper.AddShapeData(_shapeID, output, "Input " + _inputNum);
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
