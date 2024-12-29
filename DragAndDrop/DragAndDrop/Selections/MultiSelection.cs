using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop.Selections
{
    public class MultiSelection
    {
        public List<UmlDiagram> Boxes;
        public MultiSelection(int x, int y)
        {
            Boxes = new List<UmlDiagram>();
        }
    }
}
