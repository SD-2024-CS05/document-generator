﻿using AngleSharp;
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
            if (VisioShapeDataHelper.CheckIfRowsExist(_shapeID)) // Excludes node type row
            {
                HtmlParser parser = new HtmlParser();
                Dictionary<string, object> controls = VisioShapeDataHelper.GetShapeData(_shapeID);
                List<IHtmlElement> inputs = controls.Where(x => x.Key.Contains("input"))
                    .Select(x => JsonConvert.DeserializeObject<JObject>(x.Value.ToString())["OuterHtml"].ToString())
                    .Select(html => (IHtmlElement)parser.ParseFragment(html, null).First())
                    .Select(element => (IHtmlInputElement)element.GetElementsByTagName("input").First())
                    .ToList<IHtmlElement>();
                List<IHtmlElement> anchors = controls.Where(x => x.Key.Contains("a"))
                    .Select(x => JsonConvert.DeserializeObject<JObject>(x.Value.ToString())["OuterHtml"].ToString())
                    .Select(html => (IHtmlElement)parser.ParseFragment(html, null).First())
                    .Select(element => (IHtmlAnchorElement)element.GetElementsByTagName("a").First())
                    .ToList<IHtmlElement>();
                List<IHtmlElement> images = controls.Where(x => x.Key.Contains("img"))
                    .Select(x => JsonConvert.DeserializeObject<JObject>(x.Value.ToString())["OuterHtml"].ToString())
                    .Select(html => (IHtmlElement)parser.ParseFragment(html, null).First())
                    .Select(element => (IHtmlImageElement)element.GetElementsByTagName("img").First())
                    .ToList<IHtmlElement>();
                List<IHtmlElement> selects = controls.Where(x => x.Key.Contains("select"))
                    .Select(x => JsonConvert.DeserializeObject<JObject>(x.Value.ToString())["OuterHtml"].ToString())
                    .Select(html => (IHtmlElement)parser.ParseFragment(html, null).First())
                    .Select(element => (IHtmlSelectElement)element.GetElementsByTagName("select").First())
                    .ToList<IHtmlElement>();
                if (inputs.Any())
                {
                    foreach (IHtmlInputElement element in inputs.Cast<IHtmlInputElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["InputGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
                if (anchors.Any())
                {
                    foreach (IHtmlAnchorElement element in anchors.Cast<IHtmlAnchorElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["AnchorGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
                if (images.Any())
                {
                    foreach (IHtmlImageElement element in images.Cast<IHtmlImageElement>())
                    {
                        ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                        item.Group = ControlListView.Groups["ImageGroup"];
                        ControlListView.Items.Add(item);
                    }
                }
                if (selects.Any())
                {
                    foreach (IHtmlSelectElement element in selects.Cast<IHtmlSelectElement>())
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
            BrowsingContext browsing = new BrowsingContext(Configuration.Default);
            AngleSharp.Dom.IDocument document = browsing.OpenNewAsync().Result;

            // get all elements, converting them from the html
            System.Collections.Generic.List<ListViewItem> elements = ControlListView.Items.Cast<ListViewItem>().ToList();

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