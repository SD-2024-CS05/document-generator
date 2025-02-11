namespace ShapeHandler.Database.Input
{
    partial class InputAttributesForm
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
            this.InputDataGridView = new System.Windows.Forms.DataGridView();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.iHtmlInputElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autofocusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.autocompleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isDisabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isRequiredDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReadOnlyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alternativeTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maximumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patternDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formNoValidateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formTargetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.defaultValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasValueDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valueAsNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueAsDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isIndeterminateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDefaultCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMultipleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maxLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeholderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InputDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlInputElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 154);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(323, 154);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // InputDataGridView
            // 
            this.InputDataGridView.AutoGenerateColumns = false;
            this.InputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.autofocusDataGridViewCheckBoxColumn,
            this.autocompleteDataGridViewTextBoxColumn,
            this.isDisabledDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.isRequiredDataGridViewCheckBoxColumn,
            this.isReadOnlyDataGridViewCheckBoxColumn,
            this.alternativeTextDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.maximumDataGridViewTextBoxColumn,
            this.minimumDataGridViewTextBoxColumn,
            this.patternDataGridViewTextBoxColumn,
            this.stepDataGridViewTextBoxColumn,
            this.formActionDataGridViewTextBoxColumn,
            this.formMethodDataGridViewTextBoxColumn,
            this.formNoValidateDataGridViewCheckBoxColumn,
            this.formTargetDataGridViewTextBoxColumn,
            this.defaultValueDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.hasValueDataGridViewCheckBoxColumn,
            this.valueAsNumberDataGridViewTextBoxColumn,
            this.valueAsDateDataGridViewTextBoxColumn,
            this.isIndeterminateDataGridViewCheckBoxColumn,
            this.isDefaultCheckedDataGridViewCheckBoxColumn,
            this.isCheckedDataGridViewCheckBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.isMultipleDataGridViewCheckBoxColumn,
            this.maxLengthDataGridViewTextBoxColumn,
            this.minLengthDataGridViewTextBoxColumn,
            this.placeholderDataGridViewTextBoxColumn});
            this.InputDataGridView.DataSource = this.iHtmlInputElementBindingSource;
            this.InputDataGridView.Location = new System.Drawing.Point(12, 12);
            this.InputDataGridView.Name = "InputDataGridView";
            this.InputDataGridView.Size = new System.Drawing.Size(386, 136);
            this.InputDataGridView.TabIndex = 13;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(93, 154);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 14;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(242, 154);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 15;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // iHtmlInputElementBindingSource
            // 
            this.iHtmlInputElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlInputElement);
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
            // autocompleteDataGridViewTextBoxColumn
            // 
            this.autocompleteDataGridViewTextBoxColumn.DataPropertyName = "Autocomplete";
            this.autocompleteDataGridViewTextBoxColumn.HeaderText = "Autocomplete";
            this.autocompleteDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "on",
            "off"});
            this.autocompleteDataGridViewTextBoxColumn.Name = "autocompleteDataGridViewTextBoxColumn";
            this.autocompleteDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.autocompleteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "button",
            "checkbox",
            "color",
            "date",
            "datetime-local",
            "email",
            "file",
            "hidden",
            "image",
            "month",
            "number",
            "password",
            "radio",
            "range",
            "reset",
            "search",
            "submit",
            "tel",
            "text",
            "time",
            "url",
            "week"});
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isRequiredDataGridViewCheckBoxColumn
            // 
            this.isRequiredDataGridViewCheckBoxColumn.DataPropertyName = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.HeaderText = "IsRequired";
            this.isRequiredDataGridViewCheckBoxColumn.Name = "isRequiredDataGridViewCheckBoxColumn";
            // 
            // isReadOnlyDataGridViewCheckBoxColumn
            // 
            this.isReadOnlyDataGridViewCheckBoxColumn.DataPropertyName = "IsReadOnly";
            this.isReadOnlyDataGridViewCheckBoxColumn.HeaderText = "IsReadOnly";
            this.isReadOnlyDataGridViewCheckBoxColumn.Name = "isReadOnlyDataGridViewCheckBoxColumn";
            // 
            // alternativeTextDataGridViewTextBoxColumn
            // 
            this.alternativeTextDataGridViewTextBoxColumn.DataPropertyName = "AlternativeText";
            this.alternativeTextDataGridViewTextBoxColumn.HeaderText = "AlternativeText";
            this.alternativeTextDataGridViewTextBoxColumn.Name = "alternativeTextDataGridViewTextBoxColumn";
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            // 
            // maximumDataGridViewTextBoxColumn
            // 
            this.maximumDataGridViewTextBoxColumn.DataPropertyName = "Maximum";
            this.maximumDataGridViewTextBoxColumn.HeaderText = "Maximum";
            this.maximumDataGridViewTextBoxColumn.Name = "maximumDataGridViewTextBoxColumn";
            // 
            // minimumDataGridViewTextBoxColumn
            // 
            this.minimumDataGridViewTextBoxColumn.DataPropertyName = "Minimum";
            this.minimumDataGridViewTextBoxColumn.HeaderText = "Minimum";
            this.minimumDataGridViewTextBoxColumn.Name = "minimumDataGridViewTextBoxColumn";
            // 
            // patternDataGridViewTextBoxColumn
            // 
            this.patternDataGridViewTextBoxColumn.DataPropertyName = "Pattern";
            this.patternDataGridViewTextBoxColumn.HeaderText = "Pattern";
            this.patternDataGridViewTextBoxColumn.Name = "patternDataGridViewTextBoxColumn";
            // 
            // stepDataGridViewTextBoxColumn
            // 
            this.stepDataGridViewTextBoxColumn.DataPropertyName = "Step";
            this.stepDataGridViewTextBoxColumn.HeaderText = "Step";
            this.stepDataGridViewTextBoxColumn.Name = "stepDataGridViewTextBoxColumn";
            // 
            // formActionDataGridViewTextBoxColumn
            // 
            this.formActionDataGridViewTextBoxColumn.DataPropertyName = "FormAction";
            this.formActionDataGridViewTextBoxColumn.HeaderText = "FormAction";
            this.formActionDataGridViewTextBoxColumn.Name = "formActionDataGridViewTextBoxColumn";
            // 
            // formMethodDataGridViewTextBoxColumn
            // 
            this.formMethodDataGridViewTextBoxColumn.DataPropertyName = "FormMethod";
            this.formMethodDataGridViewTextBoxColumn.HeaderText = "FormMethod";
            this.formMethodDataGridViewTextBoxColumn.Name = "formMethodDataGridViewTextBoxColumn";
            // 
            // formNoValidateDataGridViewCheckBoxColumn
            // 
            this.formNoValidateDataGridViewCheckBoxColumn.DataPropertyName = "FormNoValidate";
            this.formNoValidateDataGridViewCheckBoxColumn.HeaderText = "FormNoValidate";
            this.formNoValidateDataGridViewCheckBoxColumn.Name = "formNoValidateDataGridViewCheckBoxColumn";
            // 
            // formTargetDataGridViewTextBoxColumn
            // 
            this.formTargetDataGridViewTextBoxColumn.DataPropertyName = "FormTarget";
            this.formTargetDataGridViewTextBoxColumn.HeaderText = "FormTarget";
            this.formTargetDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "_blank",
            "_self",
            "_parent",
            "_top",
            "framename"});
            this.formTargetDataGridViewTextBoxColumn.Name = "formTargetDataGridViewTextBoxColumn";
            this.formTargetDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formTargetDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // defaultValueDataGridViewTextBoxColumn
            // 
            this.defaultValueDataGridViewTextBoxColumn.DataPropertyName = "DefaultValue";
            this.defaultValueDataGridViewTextBoxColumn.HeaderText = "DefaultValue";
            this.defaultValueDataGridViewTextBoxColumn.Name = "defaultValueDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // hasValueDataGridViewCheckBoxColumn
            // 
            this.hasValueDataGridViewCheckBoxColumn.DataPropertyName = "HasValue";
            this.hasValueDataGridViewCheckBoxColumn.HeaderText = "HasValue";
            this.hasValueDataGridViewCheckBoxColumn.Name = "hasValueDataGridViewCheckBoxColumn";
            this.hasValueDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // valueAsNumberDataGridViewTextBoxColumn
            // 
            this.valueAsNumberDataGridViewTextBoxColumn.DataPropertyName = "ValueAsNumber";
            this.valueAsNumberDataGridViewTextBoxColumn.HeaderText = "ValueAsNumber";
            this.valueAsNumberDataGridViewTextBoxColumn.Name = "valueAsNumberDataGridViewTextBoxColumn";
            // 
            // valueAsDateDataGridViewTextBoxColumn
            // 
            this.valueAsDateDataGridViewTextBoxColumn.DataPropertyName = "ValueAsDate";
            this.valueAsDateDataGridViewTextBoxColumn.HeaderText = "ValueAsDate";
            this.valueAsDateDataGridViewTextBoxColumn.Name = "valueAsDateDataGridViewTextBoxColumn";
            // 
            // isIndeterminateDataGridViewCheckBoxColumn
            // 
            this.isIndeterminateDataGridViewCheckBoxColumn.DataPropertyName = "IsIndeterminate";
            this.isIndeterminateDataGridViewCheckBoxColumn.HeaderText = "IsIndeterminate";
            this.isIndeterminateDataGridViewCheckBoxColumn.Name = "isIndeterminateDataGridViewCheckBoxColumn";
            // 
            // isDefaultCheckedDataGridViewCheckBoxColumn
            // 
            this.isDefaultCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsDefaultChecked";
            this.isDefaultCheckedDataGridViewCheckBoxColumn.HeaderText = "IsDefaultChecked";
            this.isDefaultCheckedDataGridViewCheckBoxColumn.Name = "isDefaultCheckedDataGridViewCheckBoxColumn";
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            this.isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
            this.isCheckedDataGridViewCheckBoxColumn.HeaderText = "IsChecked";
            this.isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // isMultipleDataGridViewCheckBoxColumn
            // 
            this.isMultipleDataGridViewCheckBoxColumn.DataPropertyName = "IsMultiple";
            this.isMultipleDataGridViewCheckBoxColumn.HeaderText = "IsMultiple";
            this.isMultipleDataGridViewCheckBoxColumn.Name = "isMultipleDataGridViewCheckBoxColumn";
            // 
            // maxLengthDataGridViewTextBoxColumn
            // 
            this.maxLengthDataGridViewTextBoxColumn.DataPropertyName = "MaxLength";
            this.maxLengthDataGridViewTextBoxColumn.HeaderText = "MaxLength";
            this.maxLengthDataGridViewTextBoxColumn.Name = "maxLengthDataGridViewTextBoxColumn";
            // 
            // minLengthDataGridViewTextBoxColumn
            // 
            this.minLengthDataGridViewTextBoxColumn.DataPropertyName = "MinLength";
            this.minLengthDataGridViewTextBoxColumn.HeaderText = "MinLength";
            this.minLengthDataGridViewTextBoxColumn.Name = "minLengthDataGridViewTextBoxColumn";
            // 
            // placeholderDataGridViewTextBoxColumn
            // 
            this.placeholderDataGridViewTextBoxColumn.DataPropertyName = "Placeholder";
            this.placeholderDataGridViewTextBoxColumn.HeaderText = "Placeholder";
            this.placeholderDataGridViewTextBoxColumn.Name = "placeholderDataGridViewTextBoxColumn";
            // 
            // InputAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 189);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.InputDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "InputAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnchorAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.InputDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlInputElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView InputDataGridView;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.BindingSource iHtmlInputElementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autofocusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn autocompleteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isRequiredDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativeTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maximumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patternDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stepDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn formNoValidateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn formTargetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasValueDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueAsNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueAsDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isIndeterminateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDefaultCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMultipleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeholderDataGridViewTextBoxColumn;
    }
}