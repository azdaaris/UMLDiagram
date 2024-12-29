using DragAndDrop.Diagram;
using DragAndDrop.Diagram.UmlDiagram;
using DragAndDrop.Enums;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using DragAndDrop.Selections;

namespace DragAndDrop
{
    public class Canvas
    {
        public List<UmlDiagram> Boxes;
        public List<Relation> Relations;
        [JsonIgnore]
        private Selection? _selection;
        [JsonIgnore]
        private MultiSelectionBox? _visualMultiselect;
        [JsonIgnore]
        public List<UmlDiagram> Multiselect;
        [JsonIgnore]
        public Relation? SelectedRelation;
        [JsonIgnore]
        public Point SelectedPoint;
        [JsonIgnore]
        public List<Point> PointsSelected;
        [JsonIgnore]
        public PointSelection? PointSelection;

        public Canvas(List<UmlDiagram> boxes, List<Relation> relations)
        {
            Boxes = boxes;
            Relations = relations;
            _selection = null;
            _visualMultiselect = null;
            Multiselect = new List<UmlDiagram>();
            SelectedRelation = null;
            SelectedPoint = new Point(0,0);
            PointsSelected = new List<Point>();
            PointSelection = null;
        }
        public Canvas()
        {
            Boxes = new List<UmlDiagram>();
            Relations = new List<Relation>();
            _selection = null;
            _visualMultiselect = null;
            Multiselect = new List<UmlDiagram>();
            SelectedRelation = null;
            SelectedPoint = new Point(0, 0);
            PointsSelected = new List<Point>();
            PointSelection = null;

            UmlDiagram box = new UmlDiagram(10, 10);
            box.Variables = new List<Variable>{ new Variable(AccessModifier.Public, "Vlastnost", "string"),
                                                    new Variable(AccessModifier.Private, "V123", "int"),
                                                    new Variable(AccessModifier.Protected, "S", "bool"),
                                                    new Variable(AccessModifier.Internal, "A1111111111111", "string"),
                                                    };
            box.Methods = new List<Method>{ new Method(AccessModifier.Public, "Metoda", "string", new List<string>{"string","bool","int"}),
                                                new Method(AccessModifier.Private, "Metodicka","void", new List<string>{}),
                                                new Method(AccessModifier.Internal, "A123", "bool", new List<string>{"string","bool"}),
                                                    };
            box.Name = "Třída1";
            Boxes.Add(box);
            
            UmlDiagram box2 = new UmlDiagram(10, 210 + 10);
            box2.Variables = new List<Variable>{ new Variable(AccessModifier.Public, "Vlastnost", "string"),
                                                    new Variable(AccessModifier.Internal, "A1111111111111", "string"),
                                                    };
            box2.Methods = new List<Method>{ new Method(AccessModifier.Public, "Metoda", "string", new List<string>{"string","bool","int"}),
                                                new Method(AccessModifier.Private, "Metodicka","void", new List<string>{}),
                                                    };
            box2.Name = "Třída2";
            Boxes.Add(box2);

            UmlDiagram box3 = new UmlDiagram(180, 10);
            box3.Variables = new List<Variable>{ new Variable(AccessModifier.Public, "Vlastnost", "string"),
                                                    new Variable(AccessModifier.Private, "Vlastnost", "string"),

                                                    };
            box3.Methods = new List<Method>{ new Method(AccessModifier.Public, "Metoda", "string", new List<string>{"string","bool","int"}),
                                                new Method(AccessModifier.Internal, "A123", "bool", new List<string>{"string","bool"}),
                                                    };

            box3.Name = "Třída3";
            Boxes.Add(box3);

            Relation r = new Relation(1, 2, RelationType.Aggregation,Multiplicity.OneToN);
            Relations.Add(r);

            for (int i = 0; i < Boxes.Count; i++)
            {
                Boxes[i].Id = i+1;
            }

        }

        public void Draw(Graphics g)
        {
            //DEBUG
            if (Multiselect != null)
                g.DrawString($"Multiselect: {Multiselect.Count.ToString()}", new Font("Arial", 10), Brushes.Black, 10, 85);
            if (_selection != null)
                g.DrawString($"Selection: True", new Font("Arial", 10), Brushes.Black, 10, 100);
            else
                g.DrawString($"Selection: False", new Font("Arial", 10), Brushes.Black, 10, 100);
            if (_visualMultiselect != null)
                g.DrawString($"MultiSelectBox: True", new Font("Arial", 10), Brushes.Black, 10, 115);
            else
                g.DrawString($"MultiSelectBox: False", new Font("Arial", 10), Brushes.Black, 10, 115);
            if(PointsSelected.Count > 0)
                g.DrawString($"SelectedPoint X:{PointsSelected[0].X} Y:{PointsSelected[0].Y}",new Font("Arial", 10), Brushes.Black, 10, 130);
            ///////

            List<Relation> relations = new List<Relation>();
            foreach (var item in Relations)
                if(!relations.Select(s=>s.RightDiagramId).Contains(item.RightDiagramId))
                    relations.Add(item);

            foreach (Relation r in relations)
                r.Draw(g,Boxes, this);
            foreach (UmlDiagram box in Boxes)
                box.Draw(g);
            foreach (Point point in PointsSelected)
                g.FillRectangle(Brushes.LightBlue, new Rectangle(point, new Size(10, 10)));

            if (_visualMultiselect == null)
                return;
            _visualMultiselect.Draw(g);
        }

        public void Select(int x, int y)
        {
            //if (SelectedRelation != null /*&& !SelectedRelation.Used*/)
            //{
            //    if (SelectedRelation.CheckForExistingPoint(x, y).X == 0 && SelectedRelation.CheckForExistingPoint(x, y).Y == 0)
            //    {
            //        SelectedRelation.CreatePoint(x, y);
            //        SelectedRelation.Used = true;
            //        SelectedRelation = null;
            //    }
            //    else
            //    {
            //        SelectedPoint = SelectedRelation.CheckForExistingPoint(x, y);
            //        PointsSelected = new List<Point> { SelectedPoint };
            //    }
            //}
            //if(Relations.Any(s=>s.Used))
            //{
            //    Relation usedRelation = Relations.Find(s=>s.Used)!;
            //    if (usedRelation.CheckForExistingPoint(x, y).X == 0 && usedRelation.CheckForExistingPoint(x, y).Y == 0)
            //        usedRelation.CreatePoint(x, y);
            //    else
            //    {
            //        //SelectedPoint = SelectedRelation.CheckForExistingPoint(x, y);
            //        //PointsSelected = new List<Point> { SelectedPoint };
            //    }
            //}

            Unselect();

            //Checks wheter a box is in a collission with cursor///
            for (int i = Boxes.Count-1; i >= 0; i--)
            {
                if (Boxes[i].IsInCollisionWithCorner(x, y))
                {
                    _selection = new ResizeSelection(Boxes[i], x, y);
                    _selection.Select();
                    return;
                }
                else if (Boxes[i].IsInCollision(x, y))
                {
                    _selection = new MoveSelection(Boxes[i], x, y);
                    _selection.Select();
                    return;
                }
            }
            for (int i = 0; i < Relations.Count; i++)
            {
                if (Relations[i].IsInCollision(x, y,Boxes))
                {
                    Relations[i].Select();
                    SelectedRelation = Relations[i];
                    return;
                }
            }
            ///////////////////////////////////////////////////


            //No box in collission => multiselect//////////////
            //Everything needs to be unselected when multiselect is called
            _visualMultiselect = new MultiSelectionBox(this,x, y);
        }
        public void Unselect()
        {
            foreach(UmlDiagram box in Boxes)
                box.Unselect();

            foreach (Relation r in Relations)
            {
                r.Unselect();
                r.Used = false;
            }

            SelectedRelation = null;
            Multiselect.Clear();
        }
        public void Move(int x, int y)
        {
            if (_selection == null)
                return;

            _selection.Move(x, y);
        }
        public void ResizeMultiselect(int x, int y)
        {
            if (_visualMultiselect == null)
                return;

            _visualMultiselect.Selected = true;

            for (int i = 0; i < Relations.Count; i++)
                PointsSelected = _visualMultiselect.SelectedPoint(Relations[i].Positions);

            _visualMultiselect.Resize(x - _visualMultiselect.PositionX, y - _visualMultiselect.PositionY );

            for (int i = 0; i < Boxes.Count; i++)
            {
                if (Boxes[i].IsInCollision(x, y))
                {
                    Boxes[i].Select();
                    if (!Multiselect.Contains(Boxes[i]))
                        Multiselect.Add(Boxes[i]);
                }
            }

        }
        public void PinDiagram()
        {
            if (Multiselect.Count < 1)
                return;
            if (Relations.Where(s => s.LeftDiagramId == Multiselect[0].Id || s.RightDiagramId == Multiselect[0].Id).Count() < 1)
                return;

            Relation? r = Relations.Where(s=>s.LeftDiagramId == Multiselect[0].Id || s.RightDiagramId == Multiselect[0].Id).First();
            r.Positions.Add(new Point(Multiselect[0].PositionX + Multiselect[0].Width/2, Multiselect[0].PositionY+ Multiselect[0].Height/2));
        }
        public void UnselectMultiselect() 
        {
            if(_selection != null)
            {
                if(!Multiselect.Contains(_selection._selectedBox))
                    Multiselect.Add(_selection._selectedBox);
                _selection = null;
            }
            SelectedPoint = new Point(0,0) ;
            SelectedRelation = null ;
            _visualMultiselect = null;
        }
    }
}
