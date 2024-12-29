using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDrop.Enums;

namespace DragAndDrop.Diagram.UmlDiagram
{
    public class Variable : Attribute
    {
        private AccessModifier _modifier;
        private string _identificator;
        private string _dataType;
        public Variable(AccessModifier modifier, string identificator, string dataType) 
            : base(modifier, identificator, dataType)
        {
            _modifier = modifier;
            _identificator = identificator;
            _dataType = dataType;
        }

        public int CalculateWidth()
        {
            return Identificator.Length+DataType.Length+10;
        }
        public Variable Copy()
        {
            Variable v = new Variable(_modifier, _identificator, _dataType);
            return v;
        }

        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawString($"{ConvertAccessModifier()}", Font, Brushes.Black, x+5, y);
            g.DrawString($"{Identificator}: {DataType}", Font, Brushes.Black, x+15, y);
        }
        

    }
}
