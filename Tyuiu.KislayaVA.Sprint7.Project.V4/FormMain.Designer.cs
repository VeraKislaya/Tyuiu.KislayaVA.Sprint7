namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            toolStripFile_KVA = new ToolStripDropDownButton();
            toolStripOpenFile_KVA = new ToolStripMenuItem();
            toolStripSaveFile_KVA = new ToolStripMenuItem();
            toolStripStatistic_KVA = new ToolStripDropDownButton();
            ToolStripMenuFunc_KVA = new ToolStripMenuItem();
            toolStripSpravka_KVA = new ToolStripDropDownButton();
            ToolStripAbout_KVA = new ToolStripMenuItem();
            ToolStripGuide_KVA = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPageBooks_KVA = new TabPage();
            textBoxSearch_KVA = new TextBox();
            comboBoxFiltr_KVA = new ComboBox();
            dataGridView1 = new DataGridView();
            tabPageReaders_KVA = new TabPage();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            dataGridView2 = new DataGridView();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageBooks_KVA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPageReaders_KVA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripFile_KVA, toolStripStatistic_KVA, toolStripSpravka_KVA });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1433, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripFile_KVA
            // 
            toolStripFile_KVA.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripFile_KVA.DropDownItems.AddRange(new ToolStripItem[] { toolStripOpenFile_KVA, toolStripSaveFile_KVA });
            toolStripFile_KVA.ImageTransparentColor = Color.Magenta;
            toolStripFile_KVA.Name = "toolStripFile_KVA";
            toolStripFile_KVA.Size = new Size(59, 24);
            toolStripFile_KVA.Text = "Файл";
            // 
            // toolStripOpenFile_KVA
            // 
            toolStripOpenFile_KVA.Name = "toolStripOpenFile_KVA";
            toolStripOpenFile_KVA.Size = new Size(166, 26);
            toolStripOpenFile_KVA.Text = "Открыть";
            toolStripOpenFile_KVA.Click += открытьToolStripMenuItem_Click;
            // 
            // toolStripSaveFile_KVA
            // 
            toolStripSaveFile_KVA.Name = "toolStripSaveFile_KVA";
            toolStripSaveFile_KVA.Size = new Size(166, 26);
            toolStripSaveFile_KVA.Text = "Сохранить";
            // 
            // toolStripStatistic_KVA
            // 
            toolStripStatistic_KVA.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatistic_KVA.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuFunc_KVA });
            toolStripStatistic_KVA.ImageTransparentColor = Color.Magenta;
            toolStripStatistic_KVA.Name = "toolStripStatistic_KVA";
            toolStripStatistic_KVA.Size = new Size(98, 24);
            toolStripStatistic_KVA.Text = "Статистика";
            // 
            // ToolStripMenuFunc_KVA
            // 
            ToolStripMenuFunc_KVA.Name = "ToolStripMenuFunc_KVA";
            ToolStripMenuFunc_KVA.Size = new Size(131, 26);
            ToolStripMenuFunc_KVA.Text = "Цены";
            ToolStripMenuFunc_KVA.Click += ToolStripMenuFunc_KVA_CLick;
            // 
            // toolStripSpravka_KVA
            // 
            toolStripSpravka_KVA.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripSpravka_KVA.DropDownItems.AddRange(new ToolStripItem[] { ToolStripAbout_KVA, ToolStripGuide_KVA });
            toolStripSpravka_KVA.ImageTransparentColor = Color.Magenta;
            toolStripSpravka_KVA.Name = "toolStripSpravka_KVA";
            toolStripSpravka_KVA.Size = new Size(81, 24);
            toolStripSpravka_KVA.Text = "Справка";
            // 
            // ToolStripAbout_KVA
            // 
            ToolStripAbout_KVA.Name = "ToolStripAbout_KVA";
            ToolStripAbout_KVA.Size = new Size(187, 26);
            ToolStripAbout_KVA.Text = "О программе";
            ToolStripAbout_KVA.Click += ToolStripAbout_KVA_Click;
            // 
            // ToolStripGuide_KVA
            // 
            ToolStripGuide_KVA.Name = "ToolStripGuide_KVA";
            ToolStripGuide_KVA.Size = new Size(187, 26);
            ToolStripGuide_KVA.Text = "Руководство";
            ToolStripGuide_KVA.Click += ToolStripGuide_KVA_CLick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageBooks_KVA);
            tabControl1.Controls.Add(tabPageReaders_KVA);
            tabControl1.Location = new Point(12, 68);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1409, 592);
            tabControl1.TabIndex = 1;
            // 
            // tabPageBooks_KVA
            // 
            tabPageBooks_KVA.Controls.Add(textBoxSearch_KVA);
            tabPageBooks_KVA.Controls.Add(comboBoxFiltr_KVA);
            tabPageBooks_KVA.Controls.Add(dataGridView1);
            tabPageBooks_KVA.Location = new Point(4, 29);
            tabPageBooks_KVA.Name = "tabPageBooks_KVA";
            tabPageBooks_KVA.Padding = new Padding(3);
            tabPageBooks_KVA.Size = new Size(1401, 559);
            tabPageBooks_KVA.TabIndex = 0;
            tabPageBooks_KVA.Text = "Книги";
            tabPageBooks_KVA.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch_KVA
            // 
            textBoxSearch_KVA.BackColor = SystemColors.AppWorkspace;
            textBoxSearch_KVA.Location = new Point(163, 7);
            textBoxSearch_KVA.Name = "textBoxSearch_KVA";
            textBoxSearch_KVA.Size = new Size(125, 27);
            textBoxSearch_KVA.TabIndex = 2;
            // 
            // comboBoxFiltr_KVA
            // 
            comboBoxFiltr_KVA.BackColor = SystemColors.AppWorkspace;
            comboBoxFiltr_KVA.FormattingEnabled = true;
            comboBoxFiltr_KVA.Items.AddRange(new object[] { "1", "2", "3" });
            comboBoxFiltr_KVA.Location = new Point(6, 6);
            comboBoxFiltr_KVA.Name = "comboBoxFiltr_KVA";
            comboBoxFiltr_KVA.Size = new Size(151, 28);
            comboBoxFiltr_KVA.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1389, 496);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPageReaders_KVA
            // 
            tabPageReaders_KVA.Controls.Add(textBox2);
            tabPageReaders_KVA.Controls.Add(comboBox2);
            tabPageReaders_KVA.Controls.Add(dataGridView2);
            tabPageReaders_KVA.Location = new Point(4, 29);
            tabPageReaders_KVA.Name = "tabPageReaders_KVA";
            tabPageReaders_KVA.Padding = new Padding(3);
            tabPageReaders_KVA.Size = new Size(1401, 559);
            tabPageReaders_KVA.TabIndex = 1;
            tabPageReaders_KVA.Text = "Читатели";
            tabPageReaders_KVA.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.AppWorkspace;
            textBox2.Location = new Point(163, 7);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.AppWorkspace;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1", "2", "3" });
            comboBox2.Location = new Point(6, 6);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 2;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 57);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1389, 496);
            dataGridView2.TabIndex = 1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1433, 672);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Спринт 7 Проект В4 Кислая В.А. РППб25-1";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageBooks_KVA.ResumeLayout(false);
            tabPageBooks_KVA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPageReaders_KVA.ResumeLayout(false);
            tabPageReaders_KVA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripFile_KVA;
        private ToolStripMenuItem toolStripOpenFile_KVA;
        private ToolStripMenuItem toolStripSaveFile_KVA;
        private ToolStripDropDownButton toolStripStatistic_KVA;
        private ToolStripMenuItem ToolStripMenuFunc_KVA;
        private ToolStripDropDownButton toolStripSpravka_KVA;
        private ToolStripMenuItem ToolStripAbout_KVA;
        private ToolStripMenuItem ToolStripGuide_KVA;
        private TabControl tabControl1;
        private TabPage tabPageBooks_KVA;
        private DataGridView dataGridView1;
        private TabPage tabPageReaders_KVA;
        private DataGridView dataGridView2;
        private ComboBox comboBoxFiltr_KVA;
        private TextBox textBoxSearch_KVA;
        private TextBox textBox2;
        private ComboBox comboBox2;
    }
}
