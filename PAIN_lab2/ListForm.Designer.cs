namespace PAIN_lab2
{
    partial class ListForm
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
            this.filterSelect = new System.Windows.Forms.ComboBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.labelColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // filterSelect
            // 
            this.filterSelect.FormattingEnabled = true;
            this.filterSelect.Items.AddRange(new object[] {
            AppModel.FILTER.ALL.ToString(),
            AppModel.FILTER.GREATER.ToString(),
            AppModel.FILTER.LESS.ToString()});
            this.filterSelect.SelectedText = AppModel.FILTER.ALL.ToString();
            this.filterSelect.Location = new System.Drawing.Point(162, 4);
            this.filterSelect.Name = "filterSelect";
            this.filterSelect.Size = new System.Drawing.Size(121, 21);
            this.filterSelect.TabIndex = 3;
            this.filterSelect.SelectedIndexChanged += new System.EventHandler(this.filterSelect_SelectedIndexChanged);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(81, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Usuń";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(0, 2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edytuj";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // listView
            // 
            this.listView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.labelColumn,
            this.xColumn,
            this.yColumn,
            this.colorColumn});
            this.listView.Location = new System.Drawing.Point(-1, 31);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(284, 230);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // labelColumn
            // 
            this.labelColumn.Text = "Label";
            this.labelColumn.Width = 70;
            // 
            // xColumn
            // 
            this.xColumn.Text = "X";
            // 
            // yColumn
            // 
            this.yColumn.Text = "Y";
            // 
            // colorColumn
            // 
            this.colorColumn.Text = "Color";
            this.colorColumn.Width = 70;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.filterSelect);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.listView);
            this.Name = "ListForm";
            this.Text = "ListForm";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader labelColumn;
        private System.Windows.Forms.ColumnHeader xColumn;
        private System.Windows.Forms.ColumnHeader yColumn;
        private System.Windows.Forms.ColumnHeader colorColumn;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ComboBox filterSelect;
    }
}