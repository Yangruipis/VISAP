namespace VISAP商科应用
{
    partial class Binomial
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_SampleSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Cols = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_success = new System.Windows.Forms.TextBox();
            this.listBox_TwoChoices = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Likihood = new System.Windows.Forms.TextBox();
            this.button_Generate = new System.Windows.Forms.Button();
            this.chart_Posterior = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_PosteriorDensity = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Posterior)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "先验信息:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "在这次调研之前，您对这个变量有着怎样的了解?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "您所获得的信息相当于多大的样本量:";
            // 
            // textBox_SampleSize
            // 
            this.textBox_SampleSize.Location = new System.Drawing.Point(16, 112);
            this.textBox_SampleSize.Name = "textBox_SampleSize";
            this.textBox_SampleSize.Size = new System.Drawing.Size(100, 21);
            this.textBox_SampleSize.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "其中有多少样本选择了   ?";
            // 
            // comboBox_Cols
            // 
            this.comboBox_Cols.FormattingEnabled = true;
            this.comboBox_Cols.Location = new System.Drawing.Point(206, 12);
            this.comboBox_Cols.Name = "comboBox_Cols";
            this.comboBox_Cols.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Cols.TabIndex = 5;
            this.comboBox_Cols.TextChanged += new System.EventHandler(this.comboBox_Cols_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "您想要研究的变量名称:";
            // 
            // textBox_success
            // 
            this.textBox_success.Location = new System.Drawing.Point(16, 167);
            this.textBox_success.Name = "textBox_success";
            this.textBox_success.Size = new System.Drawing.Size(100, 21);
            this.textBox_success.TabIndex = 7;
            // 
            // listBox_TwoChoices
            // 
            this.listBox_TwoChoices.FormattingEnabled = true;
            this.listBox_TwoChoices.ItemHeight = 12;
            this.listBox_TwoChoices.Location = new System.Drawing.Point(471, 12);
            this.listBox_TwoChoices.Name = "listBox_TwoChoices";
            this.listBox_TwoChoices.Size = new System.Drawing.Size(263, 88);
            this.listBox_TwoChoices.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "调研信息:";
            // 
            // textBox_Likihood
            // 
            this.textBox_Likihood.Location = new System.Drawing.Point(16, 217);
            this.textBox_Likihood.Multiline = true;
            this.textBox_Likihood.Name = "textBox_Likihood";
            this.textBox_Likihood.Size = new System.Drawing.Size(311, 109);
            this.textBox_Likihood.TabIndex = 10;
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(26, 333);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(122, 23);
            this.button_Generate.TabIndex = 11;
            this.button_Generate.Text = "生成后验分析结果";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // chart_Posterior
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Posterior.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Posterior.Legends.Add(legend1);
            this.chart_Posterior.Location = new System.Drawing.Point(349, 113);
            this.chart_Posterior.Name = "chart_Posterior";
            this.chart_Posterior.Size = new System.Drawing.Size(385, 243);
            this.chart_Posterior.TabIndex = 12;
            this.chart_Posterior.Text = "chart1";
            // 
            // button_PosteriorDensity
            // 
            this.button_PosteriorDensity.Location = new System.Drawing.Point(163, 333);
            this.button_PosteriorDensity.Name = "button_PosteriorDensity";
            this.button_PosteriorDensity.Size = new System.Drawing.Size(122, 23);
            this.button_PosteriorDensity.TabIndex = 13;
            this.button_PosteriorDensity.Text = "查看后验分布";
            this.button_PosteriorDensity.UseVisualStyleBackColor = true;
            this.button_PosteriorDensity.Click += new System.EventHandler(this.button_PosteriorDensity_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(417, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "选项:";
            // 
            // Binomial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 373);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_PosteriorDensity);
            this.Controls.Add(this.chart_Posterior);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.textBox_Likihood);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox_TwoChoices);
            this.Controls.Add(this.textBox_success);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Cols);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_SampleSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Binomial";
            this.Text = "Binomial";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Posterior)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_SampleSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Cols;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_success;
        private System.Windows.Forms.ListBox listBox_TwoChoices;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Likihood;
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Posterior;
        private System.Windows.Forms.Button button_PosteriorDensity;
        private System.Windows.Forms.Label label7;
    }
}