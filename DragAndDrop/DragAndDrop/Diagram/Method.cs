using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DragAndDrop.Enums;

namespace DragAndDrop.Diagram.UmlDiagram
{
    public class Method : Attribute
    {
        public List<string> Arguments;
        private AccessModifier _modifier;
        private string _identificator;
        private string _dataType;

        public Method(AccessModifier modifier, string identificator, string dataType, List<string> arguments) 
            : base(modifier, identificator, dataType)
        {
            Arguments = arguments;
            _modifier = modifier;
            _identificator = identificator;
            _dataType = dataType;
        }



        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawString($"{ConvertAccessModifier()} ", Font, Brushes.Black, x+5, y);
            g.DrawString(Row(), Font, Brushes.Black, x+15, y);
        }
        public int CalculateWidth()
        {
            int help = 0;
            for (int i = 0; i < Arguments.Count; i++)
            {
                help+=Arguments[i].Length;
            }
            return Identificator.Length + help+ DataType.Length+3+Arguments.Count + 10;
        }
        public string Row()
        {
            string output = "";
            output += Identificator;
            output += "(";
            for (int i = 0; i < Arguments.Count; i++)
            {
                output += $"{Arguments[i]}";
                if (i != Arguments.Count - 1)
                    output += ",";
            }
            output += "): ";
            output += DataType;
            return output;
        }
        public Method Copy()
        {
            Method m = new Method(_modifier,_identificator,_dataType,Arguments);
            return m;
        }
    }

}
