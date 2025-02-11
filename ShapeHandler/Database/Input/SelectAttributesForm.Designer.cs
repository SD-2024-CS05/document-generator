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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SelectDataGridView = new System.Windows.Forms.DataGridView();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.iHtmlSelectElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.OptionDataGridView = new System.Windows.Forms.DataGridView();
            this.iHtmlOptionElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.SelectIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cancelButton.Location = new System.Drawing.Point(12, 270);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(323, 270);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
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
            this.SelectDataGridView.Location = new System.Drawing.Point(12, 12);
            this.SelectDataGridView.Name = "SelectDataGridView";
            this.SelectDataGridView.Size = new System.Drawing.Size(386, 137);
            this.SelectDataGridView.TabIndex = 13;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(93, 270);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 14;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(242, 270);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 15;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // iHtmlSelectElementBindingSource
            // 
            this.iHtmlSelectElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlSelectElement);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.Name = "IdColumn";
            // 
            // autofocusDataGridViewCheckBoxColumn
            // 
            this.autofocusDataGridViewCheckBoxColumn.DataPropertyName = "Autofocus";
            this.autofocusDataGridViewCheckBoxColumn.HeaderText = "Autofocus";
            this.autofocusDataGridViewCheckBoxColumn.Name = "autofocusDataGridViewCheckBoxColumn";
            // 
            // isDisabledDataGridViewCheckBoxColumn
            // 
            this.isDisabledDataGridViewCheckBoxColumn.DataPropertyName = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn.HeaderText = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn.Name = "isDisabledDataGridViewCheckBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isRequiredDataGridViewCheckBoxColumn
            // 
            this.isRequiredDataGridViewCheckBoxColumn.DataPropertyName = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.HeaderText = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.Name = "isRequiredDataGridViewCheckBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Length";
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isMultipleDataGridViewCheckBoxColumn
            // 
            this.isMultipleDataGridViewCheckBoxColumn.DataPropertyName = "IsMultiple";
            this.isMultipleDataGridViewCheckBoxColumn.HeaderText = "IsMultiple";
            this.isMultipleDataGridViewCheckBoxColumn.Name = "isMultipleDataGridViewCheckBoxColumn";
            // 
            // selectedIndexDataGridViewTextBoxColumn
            // 
            this.selectedIndexDataGridViewTextBoxColumn.DataPropertyName = "SelectedIndex";
            this.selectedIndexDataGridViewTextBoxColumn.HeaderText = "SelectedIndex";
            this.selectedIndexDataGridViewTextBoxColumn.Name = "selectedIndexDataGridViewTextBoxColumn";
            this.selectedIndexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // OptionDataGridView
            // 
            this.OptionDataGridView.AutoGenerateColumns = false;
            this.OptionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OptionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectIdColumn,
            this.OptionIdColumn,
            this.isDisabledDataGridViewCheckBoxColumn1,
            this.labelDataGridViewTextBoxColumn,
            this.isDefaultSelectedDataGridViewCheckBoxColumn,
            this.isSelectedDataGridViewCheckBoxColumn,
            this.valueDataGridViewTextBoxColumn1,
            this.textDataGridViewTextBoxColumn,
            this.indexDataGridViewTextBoxColumn});
            this.OptionDataGridView.DataSource = this.iHtmlOptionElementBindingSource;
            this.OptionDataGridView.Location = new System.Drawing.Point(16, 168);
            this.OptionDataGridView.Name = "OptionDataGridView";
            this.OptionDataGridView.Size = new System.Drawing.Size(385, 96);
            this.OptionDataGridView.TabIndex = 16;
            // 
            // iHtmlOptionElementBindingSource
            // 
            this.iHtmlOptionElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlOptionElement);
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Location = new System.Drawing.Point(174, 152);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(43, 13);
            this.OptionsLabel.TabIndex = 17;
            this.OptionsLabel.Text = "Options";
            // 
            // SelectIdColumn
            // 
            this.SelectIdColumn.HeaderText = "Select ID";
            this.SelectIdColumn.Name = "SelectIdColumn";
            this.SelectIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectIdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OptionIdColumn
            // 
            this.OptionIdColumn.HeaderText = "ID";
            this.OptionIdColumn.Name = "OptionIdColumn";
            this.OptionIdColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OptionIdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // isDisabledDataGridViewCheckBoxColumn1
            // 
            this.isDisabledDataGridViewCheckBoxColumn1.DataPropertyName = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn1.HeaderText = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn1.Name = "isDisabledDataGridViewCheckBoxColumn1";
            // 
            // labelDataGridViewTextBoxColumn
            // 
            this.labelDataGridViewTextBoxColumn.DataPropertyName = "Label";
            this.labelDataGridViewTextBoxColumn.HeaderText = "Label";
            this.labelDataGridViewTextBoxColumn.Name = "labelDataGridViewTextBoxColumn";
            // 
            // isDefaultSelectedDataGridViewCheckBoxColumn
            // 
            this.isDefaultSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsDefaultSelected";
            this.isDefaultSelectedDataGridViewCheckBoxColumn.HeaderText = "IsDefaultSelected";
            this.isDefaultSelectedDataGridViewCheckBoxColumn.Name = "isDefaultSelectedDataGridViewCheckBoxColumn";
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn1
            // 
            this.valueDataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn1.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn1.Name = "valueDataGridViewTextBoxColumn1";
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "Index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "Index";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            this.indexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SelectAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 305);
            this.Controls.Add(this.OptionsLabel);
            this.Controls.Add(this.OptionDataGridView);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.SelectDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Margin = new System.Windows.Forms.Padding(1);
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
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.BindingSource iHtmlSelectElementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
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
        private System.Windows.Forms.DataGridView OptionDataGridView;
        private System.Windows.Forms.BindingSource iHtmlOptionElementBindingSource;
        private System.Windows.Forms.Label OptionsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionIdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDefaultSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
    }
}