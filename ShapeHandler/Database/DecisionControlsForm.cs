using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeHandler.Database
{
    public partial class DecisionControlsForm : Form
    {
        private static int _shapeID;
        public DecisionControlsForm(int shapeID)
        {
            _shapeID = shapeID;
            InitializeComponent();
        }
    }
}
