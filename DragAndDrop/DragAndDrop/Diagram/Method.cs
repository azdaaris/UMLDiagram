using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop.Diagram.UmlDiagram
{
    public class Method : Attribute
    {
        private List<string> _arguments;

        public Method(AccessModifier modifier, string identificator, string dataType, List<string> arguments) 
            : base(modifier, identificator, dataType)
        {
            _arguments = arguments;
        }

        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawString($"{ConvertAccessModifier()} ", Font, Brushes.Black, x+5, y);
            g.DrawString(Row(), Font, Brushes.Black, x+15, y);


            //if (_arguments.Count > 0 )
            //    g.DrawString($"{_arguments[0]},", Font, Brushes.Black, x + Identificator.Length*7+20, y);

            //for (int i = 1; i < _arguments.Count; i++)
            //{
            //    if(i!= _arguments.Count-1)
            //        g.DrawString($"{_arguments[i]},", Font, Brushes.Black, x + (_arguments[i-1].Length+32)*i+ Identificator.Length * 7 + 20, y);
            //    else
            //        g.DrawString($"{_arguments[i]})", Font, Brushes.Black, x + (_arguments[i - 1].Length + 32) * i + Identificator.Length * 7 + 20, y);

            //    //if(i<_arguments.Count)
            //    //    g.DrawString(",", Font, Brushes.Black, x + (_arguments[i - 1].Length + 28) * i + Identificator.Length * 7 + 20, y);

            //}
            //if (_arguments.Count > 0)
            //    g.DrawString(")", Font, Brushes.Black, x + (_arguments[_arguments.Count-1].Length + 29) * _arguments.Count+ Identificator.Length * 7 + 17, y);

            //g.DrawString(")", Font, Brushes.Black, x + 50, y);


            //g.DrawString($"{DataType}", Font, Brushes.Black, x + Identificator.Length, y);
        }
        public string Row()
        {
            string output = "";
            output += Identificator;
            output += "(";
            for (int i = 0; i < _arguments.Count; i++)
            {
                output += $"{_arguments[i]}";
                if (i != _arguments.Count - 1)
                    output += ",";
            }
            output += ")";

            return output;
        }
    }

}
