namespace Puzzle
{
    partial class FormPuzzle
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPuzzle));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timerPuzzle = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.загрузитьКартинкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьОригиналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьЗановоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.подсказкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(937, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьКартинкуToolStripMenuItem,
            this.показатьОригиналToolStripMenuItem,
            this.начатьЗановоToolStripMenuItem,
            this.toolStripMenuItem1,
            this.SaveGame,
            this.LoadGame,
            this.toolStripMenuItem2,
            this.подсказкаToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.играToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.играToolStripMenuItem.Text = "Игра";
            this.играToolStripMenuItem.ToolTipText = "Нажмите для выбора действий игры";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(937, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 20);
            this.toolStripStatusLabel1.Text = "Время игры:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(63, 20);
            this.toolStripStatusLabel2.Text = "00:00:00";
            this.toolStripStatusLabel2.ToolTipText = "Текущее время игры";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(25, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(889, 434);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox1, "Игровое поле");
            // 
            // timerPuzzle
            // 
            this.timerPuzzle.Interval = 1000;
            this.timerPuzzle.Tick += new System.EventHandler(this.timerPuzzle_Tick);
            // 
            // загрузитьКартинкуToolStripMenuItem
            // 
            this.загрузитьКартинкуToolStripMenuItem.Image = global::Puzzle.Properties.Resources.download_26;
            this.загрузитьКартинкуToolStripMenuItem.Name = "загрузитьКартинкуToolStripMenuItem";
            this.загрузитьКартинкуToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.загрузитьКартинкуToolStripMenuItem.Text = "Загрузить &картинку";
            this.загрузитьКартинкуToolStripMenuItem.ToolTipText = "Для начала игры, выберете любую картинку";
            this.загрузитьКартинкуToolStripMenuItem.Click += new System.EventHandler(this.загрузитьКартинкуToolStripMenuItem_Click);
            // 
            // показатьОригиналToolStripMenuItem
            // 
            this.показатьОригиналToolStripMenuItem.Image = global::Puzzle.Properties.Resources.picture_26;
            this.показатьОригиналToolStripMenuItem.Name = "показатьОригиналToolStripMenuItem";
            this.показатьОригиналToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.показатьОригиналToolStripMenuItem.Text = "Показать &оригинал";
            this.показатьОригиналToolStripMenuItem.ToolTipText = "Показывает оригинал загруженной картинки";
            this.показатьОригиналToolStripMenuItem.Click += new System.EventHandler(this.показатьОригиналToolStripMenuItem_Click);
            // 
            // начатьЗановоToolStripMenuItem
            // 
            this.начатьЗановоToolStripMenuItem.Image = global::Puzzle.Properties.Resources.repeat_26;
            this.начатьЗановоToolStripMenuItem.Name = "начатьЗановоToolStripMenuItem";
            this.начатьЗановоToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.начатьЗановоToolStripMenuItem.Text = "Начать &заново";
            this.начатьЗановоToolStripMenuItem.ToolTipText = "Начать сбор пазла заново";
            this.начатьЗановоToolStripMenuItem.Click += new System.EventHandler(this.начатьЗановоToolStripMenuItem_Click);
            // 
            // SaveGame
            // 
            this.SaveGame.Image = global::Puzzle.Properties.Resources.save_as_26;
            this.SaveGame.Name = "SaveGame";
            this.SaveGame.Size = new System.Drawing.Size(203, 24);
            this.SaveGame.Text = "&Сохранить";
            this.SaveGame.ToolTipText = "Сохранить текущую игру";
            this.SaveGame.Click += new System.EventHandler(this.SaveGame_Click);
            // 
            // LoadGame
            // 
            this.LoadGame.Image = global::Puzzle.Properties.Resources.data_backup_26;
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(203, 24);
            this.LoadGame.Text = "&Загрузить";
            this.LoadGame.ToolTipText = "Загрузить ранее сохраненную игру";
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // подсказкаToolStripMenuItem
            // 
            this.подсказкаToolStripMenuItem.Image = global::Puzzle.Properties.Resources.help_32;
            this.подсказкаToolStripMenuItem.Name = "подсказкаToolStripMenuItem";
            this.подсказкаToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.подсказкаToolStripMenuItem.Text = "&Подсказка";
            this.подсказкаToolStripMenuItem.ToolTipText = "Использовать одну подсказку";
            this.подсказкаToolStripMenuItem.Click += new System.EventHandler(this.подсказкаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::Puzzle.Properties.Resources.shutdown;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.выходToolStripMenuItem.Text = "&Выход";
            this.выходToolStripMenuItem.ToolTipText = "Выход из игры";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // FormPuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 515);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPuzzle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра \"Мозаика\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьКартинкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьОригиналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьЗановоToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Timer timerPuzzle;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveGame;
        private System.Windows.Forms.ToolStripMenuItem LoadGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem подсказкаToolStripMenuItem;
    }
}

