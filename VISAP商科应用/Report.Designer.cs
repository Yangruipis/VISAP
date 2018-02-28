namespace VISAP商科应用
{
    partial class Report
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.蓝色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.红色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绿色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.斜体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下划线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.排版ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对齐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左对齐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.居中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右对齐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体格式ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.排版ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem.Text = "导入";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "导出";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.字体ToolStripMenuItem,
            this.字体格式ToolStripMenuItem,
            this.字体格式ToolStripMenuItem1});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 字体ToolStripMenuItem
            // 
            this.字体ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.蓝色ToolStripMenuItem,
            this.红色ToolStripMenuItem,
            this.绿色ToolStripMenuItem,
            this.自定义颜色ToolStripMenuItem});
            this.字体ToolStripMenuItem.Name = "字体ToolStripMenuItem";
            this.字体ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.字体ToolStripMenuItem.Text = "字体颜色";
            // 
            // 蓝色ToolStripMenuItem
            // 
            this.蓝色ToolStripMenuItem.Name = "蓝色ToolStripMenuItem";
            this.蓝色ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.蓝色ToolStripMenuItem.Text = "蓝色";
            this.蓝色ToolStripMenuItem.Click += new System.EventHandler(this.蓝色ToolStripMenuItem_Click);
            // 
            // 红色ToolStripMenuItem
            // 
            this.红色ToolStripMenuItem.Name = "红色ToolStripMenuItem";
            this.红色ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.红色ToolStripMenuItem.Text = "红色";
            this.红色ToolStripMenuItem.Click += new System.EventHandler(this.红色ToolStripMenuItem_Click);
            // 
            // 绿色ToolStripMenuItem
            // 
            this.绿色ToolStripMenuItem.Name = "绿色ToolStripMenuItem";
            this.绿色ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.绿色ToolStripMenuItem.Text = "绿色";
            this.绿色ToolStripMenuItem.Click += new System.EventHandler(this.绿色ToolStripMenuItem_Click);
            // 
            // 自定义颜色ToolStripMenuItem
            // 
            this.自定义颜色ToolStripMenuItem.Name = "自定义颜色ToolStripMenuItem";
            this.自定义颜色ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.自定义颜色ToolStripMenuItem.Text = "自定义颜色";
            this.自定义颜色ToolStripMenuItem.Click += new System.EventHandler(this.自定义颜色ToolStripMenuItem_Click);
            // 
            // 字体格式ToolStripMenuItem
            // 
            this.字体格式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粗体ToolStripMenuItem,
            this.斜体ToolStripMenuItem,
            this.下划线ToolStripMenuItem});
            this.字体格式ToolStripMenuItem.Name = "字体格式ToolStripMenuItem";
            this.字体格式ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.字体格式ToolStripMenuItem.Text = "字体样式";
            // 
            // 粗体ToolStripMenuItem
            // 
            this.粗体ToolStripMenuItem.Name = "粗体ToolStripMenuItem";
            this.粗体ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.粗体ToolStripMenuItem.Text = "粗体";
            this.粗体ToolStripMenuItem.Click += new System.EventHandler(this.粗体ToolStripMenuItem_Click);
            // 
            // 斜体ToolStripMenuItem
            // 
            this.斜体ToolStripMenuItem.Name = "斜体ToolStripMenuItem";
            this.斜体ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.斜体ToolStripMenuItem.Text = "斜体";
            this.斜体ToolStripMenuItem.Click += new System.EventHandler(this.斜体ToolStripMenuItem_Click);
            // 
            // 下划线ToolStripMenuItem
            // 
            this.下划线ToolStripMenuItem.Name = "下划线ToolStripMenuItem";
            this.下划线ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.下划线ToolStripMenuItem.Text = "下划线";
            this.下划线ToolStripMenuItem.Click += new System.EventHandler(this.下划线ToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(639, 520);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // 排版ToolStripMenuItem
            // 
            this.排版ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.对齐ToolStripMenuItem});
            this.排版ToolStripMenuItem.Name = "排版ToolStripMenuItem";
            this.排版ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.排版ToolStripMenuItem.Text = "排版";
            // 
            // 对齐ToolStripMenuItem
            // 
            this.对齐ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.左对齐ToolStripMenuItem,
            this.居中ToolStripMenuItem,
            this.右对齐ToolStripMenuItem});
            this.对齐ToolStripMenuItem.Name = "对齐ToolStripMenuItem";
            this.对齐ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.对齐ToolStripMenuItem.Text = "对齐";
            // 
            // 左对齐ToolStripMenuItem
            // 
            this.左对齐ToolStripMenuItem.Name = "左对齐ToolStripMenuItem";
            this.左对齐ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.左对齐ToolStripMenuItem.Text = "左对齐";
            this.左对齐ToolStripMenuItem.Click += new System.EventHandler(this.左对齐ToolStripMenuItem_Click);
            // 
            // 居中ToolStripMenuItem
            // 
            this.居中ToolStripMenuItem.Name = "居中ToolStripMenuItem";
            this.居中ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.居中ToolStripMenuItem.Text = "居中";
            this.居中ToolStripMenuItem.Click += new System.EventHandler(this.居中ToolStripMenuItem_Click);
            // 
            // 右对齐ToolStripMenuItem
            // 
            this.右对齐ToolStripMenuItem.Name = "右对齐ToolStripMenuItem";
            this.右对齐ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.右对齐ToolStripMenuItem.Text = "右对齐";
            this.右对齐ToolStripMenuItem.Click += new System.EventHandler(this.右对齐ToolStripMenuItem_Click);
            // 
            // 字体格式ToolStripMenuItem1
            // 
            this.字体格式ToolStripMenuItem1.Name = "字体格式ToolStripMenuItem1";
            this.字体格式ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.字体格式ToolStripMenuItem1.Text = "字体自定义";
            this.字体格式ToolStripMenuItem1.Click += new System.EventHandler(this.字体格式ToolStripMenuItem1_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 561);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Report";
            this.Text = "Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Report_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 蓝色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 红色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绿色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义颜色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 斜体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下划线ToolStripMenuItem;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 排版ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对齐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 左对齐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 居中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 右对齐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体格式ToolStripMenuItem1;
    }
}