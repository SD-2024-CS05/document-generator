namespace ShapeHandler.Database
{
    partial class DaForm
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
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Anchors", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Selects", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Images", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeDataForm));
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ControlListView = new System.Windows.Forms.ListView();
            this.IdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HtmlColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveControlButton = new System.Windows.Forms.Button();
            this.AddControlComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(334, 173);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(60, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(11, 173);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(49, 22);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ControlListView
            // 
            this.ControlListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumn,
            this.HtmlColumn});
            listViewGroup1.Header = "Inputs";
            listViewGroup1.Name = "InputGroup";
            listViewGroup2.Header = "Anchors";
            listViewGroup2.Name = "AnchorGroup";
            listViewGroup3.Header = "Selects";
            listViewGroup3.Name = "SelectGroup";
            listViewGroup4.Header = "Images";
            listViewGroup4.Name = "ImageGroup";
            this.ControlListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.ControlListView.HideSelection = false;
            this.ControlListView.Location = new System.Drawing.Point(11, 12);
            this.ControlListView.MultiSelect = false;
            this.ControlListView.Name = "ControlListView";
            this.ControlListView.Size = new System.Drawing.Size(382, 156);
            this.ControlListView.TabIndex = 17;
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
            // RemoveControlButton
            // 
            this.RemoveControlButton.Location = new System.Drawing.Point(65, 173);
            this.RemoveControlButton.Name = "RemoveControlButton";
            this.RemoveControlButton.Size = new System.Drawing.Size(94, 23);
            this.RemoveControlButton.TabIndex = 18;
            this.RemoveControlButton.Text = "Remove Control";
            this.RemoveControlButton.UseVisualStyleBackColor = true;
            this.RemoveControlButton.Click += new System.EventHandler(this.RemoveControlButton_Click);
            // 
            // AddControlComboBox
            // 
            this.AddControlComboBox.FormattingEnabled = true;
            this.AddControlComboBox.Items.AddRange(new object[] {
            "<input>",
            "<a>",
            "<select>",
            "<img>"});
            this.AddControlComboBox.Location = new System.Drawing.Point(208, 175);
            this.AddControlComboBox.Name = "AddControlComboBox";
            this.AddControlComboBox.Size = new System.Drawing.Size(121, 21);
            this.AddControlComboBox.TabIndex = 19;
            this.AddControlComboBox.SelectionChangeCommitted += new System.EventHandler(this.AddControlComboBox_SelectionChangeCommitted);
            // 
            // ShapeDataForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 202);
            this.Controls.Add(this.AddControlComboBox);
            this.Controls.Add(this.RemoveControlButton);
            this.Controls.Add(this.ControlListView);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShapeDataForm";
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.ShapeDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ListView ControlListView;
        private System.Windows.Forms.ColumnHeader IdColumn;
        private System.Windows.Forms.ColumnHeader HtmlColumn;
        private System.Windows.Forms.Button RemoveControlButton;
        private System.Windows.Forms.ComboBox AddControlComboBox;
    }
}