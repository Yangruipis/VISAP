namespace VISAP商科应用
{
    partial class HypothesisTesting
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
            this.comboBox_Cols = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Statistics = new System.Windows.Forms.ComboBox();
            this.comboBox_Operation = new System.Windows.Forms.ComboBox();
            this.textBox_NullHypothesis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Alternative = new System.Windows.Forms.Label();
            this.comboBox_Tail = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Significance = new System.Windows.Forms.ComboBox();
            this.button_StartTesting = new System.Windows.Forms.Button();
            this.button_ImportReport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_proportion = new System.Windows.Forms.ComboBox();
            this.textBox_comapre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_Cols
            // 
            this.comboBox_Cols.FormattingEnabled = true;
            this.comboBox_Cols.Location = new System.Drawing.Point(115, 12);
            this.comboBox_Cols.Name = "comboBox_Cols";
            this.comboBox_Cols.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Cols.TabIndex = 1;
            this.comboBox_Cols.SelectedIndexChanged += new System.EventHandler(this.comboBox_Cols_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "待检验变量:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "原假设:";
            // 
            // comboBox_Statistics
            // 
            this.comboBox_Statistics.FormattingEnabled = true;
            this.comboBox_Statistics.Items.AddRange(new object[] {
            "均值",
            "比率",
            "方差"});
            this.comboBox_Statistics.Location = new System.Drawing.Point(115, 43);
            this.comboBox_Statistics.Name = "comboBox_Statistics";
            this.comboBox_Statistics.Size = new System.Drawing.Size(77, 20);
            this.comboBox_Statistics.TabIndex = 4;
            this.comboBox_Statistics.Text = "均值";
            this.comboBox_Statistics.SelectedIndexChanged += new System.EventHandler(this.comboBox_Statistics_SelectedIndexChanged);
            this.comboBox_Statistics.TextChanged += new System.EventHandler(this.comboBox_Statistics_TextChanged);
            // 
            // comboBox_Operation
            // 
            this.comboBox_Operation.FormattingEnabled = true;
            this.comboBox_Operation.Items.AddRange(new object[] {
            "=",
            ">=",
            "<="});
            this.comboBox_Operation.Location = new System.Drawing.Point(212, 43);
            this.comboBox_Operation.Name = "comboBox_Operation";
            this.comboBox_Operation.Size = new System.Drawing.Size(77, 20);
            this.comboBox_Operation.TabIndex = 5;
            this.comboBox_Operation.Text = "=";
            this.comboBox_Operation.TextChanged += new System.EventHandler(this.comboBox_Operation_TextChanged);
            // 
            // textBox_NullHypothesis
            // 
            this.textBox_NullHypothesis.Location = new System.Drawing.Point(309, 42);
            this.textBox_NullHypothesis.Name = "textBox_NullHypothesis";
            this.textBox_NullHypothesis.Size = new System.Drawing.Size(100, 21);
            this.textBox_NullHypothesis.TabIndex = 6;
            this.textBox_NullHypothesis.Text = "0";
            this.textBox_NullHypothesis.TextChanged += new System.EventHandler(this.textBox_NullHypothesis_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "备择假设:";
            // 
            // label_Alternative
            // 
            this.label_Alternative.AutoSize = true;
            this.label_Alternative.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Alternative.Location = new System.Drawing.Point(112, 73);
            this.label_Alternative.Name = "label_Alternative";
            this.label_Alternative.Size = new System.Drawing.Size(72, 16);
            this.label_Alternative.TabIndex = 8;
            this.label_Alternative.Text = "均值 = 0";
            this.label_Alternative.Click += new System.EventHandler(this.label_Alternative_Click);
            // 
            // comboBox_Tail
            // 
            this.comboBox_Tail.FormattingEnabled = true;
            this.comboBox_Tail.Items.AddRange(new object[] {
            "双侧",
            "左单侧",
            "右单侧"});
            this.comboBox_Tail.Location = new System.Drawing.Point(115, 103);
            this.comboBox_Tail.Name = "comboBox_Tail";
            this.comboBox_Tail.Size = new System.Drawing.Size(77, 20);
            this.comboBox_Tail.TabIndex = 9;
            this.comboBox_Tail.Text = "双侧";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "单侧/双侧:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "显著性水平:";
            // 
            // comboBox_Significance
            // 
            this.comboBox_Significance.FormattingEnabled = true;
            this.comboBox_Significance.Items.AddRange(new object[] {
            "0.05",
            "0.1",
            "0.001"});
            this.comboBox_Significance.Location = new System.Drawing.Point(115, 126);
            this.comboBox_Significance.Name = "comboBox_Significance";
            this.comboBox_Significance.Size = new System.Drawing.Size(77, 20);
            this.comboBox_Significance.TabIndex = 12;
            this.comboBox_Significance.Text = "0.05";
            // 
            // button_StartTesting
            // 
            this.button_StartTesting.Location = new System.Drawing.Point(333, 130);
            this.button_StartTesting.Name = "button_StartTesting";
            this.button_StartTesting.Size = new System.Drawing.Size(75, 23);
            this.button_StartTesting.TabIndex = 13;
            this.button_StartTesting.Text = "开始检验";
            this.button_StartTesting.UseVisualStyleBackColor = true;
            this.button_StartTesting.Click += new System.EventHandler(this.button_StartTesting_Click);
            // 
            // button_ImportReport
            // 
            this.button_ImportReport.Location = new System.Drawing.Point(334, 159);
            this.button_ImportReport.Name = "button_ImportReport";
            this.button_ImportReport.Size = new System.Drawing.Size(75, 23);
            this.button_ImportReport.TabIndex = 14;
            this.button_ImportReport.Text = "导入报告";
            this.button_ImportReport.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "比例条件:";
            this.label4.Visible = false;
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
            this.comboBox_proportion.Location = new System.Drawing.Point(115, 152);
            this.comboBox_proportion.Name = "comboBox_proportion";
            this.comboBox_proportion.Size = new System.Drawing.Size(35, 20);
            this.comboBox_proportion.TabIndex = 12;
            this.comboBox_proportion.Text = "=";
            this.comboBox_proportion.Visible = false;
            // 
            // textBox_comapre
            // 
            this.textBox_comapre.Location = new System.Drawing.Point(156, 151);
            this.textBox_comapre.Name = "textBox_comapre";
            this.textBox_comapre.Size = new System.Drawing.Size(36, 21);
            this.textBox_comapre.TabIndex = 6;
            this.textBox_comapre.Text = "0";
            this.textBox_comapre.Visible = false;
            this.textBox_comapre.TextChanged += new System.EventHandler(this.textBox_NullHypothesis_TextChanged);
            // 
            // HypothesisTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 192);
            this.Controls.Add(this.button_ImportReport);
            this.Controls.Add(this.button_StartTesting);
            this.Controls.Add(this.comboBox_proportion);
            this.Controls.Add(this.comboBox_Significance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Tail);
            this.Controls.Add(this.label_Alternative);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_comapre);
            this.Controls.Add(this.textBox_NullHypothesis);
            this.Controls.Add(this.comboBox_Operation);
            this.Controls.Add(this.comboBox_Statistics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Cols);
            this.Name = "HypothesisTesting";
            this.Text = "HypothesisTesting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Cols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Statistics;
        private System.Windows.Forms.ComboBox comboBox_Operation;
        private System.Windows.Forms.TextBox textBox_NullHypothesis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Alternative;
        private System.Windows.Forms.ComboBox comboBox_Tail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Significance;
        private System.Windows.Forms.Button button_StartTesting;
        private System.Windows.Forms.Button button_ImportReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_proportion;
        private System.Windows.Forms.TextBox textBox_comapre;
    }
}