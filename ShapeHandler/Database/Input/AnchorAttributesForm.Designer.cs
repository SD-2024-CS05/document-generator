namespace ShapeHandler.Database.Input
{
    partial class AnchorAttributesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnchorAttributesForm));
            this.typeLabel = new System.Windows.Forms.Label();
            this.hrefLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.hrefTextBox = new System.Windows.Forms.TextBox();
            this.relTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.targetLabel = new System.Windows.Forms.Label();
            this.downloadTextBox = new System.Windows.Forms.TextBox();
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(56, 83);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(77, 32);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Type";
            // 
            // hrefLabel
            // 
            this.hrefLabel.AutoSize = true;
            this.hrefLabel.Location = new System.Drawing.Point(56, 141);
            this.hrefLabel.Name = "hrefLabel";
            this.hrefLabel.Size = new System.Drawing.Size(67, 32);
            this.hrefLabel.TabIndex = 1;
            this.hrefLabel.Text = "Href";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rel";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(368, 76);
            this.typeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(260, 38);
            this.typeTextBox.TabIndex = 0;
            // 
            // hrefTextBox
            // 
            this.hrefTextBox.Location = new System.Drawing.Point(368, 134);
            this.hrefTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hrefTextBox.Name = "hrefTextBox";
            this.hrefTextBox.Size = new System.Drawing.Size(260, 38);
            this.hrefTextBox.TabIndex = 2;
            // 
            // relTextBox
            // 
            this.relTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "alternate",
            "author",
            "bookmark",
            "external",
            "help",
            "license",
            "next",
            "nofollow",
            "noreferrer",
            "noopener",
            "prev",
            "search",
            "tag"});
            this.relTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.relTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.relTextBox.Location = new System.Drawing.Point(368, 186);
            this.relTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.relTextBox.Name = "relTextBox";
            this.relTextBox.Size = new System.Drawing.Size(260, 38);
            this.relTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(368, 24);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(260, 38);
            this.idTextBox.TabIndex = 1;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(56, 31);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(41, 32);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "ID";
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(56, 246);
            this.downloadLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(141, 32);
            this.downloadLabel.TabIndex = 7;
            this.downloadLabel.Text = "Download";
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Location = new System.Drawing.Point(56, 298);
            this.targetLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(96, 32);
            this.targetLabel.TabIndex = 8;
            this.targetLabel.Text = "Target";
            // 
            // downloadTextBox
            // 
            this.downloadTextBox.Location = new System.Drawing.Point(368, 238);
            this.downloadTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downloadTextBox.Name = "downloadTextBox";
            this.downloadTextBox.Size = new System.Drawing.Size(260, 38);
            this.downloadTextBox.TabIndex = 9;
            // 
            // targetTextBox
            // 
            this.targetTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "_blank",
            "_parent",
            "_self",
            "_top"});
            this.targetTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.targetTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.targetTextBox.Location = new System.Drawing.Point(368, 291);
            this.targetTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.Size = new System.Drawing.Size(260, 38);
            this.targetTextBox.TabIndex = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(32, 367);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 55);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(435, 367);
            this.saveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 55);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AnchorAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 451);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.targetTextBox);
            this.Controls.Add(this.downloadTextBox);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.relTextBox);
            this.Controls.Add(this.hrefTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hrefLabel);
            this.Controls.Add(this.typeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AnchorAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnchorAttributesForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label hrefLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox hrefTextBox;
        private System.Windows.Forms.TextBox relTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.TextBox downloadTextBox;
        private System.Windows.Forms.TextBox targetTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}