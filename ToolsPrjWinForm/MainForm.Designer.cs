namespace ToolsPrjWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокРабочихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИнструментаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборкаНаПроверкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.btnItemInfo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(340, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокРабочихToolStripMenuItem,
            this.списокИнструментаToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // списокРабочихToolStripMenuItem
            // 
            this.списокРабочихToolStripMenuItem.Name = "списокРабочихToolStripMenuItem";
            this.списокРабочихToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.списокРабочихToolStripMenuItem.Text = "Список рабочих";
            this.списокРабочихToolStripMenuItem.Click += new System.EventHandler(this.списокРабочихToolStripMenuItem_Click);
            // 
            // списокИнструментаToolStripMenuItem
            // 
            this.списокИнструментаToolStripMenuItem.Name = "списокИнструментаToolStripMenuItem";
            this.списокИнструментаToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.списокИнструментаToolStripMenuItem.Text = "Список инструмента";
            this.списокИнструментаToolStripMenuItem.Click += new System.EventHandler(this.списокИнструментаToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборкаНаПроверкуToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            this.отчетыToolStripMenuItem.Click += new System.EventHandler(this.отчетыToolStripMenuItem_Click);
            // 
            // выборкаНаПроверкуToolStripMenuItem
            // 
            this.выборкаНаПроверкуToolStripMenuItem.Name = "выборкаНаПроверкуToolStripMenuItem";
            this.выборкаНаПроверкуToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.выборкаНаПроверкуToolStripMenuItem.Text = "Выборка на проверку";
            this.выборкаНаПроверкуToolStripMenuItem.Click += new System.EventHandler(this.выборкаНаПроверкуToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // очиститьИсториюПеремещенияИнструментаToolStripMenuItem
            // 
            this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem.Name = "очиститьИсториюПеремещенияИнструментаToolStripMenuItem";
            this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem.Size = new System.Drawing.Size(333, 22);
            this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem.Text = "Очистить историю перемещения инструмента";
            this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem.Click += new System.EventHandler(this.очиститьИсториюПеремещенияИнструментаToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 128);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выдать\r\nПринять";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGiveTool_Click);
            // 
            // btnItemInfo
            // 
            this.btnItemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnItemInfo.Location = new System.Drawing.Point(188, 27);
            this.btnItemInfo.Name = "btnItemInfo";
            this.btnItemInfo.Size = new System.Drawing.Size(140, 128);
            this.btnItemInfo.TabIndex = 4;
            this.btnItemInfo.Text = "Поиск по\r\nинструменту";
            this.btnItemInfo.UseVisualStyleBackColor = true;
            this.btnItemInfo.Click += new System.EventHandler(this.btnItemInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 176);
            this.Controls.Add(this.btnItemInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 215);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 215);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Отслеживание инструмента";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокРабочихToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнструментаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выборкаНаПроверкуToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnItemInfo;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьИсториюПеремещенияИнструментаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
    }
}

