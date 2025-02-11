using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Database.Input;
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
            // get all elements in the controllist view and use VisioShapeDataHelper to write them to the shape
            var elements = ControlListView.Items.Cast<ListViewItem>().ToList();

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