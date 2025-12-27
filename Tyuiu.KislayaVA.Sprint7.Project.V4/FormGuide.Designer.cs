namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    partial class FormGuide
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
            label1 = new Label();
            labelInfoBrand_KVA = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(457, 140);
            label1.TabIndex = 0;
            label1.Text = "Вы можете загружать и редактировать файлы\r\nданных о книгах и читателях, производить поиск и фильтрацию\r\n\r\nдоступна статистика\r\n\r\nТак же можно посмотреть на крутого скелета\r\n\r\n";
            // 
            // labelInfoBrand_KVA
            // 
            labelInfoBrand_KVA.AutoSize = true;
            labelInfoBrand_KVA.Location = new Point(52, 424);
            labelInfoBrand_KVA.Name = "labelInfoBrand_KVA";
            labelInfoBrand_KVA.Size = new Size(384, 20);
            labelInfoBrand_KVA.TabIndex = 1;
            labelInfoBrand_KVA.Text = "Система контроля библиотеки \"Либрария\" 2025-2030";
            // 
            // FormGuide
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(497, 453);
            Controls.Add(labelInfoBrand_KVA);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "FormGuide";
            Text = "Руководство";
            Load += FormGuide_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelInfoBrand_KVA;
    }
}