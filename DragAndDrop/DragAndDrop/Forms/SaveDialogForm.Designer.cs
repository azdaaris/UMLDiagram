namespace DragAndDrop
{
    partial class SaveDialogForm
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
            textBox1 = new TextBox();
            SaveAsImgButton = new Button();
            saveAsJsonButton = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            browseButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 23);
            textBox1.TabIndex = 0;
            // 
            // SaveAsImgButton
            // 
            SaveAsImgButton.Location = new Point(12, 56);
            SaveAsImgButton.Name = "SaveAsImgButton";
            SaveAsImgButton.Size = new Size(190, 23);
            SaveAsImgButton.TabIndex = 1;
            SaveAsImgButton.Text = "Save as Img";
            SaveAsImgButton.UseVisualStyleBackColor = true;
            SaveAsImgButton.Click += SaveAsImgButton_Click;
            // 
            // saveAsJsonButton
            // 
            saveAsJsonButton.Location = new Point(208, 56);
            saveAsJsonButton.Name = "saveAsJsonButton";
            saveAsJsonButton.Size = new Size(167, 23);
            saveAsJsonButton.TabIndex = 2;
            saveAsJsonButton.Text = "Save as JSON";
            saveAsJsonButton.UseVisualStyleBackColor = true;
            saveAsJsonButton.Click += saveAsJsonButton_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(304, 12);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(71, 23);
            browseButton.TabIndex = 3;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // SaveDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 94);
            Controls.Add(browseButton);
            Controls.Add(saveAsJsonButton);
            Controls.Add(SaveAsImgButton);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SaveDialogForm";
            Text = "SaveDialogForm";
            Load += SaveDialogForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button SaveAsImgButton;
        private Button saveAsJsonButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button browseButton;
    }
}