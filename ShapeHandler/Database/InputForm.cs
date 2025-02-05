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
        private static int _shapeID;
        private static int _inputNum;

        public InputForm(int shapeID)
        {
            _shapeID = shapeID;
            InitializeComponent();
        }

        public InputForm(int shapeID, int inputNum)
        {
            _shapeID = shapeID;
            _inputNum = inputNum;
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            IDictionary<string, string> attributes = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(
                    //Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID].get_CellsSRC(
                    //    (short)VisSectionIndices.visSectionProp,
                    //    (short)VisRowIndices.visRowLast,
                    //    (short)VisCellIndices.visCustPropsValue
                    //).get_ResultStr(VisUnitCodes.visNoCast)
                    Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID]
                    .Cells["Input " + _inputNum.ToString()]
                    .ResultStr[VisCellIndices.visCustPropsValue]
                );
            typeTextBox.Text = attributes["type"];
            idTextBox.Text = attributes["id"];
            nameTextBox.Text = attributes["name"];
            valueTextBox.Text = attributes["value"];
            minTextBox.Text = attributes["min"];
            maxTextBox.Text = attributes["max"];
            classesTextBox.Text = attributes["class"];
        }

        private void InputForm_Closing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void UpdateShapeData()
        {
            StringBuilder schema = new StringBuilder("{");
            schema.Append("\"\"type\"\": \"\"" + typeTextBox.Text + "\"\", ");
            schema.Append("\"\"id\"\": \"\"" + idTextBox.Text + "\"\", ");
            schema.Append("\"\"name\"\": \"\"" + nameTextBox.Text + "\"\", ");
            schema.Append("\"\"value\"\": \"\"" + valueTextBox.Text + "\"\", ");
            schema.Append("\"\"min\"\": \"\"" + minTextBox.Text + "\"\", ");
            schema.Append("\"\"max\"\": \"\"" + maxTextBox.Text + "\"\", ");
            schema.Append("\"\"class\"\": \"\"" + classesTextBox.Text + "\"\", ");
            Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID].get_CellsSRC(
                (short)VisSectionIndices.visSectionProp,
                (short)VisRowIndices.visRowLast,
                (short)VisCellIndices.visCustPropsLabel
            ).FormulaU = "\"" + "Input 1" + "\"";
            Globals.ShapeDetector.Application.ActivePage.Shapes[_shapeID].get_CellsSRC(
                    (short)VisSectionIndices.visSectionProp,
                    (short)VisRowIndices.visRowLast,
                    (short)VisCellIndices.visCustPropsValue
                ).FormulaU = "\"" + schema + "\"";

            //// EXAMPLE USAGE OF EASIER DATA FORMATTING

            //var context = new BrowsingContext(Configuration.Default);
            //var document = context.OpenNewAsync().Result;
            //var input = document.CreateElement("input") as IHtmlInputElement;
            //input.Type = typeTextBox.Text;
            //input.Id = idTextBox.Text;
            //input.Name = nameTextBox.Text;
            //input.Value = valueTextBox.Text;
            //input.Minimum = minTextBox.Text;
            //input.Maximum = maxTextBox.Text;

            //var classList = classTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var className in classList)
            //{
            //    input.ClassList.Add(className);
            //}

            //// GET OUTPUT
            //var output = input.OuterHtml;
            //// OR UPDATE/USE CUSTOM SERIALIZATION (UPDATE TO YOUR NEEDS)
            //output = JsonConvert.SerializeObject(input, new HtmlElementSerializer());

            //VisioShapeDataHelper.AddShapeData(_shapeID, output, "Input " + _inputNum);
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
    }
}
