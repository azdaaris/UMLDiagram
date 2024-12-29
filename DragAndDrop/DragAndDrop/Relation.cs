using DragAndDrop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DragAndDrop
{
    public class Relation
    {
        public int Id { get; set; }
        public int LeftDiagramId { get; set; }
        public int RightDiagramId { get; set; }
        public RelationType RelationType { get; set; }
        public Multiplicity Multiplicity { get; set; }
        public List<Point> Positions { get; set; }
        [JsonIgnore]
        private Brush _brush { get; set; }
        [JsonIgnore]
        private Font _font { get; set; }
        [JsonIgnore]
        private UmlDiagram _leftDiagram { get; set; }
        [JsonIgnore]
        private UmlDiagram _rightDiagram { get; set; }
        [JsonIgnore]
        private int _thickness { get; set; }
        [JsonIgnore]
        public bool Used { get; set; }
        [JsonIgnore]
        public int Margin { get; set; }
        public Relation()
        {
            Id = 0;
            LeftDiagramId = 0;
            RightDiagramId = 0;
            RelationType = RelationType.Association;
            Positions = new List<Point>();
            _brush = Brushes.Black;
            _font = new Font("Arial", 10);
            _thickness = 1;
            Used = false;
            Margin = 0;
        }

        public Relation(int id, int leftDiagramId, int rightDiagramId, RelationType type, Multiplicity multiplicity, List<Point> positions)
        {
            Id = id;
            LeftDiagramId = leftDiagramId;
            RightDiagramId = rightDiagramId;
            RelationType = type;
            Positions = positions;
            _brush = Brushes.Black;
            _font = new Font("Arial", 10);
            Positions = positions;
            _thickness = 1;
            Used = false;
            Margin = 0;

        }
        public Relation(int leftDiagramId, int rightDiagramId, RelationType type, Multiplicity multiplicity)
        {
            LeftDiagramId = leftDiagramId;
            RightDiagramId = rightDiagramId;
            RelationType = type;
            Multiplicity = multiplicity;
            _brush = Brushes.Black;
            _font = new Font("Arial", 10);
            Used = false;
            _thickness = 1;
            Margin = 0;
            Positions = new List<Point>();
        }
        public void Select()  
        {
            _thickness = 3;
            Used = true;
        }
        public Point CheckForExistingPoint(int x, int y)
        {
            foreach (Point p in Positions)
            {
                if (Math.Abs(p.X - x) < 10 && Math.Abs(p.Y - y) < 10)
                    return p;
            }
            return new Point(0,0);
        }
        public void CreatePoint(int x, int y)
        {
            Point p =new Point(x, y);
            Positions.Add(p);
            Used = false;
        }
        public void Unselect()
        {
            _thickness = 1;
            Used = false;
        }
        public void Draw(Graphics g, List<UmlDiagram> diagrams,Canvas canvas)
        {
            _leftDiagram = diagrams.FirstOrDefault(s => s.Id == LeftDiagramId)!;
            _rightDiagram = diagrams.FirstOrDefault(s=> s.Id == RightDiagramId)!;
            
            //List<UmlDiagram> l = diagrams.Where(s => s.Id == RightDiagramId).ToList();
            List<Relation> r = canvas.Relations.Where(s => s.RightDiagramId == _rightDiagram.Id).ToList();



            for (int i = 0; i < r.Count; i++)
            {
                _leftDiagram = diagrams.FirstOrDefault(s=> s.Id == r[i].LeftDiagramId)!;

                Point left = new Point(_leftDiagram.PositionX + _leftDiagram.Width, _leftDiagram.PositionY + _leftDiagram.Height / 2);
                Point right = new Point(_rightDiagram.PositionX, _rightDiagram.PositionY + _rightDiagram.Height / 2+i*30);

                Point leftPoint = new Point(left.X + 10, left.Y - 20);
                Point rightPoint = new Point(right.X - 20, right.Y - 20+i*30);
                switch ((int)Multiplicity)
                {
                    case 1:
                        g.DrawString("1", _font, _brush, leftPoint);
                        g.DrawString("1", _font, _brush, rightPoint);
                        break;
                    case 2:
                        g.DrawString("1", _font, _brush, leftPoint);
                        g.DrawString("*", _font, _brush, rightPoint);
                        break;
                    case 3:
                        g.DrawString("*", _font, _brush, leftPoint);
                        g.DrawString("1", _font, _brush, rightPoint);
                        break;
                    case 4:
                        g.DrawString("*", _font, _brush, leftPoint);
                        g.DrawString("*", _font, _brush, rightPoint);
                        break;
                    default:
                        break;
                }
                switch ((int)RelationType)
                {
                    case 1:
                        g.DrawLine(Pens.Black, new Point(right.X - 20, right.Y + Margin + 10), right);
                        g.DrawLine(Pens.Black, new Point(right.X - 20, right.Y + Margin - 10), right);
                        break;
                    case 2:
                        g.DrawPolygon(Pens.Black, new PointF[] { new Point(right.X - 15, right.Y + Margin + 10), new Point(right.X - 30, right.Y + Margin), new Point(right.X - 15, right.Y + Margin - 10), right });
                        break;
                    case 3:
                        g.FillPolygon(Brushes.Black, new PointF[] { new Point(right.X - 15, right.Y + Margin + 10), new Point(right.X - 30, right.Y + Margin), new Point(right.X - 15, right.Y + Margin - 10), right });
                        break;
                    case 4:
                        g.DrawPolygon(Pens.Black, new PointF[] { new Point(right.X - 15, right.Y + Margin + 10), new Point(right.X - 15, right.Y + Margin - 10), right });
                        break;

                }
                if (Positions.Count > 0)
                {
                    g.DrawLine(Pens.Black, left, Positions[0]);
                    for (int j = 1; j < Positions.Count; j++)
                        g.DrawLine(Pens.Black, Positions[j - 1], Positions[i]);
                    g.DrawLine(Pens.Black, Positions[Positions.Count - 1], new Point(right.X - 30, right.Y));
                }
                else
                    g.DrawLine(new Pen(Color.Black, _thickness), left, new Point(right.X - 30, right.Y));

                for (int j = 0; j < Positions.Count; j++)
                    g.FillRectangle(_brush, new Rectangle(new Point(Positions[j].X, Positions[j].Y), new Size(10, 10)));

            }



            //if (/*canvas.Relations.Select(s => s.LeftDiagramId).Distinct().Count() < canvas.Relations.Count || */canvas.Relations.Select(s => s.RightDiagramId).Distinct().Count() < canvas.Relations.Count)
            //    Margin = (canvas.Relations.Count - canvas.Relations.Select(s => s.RightDiagramId).Distinct().Count()) * 20*Id;



        }
        public bool IsInCollision(int x, int y, List<UmlDiagram> diagrams)
        {
            _leftDiagram = diagrams.FirstOrDefault(s => s.Id == LeftDiagramId)!;
            _rightDiagram = diagrams.FirstOrDefault(s => s.Id == RightDiagramId)!;

            Point left = new Point(_leftDiagram.PositionX + _leftDiagram.Width, _leftDiagram.PositionY + _leftDiagram.Height / 2);
            Point right = new Point();
            //if (Positions.Count > 0)
            //{
            //    for (int i = 0; i < Positions.Count; i++)
            //    {
            //        right = Positions[i];
            //        if(LiesBetweenLeftAndRight(left, right,x,y))
            //            return true;
            //    }
            //}
            right = new Point(_rightDiagram.PositionX, _rightDiagram.PositionY + _rightDiagram.Height / 2);
            return LiesBetweenLeftAndRight(left,right,x,y);

        }
        public bool LiesBetweenLeftAndRight(Point left, Point right, int x, int y)
        {
            float crossProduct = (y - left.Y) * (right.X - left.X) - (x - left.X) * (right.Y - left.Y);
            if (Math.Abs(crossProduct) < 2500)
                return false;

            bool isWithinXBounds = Math.Min(left.X, right.X) <= x && x <= Math.Max(left.X, right.X);
            bool isWithinYBounds = Math.Min(left.Y, right.Y) <= y && y <= Math.Max(left.Y, right.Y);

            return isWithinXBounds && isWithinYBounds;

        }
    }
}
