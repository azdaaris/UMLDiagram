namespace DragAndDrop
{
    partial class EditDiagram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            editButton = new Button();
            saveButton = new Button();
            addMethodButton = new Button();
            addVariableButton = new Button();
            SuspendLayout();
            // 
            // editButton
            // 
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.ForeColor = SystemColors.Control;
            editButton.Image = Properties.Resources.edit1;
            editButton.Location = new Point(271, 12);
            editButton.Name = "editButton";
            editButton.Size = new Size(44, 34);
            editButton.TabIndex = 1;
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(240, 599);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // addMethodButton
            // 
            addMethodButton.Location = new Point(137, 599);
            addMethodButton.Name = "addMethodButton";
            addMethodButton.Size = new Size(97, 23);
            addMethodButton.TabIndex = 3;
            addMethodButton.Text = "Add Method";
            addMethodButton.UseVisualStyleBackColor = true;
            addMethodButton.Click += addMethodButton_Click;
            // 
            // addVariableButton
            // 
            addVariableButton.Location = new Point(33, 599);
            addVariableButton.Name = "addVariableButton";
            addVariableButton.Size = new Size(98, 23);
            addVariableButton.TabIndex = 4;
            addVariableButton.Text = "Add Variable";
            addVariableButton.UseVisualStyleBackColor = true;
            addVariableButton.Click += addVariableButton_Click;
            // 
            // EditDiagram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 634);
            Controls.Add(editButton);
            Controls.Add(addVariableButton);
            Controls.Add(addMethodButton);
            Controls.Add(saveButton);
            Name = "EditDiagram";
            Text = "EditDiagram";
            FormClosing += EditDiagram_FormClosing;
            Load += EditDiagram_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button saveButton;
        private Button addMethodButton;
        private Button addVariableButton;
        private Button editButton;
    }
}