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
            this.label5 = new System.Windows.Forms.Label();
            this.HTMLOptions = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AddElement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 25);
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
            this.HTMLOptions.Location = new System.Drawing.Point(85, 12);
            this.HTMLOptions.Name = "HTMLOptions";
            this.HTMLOptions.Size = new System.Drawing.Size(121, 33);
            this.HTMLOptions.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "Okay";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(695, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddElement
            // 
            this.AddElement.Location = new System.Drawing.Point(212, 12);
            this.AddElement.Name = "AddElement";
            this.AddElement.Size = new System.Drawing.Size(59, 33);
            this.AddElement.TabIndex = 15;
            this.AddElement.Text = "+";
            this.AddElement.UseVisualStyleBackColor = true;
            this.AddElement.Click += new System.EventHandler(this.AddElement_Click);
            // 
            // ShapeDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 389);
            this.Controls.Add(this.AddElement);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HTMLOptions);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddElement;
    }
}