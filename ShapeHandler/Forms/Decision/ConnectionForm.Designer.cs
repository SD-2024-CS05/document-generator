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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
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
            this.SubmissionComboBox.Location = new System.Drawing.Point(344, 38);
            this.SubmissionComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SubmissionComboBox.Name = "SubmissionComboBox";
            this.SubmissionComboBox.Size = new System.Drawing.Size(316, 39);
            this.SubmissionComboBox.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(35, 367);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(200, 55);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(467, 367);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(200, 55);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(344, 103);
            this.UrlTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(316, 38);
            this.UrlTextBox.TabIndex = 3;
            // 
            // SubmissionLabel
            // 
            this.SubmissionLabel.AutoSize = true;
            this.SubmissionLabel.Location = new System.Drawing.Point(27, 38);
            this.SubmissionLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.SubmissionLabel.Name = "SubmissionLabel";
            this.SubmissionLabel.Size = new System.Drawing.Size(261, 32);
            this.SubmissionLabel.TabIndex = 4;
            this.SubmissionLabel.Text = "Submission Control";
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(27, 103);
            this.UrlLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(70, 32);
            this.UrlLabel.TabIndex = 5;
            this.UrlLabel.Text = "URL";
            // 
            // AddConditionButton
            // 
            this.AddConditionButton.Location = new System.Drawing.Point(35, 167);
            this.AddConditionButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddConditionButton.Name = "AddConditionButton";
            this.AddConditionButton.Size = new System.Drawing.Size(632, 186);
            this.AddConditionButton.TabIndex = 6;
            this.AddConditionButton.Text = "Add Conditions";
            this.AddConditionButton.UseVisualStyleBackColor = true;
            this.AddConditionButton.Click += new System.EventHandler(this.AddConditionButton_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 451);
            this.Controls.Add(this.AddConditionButton);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.SubmissionLabel);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmissionComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ConnectionForm";
            this.Text = "Connection";
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