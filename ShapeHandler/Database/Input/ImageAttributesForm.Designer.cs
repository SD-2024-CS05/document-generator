namespace ShapeHandler.Database.Input
{
    partial class ImageAttributesForm
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
            this.ImageDataGridView = new System.Windows.Forms.DataGridView();
            this.iHtmlImageElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativeTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crossOriginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useMapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMapDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCompletedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlImageElementBindingSource)).BeginInit();
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
            // ImageDataGridView
            // 
            this.ImageDataGridView.AutoGenerateColumns = false;
            this.ImageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ImageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.alternativeTextDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.crossOriginDataGridViewTextBoxColumn,
            this.useMapDataGridViewTextBoxColumn,
            this.isMapDataGridViewCheckBoxColumn,
            this.isCompletedDataGridViewCheckBoxColumn});
            this.ImageDataGridView.DataSource = this.iHtmlImageElementBindingSource;
            this.ImageDataGridView.Location = new System.Drawing.Point(12, 12);
            this.ImageDataGridView.Name = "ImageDataGridView";
            this.ImageDataGridView.Size = new System.Drawing.Size(386, 136);
            this.ImageDataGridView.TabIndex = 13;
            // 
            // iHtmlImageElementBindingSource
            // 
            this.iHtmlImageElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlImageElement);
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
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.Name = "IdColumn";
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
            // crossOriginDataGridViewTextBoxColumn
            // 
            this.crossOriginDataGridViewTextBoxColumn.DataPropertyName = "CrossOrigin";
            this.crossOriginDataGridViewTextBoxColumn.HeaderText = "CrossOrigin";
            this.crossOriginDataGridViewTextBoxColumn.Name = "crossOriginDataGridViewTextBoxColumn";
            // 
            // useMapDataGridViewTextBoxColumn
            // 
            this.useMapDataGridViewTextBoxColumn.DataPropertyName = "UseMap";
            this.useMapDataGridViewTextBoxColumn.HeaderText = "UseMap";
            this.useMapDataGridViewTextBoxColumn.Name = "useMapDataGridViewTextBoxColumn";
            // 
            // isMapDataGridViewCheckBoxColumn
            // 
            this.isMapDataGridViewCheckBoxColumn.DataPropertyName = "IsMap";
            this.isMapDataGridViewCheckBoxColumn.HeaderText = "IsMap";
            this.isMapDataGridViewCheckBoxColumn.Name = "isMapDataGridViewCheckBoxColumn";
            // 
            // isCompletedDataGridViewCheckBoxColumn
            // 
            this.isCompletedDataGridViewCheckBoxColumn.DataPropertyName = "IsCompleted";
            this.isCompletedDataGridViewCheckBoxColumn.HeaderText = "IsCompleted";
            this.isCompletedDataGridViewCheckBoxColumn.Name = "isCompletedDataGridViewCheckBoxColumn";
            this.isCompletedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // ImageAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 189);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ImageDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ImageAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ImageDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlImageElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView ImageDataGridView;
        private System.Windows.Forms.BindingSource iHtmlImageElementBindingSource;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativeTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crossOriginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn useMapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMapDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCompletedDataGridViewCheckBoxColumn;
    }
}