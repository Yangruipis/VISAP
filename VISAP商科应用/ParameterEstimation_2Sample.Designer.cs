namespace VISAP商科应用
{
    partial class ParameterEstimation_2Sample
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
            this.button_refresh = new System.Windows.Forms.Button();
            this.textBox_ChosenCols1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_VarNames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_statistics = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Tail = new System.Windows.Forms.ComboBox();
            this.button_Estimation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_ConfidenceLevel = new System.Windows.Forms.ComboBox();
            this.comboBox_proportion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_proportion_value = new System.Windows.Forms.TextBox();
            this.textBox_ChosenCols2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(413, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 25;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // textBox_ChosenCols1
            // 
            this.textBox_ChosenCols1.Location = new System.Drawing.Point(86, 6);
            this.textBox_ChosenCols1.Name = "textBox_ChosenCols1";
            this.textBox_ChosenCols1.Size = new System.Drawing.Size(102, 21);
            this.textBox_ChosenCols1.TabIndex = 24;
            this.textBox_ChosenCols1.TextChanged += new System.EventHandler(this.textBox_ChosenCols1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "变量名：";
            // 
            // textBox_VarNames
            // 
            this.textBox_VarNames.Location = new System.Drawing.Point(86, 47);
            this.textBox_VarNames.Multiline = true;
            this.textBox_VarNames.Name = "textBox_VarNames";
            this.textBox_VarNames.ReadOnly = true;
            this.textBox_VarNames.Size = new System.Drawing.Size(299, 91);
            this.textBox_VarNames.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "列数一：";
            // 
            // comboBox_statistics
            // 
            this.comboBox_statistics.FormattingEnabled = true;
            this.comboBox_statistics.Items.AddRange(new object[] {
            "均值差",
            "比例差",
            "方差比"});
            this.comboBox_statistics.Location = new System.Drawing.Point(413, 76);
            this.comboBox_statistics.Name = "comboBox_statistics";
            this.comboBox_statistics.Size = new System.Drawing.Size(121, 20);
            this.comboBox_statistics.TabIndex = 29;
            this.comboBox_statistics.Text = "均值差";
            this.comboBox_statistics.SelectedIndexChanged += new System.EventHandler(this.comboBox_statistics_SelectedIndexChanged);
            this.comboBox_statistics.TextChanged += new System.EventHandler(this.comboBox_statistics_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(410, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "待估计的统计量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(410, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "单/双尾：";
            // 
            // comboBox_Tail
            // 
            this.comboBox_Tail.FormattingEnabled = true;
            this.comboBox_Tail.Items.AddRange(new object[] {
            "双尾",
            "单尾"});
            this.comboBox_Tail.Location = new System.Drawing.Point(413, 138);
            this.comboBox_Tail.Name = "comboBox_Tail";
            this.comboBox_Tail.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Tail.TabIndex = 31;
            this.comboBox_Tail.Text = "双尾";
            // 
            // button_Estimation
            // 
            this.button_Estimation.Location = new System.Drawing.Point(86, 194);
            this.button_Estimation.Name = "button_Estimation";
            this.button_Estimation.Size = new System.Drawing.Size(299, 85);
            this.button_Estimation.TabIndex = 33;
            this.button_Estimation.Text = "开始估计";
            this.button_Estimation.UseVisualStyleBackColor = true;
            this.button_Estimation.Click += new System.EventHandler(this.button_Estimation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(410, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "置信度：";
            // 
            // comboBox_ConfidenceLevel
            // 
            this.comboBox_ConfidenceLevel.FormattingEnabled = true;
            this.comboBox_ConfidenceLevel.Items.AddRange(new object[] {
            "0.95",
            "0.99",
            "0.90"});
            this.comboBox_ConfidenceLevel.Location = new System.Drawing.Point(413, 205);
            this.comboBox_ConfidenceLevel.Name = "comboBox_ConfidenceLevel";
            this.comboBox_ConfidenceLevel.Size = new System.Drawing.Size(121, 20);
            this.comboBox_ConfidenceLevel.TabIndex = 34;
            this.comboBox_ConfidenceLevel.Text = "0.95";
            // 
            // comboBox_proportion
            // 
            this.comboBox_proportion.FormattingEnabled = true;
            this.comboBox_proportion.Items.AddRange(new object[] {
            ">=",
            ">",
            "=",
            "<",
            "<="});
            this.comboBox_proportion.Location = new System.Drawing.Point(413, 261);
            this.comboBox_proportion.Name = "comboBox_proportion";
            this.comboBox_proportion.Size = new System.Drawing.Size(41, 20);
            this.comboBox_proportion.TabIndex = 36;
            this.comboBox_proportion.Text = "=";
            this.comboBox_proportion.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(410, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "比例条件：";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_proportion_value
            // 
            this.textBox_proportion_value.Location = new System.Drawing.Point(460, 260);
            this.textBox_proportion_value.Name = "textBox_proportion_value";
            this.textBox_proportion_value.Size = new System.Drawing.Size(74, 21);
            this.textBox_proportion_value.TabIndex = 37;
            this.textBox_proportion_value.Text = "0";
            this.textBox_proportion_value.Visible = false;
            // 
            // textBox_ChosenCols2
            // 
            this.textBox_ChosenCols2.Location = new System.Drawing.Point(283, 6);
            this.textBox_ChosenCols2.Name = "textBox_ChosenCols2";
            this.textBox_ChosenCols2.Size = new System.Drawing.Size(102, 21);
            this.textBox_ChosenCols2.TabIndex = 24;
            this.textBox_ChosenCols2.TextChanged += new System.EventHandler(this.textBox_ChosenCols2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(206, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "列数二：";
            // 
            // ParameterEstimation_2Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 291);
            this.Controls.Add(this.textBox_proportion_value);
            this.Controls.Add(this.comboBox_proportion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_ConfidenceLevel);
            this.Controls.Add(this.button_Estimation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Tail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_statistics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_VarNames);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.textBox_ChosenCols2);
            this.Controls.Add(this.textBox_ChosenCols1);
            this.Name = "ParameterEstimation_2Sample";
            this.Text = "双样本参数估计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.TextBox textBox_ChosenCols1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_VarNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_statistics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Tail;
        private System.Windows.Forms.Button button_Estimation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_ConfidenceLevel;
        private System.Windows.Forms.ComboBox comboBox_proportion;
        private System.Windows.Forms.TextBox textBox_proportion_value;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ChosenCols2;
        private System.Windows.Forms.Label label7;
    }
}