using Visio = Microsoft.Office.Interop.Visio;
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
            this.label5 = new System.Windows.Forms.Label();
            this.HTMLOptions = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddElement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Type";
            // 
            // HTMLOptions
            // 
            this.HTMLOptions.FormattingEnabled = true;
            this.HTMLOptions.Items.AddRange(new object[] {
            "<input>",
            "<button>",
            "<select>",
            "<a>",
            "<img>"});
            this.HTMLOptions.Location = new System.Drawing.Point(113, 15);
            this.HTMLOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HTMLOptions.Name = "HTMLOptions";
            this.HTMLOptions.Size = new System.Drawing.Size(160, 39);
            this.HTMLOptions.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 427);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(124, 46);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddElement
            // 
            this.AddElement.Location = new System.Drawing.Point(283, 15);
            this.AddElement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddElement.Name = "AddElement";
            this.AddElement.Size = new System.Drawing.Size(79, 41);
            this.AddElement.TabIndex = 15;
            this.AddElement.Text = "+";
            this.AddElement.UseVisualStyleBackColor = true;
            this.AddElement.Click += new System.EventHandler(this.AddElement_Click);
            // 
            // ShapeDataForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 482);
            this.Controls.Add(this.AddElement);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HTMLOptions);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShapeDataForm";
            this.Text = "Shape Data Form";
            this.Load += new System.EventHandler(this.ShapeDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox HTMLOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AddElement;
    }
}