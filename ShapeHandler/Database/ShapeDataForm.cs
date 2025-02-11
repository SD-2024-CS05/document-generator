using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.Office.Interop.Visio;
using Newtonsoft.Json;
using ShapeHandler.Database.Input;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;

namespace ShapeHandler.Database
{
    public partial class ShapeDataForm : Form
    {
        private static int _shapeID;

        public ShapeDataForm(int shapeID)
        {
            InitializeComponent();
            _shapeID = shapeID;
        }

        private void ShapeDataForm_Load(object sender, EventArgs e)
        {
        }

        private void ShapeDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            var browsing = new BrowsingContext(Configuration.Default);
            var document = browsing.OpenNewAsync().Result;

            // get all elements, converting them from the html
            var elements = ControlListView.Items.Cast<ListViewItem>().ToList();

            var inputNum = 0;
            var anchorNum = 0;
            var imageNum = 0;
            var selectNum = 0;
            var label = "<UNKNOWN>";

            foreach (var element in elements)
            {
                // get the html column
                var html = element.SubItems[1].Text;
                var group = element.Group.Name;

                var parser = new HtmlParser();
                var parsedElement = parser.ParseFragment(html, null).First() as IHtmlElement;

                switch (group)
                {
                    case "InputGroup":
                        parsedElement = parsedElement.GetElementsByTagName("input").First() as IHtmlInputElement;
                        label = $"<input> {++inputNum}";
                        break;
                    case "AnchorGroup":
                        parsedElement = parsedElement.GetElementsByTagName("a").First() as IHtmlAnchorElement;
                        label = $"<a> {++anchorNum}";
                        break;
                    case "ImageGroup":
                        parsedElement = parsedElement.GetElementsByTagName("img").First() as IHtmlImageElement;
                        label = $"<img> {++imageNum}";
                        break;
                    case "SelectGroup":
                        parsedElement = parsedElement.GetElementsByTagName("select").First() as IHtmlSelectElement;
                        label = $"<select> {++selectNum}";
                        break;
                    default:
                        break;
                }

                var output = JsonConvert.SerializeObject(parsedElement, new HtmlElementSerializer());


                VisioShapeDataHelper.AddShapeData(_shapeID, output, label);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateShapeData();
            this.Close();
        }

        private void AddControlButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveControlButton_Click(object sender, EventArgs e)
        {
            if (ControlListView.SelectedItems.Count != 0)
            {
                ControlListView.Items.Remove(ControlListView.SelectedItems[0]);
            }
        }

        private void AddControlComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedItem = AddControlComboBox.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "<input>":
                    var inputForm = new InputAttributesForm();
                    inputForm.ShowDialog();

                    if (inputForm.Elements.Any())
                    {
                        foreach (var element in inputForm.Elements)
                        {
                            var item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["InputGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                case "<a>":
                    var anchorForm = new AnchorAttributesForm();
                    anchorForm.ShowDialog();

                    if (anchorForm.Elements.Any())
                    {
                        foreach (var element in anchorForm.Elements)
                        {
                            var item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["AnchorGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                case "<img>":
                    var imageForm = new ImageAttributesForm();
                    imageForm.ShowDialog();
                    if (imageForm.Elements.Any())
                    {
                        foreach (var element in imageForm.Elements)
                        {
                            var item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["ImageGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                case "<select>":
                    var selectForm = new SelectAttributesForm();
                    selectForm.ShowDialog();
                    if (selectForm.Elements.Any())
                    {
                        foreach (var element in selectForm.Elements)
                        {
                            var item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["SelectGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}