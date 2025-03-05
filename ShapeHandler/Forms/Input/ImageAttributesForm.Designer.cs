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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageAttributesForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.ImageDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativeTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crossOriginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useMapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMapDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCompletedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iHtmlImageElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlImageElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(32, 367);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 55);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(861, 367);
            this.saveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 55);
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
            this.ImageDataGridView.Location = new System.Drawing.Point(32, 29);
            this.ImageDataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ImageDataGridView.Name = "ImageDataGridView";
            this.ImageDataGridView.RowHeadersWidth = 102;
            this.ImageDataGridView.Size = new System.Drawing.Size(1029, 324);
            this.ImageDataGridView.TabIndex = 13;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.MinimumWidth = 12;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Width = 250;
            // 
            // alternativeTextDataGridViewTextBoxColumn
            // 
            this.alternativeTextDataGridViewTextBoxColumn.DataPropertyName = "AlternativeText";
            this.alternativeTextDataGridViewTextBoxColumn.HeaderText = "AlternativeText";
            this.alternativeTextDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.alternativeTextDataGridViewTextBoxColumn.Name = "alternativeTextDataGridViewTextBoxColumn";
            this.alternativeTextDataGridViewTextBoxColumn.Width = 250;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.Width = 250;
            // 
            // crossOriginDataGridViewTextBoxColumn
            // 
            this.crossOriginDataGridViewTextBoxColumn.DataPropertyName = "CrossOrigin";
            this.crossOriginDataGridViewTextBoxColumn.HeaderText = "CrossOrigin";
            this.crossOriginDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.crossOriginDataGridViewTextBoxColumn.Name = "crossOriginDataGridViewTextBoxColumn";
            this.crossOriginDataGridViewTextBoxColumn.Width = 250;
            // 
            // useMapDataGridViewTextBoxColumn
            // 
            this.useMapDataGridViewTextBoxColumn.DataPropertyName = "UseMap";
            this.useMapDataGridViewTextBoxColumn.HeaderText = "UseMap";
            this.useMapDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.useMapDataGridViewTextBoxColumn.Name = "useMapDataGridViewTextBoxColumn";
            this.useMapDataGridViewTextBoxColumn.Width = 250;
            // 
            // isMapDataGridViewCheckBoxColumn
            // 
            this.isMapDataGridViewCheckBoxColumn.DataPropertyName = "IsMap";
            this.isMapDataGridViewCheckBoxColumn.HeaderText = "IsMap";
            this.isMapDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isMapDataGridViewCheckBoxColumn.Name = "isMapDataGridViewCheckBoxColumn";
            this.isMapDataGridViewCheckBoxColumn.Width = 250;
            // 
            // isCompletedDataGridViewCheckBoxColumn
            // 
            this.isCompletedDataGridViewCheckBoxColumn.DataPropertyName = "IsCompleted";
            this.isCompletedDataGridViewCheckBoxColumn.HeaderText = "IsCompleted";
            this.isCompletedDataGridViewCheckBoxColumn.MinimumWidth = 12;
            this.isCompletedDataGridViewCheckBoxColumn.Name = "isCompletedDataGridViewCheckBoxColumn";
            this.isCompletedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isCompletedDataGridViewCheckBoxColumn.Width = 250;
            // 
            // iHtmlImageElementBindingSource
            // 
            this.iHtmlImageElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlImageElement);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(248, 367);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(200, 55);
            this.RemoveButton.TabIndex = 14;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(645, 367);
            this.AddButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(200, 55);
            this.AddButton.TabIndex = 15;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ImageAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 451);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ImageDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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