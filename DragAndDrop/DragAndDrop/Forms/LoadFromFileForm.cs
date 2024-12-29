using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class LoadFromFileForm : Form
    {
        public Canvas Canvas { get; set; }
        public LoadFromFileForm(Canvas canvas)
        {
            Canvas = canvas;
            InitializeComponent();
        }
        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
        }
        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
                pathTextBox.Text = openFileDialog1.FileName;
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadData();
            Close();
        }
        public Canvas LoadData()
        {
            string json;
            try
            {
                json = File.ReadAllText(pathTextBox.Text);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                return JsonSerializer.Deserialize<Canvas>(json, options)!;
            }
            catch
            {
                Close();
                json = "";
                return Canvas;
            }

        }

    }
}
