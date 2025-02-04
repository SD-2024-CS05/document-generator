namespace ShapeHandler.Database
{
    partial class ShapeDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeDataForm));
            this.button1 = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.addControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 427);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 46);
            this.button1.TabIndex = 13;
            this.button1.Text = "Okay";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(927, 427);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(124, 46);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // addControlButton
            // 
            this.addControlButton.Location = new System.Drawing.Point(13, 427);
            this.addControlButton.Margin = new System.Windows.Forms.Padding(4);
            this.addControlButton.Name = "addControlButton";
            this.addControlButton.Size = new System.Drawing.Size(172, 41);
            this.addControlButton.TabIndex = 16;
            this.addControlButton.Text = "Add Control";
            this.addControlButton.UseVisualStyleBackColor = true;
            this.addControlButton.Click += new System.EventHandler(this.addControlButton_Click);
            // 
            // ShapeDataForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 482);
            this.Controls.Add(this.addControlButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShapeDataForm";
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.ShapeDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button addControlButton;
    }
}