using DragAndDrop.Diagram.UmlDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDrop
{
    public class CodeGenerationHelper
    {
        private Canvas _canvas;
        public CodeGenerationHelper(Canvas c) 
        {
            _canvas = c;
        }
        public string Generate()
        {
            string output = "";

            for (int i = 0; i < _canvas.Boxes.Count; i++)
            {
                UmlDiagram activeClass = _canvas.Boxes[i];

                output += $"public class {activeClass.Name}";
                output += CheckForGeneralization(activeClass);
                output += "\n" + "{\n";

                foreach (Variable var in activeClass.Variables)
                    output += $"{char.ToLower(var.Modifier.ToString()[0])+var.Modifier.ToString().Substring(1)} {var.DataType} {var.Identificator}" + "{get; set;}\n";
                
                output += CheckForAssociation(activeClass);

                foreach (Method meth in activeClass.Methods)
                {
                    output += $"{char.ToLower(meth.Modifier.ToString()[0]) + meth.Modifier.ToString().Substring(1)} {meth.DataType} {meth.Identificator}(";
                    for (int j = 0; j < meth.Arguments.Count; j++)
                    {
                        output += $"{meth.Arguments[j]} {meth.Arguments[j][0]}{j}";
                        if (j != meth.Arguments.Count - 1)
                            output += $",";
                    }
                    output += $")" + "{}\n";
                }

                output += "}\n";
            }
            return output;
        }
        public string CheckForGeneralization(UmlDiagram diagram)
        {
            foreach (Relation rel in _canvas.Relations)
                if(rel.RightDiagramId == diagram.Id && rel.RelationType == Enums.RelationType.Generalization)
                    return diagram.Name;
            return "";
        }
        public string CheckForAssociation(UmlDiagram diagram)
        {
            foreach (Relation rel in _canvas.Relations)
            {
                if (rel.RelationType == Enums.RelationType.Generalization)
                    continue;

                if (rel.LeftDiagramId == diagram.Id)
                {
                    UmlDiagram workingDiagram = _canvas.Boxes.Where(s=>s.Id == rel.RightDiagramId).FirstOrDefault()!;
                    
                    switch ((int)rel.Multiplicity)
                    {
                        case int value when value % 2 == 1:
                            return $"public {workingDiagram.Name} {workingDiagram.Name.Substring(0, 2)}{rel.Id}" + " {get; set;}\n";
                        case int value when value % 2 == 0:
                            return $"public List<{workingDiagram.Name}> {workingDiagram.Name.Substring(0, 2)}{rel.Id}"+" {get; set;}\n";
                    }
                }
                //if(rel.LeftDiagramId == diagram.Id)
                //{
                //    UmlDiagram workingDiagram = _canvas.Boxes.Where(s => s.Id == rel.LeftDiagramId).FirstOrDefault()!;

                //    switch ((int)rel.Multiplicity)
                //    {
                //        case int value when value <= 2:
                //            return $"public {workingDiagram.Name} {workingDiagram.Name.Substring(0, 2)}{rel.Id}" + " {get; set;}\n";
                //        case int value when value > 2:
                //            return $"public List<{workingDiagram.Name}> {workingDiagram.Name.Substring(0, 2)}{rel.Id}" + " {get; set;}\n";
                //    }
                //}

            }

            
            return "";
        }
    }
}
