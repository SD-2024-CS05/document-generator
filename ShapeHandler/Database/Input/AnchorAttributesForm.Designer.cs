namespace ShapeHandler.Database.Input
{
    partial class AnchorAttributesForm
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
            this.iHtmlAnchorElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.iValidityStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iHtmlSelectElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iHtmlAnchorElementBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.anchorAttributeDataGrid = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HrefColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ClassesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iHtmlAnchorElementBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.AddAnchorButton = new System.Windows.Forms.Button();
            this.RemoveAnchorButton = new System.Windows.Forms.Button();
            this.iHtmlInputElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iValidityStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlSelectElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchorAttributeDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlInputElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // iHtmlAnchorElementBindingSource
            // 
            this.iHtmlAnchorElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlAnchorElement);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 189);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(329, 189);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // iValidityStateBindingSource
            // 
            this.iValidityStateBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IValidityState);
            // 
            // iHtmlSelectElementBindingSource
            // 
            this.iHtmlSelectElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlSelectElement);
            // 
            // iHtmlAnchorElementBindingSource1
            // 
            this.iHtmlAnchorElementBindingSource1.DataSource = typeof(AngleSharp.Html.Dom.IHtmlAnchorElement);
            // 
            // anchorAttributeDataGrid
            // 
            this.anchorAttributeDataGrid.AutoGenerateColumns = false;
            this.anchorAttributeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.HrefColumn,
            this.typeDataGridViewTextBoxColumn,
            this.downloadDataGridViewTextBoxColumn,
            this.relationDataGridViewTextBoxColumn,
            this.targetDataGridViewTextBoxColumn,
            this.ClassesColumn});
            this.anchorAttributeDataGrid.DataSource = this.iHtmlAnchorElementBindingSource;
            this.anchorAttributeDataGrid.Location = new System.Drawing.Point(13, 18);
            this.anchorAttributeDataGrid.Name = "anchorAttributeDataGrid";
            this.anchorAttributeDataGrid.Size = new System.Drawing.Size(394, 165);
            this.anchorAttributeDataGrid.TabIndex = 3;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.Name = "IdColumn";
            // 
            // HrefColumn
            // 
            this.HrefColumn.HeaderText = "Href";
            this.HrefColumn.Name = "HrefColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // downloadDataGridViewTextBoxColumn
            // 
            this.downloadDataGridViewTextBoxColumn.DataPropertyName = "Download";
            this.downloadDataGridViewTextBoxColumn.HeaderText = "Download";
            this.downloadDataGridViewTextBoxColumn.Name = "downloadDataGridViewTextBoxColumn";
            // 
            // relationDataGridViewTextBoxColumn
            // 
            this.relationDataGridViewTextBoxColumn.DataPropertyName = "Relation";
            this.relationDataGridViewTextBoxColumn.HeaderText = "Rel";
            this.relationDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "alternate",
            "author",
            "bookmark",
            "external",
            "help",
            "license",
            "next",
            "nofollow",
            "noreferrer",
            "noopener",
            "prev",
            "search",
            "tag"});
            this.relationDataGridViewTextBoxColumn.Name = "relationDataGridViewTextBoxColumn";
            this.relationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.relationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // targetDataGridViewTextBoxColumn
            // 
            this.targetDataGridViewTextBoxColumn.HeaderText = "Target";
            this.targetDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "_blank",
            "_parent",
            "_self",
            "_top"});
            this.targetDataGridViewTextBoxColumn.Name = "targetDataGridViewTextBoxColumn";
            this.targetDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.targetDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ClassesColumn
            // 
            this.ClassesColumn.HeaderText = "Classes";
            this.ClassesColumn.Name = "ClassesColumn";
            this.ClassesColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // iHtmlAnchorElementBindingSource2
            // 
            this.iHtmlAnchorElementBindingSource2.DataSource = typeof(AngleSharp.Html.Dom.IHtmlAnchorElement);
            // 
            // AddAnchorButton
            // 
            this.AddAnchorButton.Location = new System.Drawing.Point(248, 189);
            this.AddAnchorButton.Name = "AddAnchorButton";
            this.AddAnchorButton.Size = new System.Drawing.Size(75, 23);
            this.AddAnchorButton.TabIndex = 4;
            this.AddAnchorButton.Text = "Add";
            this.AddAnchorButton.UseVisualStyleBackColor = true;
            this.AddAnchorButton.Click += new System.EventHandler(this.AddAnchorButton_Click);
            // 
            // RemoveAnchorButton
            // 
            this.RemoveAnchorButton.Location = new System.Drawing.Point(94, 190);
            this.RemoveAnchorButton.Name = "RemoveAnchorButton";
            this.RemoveAnchorButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveAnchorButton.TabIndex = 5;
            this.RemoveAnchorButton.Text = "Remove";
            this.RemoveAnchorButton.UseVisualStyleBackColor = true;
            this.RemoveAnchorButton.Click += new System.EventHandler(this.RemoveAnchorButton_Click);
            // 
            // iHtmlInputElementBindingSource
            // 
            this.iHtmlInputElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlInputElement);
            // 
            // AnchorAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 224);
            this.Controls.Add(this.RemoveAnchorButton);
            this.Controls.Add(this.AddAnchorButton);
            this.Controls.Add(this.anchorAttributeDataGrid);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "AnchorAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnchorAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iValidityStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlSelectElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchorAttributeDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlInputElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource iHtmlAnchorElementBindingSource;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.BindingSource iValidityStateBindingSource;
        private System.Windows.Forms.BindingSource iHtmlAnchorElementBindingSource1;
        private System.Windows.Forms.BindingSource iHtmlSelectElementBindingSource;
        private System.Windows.Forms.BindingSource iHtmlAnchorElementBindingSource2;
        private System.Windows.Forms.DataGridView anchorAttributeDataGrid;
        private System.Windows.Forms.Button AddAnchorButton;
        private System.Windows.Forms.Button RemoveAnchorButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HrefColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn relationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn targetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassesColumn;
        private System.Windows.Forms.BindingSource iHtmlInputElementBindingSource;
    }
}