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
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // controlsView
            // 
            this.controlsView.HideSelection = false;
            this.controlsView.Location = new System.Drawing.Point(1, 11);
            this.controlsView.Margin = new System.Windows.Forms.Padding(2);
            this.controlsView.Name = "controlsView";
            this.controlsView.Size = new System.Drawing.Size(438, 157);
            this.controlsView.TabIndex = 1;
            this.controlsView.UseCompatibleStateImageBehavior = false;
            this.controlsView.SelectedIndexChanged += new System.EventHandler(this.controlsView_SelectedIndexChanged);
            // 
            // optionsComboBox
            // 
            this.optionsComboBox.FormattingEnabled = true;
            this.optionsComboBox.Items.AddRange(new object[] {
            "<button>"});
            this.optionsComboBox.Location = new System.Drawing.Point(78, 236);
            this.optionsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.optionsComboBox.Name = "optionsComboBox";
            this.optionsComboBox.Size = new System.Drawing.Size(70, 28);
            this.optionsComboBox.TabIndex = 2;
            this.optionsComboBox.SelectedIndexChanged += new System.EventHandler(this.optionsComboBox_SelectedIndexChanged);
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(363, 241);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(75, 28);
            this.okayButton.TabIndex = 3;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(273, 241);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DecisionControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 290);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.optionsComboBox);
            this.Controls.Add(this.controlsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DecisionControlsForm";
            this.Text = "Controls";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView controlsView;
        private System.Windows.Forms.ComboBox optionsComboBox;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
    }
}