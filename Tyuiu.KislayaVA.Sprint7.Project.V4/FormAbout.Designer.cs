namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            labelAbout_KVA = new Label();
            pictureBoxCoolSkeleton_KVA = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCoolSkeleton_KVA).BeginInit();
            SuspendLayout();
            // 
            // labelAbout_KVA
            // 
            labelAbout_KVA.AutoSize = true;
            labelAbout_KVA.BackColor = SystemColors.AppWorkspace;
            labelAbout_KVA.Font = new Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelAbout_KVA.ForeColor = SystemColors.ActiveCaptionText;
            labelAbout_KVA.Location = new Point(36, 46);
            labelAbout_KVA.Name = "labelAbout_KVA";
            labelAbout_KVA.Size = new Size(324, 216);
            labelAbout_KVA.TabIndex = 0;
            labelAbout_KVA.Text = "О программе\r\n\r\n\r\nКислая В. А. РППб25-1\r\n\r\nСпринт7 Проект Вариант 4\r\n\r\nТИУ 2025\r\n";
            // 
            // pictureBoxCoolSkeleton_KVA
            // 
            pictureBoxCoolSkeleton_KVA.Image = (Image)resources.GetObject("pictureBoxCoolSkeleton_KVA.Image");
            pictureBoxCoolSkeleton_KVA.Location = new Point(397, 69);
            pictureBoxCoolSkeleton_KVA.Name = "pictureBoxCoolSkeleton_KVA";
            pictureBoxCoolSkeleton_KVA.Size = new Size(268, 233);
            pictureBoxCoolSkeleton_KVA.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCoolSkeleton_KVA.TabIndex = 1;
            pictureBoxCoolSkeleton_KVA.TabStop = false;
            pictureBoxCoolSkeleton_KVA.Click += pictureBoxCoolSkeleton_KVA_Click;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(705, 391);
            Controls.Add(pictureBoxCoolSkeleton_KVA);
            Controls.Add(labelAbout_KVA);
            MaximizeBox = false;
            Name = "FormAbout";
            Text = "О программе";
            Load += FormAbout_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCoolSkeleton_KVA).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAbout_KVA;
        private PictureBox pictureBoxCoolSkeleton_KVA;
    }
}