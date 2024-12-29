using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class SaveDialogForm : Form
    {
        private Canvas _canvas;
        private PictureBox _pb;
        public SaveDialogForm(Canvas canvas,PictureBox pb)
        {
            _canvas = canvas;
            _pb = pb;
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void SaveDialogForm_Load(object sender, EventArgs e)
        {
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void saveAsJsonButton_Click(object sender, EventArgs e)
        {
            /*
            string json = JsonSerializer.Serialize(_diagrams);
            if (textBox1.Text.Length < 1)
                browseButton_Click(sender, e);
            else
                File.WriteAllText($"{textBox1.Text}\\diagrams.json",json);
            */
            SaveFileNameInputForm f = new SaveFileNameInputForm(textBox1.Text,_canvas);
            f.ShowDialog();
            Close();
        }

        private void SaveAsImgButton_Click(object sender, EventArgs e)
        {
            SaveFileNameInputForm f = new SaveFileNameInputForm(textBox1.Text,_pb);
            f.ShowDialog();
            Close();
        }
    }
}
