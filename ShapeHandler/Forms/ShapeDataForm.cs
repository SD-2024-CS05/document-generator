using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using DnsClient.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeHandler.Database.Input;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
            List<IHtmlElement> elements = VisioShapeDataHelper.GetHtmlElements(_shapeID);
            if (elements.Any())
            {
                if (elements.OfType<IHtmlInputElement>().Any())
                {
                    foreach (IHtmlInputElement element in elements.OfType<IHtmlInputElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["InputGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
                if (elements.OfType<IHtmlAnchorElement>().Any())
                {
                    foreach (IHtmlAnchorElement element in elements.OfType<IHtmlAnchorElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["AnchorGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
                if (elements.OfType<IHtmlImageElement>().Any())
                {
                    foreach (IHtmlImageElement element in elements.OfType<IHtmlImageElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["ImageGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
                if (elements.OfType<IHtmlSelectElement>().Any())
                {
                    foreach (IHtmlSelectElement element in elements.OfType<IHtmlSelectElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["SelectGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
            }
        }

        private void ShapeDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void UpdateShapeData()
        {
            VisioShapeDataHelper.ClearShapeData(_shapeID);

            BrowsingContext browsing = new BrowsingContext(Configuration.Default);
            List<ListViewItem> elements = ControlListView.Items.Cast<ListViewItem>().ToList();

            int inputNum = 0;
            int anchorNum = 0;
            int imageNum = 0;
            int selectNum = 0;
            string label = "<UNKNOWN>";

            foreach (ListViewItem element in elements)
            {
                // get the html column
                string html = element.SubItems[1].Text;
                string group = element.Group.Name;

                HtmlParser parser = new HtmlParser();
                IHtmlElement parsedElement = parser.ParseFragment(html, null).First() as IHtmlElement;

                switch (group)
                {
                    case "InputGroup":
                        parsedElement = parsedElement.GetElementsByTagName("input").First() as IHtmlInputElement;
                        label = $"input {++inputNum}";
                        break;
                    case "AnchorGroup":
                        parsedElement = parsedElement.GetElementsByTagName("a").First() as IHtmlAnchorElement;
                        label = $"a {++anchorNum}";
                        break;
                    case "ImageGroup":
                        parsedElement = parsedElement.GetElementsByTagName("img").First() as IHtmlImageElement;
                        label = $"img {++imageNum}";
                        break;
                    case "SelectGroup":
                        parsedElement = parsedElement.GetElementsByTagName("select").First() as IHtmlSelectElement;
                        label = $"select {++selectNum}";
                        break;
                    default:
                        break;
                }

                string output = JsonConvert.SerializeObject(parsedElement, new HtmlElementSerializer());
                VisioShapeDataHelper.AddShapeData(_shapeID, output, label);
            }
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
            string selectedItem = AddControlComboBox.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "<input>":
                    InputAttributesForm inputForm = new InputAttributesForm();
                    inputForm.ShowDialog();

                    if (inputForm.Elements.Any())
                    {
                        foreach (IHtmlInputElement element in inputForm.Elements)
                        {
                            ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["InputGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                case "<a>":
                    AnchorAttributesForm anchorForm = new AnchorAttributesForm();
                    anchorForm.ShowDialog();

                    if (anchorForm.Elements.Any())
                    {
                        foreach (IHtmlAnchorElement element in anchorForm.Elements)
                        {
                            ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["AnchorGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                case "<img>":
                    ImageAttributesForm imageForm = new ImageAttributesForm();
                    imageForm.ShowDialog();
                    if (imageForm.Elements.Any())
                    {
                        foreach (IHtmlImageElement element in imageForm.Elements)
                        {
                            ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["ImageGroup"];
                            ControlListView.Items.Add(item);
                        }
                    }
                    break;
                case "<select>":
                    SelectAttributesForm selectForm = new SelectAttributesForm();
                    selectForm.ShowDialog();
                    if (selectForm.Elements.Any())
                    {
                        foreach (IHtmlSelectElement element in selectForm.Elements)
                        {
                            ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
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