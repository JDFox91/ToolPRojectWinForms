namespace ToolsPrjWinForm
{
    partial class frmChangeCondition
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
            this.btnFree = new System.Windows.Forms.Button();
            this.btnLost = new System.Windows.Forms.Button();
            this.btnDefected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFree
            // 
            this.btnFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFree.Location = new System.Drawing.Point(12, 12);
            this.btnFree.Name = "btnFree";
            this.btnFree.Size = new System.Drawing.Size(184, 35);
            this.btnFree.TabIndex = 0;
            this.btnFree.Text = "Инструмент свободен";
            this.btnFree.UseVisualStyleBackColor = true;
            this.btnFree.Click += new System.EventHandler(this.btnFree_Click);
            // 
            // btnLost
            // 
            this.btnLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLost.Location = new System.Drawing.Point(12, 53);
            this.btnLost.Name = "btnLost";
            this.btnLost.Size = new System.Drawing.Size(184, 34);
            this.btnLost.TabIndex = 2;
            this.btnLost.Text = "Инструмент утерян";
            this.btnLost.UseVisualStyleBackColor = true;
            this.btnLost.Click += new System.EventHandler(this.btnLost_Click);
            // 
            // btnDefected
            // 
            this.btnDefected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDefected.Location = new System.Drawing.Point(12, 93);
            this.btnDefected.Name = "btnDefected";
            this.btnDefected.Size = new System.Drawing.Size(184, 31);
            this.btnDefected.TabIndex = 3;
            this.btnDefected.Text = "Инструмент забракован";
            this.btnDefected.UseVisualStyleBackColor = true;
            this.btnDefected.Click += new System.EventHandler(this.btnDefected_Click);
            // 
            // frmChangeCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 133);
            this.Controls.Add(this.btnDefected);
            this.Controls.Add(this.btnLost);
            this.Controls.Add(this.btnFree);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(225, 172);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(225, 172);
            this.Name = "frmChangeCondition";
            this.ShowIcon = false;
            this.Text = "Изменить состояние";
            this.Load += new System.EventHandler(this.frmChangeCondition_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFree;
        private System.Windows.Forms.Button btnLost;
        private System.Windows.Forms.Button btnDefected;
    }
}