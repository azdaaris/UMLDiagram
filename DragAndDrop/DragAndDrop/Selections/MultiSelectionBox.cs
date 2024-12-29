using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop.Selections
{
    internal class MultiSelectionBox
    {
        private Canvas _canvas;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Selected { get; set; }

        public MultiSelectionBox(Canvas canvas,int x, int y)
        {
            _canvas = canvas;
            PositionX = x;
            PositionY = y;
            Width = 0;
            Height = 0;
        }
        public List<UmlDiagram> ListSelectedDiagrams(List<UmlDiagram> boxes)
        {
            List<UmlDiagram> output = new List<UmlDiagram>();
            foreach (UmlDiagram diagram in boxes)
            {
                if (diagram.PositionX + Width / 2 > PositionX && diagram.PositionX + Width < PositionX + Width)
                    if (diagram.PositionY + Height / 2 > PositionY && diagram.PositionY + Height < PositionY + Height)
                        output.Add(diagram);
            }
            return output;
        }
        public List<Point> SelectedPoint(List<Point> points)
        {
            List<Point> output = new List<Point>();
            foreach (Point point in points)
            {
                if(point.X > PositionX && point.X <PositionX + Width && point.Y > PositionY && point.Y < PositionY+Height)
                    output.Add(point);
            }
            return output;
        }
        public void Draw(Graphics g)
        {
            if (Selected)
            {
                //g.TranslateTransform(PositionX, PositionY);
                g.DrawRectangle(Pens.Black, PositionX, PositionY, Width, Height);

                if (Height < 0 && Width > 0)
                    g.DrawRectangle(Pens.Black, PositionX, Height * -1, Width, PositionY - Height * -1);

                //g.FillRectangle(Brushes.Blue,new Rectangle(_canvas.SelectedPoint,new Size(10,10)));

                g.ResetTransform();
            }
        }

        public void Resize(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public void Unselect() => Selected = false;
        public bool IsInCollision(int x, int y)
        {
            return x > PositionX && x <= PositionX + Width
                && y > PositionY && y <= PositionY + Height;
        }
    }
}
