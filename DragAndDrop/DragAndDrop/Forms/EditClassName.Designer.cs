namespace DragAndDrop.Forms
{
    partial class EditClassName
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
            confirmButton = new Button();
            cancelButton = new Button();
            textBox1 = new TextBox();
            clearButton = new Button();
            SuspendLayout();
            // 
            // confirmButton
            // 
            confirmButton.ForeColor = Color.Green;
            confirmButton.Location = new Point(285, 58);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(75, 23);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.ForeColor = Color.Red;
            cancelButton.Location = new Point(204, 58);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 23);
            textBox1.TabIndex = 2;
            // 
            // clearButton
            // 
            clearButton.ForeColor = Color.Red;
            clearButton.Location = new Point(339, 21);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(21, 23);
            clearButton.TabIndex = 3;
            clearButton.Text = "X";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // EditClassName
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 93);
            Controls.Add(clearButton);
            Controls.Add(textBox1);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Name = "EditClassName";
            Text = "EditClassName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmButton;
        private Button cancelButton;
        private TextBox textBox1;
        private Button clearButton;
    }
}