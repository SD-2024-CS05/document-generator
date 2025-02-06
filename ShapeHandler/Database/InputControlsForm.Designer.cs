namespace ShapeHandler.Database
{
    partial class InputControlsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputControlsForm));
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(785, 427);
            this.okayButton.Margin = new System.Windows.Forms.Padding(4);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(124, 46);
            this.okayButton.TabIndex = 13;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(927, 427);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(124, 46);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            this.addControlButton.Click += new System.EventHandler(this.AddControlButton_Click);
            // 
            // InputControlsForm
            // 
            this.AcceptButton = this.okayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 482);
            this.Controls.Add(this.addControlButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InputControlsForm";
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.ShapeDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addControlButton;
    }
}