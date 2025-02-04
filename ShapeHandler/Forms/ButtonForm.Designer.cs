namespace ShapeHandler.Forms
{
    partial class ButtonForm
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
            this.IdLabel = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.FormActionLabel = new System.Windows.Forms.Label();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            this.ClassTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.FormActionTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DisabledCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(18, 8);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(18, 13);
            this.IdLabel.TabIndex = 0;
            this.IdLabel.Text = "ID";
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Location = new System.Drawing.Point(18, 34);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(32, 13);
            this.ClassLabel.TabIndex = 1;
            this.ClassLabel.Text = "Class";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(18, 60);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "Type";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(18, 86);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Name";
            this.NameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(18, 112);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(34, 13);
            this.ValueLabel.TabIndex = 4;
            this.ValueLabel.Text = "Value";
            // 
            // FormActionLabel
            // 
            this.FormActionLabel.AutoSize = true;
            this.FormActionLabel.Location = new System.Drawing.Point(17, 138);
            this.FormActionLabel.Name = "FormActionLabel";
            this.FormActionLabel.Size = new System.Drawing.Size(63, 13);
            this.FormActionLabel.TabIndex = 6;
            this.FormActionLabel.Text = "Form Action";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(126, 5);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdTextBox.TabIndex = 7;
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "button",
            "submit",
            "reset"});
            this.TypeTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TypeTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TypeTextBox.Location = new System.Drawing.Point(126, 57);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.TypeTextBox.TabIndex = 8;
            // 
            // ClassTextBox
            // 
            this.ClassTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ClassTextBox.Location = new System.Drawing.Point(126, 31);
            this.ClassTextBox.Name = "ClassTextBox";
            this.ClassTextBox.Size = new System.Drawing.Size(100, 20);
            this.ClassTextBox.TabIndex = 9;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(126, 83);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 10;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(126, 109);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.ValueTextBox.TabIndex = 11;
            // 
            // FormActionTextBox
            // 
            this.FormActionTextBox.Location = new System.Drawing.Point(126, 135);
            this.FormActionTextBox.Name = "FormActionTextBox";
            this.FormActionTextBox.Size = new System.Drawing.Size(100, 20);
            this.FormActionTextBox.TabIndex = 12;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(13, 253);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(193, 253);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DisabledCheckBox
            // 
            this.DisabledCheckBox.AutoSize = true;
            this.DisabledCheckBox.Location = new System.Drawing.Point(20, 164);
            this.DisabledCheckBox.Name = "DisabledCheckBox";
            this.DisabledCheckBox.Size = new System.Drawing.Size(73, 17);
            this.DisabledCheckBox.TabIndex = 17;
            this.DisabledCheckBox.Text = "Disabled?";
            this.DisabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // ButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 288);
            this.Controls.Add(this.DisabledCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.FormActionTextBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ClassTextBox);
            this.Controls.Add(this.TypeTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.FormActionLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.IdLabel);
            this.Name = "ButtonForm";
            this.Text = "ButtonForm";
            this.Load += new System.EventHandler(this.ButtonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label FormActionLabel;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox TypeTextBox;
        private System.Windows.Forms.TextBox ClassTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.TextBox FormActionTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox DisabledCheckBox;
    }
}