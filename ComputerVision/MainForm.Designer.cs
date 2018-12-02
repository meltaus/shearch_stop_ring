namespace ComputerVision
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanListFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.sing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.haarLabel = new System.Windows.Forms.Label();
            this.cennyLabe = new System.Windows.Forms.Label();
            this.timeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.haarPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cannyPictureBox2 = new System.Windows.Forms.PictureBox();
            this.cannyPictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.haarPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cannyPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyPictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFile,
            this.cleanListFileToolStripMenuItem,
            this.menuExitProgram});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(168, 22);
            this.menuOpenFile.Text = "Добавить";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // cleanListFileToolStripMenuItem
            // 
            this.cleanListFileToolStripMenuItem.Name = "cleanListFileToolStripMenuItem";
            this.cleanListFileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cleanListFileToolStripMenuItem.Text = "Очистить список";
            this.cleanListFileToolStripMenuItem.Click += new System.EventHandler(this.cleanListFileToolStripMenuItem_Click);
            // 
            // menuExitProgram
            // 
            this.menuExitProgram.Name = "menuExitProgram";
            this.menuExitProgram.Size = new System.Drawing.Size(168, 22);
            this.menuExitProgram.Text = "Выход";
            this.menuExitProgram.Click += new System.EventHandler(this.menuExitProgram_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizeToolStripMenuItem,
            this.abortThreadToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // analizeToolStripMenuItem
            // 
            this.analizeToolStripMenuItem.Name = "analizeToolStripMenuItem";
            this.analizeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.analizeToolStripMenuItem.Text = "Анализ";
            this.analizeToolStripMenuItem.Click += new System.EventHandler(this.menuAnalizeFile_Click);
            // 
            // abortThreadToolStripMenuItem
            // 
            this.abortThreadToolStripMenuItem.Name = "abortThreadToolStripMenuItem";
            this.abortThreadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.abortThreadToolStripMenuItem.Text = "Стоп";
            this.abortThreadToolStripMenuItem.Click += new System.EventHandler(this.abortThreadToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sing});
            this.listView.Location = new System.Drawing.Point(0, 27);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(171, 422);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // sing
            // 
            this.sing.Tag = "";
            this.sing.Text = "Знаки";
            this.sing.Width = 183;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.haarLabel);
            this.groupBox4.Controls.Add(this.cennyLabe);
            this.groupBox4.Controls.Add(this.timeChart);
            this.groupBox4.Location = new System.Drawing.Point(177, 248);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(653, 201);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Время";
            // 
            // haarLabel
            // 
            this.haarLabel.AutoSize = true;
            this.haarLabel.Location = new System.Drawing.Point(7, 34);
            this.haarLabel.Name = "haarLabel";
            this.haarLabel.Size = new System.Drawing.Size(65, 13);
            this.haarLabel.TabIndex = 3;
            this.haarLabel.Text = "Статистика";
            // 
            // cennyLabe
            // 
            this.cennyLabe.AutoSize = true;
            this.cennyLabe.Location = new System.Drawing.Point(7, 17);
            this.cennyLabe.Name = "cennyLabe";
            this.cennyLabe.Size = new System.Drawing.Size(65, 13);
            this.cennyLabe.TabIndex = 2;
            this.cennyLabe.Text = "Статистика";
            // 
            // timeChart
            // 
            this.timeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.Name = "ChartArea1";
            this.timeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.timeChart.Legends.Add(legend1);
            this.timeChart.Location = new System.Drawing.Point(6, 50);
            this.timeChart.Name = "timeChart";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Хаар";
            series1.YValuesPerPoint = 4;
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Кенни";
            this.timeChart.Series.Add(series1);
            this.timeChart.Series.Add(series2);
            this.timeChart.Size = new System.Drawing.Size(628, 145);
            this.timeChart.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.haarPictureBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(465, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 184);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Метод Хаара";
            // 
            // haarPictureBox
            // 
            this.haarPictureBox.Location = new System.Drawing.Point(9, 33);
            this.haarPictureBox.Name = "haarPictureBox";
            this.haarPictureBox.Size = new System.Drawing.Size(150, 150);
            this.haarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.haarPictureBox.TabIndex = 4;
            this.haarPictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Знак на исходном изображении";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cannyPictureBox2);
            this.groupBox2.Controls.Add(this.cannyPictureBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(176, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 184);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Метод Кенни";
            // 
            // cannyPictureBox2
            // 
            this.cannyPictureBox2.Location = new System.Drawing.Point(114, 33);
            this.cannyPictureBox2.Name = "cannyPictureBox2";
            this.cannyPictureBox2.Size = new System.Drawing.Size(150, 150);
            this.cannyPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cannyPictureBox2.TabIndex = 6;
            this.cannyPictureBox2.TabStop = false;
            // 
            // cannyPictureBox1
            // 
            this.cannyPictureBox1.Location = new System.Drawing.Point(7, 33);
            this.cannyPictureBox1.Name = "cannyPictureBox1";
            this.cannyPictureBox1.Size = new System.Drawing.Size(100, 100);
            this.cannyPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cannyPictureBox1.TabIndex = 5;
            this.cannyPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Знак на исходном изображении";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Знак";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 184);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходное изображение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Исходное изображение";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(177, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(653, 213);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 461);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(854, 500);
            this.Name = "MainForm";
            this.Text = "ComputerVision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.haarPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cannyPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyPictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuExitProgram;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader sing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox haarPictureBox;
        private System.Windows.Forms.PictureBox cannyPictureBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeChart;
        private System.Windows.Forms.Label cennyLabe;
        private System.Windows.Forms.Label haarLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox cannyPictureBox1;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanListFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortThreadToolStripMenuItem;
    }
}

