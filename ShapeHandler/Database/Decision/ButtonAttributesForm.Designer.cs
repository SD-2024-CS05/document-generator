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
            this.iHtmlButtonElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonDataGridView = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.autofocusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDisabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formEncTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formNoValidateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formTargetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlButtonElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // iHtmlButtonElementBindingSource
            // 
            this.iHtmlButtonElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlButtonElement);
            // 
            // ButtonDataGridView
            // 
            this.ButtonDataGridView.AutoGenerateColumns = false;
            this.ButtonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ButtonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.autofocusDataGridViewCheckBoxColumn,
            this.IdColumn,
            this.isDisabledDataGridViewCheckBoxColumn,
            this.formDataGridViewTextBoxColumn,
            this.labelsDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.formActionDataGridViewTextBoxColumn,
            this.formEncTypeDataGridViewTextBoxColumn,
            this.formMethodDataGridViewTextBoxColumn,
            this.formNoValidateDataGridViewCheckBoxColumn,
            this.formTargetDataGridViewTextBoxColumn});
            this.ButtonDataGridView.DataSource = this.iHtmlButtonElementBindingSource;
            this.ButtonDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ButtonDataGridView.Name = "ButtonDataGridView";
            this.ButtonDataGridView.RowHeadersWidth = 102;
            this.ButtonDataGridView.RowTemplate.Height = 40;
            this.ButtonDataGridView.Size = new System.Drawing.Size(1029, 353);
            this.ButtonDataGridView.TabIndex = 45;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(625, 375);
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
            this.RemoveButton.Location = new System.Drawing.Point(228, 375);
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
            this.saveButton.Location = new System.Drawing.Point(841, 375);
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
            this.cancelButton.Location = new System.Drawing.Point(12, 375);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 55);
            this.cancelButton.TabIndex = 46;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // autofocusDataGridViewCheckBoxColumn
            // 
            this.autofocusDataGridViewCheckBoxColumn.DataPropertyName = "Autofocus";
            this.autofocusDataGridViewCheckBoxColumn.HeaderText = "Autofocus";
            this.autofocusDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.autofocusDataGridViewCheckBoxColumn.Name = "autofocusDataGridViewCheckBoxColumn";
            this.autofocusDataGridViewCheckBoxColumn.Width = 250;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.MinimumWidth = 12;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Width = 250;
            // 
            // isDisabledDataGridViewCheckBoxColumn
            // 
            this.isDisabledDataGridViewCheckBoxColumn.DataPropertyName = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn.HeaderText = "IsDisabled";
            this.isDisabledDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isDisabledDataGridViewCheckBoxColumn.Name = "isDisabledDataGridViewCheckBoxColumn";
            this.isDisabledDataGridViewCheckBoxColumn.Width = 250;
            // 
            // formDataGridViewTextBoxColumn
            // 
            this.formDataGridViewTextBoxColumn.DataPropertyName = "Form";
            this.formDataGridViewTextBoxColumn.HeaderText = "Form";
            this.formDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.formDataGridViewTextBoxColumn.Name = "formDataGridViewTextBoxColumn";
            this.formDataGridViewTextBoxColumn.ReadOnly = true;
            this.formDataGridViewTextBoxColumn.Width = 250;
            // 
            // labelsDataGridViewTextBoxColumn
            // 
            this.labelsDataGridViewTextBoxColumn.DataPropertyName = "Labels";
            this.labelsDataGridViewTextBoxColumn.HeaderText = "Labels";
            this.labelsDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.labelsDataGridViewTextBoxColumn.Name = "labelsDataGridViewTextBoxColumn";
            this.labelsDataGridViewTextBoxColumn.ReadOnly = true;
            this.labelsDataGridViewTextBoxColumn.Width = 250;
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
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
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
            // formActionDataGridViewTextBoxColumn
            // 
            this.formActionDataGridViewTextBoxColumn.DataPropertyName = "FormAction";
            this.formActionDataGridViewTextBoxColumn.HeaderText = "FormAction";
            this.formActionDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.formActionDataGridViewTextBoxColumn.Name = "formActionDataGridViewTextBoxColumn";
            this.formActionDataGridViewTextBoxColumn.Width = 250;
            // 
            // formEncTypeDataGridViewTextBoxColumn
            // 
            this.formEncTypeDataGridViewTextBoxColumn.DataPropertyName = "FormEncType";
            this.formEncTypeDataGridViewTextBoxColumn.HeaderText = "FormEncType";
            this.formEncTypeDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.formEncTypeDataGridViewTextBoxColumn.Name = "formEncTypeDataGridViewTextBoxColumn";
            this.formEncTypeDataGridViewTextBoxColumn.Width = 250;
            // 
            // formMethodDataGridViewTextBoxColumn
            // 
            this.formMethodDataGridViewTextBoxColumn.DataPropertyName = "FormMethod";
            this.formMethodDataGridViewTextBoxColumn.HeaderText = "FormMethod";
            this.formMethodDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.formMethodDataGridViewTextBoxColumn.Name = "formMethodDataGridViewTextBoxColumn";
            this.formMethodDataGridViewTextBoxColumn.Width = 250;
            // 
            // formNoValidateDataGridViewCheckBoxColumn
            // 
            this.formNoValidateDataGridViewCheckBoxColumn.DataPropertyName = "FormNoValidate";
            this.formNoValidateDataGridViewCheckBoxColumn.HeaderText = "FormNoValidate";
            this.formNoValidateDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.formNoValidateDataGridViewCheckBoxColumn.Name = "formNoValidateDataGridViewCheckBoxColumn";
            this.formNoValidateDataGridViewCheckBoxColumn.Width = 250;
            // 
            // formTargetDataGridViewTextBoxColumn
            // 
            this.formTargetDataGridViewTextBoxColumn.DataPropertyName = "FormTarget";
            this.formTargetDataGridViewTextBoxColumn.HeaderText = "FormTarget";
            this.formTargetDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.formTargetDataGridViewTextBoxColumn.Name = "formTargetDataGridViewTextBoxColumn";
            this.formTargetDataGridViewTextBoxColumn.Width = 250;
            // 
            // ButtonAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 443);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ButtonDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ButtonAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ButtonAttributesForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlButtonElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource iHtmlButtonElementBindingSource;
        private System.Windows.Forms.DataGridView ButtonDataGridView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autofocusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDisabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formEncTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn formNoValidateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formTargetDataGridViewTextBoxColumn;
    }
}