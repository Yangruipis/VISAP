namespace VISAP商科应用
{
    partial class BetaPosterior
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
            this.chart_PosteriorDensity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_Percentiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_NewSampleSize = new System.Windows.Forms.TextBox();
            this.textBox_success = new System.Windows.Forms.TextBox();
            this.button_Percentile = new System.Windows.Forms.Button();
            this.button_predict = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PosteriorDensity)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_PosteriorDensity
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_PosteriorDensity.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_PosteriorDensity.Legends.Add(legend1);
            this.chart_PosteriorDensity.Location = new System.Drawing.Point(410, 12);
            this.chart_PosteriorDensity.Name = "chart_PosteriorDensity";
            this.chart_PosteriorDensity.Size = new System.Drawing.Size(525, 339);
            this.chart_PosteriorDensity.TabIndex = 0;
            this.chart_PosteriorDensity.Text = "chart1";
            // 
            // textBox_Percentiles
            // 
            this.textBox_Percentiles.Location = new System.Drawing.Point(178, 13);
            this.textBox_Percentiles.Name = "textBox_Percentiles";
            this.textBox_Percentiles.Size = new System.Drawing.Size(148, 21);
            this.textBox_Percentiles.TabIndex = 1;
            this.textBox_Percentiles.Text = "0.05,0.95";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "分位数(用逗号分隔):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "预测:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "输入您想要预测的新样本数:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "输入回答  的次数(用逗号分隔):";
            // 
            // textBox_NewSampleSize
            // 
            this.textBox_NewSampleSize.Location = new System.Drawing.Point(226, 97);
            this.textBox_NewSampleSize.Name = "textBox_NewSampleSize";
            this.textBox_NewSampleSize.Size = new System.Drawing.Size(100, 21);
            this.textBox_NewSampleSize.TabIndex = 6;
            // 
            // textBox_success
            // 
            this.textBox_success.Location = new System.Drawing.Point(15, 152);
            this.textBox_success.Name = "textBox_success";
            this.textBox_success.Size = new System.Drawing.Size(311, 21);
            this.textBox_success.TabIndex = 7;
            // 
            // button_Percentile
            // 
            this.button_Percentile.Location = new System.Drawing.Point(251, 40);
            this.button_Percentile.Name = "button_Percentile";
            this.button_Percentile.Size = new System.Drawing.Size(75, 23);
            this.button_Percentile.TabIndex = 8;
            this.button_Percentile.Text = "分位数报告";
            this.button_Percentile.UseVisualStyleBackColor = true;
            this.button_Percentile.Click += new System.EventHandler(this.button_Percentile_Click);
            // 
            // button_predict
            // 
            this.button_predict.Location = new System.Drawing.Point(251, 179);
            this.button_predict.Name = "button_predict";
            this.button_predict.Size = new System.Drawing.Size(75, 23);
            this.button_predict.TabIndex = 9;
            this.button_predict.Text = "预测报告";
            this.button_predict.UseVisualStyleBackColor = true;
            this.button_predict.Click += new System.EventHandler(this.button_predict_Click);
            // 
            // BetaPosterior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 363);
            this.Controls.Add(this.button_predict);
            this.Controls.Add(this.button_Percentile);
            this.Controls.Add(this.textBox_success);
            this.Controls.Add(this.textBox_NewSampleSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Percentiles);
            this.Controls.Add(this.chart_PosteriorDensity);
            this.Name = "BetaPosterior";
            this.Text = "BetaPosterior";
            ((System.ComponentModel.ISupportInitialize)(this.chart_PosteriorDensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PosteriorDensity;
        private System.Windows.Forms.TextBox textBox_Percentiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_NewSampleSize;
        private System.Windows.Forms.TextBox textBox_success;
        private System.Windows.Forms.Button button_Percentile;
        private System.Windows.Forms.Button button_predict;
    }
}