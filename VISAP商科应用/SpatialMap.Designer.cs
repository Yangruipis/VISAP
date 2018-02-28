namespace VISAP商科应用
{
    partial class SpatialMap
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_map = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.texbox_province = new System.Windows.Forms.TextBox();
            this.textBox_variable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_boundary = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_theme = new System.Windows.Forms.ComboBox();
            this.textBox_show1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_show2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineWidth = 0;
            chartArea1.AxisX.MajorTickMark.Size = 0F;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorGrid.LineWidth = 0;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorTickMark.LineWidth = 0;
            chartArea1.AxisX.MinorTickMark.Size = 0F;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineWidth = 0;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.BorderWidth = 0;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 88F;
            chartArea1.InnerPlotPosition.Width = 88.26493F;
            chartArea1.InnerPlotPosition.X = 9.66083F;
            chartArea1.InnerPlotPosition.Y = 3.35106F;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, -2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart1.Size = new System.Drawing.Size(585, 422);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button_map
            // 
            this.button_map.Location = new System.Drawing.Point(597, 230);
            this.button_map.Name = "button_map";
            this.button_map.Size = new System.Drawing.Size(186, 37);
            this.button_map.TabIndex = 1;
            this.button_map.Text = "开始作图";
            this.button_map.UseVisualStyleBackColor = true;
            this.button_map.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(593, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "省份所在列:";
            // 
            // texbox_province
            // 
            this.texbox_province.Location = new System.Drawing.Point(713, 37);
            this.texbox_province.Name = "texbox_province";
            this.texbox_province.Size = new System.Drawing.Size(70, 21);
            this.texbox_province.TabIndex = 26;
            this.texbox_province.TextChanged += new System.EventHandler(this.texbox_province_TextChanged);
            // 
            // textBox_variable
            // 
            this.textBox_variable.Location = new System.Drawing.Point(713, 101);
            this.textBox_variable.Name = "textBox_variable";
            this.textBox_variable.Size = new System.Drawing.Size(70, 21);
            this.textBox_variable.TabIndex = 26;
            this.textBox_variable.TextChanged += new System.EventHandler(this.textBox_variable_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(593, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "指标所在列:";
            // 
            // comboBox_boundary
            // 
            this.comboBox_boundary.FormattingEnabled = true;
            this.comboBox_boundary.Items.AddRange(new object[] {
            "无边界",
            "黑色",
            "白色"});
            this.comboBox_boundary.Location = new System.Drawing.Point(713, 167);
            this.comboBox_boundary.Name = "comboBox_boundary";
            this.comboBox_boundary.Size = new System.Drawing.Size(70, 20);
            this.comboBox_boundary.TabIndex = 28;
            this.comboBox_boundary.Text = "无边界";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(593, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "地图边界线：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(593, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "主题色：";
            // 
            // comboBox_theme
            // 
            this.comboBox_theme.FormattingEnabled = true;
            this.comboBox_theme.Items.AddRange(new object[] {
            "蓝色",
            "绿色",
            "青色",
            "红色"});
            this.comboBox_theme.Location = new System.Drawing.Point(713, 193);
            this.comboBox_theme.Name = "comboBox_theme";
            this.comboBox_theme.Size = new System.Drawing.Size(70, 20);
            this.comboBox_theme.TabIndex = 28;
            this.comboBox_theme.Text = "蓝色";
            // 
            // textBox_show1
            // 
            this.textBox_show1.Location = new System.Drawing.Point(652, 67);
            this.textBox_show1.Name = "textBox_show1";
            this.textBox_show1.ReadOnly = true;
            this.textBox_show1.Size = new System.Drawing.Size(131, 21);
            this.textBox_show1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(593, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "列名:";
            // 
            // textBox_show2
            // 
            this.textBox_show2.Location = new System.Drawing.Point(652, 134);
            this.textBox_show2.Name = "textBox_show2";
            this.textBox_show2.ReadOnly = true;
            this.textBox_show2.Size = new System.Drawing.Size(131, 21);
            this.textBox_show2.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(593, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "列名:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(597, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "导入报告";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // SpatialMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 335);
            this.Controls.Add(this.comboBox_theme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_boundary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_show2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_show1);
            this.Controls.Add(this.textBox_variable);
            this.Controls.Add(this.texbox_province);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_map);
            this.Controls.Add(this.chart1);
            this.Name = "SpatialMap";
            this.Text = "SpatialMap";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button_map;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox texbox_province;
        private System.Windows.Forms.TextBox textBox_variable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_boundary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_theme;
        private System.Windows.Forms.TextBox textBox_show1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_show2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}