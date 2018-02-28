using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VISAP商科应用
{
    public partial class Report : Form
    {
        public static Report ReportText = null;
        public Report()
        {
            InitializeComponent();
            ReportText = this;
            MainForm.S.ReportIsOn = 1;
            //打开开关，表示Report窗口已经被打开
            richTextBox1.Rtf = MainForm.S.rtb.Rtf;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportV.ImportFile(richTextBox1);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportV.ExportFiles(richTextBox1);
        }

        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }

        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void 绿色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Green;
        }

        private void 自定义颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ChooseColor = new ColorDialog();
            if (ChooseColor.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = ChooseColor.Color;
            }
        }

        private void 粗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportV.ChangeFontStyle(FontStyle.Bold,richTextBox1);
        }

        private void 斜体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportV.ChangeFontStyle(FontStyle.Italic, richTextBox1);
        }

        private void 下划线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportV.ChangeFontStyle(FontStyle.Underline, richTextBox1);
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            //窗体关闭时将内容保存至父窗体
           MainForm.S.rtb.Rtf = richTextBox1.Rtf;
           MainForm.S.ReportIsOn = 0;
            //将开关关闭
        }

        private void 左对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void 右对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void 字体格式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog ChooseFont = new FontDialog();
            if (ChooseFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = ChooseFont.Font;
            }
        }
    }
}
