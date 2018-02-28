using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISAP商科应用
{
    public partial class Summary : Form
    {
        public static StringBuilder Temp = new StringBuilder();
        //Temp用于记录上一次汇总的信息
        public static StringBuilder Result = new StringBuilder();
        //Result用于记录输出结果
        private const string Header = "      变量名\t      样本数\t        均值\t      标准差\t      最小值\t      最大值\r\n";
        public Summary()
        {
            InitializeComponent();
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_Cols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }
        
        private void button_summary_Click(object sender, EventArgs e)
        {
            string ColNums = textBox_Cols.Text;
            char[] separator = { ',' };
            //string是以逗号分隔的
            string[] AllNum = ColNums.Split(separator);
            //按照逗号分割
            Temp.Clear();
            //缓存清空
            Result.Clear();
            //结果记录清空
            Result.Append(Header);
            foreach (string SingleNum in AllNum)
            {
                if (SingleNum != "")
                {
                    Result.Append(Stat.QuickSummary(MainForm.MainDT, Convert.ToInt32(SingleNum) - 1));
                }
            }
            MainForm.S.richTextBox1.AppendText(Result.ToString());
            Temp.Append(Result);
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength,0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_Cols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void textBox_Cols_TextChanged(object sender, EventArgs e)
        {
            textBox_VarNames.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_Cols.Text);
        }

        private void button_ImportReport_Click(object sender, EventArgs e)
        {
            ReportV.InsertText(MainForm.S.rtb, Temp.ToString(), MainForm.S.ReportIsOn);
        }
    }
}
