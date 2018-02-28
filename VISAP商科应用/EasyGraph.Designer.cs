namespace VISAP商科应用
{
    partial class EasyGraph
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.comboBox_x = new System.Windows.Forms.ComboBox();
            this.comboBox_y = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_subset = new System.Windows.Forms.DataGridView();
            this.chart_basic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_add = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.button_import = new System.Windows.Forms.Button();
            this.textBox_ChosenCols = new System.Windows.Forms.TextBox();
            this.label_Column = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Row = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Legend = new System.Windows.Forms.TextBox();
            this.button_ImportReport = new System.Windows.Forms.Button();
            this.checkBox_IsXLabel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_basic)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_x
            // 
            this.comboBox_x.FormattingEnabled = true;
            this.comboBox_x.Location = new System.Drawing.Point(47, 22);
            this.comboBox_x.Name = "comboBox_x";
            this.comboBox_x.Size = new System.Drawing.Size(193, 20);
            this.comboBox_x.TabIndex = 0;
            // 
            // comboBox_y
            // 
            this.comboBox_y.FormattingEnabled = true;
            this.comboBox_y.Location = new System.Drawing.Point(47, 54);
            this.comboBox_y.Name = "comboBox_y";
            this.comboBox_y.Size = new System.Drawing.Size(193, 20);
            this.comboBox_y.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "x:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "y:";
            // 
            // dataGridView_subset
            // 
            this.dataGridView_subset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_subset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_subset.Location = new System.Drawing.Point(16, 195);
            this.dataGridView_subset.Name = "dataGridView_subset";
            this.dataGridView_subset.RowTemplate.Height = 23;
            this.dataGridView_subset.Size = new System.Drawing.Size(224, 305);
            this.dataGridView_subset.TabIndex = 4;
            this.dataGridView_subset.VirtualMode = true;
            this.dataGridView_subset.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_subset_CellClick);
            this.dataGridView_subset.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_subset_CellValueChanged);
            // 
            // chart_basic
            // 
            this.chart_basic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_basic.ChartAreas.Add(chartArea1);
            this.chart_basic.ContextMenuStrip = this.contextMenuStrip1;
            legend1.Name = "Legend1";
            this.chart_basic.Legends.Add(legend1);
            this.chart_basic.Location = new System.Drawing.Point(265, 54);
            this.chart_basic.Name = "chart_basic";
            this.chart_basic.Size = new System.Drawing.Size(651, 496);
            this.chart_basic.TabIndex = 5;
            this.chart_basic.Text = "chart1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.清空ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(265, 17);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 6;
            this.button_add.Text = "添加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(71, 166);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 23;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "图表类型:";
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
            this.comboBox_type.Location = new System.Drawing.Point(99, 103);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(141, 20);
            this.comboBox_type.TabIndex = 21;
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(165, 166);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 23);
            this.button_import.TabIndex = 20;
            this.button_import.Text = "导入数据";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // textBox_ChosenCols
            // 
            this.textBox_ChosenCols.Location = new System.Drawing.Point(16, 134);
            this.textBox_ChosenCols.Name = "textBox_ChosenCols";
            this.textBox_ChosenCols.Size = new System.Drawing.Size(224, 21);
            this.textBox_ChosenCols.TabIndex = 19;
            // 
            // label_Column
            // 
            this.label_Column.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Column.AutoSize = true;
            this.label_Column.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Column.Location = new System.Drawing.Point(195, 517);
            this.label_Column.Name = "label_Column";
            this.label_Column.Size = new System.Drawing.Size(19, 20);
            this.label_Column.TabIndex = 27;
            this.label_Column.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(140, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "列数";
            // 
            // label_Row
            // 
            this.label_Row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Row.AutoSize = true;
            this.label_Row.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Row.Location = new System.Drawing.Point(67, 517);
            this.label_Row.Name = "label_Row";
            this.label_Row.Size = new System.Drawing.Size(19, 20);
            this.label_Row.TabIndex = 25;
            this.label_Row.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "行数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(353, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "标签:";
            // 
            // textBox_Legend
            // 
            this.textBox_Legend.Location = new System.Drawing.Point(414, 17);
            this.textBox_Legend.Name = "textBox_Legend";
            this.textBox_Legend.Size = new System.Drawing.Size(100, 21);
            this.textBox_Legend.TabIndex = 29;
            // 
            // button_ImportReport
            // 
            this.button_ImportReport.Location = new System.Drawing.Point(819, 17);
            this.button_ImportReport.Name = "button_ImportReport";
            this.button_ImportReport.Size = new System.Drawing.Size(75, 23);
            this.button_ImportReport.TabIndex = 30;
            this.button_ImportReport.Text = "导入报告";
            this.button_ImportReport.UseVisualStyleBackColor = true;
            this.button_ImportReport.Click += new System.EventHandler(this.button_ImportReport_Click);
            // 
            // checkBox_IsXLabel
            // 
            this.checkBox_IsXLabel.AutoSize = true;
            this.checkBox_IsXLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_IsXLabel.Location = new System.Drawing.Point(15, 80);
            this.checkBox_IsXLabel.Name = "checkBox_IsXLabel";
            this.checkBox_IsXLabel.Size = new System.Drawing.Size(117, 18);
            this.checkBox_IsXLabel.TabIndex = 32;
            this.checkBox_IsXLabel.Text = "x作为文本标签";
            this.checkBox_IsXLabel.UseVisualStyleBackColor = true;
            // 
            // EasyGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 562);
            this.Controls.Add(this.checkBox_IsXLabel);
            this.Controls.Add(this.button_ImportReport);
            this.Controls.Add(this.textBox_Legend);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_Column);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Row);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.textBox_ChosenCols);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.chart_basic);
            this.Controls.Add(this.dataGridView_subset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_y);
            this.Controls.Add(this.comboBox_x);
            this.Name = "EasyGraph";
            this.Text = "简单图表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_basic)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_x;
        private System.Windows.Forms.ComboBox comboBox_y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_subset;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.TextBox textBox_ChosenCols;
        private System.Windows.Forms.Label label_Column;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_Row;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Legend;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart_basic;
        private System.Windows.Forms.Button button_ImportReport;
        private System.Windows.Forms.CheckBox checkBox_IsXLabel;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
    }
}