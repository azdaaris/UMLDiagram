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
    public partial class SaveFileNameInputForm : Form
    {
        private string _path { get; set; }
        private string _extension { get; set; }
        private Canvas _canvas;
        private PictureBox _pb;
        public SaveFileNameInputForm(string path, Canvas canvas)
        {
            _path = path;
            _extension = ".json";
            _canvas = canvas;
            InitializeComponent();
        }
        public SaveFileNameInputForm(string path, PictureBox pb)
        {
            _extension = ".png";
            _path = path;
            _pb = pb;
            InitializeComponent();

        }

        private void SaveFileNameInputForm_Load(object sender, EventArgs e)
        {
            jsonSlashPngLabel.Text = _extension;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(_extension == ".json")
            {
                if (File.Exists($"{_path}\\{textBox1.Text}{_extension}"))
                {
                    DialogResult r = MessageBox.Show("Given file already exists, do you want to rewrite it?", "File Exists", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        File.WriteAllText($"{_path}\\{textBox1.Text}{_extension}", JsonSerializer.Serialize(_canvas, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));
                        MessageBox.Show($"Image exported to {_path}");
                        Close();
                    }
                }
                else
                {
                    File.WriteAllText($"{_path}\\{textBox1.Text}{_extension}", JsonSerializer.Serialize(_canvas, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));
                    MessageBox.Show($"Image exported to {_path}");
                    Close();
                }

            }
            else
            {
                using (Bitmap bmp = new Bitmap(_pb.Width, _pb.Height))
                {
                    _pb.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save($"{_path}\\{textBox1.Text}{_extension}", System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show($"Image exported to {_path}");
                    Close();
                }
            }
        }
    }
}
