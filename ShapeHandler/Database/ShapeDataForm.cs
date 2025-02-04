﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShapeHandler.Database.Input;

namespace ShapeHandler.Database
{
    public partial class ShapeDataForm : Form
    {
        private static ShapeDataForm _shapeDataForm = null;
        public ShapeDataForm()
        {
            InitializeComponent();
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
                    _shapeDataForm = new ShapeDataForm();
                }
                return _shapeDataForm;
            }
        }

        private void ShapeDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _shapeDataForm = null;
        }

        private void AddElement_Click(object sender, EventArgs e)
        {
            if (HTMLOptions.SelectedItem != null) {
                var htmlElement = HTMLOptions.SelectedItem.ToString();
                InputForm inputForm = new InputForm();
                ButtonAttributesForm buttonAttributesForm = new ButtonAttributesForm();
                switch (htmlElement)
                {
                    case "<input>": inputForm.ShowDialog(); break;
                    case "<button>": buttonAttributesForm.ShowDialog(); break;
                    case "<select>": inputForm.ShowDialog(); break;
                    case "<a>": inputForm.ShowDialog(); break;
                    case "<image>": inputForm.ShowDialog(); break;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _shapeDataForm.Close();
        }
    }
}