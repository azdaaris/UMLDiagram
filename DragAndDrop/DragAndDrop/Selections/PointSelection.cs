using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop.Selections
{
    public class PointSelection
    {
        private Point Point;
        protected int _relativeX;
        protected int _relativeY;
        public PointSelection(Point p, int x, int y)
        {
            Point = p;
            _relativeX = x-p.X;
            _relativeY = y-p.Y;
        }
        public void Move(int x, int y)
        {
            Point.X = x-_relativeX;
            Point.Y = y-_relativeY;
        }
    }
}
