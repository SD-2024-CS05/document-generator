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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnchorAttributesForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.AnchorDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.targetLanguageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iHtmlAnchorElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AnchorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource)).BeginInit();
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
            // AnchorDataGridView
            // 
            this.AnchorDataGridView.AutoGenerateColumns = false;
            this.AnchorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnchorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.downloadDataGridViewTextBoxColumn,
            this.relationDataGridViewTextBoxColumn,
            this.targetLanguageDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn});
            this.AnchorDataGridView.DataSource = this.iHtmlAnchorElementBindingSource;
            this.AnchorDataGridView.Location = new System.Drawing.Point(32, 29);
            this.AnchorDataGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AnchorDataGridView.Name = "AnchorDataGridView";
            this.AnchorDataGridView.RowHeadersWidth = 102;
            this.AnchorDataGridView.Size = new System.Drawing.Size(1029, 324);
            this.AnchorDataGridView.TabIndex = 13;
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.MinimumWidth = 12;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Width = 250;
            // 
            // downloadDataGridViewTextBoxColumn
            // 
            this.downloadDataGridViewTextBoxColumn.DataPropertyName = "Download";
            this.downloadDataGridViewTextBoxColumn.HeaderText = "Download";
            this.downloadDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.downloadDataGridViewTextBoxColumn.Name = "downloadDataGridViewTextBoxColumn";
            this.downloadDataGridViewTextBoxColumn.Width = 250;
            // 
            // relationDataGridViewTextBoxColumn
            // 
            this.relationDataGridViewTextBoxColumn.DataPropertyName = "Relation";
            this.relationDataGridViewTextBoxColumn.HeaderText = "Relation";
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
            this.relationDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.relationDataGridViewTextBoxColumn.Name = "relationDataGridViewTextBoxColumn";
            this.relationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.relationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.relationDataGridViewTextBoxColumn.Width = 250;
            // 
            // targetLanguageDataGridViewTextBoxColumn
            // 
            this.targetLanguageDataGridViewTextBoxColumn.DataPropertyName = "Target";
            this.targetLanguageDataGridViewTextBoxColumn.HeaderText = "Target";
            this.targetLanguageDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "_blank",
            "_parent",
            "_self",
            "_top"});
            this.targetLanguageDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.targetLanguageDataGridViewTextBoxColumn.Name = "targetLanguageDataGridViewTextBoxColumn";
            this.targetLanguageDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.targetLanguageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.targetLanguageDataGridViewTextBoxColumn.Width = 250;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.ReadOnly = true;
            this.textDataGridViewTextBoxColumn.Width = 250;
            // 
            // iHtmlAnchorElementBindingSource
            // 
            this.iHtmlAnchorElementBindingSource.DataSource = typeof(AngleSharp.Html.Dom.IHtmlAnchorElement);
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
            // AnchorAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 451);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AnchorDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AnchorAttributesForm";
            this.Text = "Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnchorAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.AnchorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHtmlAnchorElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView AnchorDataGridView;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.BindingSource iHtmlAnchorElementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn relationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn targetLanguageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
    }
}