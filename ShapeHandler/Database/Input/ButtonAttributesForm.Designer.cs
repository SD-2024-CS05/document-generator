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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.ButtonDataGridView = new System.Windows.Forms.DataGridView();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.iHtmlButtonElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autofocusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDisabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.formNoValidateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formTargetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlButtonElementBindingSource)).BeginInit();
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
            // ButtonDataGridView
            // 
            this.ButtonDataGridView.AutoGenerateColumns = false;
            this.ButtonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ButtonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.autofocusDataGridViewCheckBoxColumn,
            this.isDisabledDataGridViewCheckBoxColumn,
            this.formDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.formActionDataGridViewTextBoxColumn,
            this.formMethodDataGridViewTextBoxColumn,
            this.formNoValidateDataGridViewCheckBoxColumn,
            this.formTargetDataGridViewTextBoxColumn});
            this.ButtonDataGridView.DataSource = this.iHtmlButtonElementBindingSource;
            this.ButtonDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ButtonDataGridView.Name = "ButtonDataGridView";
            this.ButtonDataGridView.Size = new System.Drawing.Size(386, 136);
            this.ButtonDataGridView.TabIndex = 13;
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
            // iHtmlButtonElementBindingSource
            // 
            this.iHtmlButtonElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlButtonElement);
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
            // formDataGridViewTextBoxColumn
            // 
            this.formDataGridViewTextBoxColumn.DataPropertyName = "Form";
            this.formDataGridViewTextBoxColumn.HeaderText = "Form";
            this.formDataGridViewTextBoxColumn.Name = "formDataGridViewTextBoxColumn";
            this.formDataGridViewTextBoxColumn.ReadOnly = true;
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
            "reset",
            "submit"});
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
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
            this.formMethodDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "get",
            "post"});
            this.formMethodDataGridViewTextBoxColumn.Name = "formMethodDataGridViewTextBoxColumn";
            this.formMethodDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formMethodDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // ButtonAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 189);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ButtonDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ButtonAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnchorAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlButtonElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView ButtonDataGridView;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.BindingSource iHtmlButtonElementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autofocusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn formMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn formNoValidateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn formTargetDataGridViewTextBoxColumn;
    }
}