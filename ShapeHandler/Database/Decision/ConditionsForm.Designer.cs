namespace ShapeHandler.Database.Decision
{
    partial class ConditionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionsForm));
            this.SaveButton = new System.Windows.Forms.Button();
            this.ElementComboBox1 = new System.Windows.Forms.ComboBox();
            this.OperatorComboBox1 = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(645, 415);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(352, 55);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ElementComboBox1
            // 
            this.ElementComboBox1.FormattingEnabled = true;
            this.ElementComboBox1.Location = new System.Drawing.Point(35, 31);
            this.ElementComboBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ElementComboBox1.Name = "ElementComboBox1";
            this.ElementComboBox1.Size = new System.Drawing.Size(316, 39);
            this.ElementComboBox1.TabIndex = 1;
            // 
            // OperatorComboBox1
            // 
            this.OperatorComboBox1.FormattingEnabled = true;
            this.OperatorComboBox1.Location = new System.Drawing.Point(373, 31);
            this.OperatorComboBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.OperatorComboBox1.Name = "OperatorComboBox1";
            this.OperatorComboBox1.Size = new System.Drawing.Size(127, 39);
            this.OperatorComboBox1.TabIndex = 2;
            this.OperatorComboBox1.SelectionChangeCommitted += new System.EventHandler(this.OperatorComboBox1_SelectionChangeCommitted);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(32, 415);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(352, 55);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConditionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 498);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OperatorComboBox1);
            this.Controls.Add(this.ElementComboBox1);
            this.Controls.Add(this.SaveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ConditionsForm";
            this.Text = "Conditions";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ElementComboBox;
        private System.Windows.Forms.ComboBox OperatorComboBox;
        private System.Windows.Forms.Button AddConditionButton;

        
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox ElementComboBox1;
        private System.Windows.Forms.ComboBox OperatorComboBox1;
        private System.Windows.Forms.Button CancelButton;
    }
}