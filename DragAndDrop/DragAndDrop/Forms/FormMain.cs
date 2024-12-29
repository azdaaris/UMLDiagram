namespace DragAndDrop
{
    public partial class FormMain : Form
    {
        private Canvas _canvas;

        public FormMain()
        {
            _canvas = new Canvas();

            InitializeComponent();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _canvas.UnselectMultiselect();
            pictureBox.Refresh();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _canvas.Select(e.X, e.Y);

            pictureBox.Refresh();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _canvas.Move(e.X, e.Y);
            //_canvas.MovePoint(e.X, e.Y);
            _canvas.ResizeMultiselect(e.X, e.Y);
            pictureBox.Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _canvas.Draw(e.Graphics);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            UmlDiagram umlDiagram = new UmlDiagram(Width / 2, Height / 2);
            umlDiagram.Id = _canvas.Boxes.Count > 0 ? _canvas.Boxes.MaxBy(x => x.Id)!.Id + 1 : 1;

            _canvas.Boxes.Add(umlDiagram);
            EditDiagram g = new EditDiagram(umlDiagram);
            pictureBox.Refresh();
            g.ShowDialog();
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (_canvas.Multiselect.Count <= 0)
                return;

            if (_canvas.Multiselect.Count > 1)
            {
                DialogResult r = MessageBox.Show($"You are about to edit {_canvas.Multiselect.Count} diagrams is that OK?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes)
                    return;
                else
                {
                    for (int i = 0; i < _canvas.Multiselect.Count; i++)
                    {
                        EditDiagram g = new EditDiagram(_canvas.Multiselect[i]);
                        g.ShowDialog();
                    }
                }

            }
            else
            {
                EditDiagram f = new EditDiagram(_canvas.Multiselect[0]);
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDialogForm f = new SaveDialogForm(_canvas, pictureBox);
            f.ShowDialog();
        }

        //Load button 
        private void button3_Click(object sender, EventArgs e)
        {
            LoadFromFileForm f = new LoadFromFileForm(_canvas);
            f.ShowDialog();
            _canvas = f.LoadData();
            pictureBox.Refresh();

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (_canvas.SelectedRelation != null)
            {
                _canvas.Relations.Remove(_canvas.SelectedRelation);
                _canvas.PointsSelected.Clear();
            }

            foreach (UmlDiagram diagram in _canvas.Multiselect)
                if (_canvas.Relations.Any(s => diagram.Id == s.LeftDiagramId || diagram.Id == s.RightDiagramId))
                    _canvas.Relations.RemoveAll(s => s.LeftDiagramId == diagram.Id || s.RightDiagramId == diagram.Id);

            foreach (var item in _canvas.Relations)
            {
                _canvas.PointsSelected.ForEach(p => item.Positions.Remove(p));
                _canvas.PointsSelected.Clear();
            }

            if (_canvas.Multiselect.Count > 0)
            {
                _canvas.Boxes.Remove(_canvas.Multiselect[0]);
                _canvas.Multiselect.Remove(_canvas.Multiselect[0]);
            }


            pictureBox.Refresh();

        }
        private void relationsButton_Click(object sender, EventArgs e)
        {
            RelationForm f = new RelationForm(_canvas);
            f.ShowDialog();
        }

        private void generateCodeButton_Click(object sender, EventArgs e)
        {
            CodeGenerationHelper h = new CodeGenerationHelper(_canvas);
            File.WriteAllText("C:\\Users\\jmeno\\Desktop\\13.txt", h.Generate());
        }

        private void addPointButton_Click(object sender, EventArgs e)
        {
            _canvas.PinDiagram();
        }
    }
}
