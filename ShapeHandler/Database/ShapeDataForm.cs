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

namespace ShapeHandler.Database
{
    public partial class ShapeDataForm : Form
    {
        public ShapeDataForm()
        {
            InitializeComponent();
        }

        private void ShapeDataForm_Load(object sender, EventArgs e)
        {

        }

        private void AddElement_Click(object sender, EventArgs e)
        {
            if (HTMLOptions.SelectedItem != null) {
                var htmlElement = HTMLOptions.SelectedItem.ToString();
                InputForm inputForm = new InputForm();
                switch (htmlElement)
                {
                    case "<input>": inputForm.ShowDialog(); break;
                    case "<button>": inputForm.ShowDialog(); break;
                    case "<select>": inputForm.ShowDialog(); break;
                    case "<a>": inputForm.ShowDialog(); break;
                    case "<image>": inputForm.ShowDialog(); break;
                }
            }
        }
    }
}