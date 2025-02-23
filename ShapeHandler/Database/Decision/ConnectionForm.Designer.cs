namespace ShapeHandler.Database.Decision
{
    partial class ConnectionForm
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
            this.SubmissionComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.SubmissionLabel = new System.Windows.Forms.Label();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.AddConditionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubmissionComboBox
            // 
            this.SubmissionComboBox.FormattingEnabled = true;
            this.SubmissionComboBox.Location = new System.Drawing.Point(129, 16);
            this.SubmissionComboBox.Name = "SubmissionComboBox";
            this.SubmissionComboBox.Size = new System.Drawing.Size(121, 21);
            this.SubmissionComboBox.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(13, 154);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(175, 154);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(129, 43);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(121, 20);
            this.UrlTextBox.TabIndex = 3;
            // 
            // SubmissionLabel
            // 
            this.SubmissionLabel.AutoSize = true;
            this.SubmissionLabel.Location = new System.Drawing.Point(10, 16);
            this.SubmissionLabel.Name = "SubmissionLabel";
            this.SubmissionLabel.Size = new System.Drawing.Size(96, 13);
            this.SubmissionLabel.TabIndex = 4;
            this.SubmissionLabel.Text = "Submission Control";
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(10, 43);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(29, 13);
            this.UrlLabel.TabIndex = 5;
            this.UrlLabel.Text = "URL";
            // 
            // AddConditionButton
            // 
            this.AddConditionButton.Location = new System.Drawing.Point(13, 70);
            this.AddConditionButton.Name = "AddConditionButton";
            this.AddConditionButton.Size = new System.Drawing.Size(237, 78);
            this.AddConditionButton.TabIndex = 6;
            this.AddConditionButton.Text = "Add Conditions";
            this.AddConditionButton.UseVisualStyleBackColor = true;
            this.AddConditionButton.Click += new System.EventHandler(this.AddConditionButton_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 189);
            this.Controls.Add(this.AddConditionButton);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.SubmissionLabel);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmissionComboBox);
            this.Name = "ConnectionForm";
            this.Text = "ConnectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SubmissionComboBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label SubmissionLabel;
        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.Button AddConditionButton;
    }
}