namespace ShapeHandler.Database.Input
{
    partial class SelectAttributesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectAttributesForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SelectDataGridView = new System.Windows.Forms.DataGridView();
            this.iHtmlSelectElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RemoveSelectButton = new System.Windows.Forms.Button();
            this.AddSelectButton = new System.Windows.Forms.Button();
            this.OptionDataGridView = new System.Windows.Forms.DataGridView();
            this.iHtmlOptionElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.RemoveOptionButton = new System.Windows.Forms.Button();
            this.AddOptionButton = new System.Windows.Forms.Button();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectClassesColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.autofocusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDisabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRequiredDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMultipleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selectedIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectIdColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OptionIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionClassesColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.isDisabledDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.labelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDefaultSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SelectDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlSelectElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlOptionElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(22, 474);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 35);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(489, 474);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 35);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SelectDataGridView
            // 
            this.SelectDataGridView.AutoGenerateColumns = false;
            this.SelectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.SelectClassesColumn,
            this.autofocusDataGridViewCheckBoxColumn,
            this.isDisabledDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.isRequiredDataGridViewCheckBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.isMultipleDataGridViewCheckBoxColumn,
            this.selectedIndexDataGridViewTextBoxColumn});
            this.SelectDataGridView.DataSource = this.iHtmlSelectElementBindingSource;
            this.SelectDataGridView.Location = new System.Drawing.Point(18, 18);
            this.SelectDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectDataGridView.Name = "SelectDataGridView";
            this.SelectDataGridView.RowHeadersWidth = 102;
            this.SelectDataGridView.Size = new System.Drawing.Size(579, 211);
            this.SelectDataGridView.TabIndex = 13;
            this.SelectDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectDataGridView_CellValueChanged);
            this.SelectDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.SelectDataGridView_RowsRemoved);
            // 
            // iHtmlSelectElementBindingSource
            // 
            this.iHtmlSelectElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlSelectElement);
            // 
            // RemoveSelectButton
            // 
            this.RemoveSelectButton.Location = new System.Drawing.Point(22, 238);
            this.RemoveSelectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemoveSelectButton.Name = "RemoveSelectButton";
            this.RemoveSelectButton.Size = new System.Drawing.Size(112, 35);
            this.RemoveSelectButton.TabIndex = 14;
            this.RemoveSelectButton.Text = "Remove";
            this.RemoveSelectButton.UseVisualStyleBackColor = true;
            this.RemoveSelectButton.Click += new System.EventHandler(this.RemoveSelectButton_Click);
            // 
            // AddSelectButton
            // 
            this.AddSelectButton.Location = new System.Drawing.Point(489, 238);
            this.AddSelectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddSelectButton.Name = "AddSelectButton";
            this.AddSelectButton.Size = new System.Drawing.Size(112, 35);
            this.AddSelectButton.TabIndex = 15;
            this.AddSelectButton.Text = "Add";
            this.AddSelectButton.UseVisualStyleBackColor = true;
            this.AddSelectButton.Click += new System.EventHandler(this.AddSelectButton_Click);
            // 
            // OptionDataGridView
            // 
            this.OptionDataGridView.AutoGenerateColumns = false;
            this.OptionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OptionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectIdColumn,
            this.OptionIdColumn,
            this.OptionClassesColumn,
            this.isDisabledDataGridViewCheckBoxColumn1,
            this.labelDataGridViewTextBoxColumn,
            this.isDefaultSelectedDataGridViewCheckBoxColumn,
            this.isSelectedDataGridViewCheckBoxColumn,
            this.valueDataGridViewTextBoxColumn1,
            this.textDataGridViewTextBoxColumn,
            this.indexDataGridViewTextBoxColumn});
            this.OptionDataGridView.DataSource = this.iHtmlOptionElementBindingSource;
            this.OptionDataGridView.Location = new System.Drawing.Point(24, 294);
            this.OptionDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OptionDataGridView.Name = "OptionDataGridView";
            this.OptionDataGridView.RowHeadersWidth = 102;
            this.OptionDataGridView.Size = new System.Drawing.Size(578, 148);
            this.OptionDataGridView.TabIndex = 16;
            // 
            // iHtmlOptionElementBindingSource
            // 
            this.iHtmlOptionElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlOptionElement);
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Location = new System.Drawing.Point(278, 269);
            this.OptionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(64, 20);
            this.OptionsLabel.TabIndex = 17;
            this.OptionsLabel.Text = "Options";
            // 
            // RemoveOptionButton
            // 
            this.RemoveOptionButton.Location = new System.Drawing.Point(158, 451);
            this.RemoveOptionButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemoveOptionButton.Name = "RemoveOptionButton";
            this.RemoveOptionButton.Size = new System.Drawing.Size(112, 35);
            this.RemoveOptionButton.TabIndex = 18;
            this.RemoveOptionButton.Text = "Remove";
            this.RemoveOptionButton.UseVisualStyleBackColor = true;
            this.RemoveOptionButton.Click += new System.EventHandler(this.RemoveOptionButton_Click);
            // 
            // AddOptionButton
            // 
            this.AddOptionButton.Location = new System.Drawing.Point(352, 451);
            this.AddOptionButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddOptionButton.Name = "AddOptionButton";
            this.AddOptionButton.Size = new System.Drawing.Size(112, 35);
            this.AddOptionButton.TabIndex = 19;
            this.AddOptionButton.Text = "Add";
            this.AddOptionButton.UseVisualStyleBackColor = true;
            this.AddOptionButton.Click += new System.EventHandler(this.AddOptionButton_Click);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.MinimumWidth = 12;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Width = 250;
            // 
            // SelectClassesColumn
            // 
            this.SelectClassesColumn.HeaderText = "Add Classes";
            this.SelectClassesColumn.MinimumWidth = 8;
            this.SelectClassesColumn.Name = "SelectClassesColumn";
            this.SelectClassesColumn.Width = 150;
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
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 250;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 250;
            // 
            // isRequiredDataGridViewCheckBoxColumn
            // 
            this.isRequiredDataGridViewCheckBoxColumn.DataPropertyName = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.HeaderText = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isRequiredDataGridViewCheckBoxColumn.Name = "isRequiredDataGridViewCheckBoxColumn";
            this.isRequiredDataGridViewCheckBoxColumn.Width = 250;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.Width = 250;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Length";
            this.lengthDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.lengthDataGridViewTextBoxColumn.Width = 250;
            // 
            // isMultipleDataGridViewCheckBoxColumn
            // 
            this.isMultipleDataGridViewCheckBoxColumn.DataPropertyName = "IsMultiple";
            this.isMultipleDataGridViewCheckBoxColumn.HeaderText = "IsMultiple";
            this.isMultipleDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isMultipleDataGridViewCheckBoxColumn.Name = "isMultipleDataGridViewCheckBoxColumn";
            this.isMultipleDataGridViewCheckBoxColumn.Width = 250;
            // 
            // selectedIndexDataGridViewTextBoxColumn
            // 
            this.selectedIndexDataGridViewTextBoxColumn.DataPropertyName = "SelectedIndex";
            this.selectedIndexDataGridViewTextBoxColumn.HeaderText = "SelectedIndex";
            this.selectedIndexDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.selectedIndexDataGridViewTextBoxColumn.Name = "selectedIndexDataGridViewTextBoxColumn";
            this.selectedIndexDataGridViewTextBoxColumn.ReadOnly = true;
            this.selectedIndexDataGridViewTextBoxColumn.Width = 250;
            // 
            // SelectIdColumn
            // 
            this.SelectIdColumn.HeaderText = "Select ID";
            this.SelectIdColumn.MinimumWidth = 12;
            this.SelectIdColumn.Name = "SelectIdColumn";
            this.SelectIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectIdColumn.Width = 250;
            // 
            // OptionIdColumn
            // 
            this.OptionIdColumn.HeaderText = "ID";
            this.OptionIdColumn.MinimumWidth = 12;
            this.OptionIdColumn.Name = "OptionIdColumn";
            this.OptionIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OptionIdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OptionIdColumn.Width = 250;
            // 
            // OptionClassesColumn
            // 
            this.OptionClassesColumn.HeaderText = "Add Classes";
            this.OptionClassesColumn.MinimumWidth = 8;
            this.OptionClassesColumn.Name = "OptionClassesColumn";
            this.OptionClassesColumn.Width = 150;
            // 
            // isDisabledDataGridViewCheckBoxColumn1
            // 
            this.isDisabledDataGridViewCheckBoxColumn1.DataPropertyName = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn1.HeaderText = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn1.MinimumWidth = 12;
            this.isDisabledDataGridViewCheckBoxColumn1.Name = "isDisabledDataGridViewCheckBoxColumn1";
            this.isDisabledDataGridViewCheckBoxColumn1.Width = 250;
            // 
            // labelDataGridViewTextBoxColumn
            // 
            this.labelDataGridViewTextBoxColumn.DataPropertyName = "Label";
            this.labelDataGridViewTextBoxColumn.HeaderText = "Label";
            this.labelDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.labelDataGridViewTextBoxColumn.Name = "labelDataGridViewTextBoxColumn";
            this.labelDataGridViewTextBoxColumn.Width = 250;
            // 
            // isDefaultSelectedDataGridViewCheckBoxColumn
            // 
            this.isDefaultSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsDefaultSelected";
            this.isDefaultSelectedDataGridViewCheckBoxColumn.HeaderText = "IsDefaultSelected";
            this.isDefaultSelectedDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isDefaultSelectedDataGridViewCheckBoxColumn.Name = "isDefaultSelectedDataGridViewCheckBoxColumn";
            this.isDefaultSelectedDataGridViewCheckBoxColumn.Width = 250;
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            this.isSelectedDataGridViewCheckBoxColumn.Width = 250;
            // 
            // valueDataGridViewTextBoxColumn1
            // 
            this.valueDataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn1.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn1.MinimumWidth = 12;
            this.valueDataGridViewTextBoxColumn1.Name = "valueDataGridViewTextBoxColumn1";
            this.valueDataGridViewTextBoxColumn1.Width = 250;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.Width = 250;
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "Index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "Index";
            this.indexDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            this.indexDataGridViewTextBoxColumn.ReadOnly = true;
            this.indexDataGridViewTextBoxColumn.Width = 250;
            // 
            // SelectAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 528);
            this.Controls.Add(this.AddOptionButton);
            this.Controls.Add(this.RemoveOptionButton);
            this.Controls.Add(this.OptionsLabel);
            this.Controls.Add(this.OptionDataGridView);
            this.Controls.Add(this.AddSelectButton);
            this.Controls.Add(this.RemoveSelectButton);
            this.Controls.Add(this.SelectDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SelectAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SelectDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlSelectElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlOptionElementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView SelectDataGridView;
        private System.Windows.Forms.Button RemoveSelectButton;
        private System.Windows.Forms.Button AddSelectButton;
        private System.Windows.Forms.BindingSource iHtmlSelectElementBindingSource;
        private System.Windows.Forms.DataGridView OptionDataGridView;
        private System.Windows.Forms.BindingSource iHtmlOptionElementBindingSource;
        private System.Windows.Forms.Label OptionsLabel;
        private System.Windows.Forms.Button RemoveOptionButton;
        private System.Windows.Forms.Button AddOptionButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewButtonColumn SelectClassesColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autofocusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isRequiredDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMultipleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn SelectIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionIdColumn;
        private System.Windows.Forms.DataGridViewButtonColumn OptionClassesColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDefaultSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
    }
}