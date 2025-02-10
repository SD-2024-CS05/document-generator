namespace ShapeHandler.Database
{
    partial class ShapeDataForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Inputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Anchors", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Selects", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Images", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Inputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeDataForm));
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddControlComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(360, 169);
            this.okayButton.Margin = new System.Windows.Forms.Padding(2);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(46, 29);
            this.okayButton.TabIndex = 13;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(11, 171);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(63, 29);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // listView1
            // 
            listViewGroup1.Header = "Inputs";
            listViewGroup1.Name = "InputGroup";
            listViewGroup2.Header = "Anchors";
            listViewGroup2.Name = "AnchorGroup";
            listViewGroup3.Header = "Selects";
            listViewGroup3.Name = "SelectGroup";
            listViewGroup4.Header = "Images";
            listViewGroup4.Name = "ImageGroup";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.listView1.HideSelection = false;
            listViewGroup5.Header = "Inputs";
            listViewGroup5.Name = "InputGroup";
            listViewItem1.Group = listViewGroup5;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(394, 152);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AddControlComboBox
            // 
            this.AddControlComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "<input>",
            "<a>",
            "<select>",
            "<img>"});
            this.AddControlComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.AddControlComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.AddControlComboBox.FormattingEnabled = true;
            this.AddControlComboBox.Items.AddRange(new object[] {
            "<input>",
            "<a>",
            "<select>",
            "<img>"});
            this.AddControlComboBox.Location = new System.Drawing.Point(240, 174);
            this.AddControlComboBox.Name = "AddControlComboBox";
            this.AddControlComboBox.Size = new System.Drawing.Size(115, 21);
            this.AddControlComboBox.TabIndex = 18;
            this.AddControlComboBox.SelectedIndexChanged += new System.EventHandler(this.AddControlComboBox_SelectedIndexChanged);
            // 
            // ShapeDataForm
            // 
            this.AcceptButton = this.okayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 202);
            this.Controls.Add(this.AddControlComboBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShapeDataForm";
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.ShapeDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox AddControlComboBox;
    }
}