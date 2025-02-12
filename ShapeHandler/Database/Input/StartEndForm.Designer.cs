namespace ShapeHandler.Database.Input
{
    partial class StartEndForm
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
            this.StartCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // StartCheckBox
            // 
            this.StartCheckBox.AutoSize = true;
            this.StartCheckBox.Location = new System.Drawing.Point(41, 30);
            this.StartCheckBox.Name = "StartCheckBox";
            this.StartCheckBox.Size = new System.Drawing.Size(102, 17);
            this.StartCheckBox.TabIndex = 0;
            this.StartCheckBox.Text = "Is Start of Flow?";
            this.StartCheckBox.UseVisualStyleBackColor = true;
            this.StartCheckBox.CheckedChanged += new System.EventHandler(this.StartCheckBox_CheckedChanged);
            // 
            // StartEndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 74);
            this.Controls.Add(this.StartCheckBox);
            this.Name = "StartEndForm";
            this.Text = "StartEndForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox StartCheckBox;
    }
}