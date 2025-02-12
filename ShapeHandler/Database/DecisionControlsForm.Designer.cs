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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecisionControlsForm));
            this.controlsView = new System.Windows.Forms.ListView();
            this.optionsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // controlsView
            // 
            this.controlsView.HideSelection = false;
            this.controlsView.Location = new System.Drawing.Point(12, 12);
            this.controlsView.Name = "controlsView";
            this.controlsView.Size = new System.Drawing.Size(776, 241);
            this.controlsView.TabIndex = 1;
            this.controlsView.UseCompatibleStateImageBehavior = false;
            // 
            // optionsComboBox
            // 
            this.optionsComboBox.FormattingEnabled = true;
            this.optionsComboBox.Items.AddRange(new object[] {
            "<button>"});
            this.optionsComboBox.Location = new System.Drawing.Point(433, 374);
            this.optionsComboBox.Name = "optionsComboBox";
            this.optionsComboBox.Size = new System.Drawing.Size(121, 39);
            this.optionsComboBox.TabIndex = 2;
            this.optionsComboBox.SelectedIndexChanged += new System.EventHandler(this.optionsComboBox_SelectedIndexChanged);
            // 
            // DecisionControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.optionsComboBox);
            this.Controls.Add(this.controlsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DecisionControlsForm";
            this.Text = "Controls";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView controlsView;
        private System.Windows.Forms.ComboBox optionsComboBox;
    }
}