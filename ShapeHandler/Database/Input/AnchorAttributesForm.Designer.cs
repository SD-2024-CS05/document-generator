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
            this.typeLabel = new System.Windows.Forms.Label();
            this.hrefLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.hrefTextBox = new System.Windows.Forms.TextBox();
            this.relTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(12, 9);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(77, 32);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Type";
            // 
            // hrefLabel
            // 
            this.hrefLabel.AutoSize = true;
            this.hrefLabel.Location = new System.Drawing.Point(22, 103);
            this.hrefLabel.Name = "hrefLabel";
            this.hrefLabel.Size = new System.Drawing.Size(67, 32);
            this.hrefLabel.TabIndex = 1;
            this.hrefLabel.Text = "Href";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rel";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(95, 9);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(100, 38);
            this.typeTextBox.TabIndex = 0;
            // 
            // hrefTextBox
            // 
            this.hrefTextBox.Location = new System.Drawing.Point(95, 97);
            this.hrefTextBox.Name = "hrefTextBox";
            this.hrefTextBox.Size = new System.Drawing.Size(100, 38);
            this.hrefTextBox.TabIndex = 2;
            // 
            // relTextBox
            // 
            this.relTextBox.Location = new System.Drawing.Point(95, 141);
            this.relTextBox.Name = "relTextBox";
            this.relTextBox.Size = new System.Drawing.Size(100, 38);
            this.relTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(95, 53);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 38);
            this.idTextBox.TabIndex = 1;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(48, 56);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(41, 32);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "ID";
            // 
            // AnchorAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.relTextBox);
            this.Controls.Add(this.hrefTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hrefLabel);
            this.Controls.Add(this.typeLabel);
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
    }
}