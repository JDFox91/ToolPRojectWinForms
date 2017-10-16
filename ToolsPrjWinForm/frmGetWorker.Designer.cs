namespace ToolsPrjWinForm
{
    partial class frmGetWorker
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
            this.lstWorkers = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbNameSearch = new System.Windows.Forms.RadioButton();
            this.rdbPersonalNumberSearch = new System.Windows.Forms.RadioButton();
            this.btnAddWorker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstWorkers
            // 
            this.lstWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWorkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstWorkers.FormattingEnabled = true;
            this.lstWorkers.ItemHeight = 18;
            this.lstWorkers.Location = new System.Drawing.Point(15, 119);
            this.lstWorkers.Name = "lstWorkers";
            this.lstWorkers.Size = new System.Drawing.Size(264, 310);
            this.lstWorkers.TabIndex = 0;
            this.lstWorkers.TabStop = false;
            this.lstWorkers.DoubleClick += new System.EventHandler(this.lstWorkers_DoubleClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(123, 445);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(204, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Список рабочих";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(15, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(264, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Строка поиска";
            // 
            // rdbNameSearch
            // 
            this.rdbNameSearch.AutoSize = true;
            this.rdbNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rdbNameSearch.Location = new System.Drawing.Point(174, 57);
            this.rdbNameSearch.Name = "rdbNameSearch";
            this.rdbNameSearch.Size = new System.Drawing.Size(105, 20);
            this.rdbNameSearch.TabIndex = 10;
            this.rdbNameSearch.Text = "по фамилии";
            this.rdbNameSearch.UseVisualStyleBackColor = true;
            // 
            // rdbPersonalNumberSearch
            // 
            this.rdbPersonalNumberSearch.AutoSize = true;
            this.rdbPersonalNumberSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rdbPersonalNumberSearch.Location = new System.Drawing.Point(15, 57);
            this.rdbPersonalNumberSearch.Name = "rdbPersonalNumberSearch";
            this.rdbPersonalNumberSearch.Size = new System.Drawing.Size(124, 20);
            this.rdbPersonalNumberSearch.TabIndex = 11;
            this.rdbPersonalNumberSearch.Text = "по табельному";
            this.rdbPersonalNumberSearch.UseVisualStyleBackColor = true;
            this.rdbPersonalNumberSearch.CheckedChanged += new System.EventHandler(this.rdbPersonalNumberSearch_CheckedChanged);
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Location = new System.Drawing.Point(13, 445);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(75, 23);
            this.btnAddWorker.TabIndex = 12;
            this.btnAddWorker.Text = "Добавить";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // frmGetWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 480);
            this.Controls.Add(this.btnAddWorker);
            this.Controls.Add(this.rdbPersonalNumberSearch);
            this.Controls.Add(this.rdbNameSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstWorkers);
            this.MinimumSize = new System.Drawing.Size(307, 519);
            this.Name = "frmGetWorker";
            this.ShowIcon = false;
            this.Text = "Выберите рабочего";
            this.Load += new System.EventHandler(this.frmGetWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstWorkers;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbNameSearch;
        private System.Windows.Forms.RadioButton rdbPersonalNumberSearch;
        private System.Windows.Forms.Button btnAddWorker;
    }
}