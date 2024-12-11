using DragAndDrop.Diagram.UmlDiagram;

namespace DragAndDrop
{
    public class UmlDiagram
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int MinWidth => 100;
        public int MinHeight => 100;
        public int MaxWidth => 320;
        public int MaxHeight => 320;

        private Brush _color;
        private string _text;
        private string _name;
        private StringFormat _formatCenter;
        
        public List<Variable> Variables;
        public List<Method> Methods;
        public List<Method> Constructors;
        public UmlDiagram(int x, int y)
        {
            PositionX = x;
            PositionY = y;

            Width = 160;
            Height = 200;
            _color = Brushes.LightBlue;
            //_text = "Box";
            _name = "MyClass";
            Variables = new List<Variable>();
            Methods = new List<Method>();
            _formatCenter = new StringFormat()
            {
                Alignment = StringAlignment.Center
            };

        }

        public void Select()
        {
            _color = Brushes.LightSkyBlue;

            //_text = "Selected";
        }

        public void Unselect()
        {
            _color = Brushes.LightBlue;
            //_text = "Box";
        }

        public void Move(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Resize(int w, int h)
        {
            if (w < MinWidth)
                w = MinWidth;

            if (h < MinHeight)
                h = MinHeight;

            if (w > MaxWidth)
                w = MaxWidth;

            if (h > MaxHeight)
                h = MaxHeight;

            Width = w;
            Height = h;
        }

        public void Draw(Graphics g)
        {
            g.TranslateTransform(PositionX, PositionY);
            g.DrawRectangle(Pens.Black, 0, 0, Width+1, Height+1);
            g.FillRectangle(_color, 1,1, Width, Height);
            g.FillRectangle(Brushes.Black, Width - 9, Height - 9, 10, 10);
            g.DrawString(_text, new Font("Arial", 10), Brushes.Black, 10, 85 * Height / 100);
            g.ResetTransform();

            g.DrawString(_name, new Font("ArialBold", 10), Brushes.Black, PositionX + Width / 2, PositionY,_formatCenter) ;
            g.DrawLine(Pens.Black, PositionX, PositionY + 15, PositionX + Width, PositionY + 15 );

            for (int i = 0; i < Variables.Count; i++)
            {
                Variables[i].Draw(g, PositionX, PositionY+i*20+20);

                if (i == Variables.Count - 1)
                    g.DrawLine(Pens.Black, PositionX, PositionY + i * 20 +40, PositionX + Width, PositionY + i * 20 + 40);
            }
            //for (int i = 0; i < Constructors.Count; i++)
            //{
            //    Constructors[i].Draw(g, PositionX, PositionY + i * 20 + Variables.Count * 20 + 25);
            //}
            for (int i = 0; i < Methods.Count; i++)
            {
                Methods[i].Draw(g, PositionX, PositionY + i * 20 + (Variables.Count/*+Constructors.Count*/)*20+25);
            }

        }

        public bool IsInCollision(int x, int y)
        {
            return x > PositionX && x <= PositionX + Width
                && y > PositionY && y <= PositionY + Height;
        }

        public bool IsInCollisionWithCorner(int x, int y)
        {
            return x > (PositionX + Width - 9) && x <= PositionX + Width
                && y > (PositionY + Height - 9) && y <= PositionY + Height;
        }
    }
}
