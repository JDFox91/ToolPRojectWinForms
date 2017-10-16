namespace ToolsPrjWinForm
{
    partial class frmGetItem
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьВБазуНовыйИнструментToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstGroup = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstItem = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.rdbNameSearch = new System.Windows.Forms.RadioButton();
            this.rdbIdSearch = new System.Windows.Forms.RadioButton();
            this.rdbCodeSearch = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(714, 381);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(795, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВБазуНовыйИнструментToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьВБазуНовыйИнструментToolStripMenuItem
            // 
            this.добавитьВБазуНовыйИнструментToolStripMenuItem.Name = "добавитьВБазуНовыйИнструментToolStripMenuItem";
            this.добавитьВБазуНовыйИнструментToolStripMenuItem.Size = new System.Drawing.Size(214, 20);
            this.добавитьВБазуНовыйИнструментToolStripMenuItem.Text = "Добавить в базу новый инструмент";
            this.добавитьВБазуНовыйИнструментToolStripMenuItem.Click += new System.EventHandler(this.добавитьВБазуНовыйИнструментToolStripMenuItem_Click);
            // 
            // lstGroup
            // 
            this.lstGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.ItemHeight = 18;
            this.lstGroup.Location = new System.Drawing.Point(12, 65);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(166, 310);
            this.lstGroup.TabIndex = 4;
            this.lstGroup.SelectedIndexChanged += new System.EventHandler(this.lstGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Группа";
            // 
            // lstItem
            // 
            this.lstItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItem.ColumnWidth = 300;
            this.lstItem.FormattingEnabled = true;
            this.lstItem.HorizontalScrollbar = true;
            this.lstItem.ItemHeight = 18;
            this.lstItem.Location = new System.Drawing.Point(200, 65);
            this.lstItem.MultiColumn = true;
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(670, 310);
            this.lstItem.TabIndex = 6;
            this.lstItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItem_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Элемент";
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchBar.Location = new System.Drawing.Point(714, 32);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(158, 24);
            this.txtSearchBar.TabIndex = 8;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(436, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поиск";
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInfo.Location = new System.Drawing.Point(200, 381);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 10;
            this.btnInfo.Text = "Инфо";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // rdbNameSearch
            // 
            this.rdbNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNameSearch.AutoSize = true;
            this.rdbNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rdbNameSearch.Location = new System.Drawing.Point(494, 37);
            this.rdbNameSearch.Name = "rdbNameSearch";
            this.rdbNameSearch.Size = new System.Drawing.Size(72, 17);
            this.rdbNameSearch.TabIndex = 11;
            this.rdbNameSearch.TabStop = true;
            this.rdbNameSearch.Text = "по имени";
            this.rdbNameSearch.UseVisualStyleBackColor = true;
            // 
            // rdbIdSearch
            // 
            this.rdbIdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbIdSearch.AutoSize = true;
            this.rdbIdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rdbIdSearch.Location = new System.Drawing.Point(572, 37);
            this.rdbIdSearch.Name = "rdbIdSearch";
            this.rdbIdSearch.Size = new System.Drawing.Size(57, 17);
            this.rdbIdSearch.TabIndex = 12;
            this.rdbIdSearch.TabStop = true;
            this.rdbIdSearch.Text = "по ИД";
            this.rdbIdSearch.UseVisualStyleBackColor = true;
            // 
            // rdbCodeSearch
            // 
            this.rdbCodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbCodeSearch.AutoSize = true;
            this.rdbCodeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rdbCodeSearch.Location = new System.Drawing.Point(635, 37);
            this.rdbCodeSearch.Name = "rdbCodeSearch";
            this.rdbCodeSearch.Size = new System.Drawing.Size(73, 17);
            this.rdbCodeSearch.TabIndex = 13;
            this.rdbCodeSearch.TabStop = true;
            this.rdbCodeSearch.Text = "по шифру";
            this.rdbCodeSearch.UseVisualStyleBackColor = true;
            // 
            // frmGetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 416);
            this.Controls.Add(this.rdbCodeSearch);
            this.Controls.Add(this.rdbIdSearch);
            this.Controls.Add(this.rdbNameSearch);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(736, 416);
            this.Name = "frmGetItem";
            this.ShowIcon = false;
            this.Text = "Выберите инструмент";
            this.Load += new System.EventHandler(this.frmGetItem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВБазуНовыйИнструментToolStripMenuItem;
        private System.Windows.Forms.ListBox lstGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.RadioButton rdbNameSearch;
        private System.Windows.Forms.RadioButton rdbIdSearch;
        private System.Windows.Forms.RadioButton rdbCodeSearch;
    }
}