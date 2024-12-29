namespace DragAndDrop
{
    partial class SaveFileNameInputForm
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
            label1 = new Label();
            jsonSlashPngLabel = new Label();
            textBox1 = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter file name:";
            // 
            // jsonSlashPngLabel
            // 
            jsonSlashPngLabel.AutoSize = true;
            jsonSlashPngLabel.Location = new Point(299, 19);
            jsonSlashPngLabel.Name = "jsonSlashPngLabel";
            jsonSlashPngLabel.Size = new Size(38, 15);
            jsonSlashPngLabel.TabIndex = 1;
            jsonSlashPngLabel.Text = "label2";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(107, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 23);
            textBox1.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(262, 50);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(181, 50);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveFileNameInputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 88);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(textBox1);
            Controls.Add(jsonSlashPngLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SaveFileNameInputForm";
            Text = "SaveFileNameInputForm";
            Load += SaveFileNameInputForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label jsonSlashPngLabel;
        private TextBox textBox1;
        private Button saveButton;
        private Button cancelButton;
    }
}