namespace ShapeHandler.Forms
{
    partial class ClassListForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ClassesTextBox = new System.Windows.Forms.TextBox();
            this.ClassesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(217, 194);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(106, 28);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 194);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 28);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ClassesTextBox
            // 
            this.ClassesTextBox.Location = new System.Drawing.Point(12, 43);
            this.ClassesTextBox.Multiline = true;
            this.ClassesTextBox.Name = "ClassesTextBox";
            this.ClassesTextBox.Size = new System.Drawing.Size(311, 145);
            this.ClassesTextBox.TabIndex = 4;
            // 
            // ClassesLabel
            // 
            this.ClassesLabel.AutoSize = true;
            this.ClassesLabel.Location = new System.Drawing.Point(12, 9);
            this.ClassesLabel.Name = "ClassesLabel";
            this.ClassesLabel.Size = new System.Drawing.Size(271, 20);
            this.ClassesLabel.TabIndex = 5;
            this.ClassesLabel.Text = "Enter classes separately on each line";
            // 
            // ClassListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 241);
            this.Controls.Add(this.ClassesLabel);
            this.Controls.Add(this.ClassesTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Name = "ClassListForm";
            this.Text = "Add Classes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox ClassesTextBox;
        private System.Windows.Forms.Label ClassesLabel;
    }
}