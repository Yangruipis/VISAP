namespace VISAP商科应用
{
    partial class GraphSet
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
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.listBox_series = new System.Windows.Forms.ListBox();
            this.button_Apply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_LineWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MarkerSize = new System.Windows.Forms.TextBox();
            this.label_ColorShow = new System.Windows.Forms.Label();
            this.label_MarkerStyle = new System.Windows.Forms.Label();
            this.textBox_Main = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_MarkerStyle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "散点图",
            "折线图",
            "阶梯线图",
            "饼图",
            "条形图",
            "柱形图",
            "面积图",
            "棱锥图",
            "雷达图"});
            this.comboBox_type.Location = new System.Drawing.Point(271, 13);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(121, 20);
            this.comboBox_type.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(166, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "图表类型:";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(306, 341);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // listBox_series
            // 
            this.listBox_series.FormattingEnabled = true;
            this.listBox_series.ItemHeight = 12;
            this.listBox_series.Location = new System.Drawing.Point(15, 13);
            this.listBox_series.Name = "listBox_series";
            this.listBox_series.Size = new System.Drawing.Size(120, 148);
            this.listBox_series.TabIndex = 3;
            this.listBox_series.SelectedIndexChanged += new System.EventHandler(this.listBox_series_SelectedIndexChanged);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(306, 312);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 4;
            this.button_Apply.Text = "应用";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(166, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "颜色:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(166, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "线条粗细:";
            // 
            // textBox_LineWidth
            // 
            this.textBox_LineWidth.Location = new System.Drawing.Point(271, 73);
            this.textBox_LineWidth.Name = "textBox_LineWidth";
            this.textBox_LineWidth.Size = new System.Drawing.Size(121, 21);
            this.textBox_LineWidth.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(166, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "数据点大小:";
            // 
            // textBox_MarkerSize
            // 
            this.textBox_MarkerSize.Location = new System.Drawing.Point(271, 103);
            this.textBox_MarkerSize.Name = "textBox_MarkerSize";
            this.textBox_MarkerSize.Size = new System.Drawing.Size(121, 21);
            this.textBox_MarkerSize.TabIndex = 13;
            // 
            // label_ColorShow
            // 
            this.label_ColorShow.AutoSize = true;
            this.label_ColorShow.BackColor = System.Drawing.Color.White;
            this.label_ColorShow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ColorShow.Location = new System.Drawing.Point(271, 43);
            this.label_ColorShow.Name = "label_ColorShow";
            this.label_ColorShow.Size = new System.Drawing.Size(112, 16);
            this.label_ColorShow.TabIndex = 14;
            this.label_ColorShow.Text = "             ";
            this.label_ColorShow.DoubleClick += new System.EventHandler(this.label_ColorShow_DoubleClick);
            // 
            // label_MarkerStyle
            // 
            this.label_MarkerStyle.AutoSize = true;
            this.label_MarkerStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MarkerStyle.Location = new System.Drawing.Point(166, 133);
            this.label_MarkerStyle.Name = "label_MarkerStyle";
            this.label_MarkerStyle.Size = new System.Drawing.Size(96, 16);
            this.label_MarkerStyle.TabIndex = 15;
            this.label_MarkerStyle.Text = "数据点样式:";
            // 
            // textBox_Main
            // 
            this.textBox_Main.Location = new System.Drawing.Point(271, 163);
            this.textBox_Main.Name = "textBox_Main";
            this.textBox_Main.Size = new System.Drawing.Size(121, 21);
            this.textBox_Main.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(165, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "主标题：";
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(271, 224);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(121, 21);
            this.textBox_y.TabIndex = 20;
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(271, 193);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(121, 21);
            this.textBox_x.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(165, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "y轴的标题：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(166, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "x轴的标题：";
            // 
            // comboBox_MarkerStyle
            // 
            this.comboBox_MarkerStyle.FormattingEnabled = true;
            this.comboBox_MarkerStyle.Items.AddRange(new object[] {
            "圆形",
            "十字形",
            "菱形",
            "无",
            "正方形",
            "三角形"});
            this.comboBox_MarkerStyle.Location = new System.Drawing.Point(274, 133);
            this.comboBox_MarkerStyle.Name = "comboBox_MarkerStyle";
            this.comboBox_MarkerStyle.Size = new System.Drawing.Size(121, 20);
            this.comboBox_MarkerStyle.TabIndex = 23;
            // 
            // GraphSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 376);
            this.Controls.Add(this.comboBox_MarkerStyle);
            this.Controls.Add(this.textBox_Main);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_MarkerStyle);
            this.Controls.Add(this.label_ColorShow);
            this.Controls.Add(this.textBox_MarkerSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_LineWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.listBox_series);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_type);
            this.Name = "GraphSet";
            this.Text = "GraphSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ListBox listBox_series;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_LineWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_MarkerSize;
        private System.Windows.Forms.Label label_ColorShow;
        private System.Windows.Forms.Label label_MarkerStyle;
        private System.Windows.Forms.TextBox textBox_Main;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_MarkerStyle;
    }
}