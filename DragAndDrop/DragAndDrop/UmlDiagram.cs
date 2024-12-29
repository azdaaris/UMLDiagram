using DragAndDrop.Diagram.UmlDiagram;
using System.Text.Json.Serialization;

namespace DragAndDrop
{
    public class UmlDiagram
    {
        public int Id { get; set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        [JsonIgnore]
        public int MinWidth => CalculateMinWidth();
        [JsonIgnore]
        public int MinHeight => CalculateMinHeight();
        [JsonIgnore]
        public int MaxWidth => 1000;
        [JsonIgnore]
        public int MaxHeight => 1000;
        public string Name;

        [JsonIgnore]
        private Brush _color;
        [JsonIgnore]
        private StringFormat _formatCenter;

        [JsonInclude]
        public List<Variable> Variables;
        [JsonInclude]
        public List<Method> Methods;
        //public List<Method> Constructors;
        public UmlDiagram(int x, int y)
        {
            Id = 0;
            PositionX = x;
            PositionY = y;

            Width = 200;
            Height = 200;
            _color = Brushes.LightBlue;
            //_text = "Box";
            Name = "MyClass";
            Variables = new List<Variable>();
            Methods = new List<Method>();
            _formatCenter = new StringFormat()
            {
                Alignment = StringAlignment.Center
            };

        }
        [JsonConstructor]
        public UmlDiagram(int id,int positionX, int positionY, int width, int height, string name, List<Variable> variables, List<Method> methods)
        {
            Id = id;
            PositionX = positionX;
            PositionY = positionY;
            Width = width;
            Height = height;
            Name = name;
            Variables = variables ?? new List<Variable>();
            Methods = methods ?? new List<Method>();
            _color = Brushes.LightBlue;
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

        public int CalculateMinHeight()
        {
            return 20+Variables.Count*20 + Methods.Count*20 + 10;
        }
        public int CalculateMinWidth()
        {
            int m;
            int v;
            if(Methods.Count>0)
                m = Methods.MaxBy(s=>s.CalculateWidth())!.CalculateWidth();
            else m = 0;

            if(Variables.Count>0)
                v = Variables.MaxBy(s=>s.CalculateWidth())!.CalculateWidth();
            else v = 0;

            return (Math.Max(m, v))*5;
        }
        public void Draw(Graphics g)
        {
            g.TranslateTransform(PositionX, PositionY);
            g.DrawRectangle(Pens.Black, 0, 0, Width+1, Height+1);
            g.FillRectangle(_color, 1,1, Width, Height);
            g.FillRectangle(Brushes.Black, Width - 9, Height - 9, 10, 10);
            //g.DrawString(_text, new Font("Arial", 10), Brushes.Black, 10, 85 * Height / 100);
            g.ResetTransform();

            g.DrawString(Name, new Font("ArialBold", 10), Brushes.Black, PositionX + Width / 2, PositionY,_formatCenter) ;
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
        public UmlDiagram Clone()
        {
            UmlDiagram d = new UmlDiagram(PositionX, PositionY);
            d.Variables = Variables.Select(v => v.Copy()).ToList();
            return d;
        } 
    }
}
