using DragAndDrop.Diagram;
using DragAndDrop.Diagram.UmlDiagram;

namespace DragAndDrop
{
    public class Canvas
    {
        private List<UmlDiagram> _boxes;
        private Selection? _selection;
        private Selection? _visualSelection;
        public Canvas()
        {
            _boxes = new List<UmlDiagram>();
            _selection = null;

            for(int i = 0; i < 2; i++)
            {
                UmlDiagram box = new UmlDiagram(10, (i * 210) + 10);
                box.Variables = new List<Variable>{ new Variable(AccessModifier.Public, "Vlastnost", "string"),
                                                    new Variable(AccessModifier.Private, "V123", "int"),
                                                    new Variable(AccessModifier.Protected, "S", "bool"),
                                                    new Variable(AccessModifier.Internal, "1111111111111", "string"),
                                                    };
                //box.Constructors = new List<Method> { new Method(AccessModifier.Public, "", "", new List<string> { }),
                //                                    new Method(AccessModifier.Public, "", "", new List<string> { })
                //                                    };
                box.Methods = new List<Method>{ new Method(AccessModifier.Public, "Metoda", "string", new List<string>{"string","bool","int"}),
                                                new Method(AccessModifier.Private, "Metodicka","void", new List<string>{}),
                                                new Method(AccessModifier.Internal, "123", "bool", new List<string>{"string","bool"}),
                                                    };
                _boxes.Add(box);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (UmlDiagram box in _boxes)
                box.Draw(g);
        }

        public void Select(int x, int y)
        {
            if (_visualSelection != null)
            {
                _visualSelection.Unselect();
            }
            for (int i = _boxes.Count-1; i >= 0; i--)
            {
                UmlDiagram box = _boxes[i];
                if (box.IsInCollisionWithCorner(x, y))
                {
                    //MessageBox.Show("Corner selected!");

                    _selection = new ResizeSelection(box, x, y);
                    _selection.Select();
                    return;
                }
                else if (box.IsInCollision(x, y))
                {
                    _selection = new MoveSelection(box, x, y);
                    _selection.Select();
                    return;
                }
            }
  
            //Unselect();
        }
        public void Unselect()
        {
            if (_selection == null)
                return;

            _selection.Unselect();
            _selection = null;
        }
        public void VisualUnselect()
        {
            _visualSelection = _selection;
            _selection = null ;
        }

        public void Move(int x, int y)
        {
            if (_selection == null)
                return;

            _selection.Move(x, y);
        }
    }
}
