namespace DragAndDrop
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            editButton = new Button();
            addButton = new Button();
            removeButton = new Button();
            button1 = new Button();
            button3 = new Button();
            relationsButton = new Button();
            generateCodeButton = new Button();
            addPointButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.White;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(861, 611);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1021, 617);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(editButton, 0, 0);
            tableLayoutPanel3.Controls.Add(addButton, 0, 2);
            tableLayoutPanel3.Controls.Add(removeButton, 0, 1);
            tableLayoutPanel3.Controls.Add(relationsButton, 0, 3);
            tableLayoutPanel3.Controls.Add(button1, 0, 8);
            tableLayoutPanel3.Controls.Add(button3, 0, 7);
            tableLayoutPanel3.Controls.Add(generateCodeButton, 0, 6);
            tableLayoutPanel3.Controls.Add(addPointButton, 0, 4);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(870, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 9;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.Size = new Size(148, 611);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // editButton
            // 
            editButton.Dock = DockStyle.Fill;
            editButton.Location = new Point(3, 3);
            editButton.Name = "editButton";
            editButton.Size = new Size(142, 34);
            editButton.TabIndex = 0;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Fill;
            addButton.ForeColor = Color.Green;
            addButton.Location = new Point(3, 83);
            addButton.Name = "addButton";
            addButton.Size = new Size(142, 34);
            addButton.TabIndex = 1;
            addButton.Text = "New Class";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Dock = DockStyle.Fill;
            removeButton.ForeColor = Color.Red;
            removeButton.Location = new Point(3, 43);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(142, 34);
            removeButton.TabIndex = 2;
            removeButton.Text = "Delete";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(3, 574);
            button1.Name = "button1";
            button1.Size = new Size(142, 34);
            button1.TabIndex = 3;
            button1.Text = "Save as";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 534);
            button3.Name = "button3";
            button3.Size = new Size(142, 34);
            button3.TabIndex = 5;
            button3.Text = "Load";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // relationsButton
            // 
            relationsButton.Dock = DockStyle.Fill;
            relationsButton.ForeColor = Color.Green;
            relationsButton.Location = new Point(3, 123);
            relationsButton.Name = "relationsButton";
            relationsButton.Size = new Size(142, 34);
            relationsButton.TabIndex = 6;
            relationsButton.Text = "New Relation";
            relationsButton.UseVisualStyleBackColor = true;
            relationsButton.Click += relationsButton_Click;
            // 
            // generateCodeButton
            // 
            generateCodeButton.Location = new Point(3, 494);
            generateCodeButton.Name = "generateCodeButton";
            generateCodeButton.Size = new Size(142, 34);
            generateCodeButton.TabIndex = 2;
            generateCodeButton.Text = "Generate Code";
            generateCodeButton.UseVisualStyleBackColor = true;
            generateCodeButton.Click += generateCodeButton_Click;
            // 
            // addPointButton
            // 
            addPointButton.Dock = DockStyle.Fill;
            addPointButton.ForeColor = Color.Green;
            addPointButton.Location = new Point(3, 163);
            addPointButton.Name = "addPointButton";
            addPointButton.Size = new Size(142, 34);
            addPointButton.TabIndex = 7;
            addPointButton.Text = "New Point";
            addPointButton.UseVisualStyleBackColor = true;
            addPointButton.Click += addPointButton_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 617);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "DragAndDrop";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Button editButton;
        private Button addButton;
        private Button removeButton;
        private Button button1;
        private Button button3;
        private Button relationsButton;
        private Button generateCodeButton;
        private Button addPointButton;
    }
}
