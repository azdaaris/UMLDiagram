using DragAndDrop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class RelationForm : Form
    {
        private Canvas _canvas { get; set; }

        private ComboBox _leftDiagramComboBox {  get; set; }
        private ComboBox _multiplicityLeftComboBox { get; set; }
        private ComboBox _multiplicityRightComboBox { get; set; }
        private ComboBox _rightDiagramComboBox {  get; set; }
        private ComboBox _relationComboBox {  get; set; }
        private Button _cancelButton {  get; set; }
        private Button _saveButton { get; set; }
        public RelationForm(Canvas canvas)
        {
            _canvas = canvas;
            SetValues();
            InitializeComponent();

        }
        public void SetValues()
        {
            _leftDiagramComboBox = new ComboBox
            {
                Size = new Size(200, 50),
                Location = new Point(10, 50),
            };
            _multiplicityLeftComboBox = new ComboBox
            {
                Size = new Size(50, 50),
                Location = new Point(220, 20),
                Items = { "1", "*" }
            };
            _relationComboBox = new ComboBox
            {
                Size = new Size(200, 50),
                Location = new Point(300, 50),
            };

            _multiplicityRightComboBox = new ComboBox
            {
                Size = new Size(50, 50),
                Location = new Point(520, 20),
                Items = { "1", "*" }
            };
            _rightDiagramComboBox = new ComboBox
            {
                Size = new Size(200, 50),
                Location = new Point(575, 50),
            };
            _cancelButton = new Button
            {
                Size = new Size(100, 25),
                Location = new Point(550, 150),
                Text = "Cancel",
                ForeColor = Color.Red,
            };
            _saveButton = new Button
            {
                Size = new Size(100, 25),
                Location = new Point(675,150),
                Text = "Save",
                ForeColor = Color.Green,
            };

            _leftDiagramComboBox.Items.AddRange(_canvas.Boxes.Select(s => s.Name).ToArray());
            _relationComboBox.Items.AddRange(Enum.GetValues(typeof(RelationType)).Cast<object>().ToArray());
            _rightDiagramComboBox.Items.AddRange(_canvas.Boxes.Select(s => s.Name).ToArray());

            _relationComboBox.SelectedValueChanged += (s, e) => Refresh();
            _saveButton.Click += (s, e) => SaveButtonClicked();
            _cancelButton.Click += (s, e) => Close();

            _relationComboBox.SelectedIndex = 0;
            _multiplicityLeftComboBox.SelectedIndex = 0;
            _multiplicityRightComboBox.SelectedIndex = 0;

            Controls.Add(_leftDiagramComboBox);
            Controls.Add(_multiplicityLeftComboBox);
            Controls.Add(_relationComboBox);
            Controls.Add(_multiplicityRightComboBox);
            Controls.Add(_rightDiagramComboBox);
            Controls.Add(_cancelButton);
            Controls.Add(_saveButton);

            InitializeComponent();
        }
        private void SaveButtonClicked()
        {
            int m = 0;
            switch (_multiplicityLeftComboBox.SelectedIndex)
            {
                case 0:
                    m = _multiplicityRightComboBox.SelectedIndex == 0 ? 1 : 2;
                    break;
                case 1:
                    m = _multiplicityRightComboBox.SelectedIndex == 1 ? 3 : 4;
                    break;
            }

            Relation r = new Relation
            {
                Id = _canvas.Relations.Count > 0 ? _canvas.Relations.MaxBy(x => x.Id)!.Id + 1 : 1,
                LeftDiagramId = _canvas.Boxes.Where(s => s.Name == (string)_leftDiagramComboBox.SelectedItem!).First().Id,
                RightDiagramId = _canvas.Boxes.Where(s => s.Name == (string)_rightDiagramComboBox.SelectedItem!).First().Id,
                RelationType = Enum.GetValues(typeof(RelationType)).Cast<RelationType>().ToList()[_relationComboBox.SelectedIndex],
                Positions = new List<Point>(),
                Multiplicity = Enum.GetValues(typeof(Multiplicity)).Cast<Multiplicity>().ToList()[m - 1]
            };
            _canvas.Relations.Add(r);
            Close();
        }
        private void RelationForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("Class 1", new Font("Arial",10), Brushes.Black, new Point(30,25));
            g.DrawString("Class 2", new Font("Arial", 10), Brushes.Black, new Point(600, 25));
            g.DrawString("Relation", new Font("Arial", 10), Brushes.Black, new Point(325, 25));
            g.DrawLine(Pens.Black, 210, 62, 545, 62);

            DrawSymbol(e);
        }
        private void DrawSymbol(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            switch (_relationComboBox.SelectedIndex)
            {
                case 0:
                    g.DrawLine(Pens.Black, 210, 62, 575, 62);
                    break;
                case 1:
                    g.DrawPolygon(Pens.Black, new PointF[] { new Point(560, 52), new Point(545, 62),new Point(560,72), new Point(575,62)});
                    break;
                case 2:
                    g.FillPolygon(Brushes.Black, new PointF[] { new Point(560, 52), new Point(545, 62), new Point(560, 72), new Point(575, 62) });
                    break;
                case 3:
                    g.DrawLine(Pens.Black, 545, 62,560,62);
                    g.DrawPolygon(Pens.Black, new PointF[] { new Point(560, 52), new Point(560, 72), new Point(575, 62) });
                    break;
            }
        }
    }
}
