namespace StohasticRewardGame
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioCase1 = new System.Windows.Forms.RadioButton();
            this.radioCase2 = new System.Windows.Forms.RadioButton();
            this.radioCase3 = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCase3);
            this.groupBox1.Controls.Add(this.radioCase2);
            this.groupBox1.Controls.Add(this.radioCase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cases";
            // 
            // radioCase1
            // 
            this.radioCase1.AutoSize = true;
            this.radioCase1.Checked = true;
            this.radioCase1.Location = new System.Drawing.Point(16, 19);
            this.radioCase1.Name = "radioCase1";
            this.radioCase1.Size = new System.Drawing.Size(55, 17);
            this.radioCase1.TabIndex = 0;
            this.radioCase1.TabStop = true;
            this.radioCase1.Text = "Case1";
            this.radioCase1.UseVisualStyleBackColor = true;
            // 
            // radioCase2
            // 
            this.radioCase2.AutoSize = true;
            this.radioCase2.Location = new System.Drawing.Point(16, 42);
            this.radioCase2.Name = "radioCase2";
            this.radioCase2.Size = new System.Drawing.Size(55, 17);
            this.radioCase2.TabIndex = 1;
            this.radioCase2.Text = "Case2";
            this.radioCase2.UseVisualStyleBackColor = true;
            // 
            // radioCase3
            // 
            this.radioCase3.AutoSize = true;
            this.radioCase3.Location = new System.Drawing.Point(16, 65);
            this.radioCase3.Name = "radioCase3";
            this.radioCase3.Size = new System.Drawing.Size(55, 17);
            this.radioCase3.TabIndex = 2;
            this.radioCase3.Text = "Case3";
            this.radioCase3.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(161, 68);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(199, 12);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(871, 524);
            this.chart.TabIndex = 4;
            this.chart.Text = "chart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 548);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Stochastic climbing game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioCase3;
        private System.Windows.Forms.RadioButton radioCase2;
        private System.Windows.Forms.RadioButton radioCase1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

