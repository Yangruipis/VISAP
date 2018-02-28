namespace VISAP商科应用
{
    partial class Timeseries
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
            this.chart_timeseries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_chart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_depshow = new System.Windows.Forms.TextBox();
            this.textBox_period = new System.Windows.Forms.TextBox();
            this.texbox_dep = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_timeseries)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_timeseries
            // 
            chartArea1.CursorY.LineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chart_timeseries.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_timeseries.Legends.Add(legend1);
            this.chart_timeseries.Location = new System.Drawing.Point(12, 12);
            this.chart_timeseries.Name = "chart_timeseries";
            this.chart_timeseries.Size = new System.Drawing.Size(556, 207);
            this.chart_timeseries.TabIndex = 20;
            this.chart_timeseries.Text = "chart1";
            // 
            // button_chart
            // 
            this.button_chart.Location = new System.Drawing.Point(578, 190);
            this.button_chart.Name = "button_chart";
            this.button_chart.Size = new System.Drawing.Size(95, 29);
            this.button_chart.TabIndex = 28;
            this.button_chart.Text = "灰色预测";
            this.button_chart.UseVisualStyleBackColor = true;
            this.button_chart.Click += new System.EventHandler(this.button_chart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(574, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "序列名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(574, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "预测几期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(574, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "序列编号:";
            // 
            // textBox_depshow
            // 
            this.textBox_depshow.Location = new System.Drawing.Point(679, 45);
            this.textBox_depshow.Name = "textBox_depshow";
            this.textBox_depshow.ReadOnly = true;
            this.textBox_depshow.Size = new System.Drawing.Size(98, 21);
            this.textBox_depshow.TabIndex = 23;
            this.textBox_depshow.TextChanged += new System.EventHandler(this.textBox_depshow_TextChanged);
            // 
            // textBox_period
            // 
            this.textBox_period.Location = new System.Drawing.Point(679, 82);
            this.textBox_period.Name = "textBox_period";
            this.textBox_period.Size = new System.Drawing.Size(98, 21);
            this.textBox_period.TabIndex = 21;
            // 
            // texbox_dep
            // 
            this.texbox_dep.Location = new System.Drawing.Point(679, 12);
            this.texbox_dep.Name = "texbox_dep";
            this.texbox_dep.Size = new System.Drawing.Size(98, 21);
            this.texbox_dep.TabIndex = 22;
            this.texbox_dep.TextChanged += new System.EventHandler(this.texbox_dep_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 27;
            this.button1.Text = "时间序列预测";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(679, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 29);
            this.button2.TabIndex = 27;
            this.button2.Text = "导入报告";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(679, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 29);
            this.button3.TabIndex = 27;
            this.button3.Text = "导入报告";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Timeseries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 233);
            this.Controls.Add(this.button_chart);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_depshow);
            this.Controls.Add(this.textBox_period);
            this.Controls.Add(this.texbox_dep);
            this.Controls.Add(this.chart_timeseries);
            this.Name = "Timeseries";
            this.Text = "Timeseries";
            ((System.ComponentModel.ISupportInitialize)(this.chart_timeseries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_timeseries;
        private System.Windows.Forms.Button button_chart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_depshow;
        private System.Windows.Forms.TextBox textBox_period;
        private System.Windows.Forms.TextBox texbox_dep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

    }
}