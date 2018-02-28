namespace VISAP商科应用
{
    partial class Economicdata
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
            this.textBox_choosen = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBox_period = new System.Windows.Forms.ComboBox();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_getdata = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_choosen
            // 
            this.textBox_choosen.Location = new System.Drawing.Point(6, 23);
            this.textBox_choosen.Multiline = true;
            this.textBox_choosen.Name = "textBox_choosen";
            this.textBox_choosen.ReadOnly = true;
            this.textBox_choosen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_choosen.Size = new System.Drawing.Size(132, 423);
            this.textBox_choosen.TabIndex = 14;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 111);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(143, 389);
            this.treeView1.TabIndex = 15;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // comboBox_period
            // 
            this.comboBox_period.FormattingEnabled = true;
            this.comboBox_period.Items.AddRange(new object[] {
            "年度",
            "季度",
            "月度"});
            this.comboBox_period.Location = new System.Drawing.Point(16, 46);
            this.comboBox_period.Name = "comboBox_period";
            this.comboBox_period.Size = new System.Drawing.Size(109, 20);
            this.comboBox_period.TabIndex = 12;
            this.comboBox_period.Text = "年度";
            // 
            // comboBox_area
            // 
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Items.AddRange(new object[] {
            "全国",
            "31省(不含港澳台)",
            "主要城市"});
            this.comboBox_area.Location = new System.Drawing.Point(16, 17);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(109, 20);
            this.comboBox_area.TabIndex = 13;
            this.comboBox_area.Text = "全国";
            this.comboBox_area.TextChanged += new System.EventHandler(this.comboBox_area_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_log);
            this.groupBox1.Location = new System.Drawing.Point(454, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 164);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志文件";
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(6, 17);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(481, 138);
            this.textBox_log.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(454, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(493, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox_choosen);
            this.groupBox2.Location = new System.Drawing.Point(161, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 485);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已选指标";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "清空选项";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_refresh);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.comboBox_area);
            this.groupBox4.Controls.Add(this.comboBox_period);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 99);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "确认想要的数据";
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(16, 72);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(109, 21);
            this.button_refresh.TabIndex = 1;
            this.button_refresh.Text = "初始化";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(470, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 27);
            this.button4.TabIndex = 1;
            this.button4.Text = "打开数据";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button_getdata
            // 
            this.button_getdata.Location = new System.Drawing.Point(329, 362);
            this.button_getdata.Name = "button_getdata";
            this.button_getdata.Size = new System.Drawing.Size(115, 27);
            this.button_getdata.TabIndex = 1;
            this.button_getdata.Text = "获取数据";
            this.button_getdata.UseVisualStyleBackColor = true;
            this.button_getdata.Click += new System.EventHandler(this.button_getdata_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(329, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(618, 295);
            this.dataGridView1.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(329, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "导入主窗口";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Economicdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 508);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_getdata);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "Economicdata";
            this.Text = "宏观经济数据爬取";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_choosen;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox_period;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_getdata;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}