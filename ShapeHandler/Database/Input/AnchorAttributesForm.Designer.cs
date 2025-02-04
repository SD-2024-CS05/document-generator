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
            this.relTextBox = new System.Windows.Forms.TextBox();
            this.relLabel = new System.Windows.Forms.Label();
            this.hrefTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.hrefLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // relTextBox
            // 
            this.relTextBox.Location = new System.Drawing.Point(184, 97);
            this.relTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.relTextBox.Name = "relTextBox";
            this.relTextBox.Size = new System.Drawing.Size(132, 38);
            this.relTextBox.TabIndex = 33;
            // 
            // relLabel
            // 
            this.relLabel.AutoSize = true;
            this.relLabel.Location = new System.Drawing.Point(96, 100);
            this.relLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.relLabel.Name = "relLabel";
            this.relLabel.Size = new System.Drawing.Size(57, 32);
            this.relLabel.TabIndex = 32;
            this.relLabel.Text = "Rel";
            this.relLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // hrefTextBox
            // 
            this.hrefTextBox.Location = new System.Drawing.Point(184, 51);
            this.hrefTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.hrefTextBox.Name = "hrefTextBox";
            this.hrefTextBox.Size = new System.Drawing.Size(132, 38);
            this.hrefTextBox.TabIndex = 27;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(184, 5);
            this.typeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(132, 38);
            this.typeTextBox.TabIndex = 26;
            // 
            // hrefLabel
            // 
            this.hrefLabel.AutoSize = true;
            this.hrefLabel.Location = new System.Drawing.Point(105, 54);
            this.hrefLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrefLabel.Name = "hrefLabel";
            this.hrefLabel.Size = new System.Drawing.Size(67, 32);
            this.hrefLabel.TabIndex = 21;
            this.hrefLabel.Text = "Href";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Type";
            // 
            // AnchorAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.relTextBox);
            this.Controls.Add(this.relLabel);
            this.Controls.Add(this.hrefTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.hrefLabel);
            this.Controls.Add(this.label1);
            this.Name = "AnchorAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnchorAttributesForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox relTextBox;
        private System.Windows.Forms.Label relLabel;
        private System.Windows.Forms.TextBox hrefTextBox;
        public System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label hrefLabel;
        private System.Windows.Forms.Label label1;
    }
}