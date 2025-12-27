namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    partial class FormGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            labelStatis_KVA = new Label();
            chartStats_KVA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            buttonCloseStats_KVA = new Button();
            ((System.ComponentModel.ISupportInitialize)chartStats_KVA).BeginInit();
            SuspendLayout();
            // 
            // labelStatis_KVA
            // 
            labelStatis_KVA.AutoSize = true;
            labelStatis_KVA.Location = new Point(35, 42);
            labelStatis_KVA.Name = "labelStatis_KVA";
            labelStatis_KVA.Size = new Size(15, 20);
            labelStatis_KVA.TabIndex = 2;
            labelStatis_KVA.Text = "-";
            // 
            // chartStats_KVA
            // 
            chartStats_KVA.BackColor = SystemColors.AppWorkspace;
            chartArea1.Name = "ChartArea1";
            chartStats_KVA.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartStats_KVA.Legends.Add(legend1);
            chartStats_KVA.Location = new Point(510, 106);
            chartStats_KVA.Name = "chartStats_KVA";
            chartStats_KVA.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStats_KVA.Series.Add(series1);
            chartStats_KVA.Size = new Size(564, 549);
            chartStats_KVA.TabIndex = 3;
            chartStats_KVA.Text = "chart1";
            // 
            // buttonCloseStats_KVA
            // 
            buttonCloseStats_KVA.Location = new Point(967, 20);
            buttonCloseStats_KVA.Name = "buttonCloseStats_KVA";
            buttonCloseStats_KVA.Size = new Size(107, 64);
            buttonCloseStats_KVA.TabIndex = 4;
            buttonCloseStats_KVA.Text = "Закрыть";
            buttonCloseStats_KVA.UseVisualStyleBackColor = true;
            buttonCloseStats_KVA.Click += buttonCloseStats_KVA_Click;
            // 
            // FormGraph
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1086, 667);
            Controls.Add(buttonCloseStats_KVA);
            Controls.Add(chartStats_KVA);
            Controls.Add(labelStatis_KVA);
            MaximizeBox = false;
            Name = "FormGraph";
            Text = "Статистика";
            Load += FormGraph_Load;
            ((System.ComponentModel.ISupportInitialize)chartStats_KVA).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelStatis_KVA;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStats_KVA;
        private Button buttonCloseStats_KVA;
    }
}