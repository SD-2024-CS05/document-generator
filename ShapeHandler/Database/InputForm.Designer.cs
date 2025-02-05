namespace ShapeHandler.Database
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.typeLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.classesTextBox = new System.Windows.Forms.TextBox();
            this.classesLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(20, 38);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Type";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(20, 14);
            this.idLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "ID";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(20, 62);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(20, 86);
            this.valueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(34, 13);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "Value";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(20, 110);
            this.minLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(24, 13);
            this.minLabel.TabIndex = 4;
            this.minLabel.Text = "Min";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(20, 134);
            this.maxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(27, 13);
            this.maxLabel.TabIndex = 5;
            this.maxLabel.Text = "Max";
            // 
            // typeTextBox
            // 
            this.typeTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "button",
            "checkbox",
            "color",
            "date",
            "datetime-local",
            "email",
            "file",
            "hidde",
            "image",
            "month",
            "number",
            "password",
            "radio",
            "range",
            "reset",
            "search",
            "submit",
            "tel",
            "text",
            "time",
            "url",
            "week"});
            this.typeTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.typeTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.typeTextBox.Location = new System.Drawing.Point(127, 35);
            this.typeTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(102, 20);
            this.typeTextBox.TabIndex = 0;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(127, 11);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(102, 20);
            this.idTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(127, 59);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(102, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(127, 83);
            this.valueTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(102, 20);
            this.valueTextBox.TabIndex = 4;
            // 
            // minTextBox
            // 
            this.minTextBox.Location = new System.Drawing.Point(127, 107);
            this.minTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(102, 20);
            this.minTextBox.TabIndex = 5;
            // 
            // maxTextBox
            // 
            this.maxTextBox.Location = new System.Drawing.Point(127, 131);
            this.maxTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.Size = new System.Drawing.Size(102, 20);
            this.maxTextBox.TabIndex = 6;
            // 
            // classesTextBox
            // 
            this.classesTextBox.Location = new System.Drawing.Point(127, 155);
            this.classesTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.classesTextBox.Name = "classesTextBox";
            this.classesTextBox.Size = new System.Drawing.Size(102, 20);
            this.classesTextBox.TabIndex = 2;
            // 
            // classesLabel
            // 
            this.classesLabel.AutoSize = true;
            this.classesLabel.Location = new System.Drawing.Point(20, 158);
            this.classesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classesLabel.Name = "classesLabel";
            this.classesLabel.Size = new System.Drawing.Size(43, 13);
            this.classesLabel.TabIndex = 12;
            this.classesLabel.Text = "Classes";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 196);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(161, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 229);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.classesTextBox);
            this.Controls.Add(this.classesLabel);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.typeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InputForm";
            this.Text = "Input Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputForm_Closing);
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label classesLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox classesTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}