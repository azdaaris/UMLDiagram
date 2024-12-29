namespace DragAndDrop
{
    partial class LoadFromFileForm
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
            pathTextBox = new TextBox();
            pathLabel = new Label();
            browseButton = new Button();
            loadButton = new Button();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(52, 20);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(256, 23);
            pathTextBox.TabIndex = 0;
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(12, 23);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(34, 15);
            pathLabel.TabIndex = 1;
            pathLabel.Text = "Path:";
            // 
            // browseButton
            // 
            browseButton.Location = new Point(314, 20);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 23);
            browseButton.TabIndex = 2;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(314, 57);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 3;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += this.loadButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(233, 57);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk_1;
            // 
            // LoadFromFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 91);
            Controls.Add(button3);
            Controls.Add(loadButton);
            Controls.Add(browseButton);
            Controls.Add(pathLabel);
            Controls.Add(pathTextBox);
            Name = "LoadFromFileForm";
            Text = "LoadFromFile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pathTextBox;
        private Label pathLabel;
        private Button browseButton;
        private Button loadButton;
        private Button button3;
        private OpenFileDialog openFileDialog1;
    }
}