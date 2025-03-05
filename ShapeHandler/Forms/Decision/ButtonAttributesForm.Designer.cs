namespace ShapeHandler.Database.Input
{
    partial class ButtonAttributesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonAttributesForm));
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ButtonDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autofocusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDisabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iHtmlButtonElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlButtonElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(624, 374);
            this.AddButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(200, 55);
            this.AddButton.TabIndex = 49;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(229, 374);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(200, 55);
            this.RemoveButton.TabIndex = 48;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(840, 374);
            this.saveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 55);
            this.saveButton.TabIndex = 47;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(11, 374);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 55);
            this.cancelButton.TabIndex = 46;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ButtonDataGridView
            // 
            this.ButtonDataGridView.AutoGenerateColumns = false;
            this.ButtonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ButtonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.autofocusDataGridViewCheckBoxColumn,
            this.isDisabledDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.ButtonDataGridView.DataSource = this.iHtmlButtonElementBindingSource;
            this.ButtonDataGridView.Location = new System.Drawing.Point(32, 29);
            this.ButtonDataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ButtonDataGridView.Name = "ButtonDataGridView";
            this.ButtonDataGridView.RowHeadersWidth = 102;
            this.ButtonDataGridView.Size = new System.Drawing.Size(989, 331);
            this.ButtonDataGridView.TabIndex = 50;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.MinimumWidth = 12;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdColumn.Width = 250;
            // 
            // autofocusDataGridViewCheckBoxColumn
            // 
            this.autofocusDataGridViewCheckBoxColumn.DataPropertyName = "Autofocus";
            this.autofocusDataGridViewCheckBoxColumn.HeaderText = "Autofocus";
            this.autofocusDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.autofocusDataGridViewCheckBoxColumn.Name = "autofocusDataGridViewCheckBoxColumn";
            this.autofocusDataGridViewCheckBoxColumn.Width = 250;
            // 
            // isDisabledDataGridViewCheckBoxColumn
            // 
            this.isDisabledDataGridViewCheckBoxColumn.DataPropertyName = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn.HeaderText = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isDisabledDataGridViewCheckBoxColumn.Name = "isDisabledDataGridViewCheckBoxColumn";
            this.isDisabledDataGridViewCheckBoxColumn.Width = 250;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "button",
            "reset",
            "submit"});
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.typeDataGridViewTextBoxColumn.Width = 250;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 250;
            // 
            // iHtmlButtonElementBindingSource
            // 
            this.iHtmlButtonElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlButtonElement);
            // 
            // ButtonAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 444);
            this.Controls.Add(this.ButtonDataGridView);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ButtonAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ButtonAttributesForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlButtonElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView ButtonDataGridView;
        private System.Windows.Forms.BindingSource iHtmlButtonElementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autofocusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}