using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop.Forms
{
    public partial class EditClassName : Form
    {
        private UmlDiagram _diagram;
        public EditClassName(UmlDiagram d)
        {
            _diagram = d;
            InitializeComponent();
            textBox1.Text = _diagram.Name;
            Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            _diagram.Name = textBox1.Text;
            Close();
        }
    }
}
