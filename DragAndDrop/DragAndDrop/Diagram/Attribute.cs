using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDrop.Enums;

namespace DragAndDrop.Diagram.UmlDiagram
{
    public abstract class Attribute
    {
        public AccessModifier Modifier { get; set; }
        public string Identificator { get; set; }
        public string DataType { get; set; }
        protected Font Font { get; set; }
        public Attribute()
        {
            Modifier = AccessModifier.Public;
            Identificator = "MyClass";
            DataType = "string";
            Font = new Font("Arial", 10);
        }
        public Attribute(AccessModifier modifier, string identificator, string dataType)
        {
            Modifier = modifier;
            Identificator = identificator;
            DataType = dataType;
            Font = new Font("Arial", 10);
        }

        protected void ChangeAccess()
        {
            Modifier++;
        }
        protected string ConvertAccessModifier()
        {
            switch (Modifier)
            {
                case AccessModifier.Public:
                    return "+";
                case AccessModifier.Private:
                    return "-";
                case AccessModifier.Protected:
                    return "#";
                case AccessModifier.Internal:
                    return "~";
                default:
                    return "+";
            }
            
        }
        public abstract void Draw(Graphics g, int x, int y);
    }
}
