using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using ShapeHandler.Database.Input;
using ShapeHandler.Helpers;
using ShapeHandler.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShapeHandler.Database
{
    public partial class DecisionControlsForm : Form
    {
        private static int _shapeID;
        public DecisionControlsForm(int shapeID)
        {
            InitializeComponent();
            _shapeID = shapeID;
        }

        private void UpdateShapeData()
        {
            List<ListViewItem> elements = ControlListView.Items.Cast<ListViewItem>().ToList();
            int buttonNum = 0;
            string label = "<UNKNOWN>";
            foreach (ListViewItem element in elements)
            {
                string html = element.SubItems[1].Text;
                string group = element.Group.Name;
                HtmlParser parser = new HtmlParser();
                IHtmlElement parsedElement = parser.ParseFragment(html, null).First() as IHtmlElement;
                switch (group)
                {
                    case "ButtonGroup":
                        parsedElement = parsedElement.GetElementsByTagName("button").First() as IHtmlButtonElement;
                        label = $"button {++buttonNum}";
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
                case "<button>":
                    ButtonAttributesForm buttonAttributesForm = new ButtonAttributesForm();
                    buttonAttributesForm.ShowDialog();

                    if (buttonAttributesForm.Elements.Any())
                    {
                        foreach (IHtmlButtonElement element in buttonAttributesForm.Elements)
                        {
                            ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                            item.Group = ControlListView.Groups["ButtonGroup"];
                            // There can only be two button controls per decision node
                            if (item.Group.Items.Count <= 2)
                            {
                                ControlListView.Items.Add(item);
                            }
                        }
                        if (buttonAttributesForm.Elements.Count > 2)
                        {
                            buttonAttributesForm.Elements.RemoveRange(2, buttonAttributesForm.Elements.Count - 2);
                            MessageBox.Show("There can only be two button controls.", "Error");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void DecisionControlsForm_Load(object sender, EventArgs e)
        {
            List<IHtmlElement> elements = VisioShapeDataHelper.GetHtmlElements(_shapeID);
            if (elements.Any())
            {
                foreach (IHtmlButtonElement element in elements.OfType<IHtmlButtonElement>())
                {
                    ListViewItem item = new ListViewItem(new[] { element.Id, element.OuterHtml });
                    item.Group = ControlListView.Groups["ButtonGroup"];
                    ControlListView.Items.Add(item);
                }   
            }
        }
    }
}
