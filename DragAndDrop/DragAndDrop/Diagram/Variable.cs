using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop.Diagram.UmlDiagram
{
    public class Variable : Attribute
    {
        public Variable(AccessModifier modifier, string identificator, string dataType) 
            : base(modifier, identificator, dataType)
        {
        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawString($"{ConvertAccessModifier()}", Font, Brushes.Black, x+5, y);
            g.DrawString($"{Identificator}: {DataType}", Font, Brushes.Black, x+15, y);
        }
        
    }
}
