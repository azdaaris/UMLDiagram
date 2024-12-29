using DragAndDrop.Diagram.UmlDiagram;
using DragAndDrop.Enums;
using DragAndDrop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class EditDiagram : Form
    {
        UmlDiagram Diagram { get; set; }
        UmlDiagram ClonedDiagram { get; set; }

        Label ClassNameLabel { get; set; }
        List<AccessModifier> AmVariables {  get; set; } 
        List<AccessModifier> AmMethods {  get; set; }
        List<string> DataTypeVariables { get; set; }
        List<string> DataTypeMethods { get; set; }
        List<string> IdentificatorVariables { get; set; }
        List<string> IdentificatorMethods { get; set; }
        
        public EditDiagram(UmlDiagram diagram)
        {
            Diagram = diagram;
            InitializeComponent();
        }
        public void LoadButtons()
        {
            Controls.Remove(ClassNameLabel);
            ClassNameLabel = new Label
            {
                Size = new Size(80, 30),
                Location = new Point(150, 20),
                Text = Diagram.Name,
                ForeColor = Color.Black
            };
            Controls.Add(ClassNameLabel);

            for (int i = 0; i < Diagram.Variables.Count; i++)
            {
                int index = i;

                ComboBox boxAMVariable = new ComboBox
                {
                    Size = new Size(80, 30),
                    Location = new Point(10, 50 + i * 40),
                    Items = { "Public", "Private", "Protected", "Internal" },
                    SelectedItem = Diagram.Variables[i].Modifier.ToString(),
                };

                TextBox textBoxDataTypeVariable = new TextBox
                {
                    Text = Diagram.Variables[i].DataType.ToString(),
                    Size = new Size(80, 30),
                    Location = new Point(100, 50 + i * 40),
                };

                TextBox textBoxIdentificatorVariable = new TextBox
                {
                    Text = Diagram.Variables[i].Identificator.ToString(),
                    Size = new Size(80, 30),
                    Location = new Point(190, 50 + i * 40)
                };


                Button deleteButton = new Button
                {
                    Text = "X",
                    ForeColor = Color.Red,
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Popup,
                    Size = new Size(30, 23),
                    Location = new Point(280, 50 + i * 40),

                };

                boxAMVariable.SelectedValueChanged += (sender, e) => ChangeValuesAmVariable(index, boxAMVariable.SelectedIndex);
                textBoxDataTypeVariable.TextChanged += (sender, e) => ChangeValuesDataTypeVariable(index, textBoxDataTypeVariable.Text);
                textBoxIdentificatorVariable.TextChanged += (sender, e) => ChangeValuesIdentificatorVariable(index, textBoxIdentificatorVariable.Text);

                deleteButton.Click += (sender, e) => RemoveItemVariable(index);

                Controls.Add(boxAMVariable);
                Controls.Add(textBoxDataTypeVariable);
                Controls.Add(textBoxIdentificatorVariable);

                Controls.Add(deleteButton);

                AmVariables.Add(Diagram.Variables[i].Modifier);
                DataTypeVariables.Add(textBoxDataTypeVariable.Text);
                IdentificatorVariables.Add(textBoxIdentificatorVariable.Text);

                InitializeComponent();
            }

            int margin = Diagram.Variables.Count * 40 + 50 + 10;

            for (int i = 0; i < Diagram.Methods.Count; i++)
            {
                int index = i;

                ComboBox boxAMMethod = new ComboBox
                {
                    Size = new Size(80, 30),
                    Location = new Point(10, margin + i * 40),
                    Items = { "Public", "Private", "Protected", "Internal" },
                    SelectedItem = Diagram.Methods[i].Modifier.ToString(),
                };
                TextBox textBoxDataTypeMethod = new TextBox
                {
                    Text = Diagram.Methods[i].DataType.ToString(),
                    Size = new Size(80, 30),
                    Location = new Point(100, margin + i * 40),
                };
                TextBox textBoxIdentificatorMethod = new TextBox
                {
                    Text = Diagram.Methods[i].Identificator.ToString(),
                    Size = new Size(80, 30),
                    Location = new Point(190, margin + i * 40)
                };
                Button deleteButton = new Button
                {
                    Text = "X",
                    ForeColor = Color.Red,
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Popup,
                    Size = new Size(30, 23),
                    Location = new Point(280, margin + i * 40),

                };


                boxAMMethod.SelectedValueChanged += (sender, e) => ChangeValuesAmMethod(index, boxAMMethod.SelectedIndex);
                textBoxDataTypeMethod.TextChanged += (sender, e) => ChangeValuesDataTypeMethod(index, textBoxDataTypeMethod.Text);
                textBoxIdentificatorMethod.TextChanged += (sender, e) => ChangeValuesIdentificatorMethod(index, textBoxIdentificatorMethod.Text);
                deleteButton.Click += (sender, e) => RemoveItemMethod(index);
                
                Controls.Add(boxAMMethod);
                Controls.Add(textBoxDataTypeMethod);
                Controls.Add(textBoxIdentificatorMethod);

                Controls.Add(deleteButton);
                
                AmMethods.Add(Diagram.Methods[i].Modifier);
                DataTypeMethods.Add(textBoxDataTypeMethod.Text);
                IdentificatorMethods.Add(textBoxIdentificatorMethod.Text);

                InitializeComponent();
            }

        }
        private void ChangeValuesAmMethod(int index, int value) => AmMethods[index] = Enum.GetValues(typeof(AccessModifier)).Cast<AccessModifier>().ToList()[value];
        private void ChangeValuesDataTypeMethod(int index, string value) => DataTypeMethods[index] = value;
        private void ChangeValuesIdentificatorMethod(int index,string value) => IdentificatorMethods[index] = value;
        private void ChangeValuesAmVariable(int index, int value) => AmVariables[index] = Enum.GetValues(typeof(AccessModifier)).Cast<AccessModifier>().ToList()[value];
        private void ChangeValuesDataTypeVariable(int index, string value) => DataTypeVariables[index] = value;
        private void ChangeValuesIdentificatorVariable(int index, string value) => IdentificatorVariables[index] = value;
        private void RemoveItemVariable(int index)
        {
            DialogResult r = MessageBox.Show(
                $"You are about to delete variable {Diagram.Variables[index].Identificator} are you sure?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (r != DialogResult.Yes)
                return;


            Diagram.Variables.Remove(Diagram.Variables[index]);

            AmVariables.RemoveAt(index);
            DataTypeVariables.RemoveAt(index);
            IdentificatorVariables.RemoveAt(index);

            Controls.Clear();
            LoadButtons();
        }
        private void RemoveItemMethod(int index)
        {
            DialogResult r = MessageBox.Show(
                $"You are about to delete variable {Diagram.Methods[index].Identificator} are you sure?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (r != DialogResult.Yes)
                return;


            Diagram.Methods.RemoveAt(index);

            AmMethods.RemoveAt(index);
            DataTypeMethods.RemoveAt(index);
            IdentificatorMethods.RemoveAt(index);

            Controls.Clear();
            LoadButtons();
        }

        private void EditDiagram_Load(object sender, EventArgs e)
        {
            //classNameLabel.Text = Diagram.Name;

            ClonedDiagram = Diagram.Clone();
            AmVariables = new List<AccessModifier>();
            AmMethods = new List<AccessModifier>();
            DataTypeVariables = new List<string>();
            DataTypeMethods = new List<string>();
            IdentificatorVariables = new List<string>();
            IdentificatorMethods = new List<string>();
            LoadButtons();
        }
            private void EditDiagram_FormClosing(object sender, FormClosingEventArgs e)
            {

                for (int i = 0; i < Diagram.Variables.Count; i++)
                {
                    Diagram.Variables[i].Modifier = AmVariables[i];
                    Diagram.Variables[i].DataType = DataTypeVariables[i];
                    Diagram.Variables[i].Identificator = IdentificatorVariables[i];
                }
                for (int i = 0; i < Diagram.Methods.Count; i++)
                {
                    Diagram.Methods[i].Modifier = AmMethods[i];
                    Diagram.Methods[i].DataType = DataTypeMethods[i];
                    Diagram.Methods[i].Identificator = IdentificatorMethods[i];
                }
            //if(e.CloseReason == CloseReason.UserClosing  && Diagram != ClonedDiagram)
            //{
            //    DialogResult r = MessageBox.Show("Do you want to save your work?", "Confirm close", MessageBoxButtons.YesNoCancel);
            //    if (r == DialogResult.No)
            //    {
            //        Diagram= ClonedDiagram;
            //        //Diagram get rewritten to the copy made earlier
            //    }
            //    else if (r == DialogResult.Yes)
            //    {
            //        //Nothing happens
            //    }
            //    else if (r == DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //        //Window doesnt get closed
            //    }
            //}
            /*
            if (isClosingHandled) return;

            if (e.CloseReason == CloseReason.UserClosing && Diagram != ClonedDiagram)
            {
                isClosingHandled = true;

                DialogResult r = MessageBox.Show("Do you want to save your work?", "Confirm close", MessageBoxButtons.YesNo);
                if (r == DialogResult.No)
                {
                    Diagram = new UmlDiagram(1, 1); // Revert changes
                    Diagram = ClonedDiagram.Clone();
                }
                else if (r == DialogResult.Yes)
                {
                    // Save or proceed without changes
                }
            }
            */
        }

        private void addMethodButton_Click(object sender, EventArgs e)
        {
            Diagram.Methods.Add(new Method(AccessModifier.Public, "", "", new List<string>()));
            Controls.Clear();
            LoadButtons();
        }

        private void addVariableButton_Click(object sender, EventArgs e)
        {
            Diagram.Variables.Add(new Variable(AccessModifier.Public, "", ""));
            Controls.Clear();
            LoadButtons();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditClassName f = new EditClassName(Diagram);
            f.ShowDialog();
            LoadButtons();
        }
    }
}
