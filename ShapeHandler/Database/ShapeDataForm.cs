using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Visio;
using ShapeHandler.Database.Input;

namespace ShapeHandler.Database
{
    public partial class ShapeDataForm : Form
    {
        private static int _shapeID;
        private static ShapeDataForm _shapeDataForm = null;


        private int _inputNum = 0;
        private int _anchorNum = 0;

        public ShapeDataForm(int shapeID)
        {
            InitializeComponent();
            _shapeID = shapeID;
        }

        private void ShapeDataForm_Load(object sender, EventArgs e)
        {

        }

        public static ShapeDataForm Instance
        {
            get
            {
                if (_shapeDataForm == null)
                {
                    _shapeDataForm = new ShapeDataForm(_shapeID);
                }
                return _shapeDataForm;
            }
        }

        private void ShapeDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _shapeDataForm = null;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _shapeDataForm.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            _shapeDataForm.Close();
        }

        private void AddControlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = AddControlComboBox.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "<input>":
                    var inputForm = new InputForm(_shapeID, _inputNum++);
                    inputForm.ShowDialog();
                    break;
                case "<a>":
                    var anchorForm = new AnchorAttributesForm(_shapeID);
                    anchorForm.ShowDialog();
                    break;
                case "<select>":
                    break;
                case "<img>":
                    break;
                default:
                    break;
            }
        }
    }
}