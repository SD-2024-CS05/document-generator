namespace ShapeHandler.Database
{
    partial class DecisionControlsForm
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
            this.addControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addControlButton
            // 
            this.addControlButton.Location = new System.Drawing.Point(615, 395);
            this.addControlButton.Name = "addControlButton";
            this.addControlButton.Size = new System.Drawing.Size(173, 43);
            this.addControlButton.TabIndex = 0;
            this.addControlButton.Text = "Add Control";
            this.addControlButton.UseVisualStyleBackColor = true;
            // 
            // DecisionControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addControlButton);
            this.Name = "DecisionControlsForm";
            this.Text = "Controls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addControlButton;
    }
}