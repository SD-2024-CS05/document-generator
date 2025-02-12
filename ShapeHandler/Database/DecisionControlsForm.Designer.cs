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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Inputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecisionControlsForm));
            this.ControlListView = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HtmlColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddControlComboBox = new System.Windows.Forms.ComboBox();
            this.RemoveControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ControlListView
            // 
            this.ControlListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumn,
            this.HtmlColumn});
            listViewGroup1.Header = "Inputs";
            listViewGroup1.Name = "ButtonGroup";
            this.ControlListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.ControlListView.HideSelection = false;
            this.ControlListView.Location = new System.Drawing.Point(17, 16);
            this.ControlListView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ControlListView.MultiSelect = false;
            this.ControlListView.Name = "ControlListView";
            this.ControlListView.Size = new System.Drawing.Size(1012, 366);
            this.ControlListView.TabIndex = 22;
            this.ControlListView.UseCompatibleStateImageBehavior = false;
            this.ControlListView.View = System.Windows.Forms.View.Details;
            // 
            // IdColumn
            // 
            this.IdColumn.Text = "ID";
            this.IdColumn.Width = 135;
            // 
            // HtmlColumn
            // 
            this.HtmlColumn.Text = "HTML";
            this.HtmlColumn.Width = 243;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(17, 400);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(131, 52);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(879, 400);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(160, 55);
            this.SaveButton.TabIndex = 20;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddControlComboBox
            // 
            this.AddControlComboBox.FormattingEnabled = true;
            this.AddControlComboBox.Items.AddRange(new object[] {
            "<button>"});
            this.AddControlComboBox.Location = new System.Drawing.Point(543, 404);
            this.AddControlComboBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddControlComboBox.Name = "AddControlComboBox";
            this.AddControlComboBox.Size = new System.Drawing.Size(316, 39);
            this.AddControlComboBox.TabIndex = 24;
            this.AddControlComboBox.SelectionChangeCommitted += new System.EventHandler(this.AddControlComboBox_SelectionChangeCommitted);
            // 
            // RemoveControlButton
            // 
            this.RemoveControlButton.Location = new System.Drawing.Point(161, 400);
            this.RemoveControlButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.RemoveControlButton.Name = "RemoveControlButton";
            this.RemoveControlButton.Size = new System.Drawing.Size(251, 55);
            this.RemoveControlButton.TabIndex = 23;
            this.RemoveControlButton.Text = "Remove Control";
            this.RemoveControlButton.UseVisualStyleBackColor = true;
            this.RemoveControlButton.Click += new System.EventHandler(this.RemoveControlButton_Click);
            // 
            // DecisionControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 485);
            this.Controls.Add(this.ControlListView);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddControlComboBox);
            this.Controls.Add(this.RemoveControlButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DecisionControlsForm";
            this.Text = "Controls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ControlListView;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader HtmlColumn;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox AddControlComboBox;
        private System.Windows.Forms.Button RemoveControlButton;
    }
}