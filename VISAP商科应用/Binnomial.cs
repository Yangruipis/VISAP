using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VISAP商科应用
{
    public partial class Binomial : Form
    {
        public static string[] Classification;
        public static int [] CountTimes;
        StringBuilder Result = new StringBuilder();
        public Binomial()
        {
            InitializeComponent();
            button_PosteriorDensity.Enabled = false;
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_Cols);
        }

        public static int Alpha = 0;
        public static int Beta = 0;
        private void button_Generate_Click(object sender, EventArgs e)
        {
            Stat.BetaAlphaBeta(Convert.ToInt32(textBox_SampleSize.Text),Convert.ToInt32(textBox_success.Text),ref Alpha,ref Beta);
            if (Classification.Length != 0 && CountTimes.Length != 0)
            {
                Result.Append("先验分布: ");
                Result.Append("Beta(");
                Result.Append(Alpha.ToString());
                Result.Append(", ");
                Result.Append(Beta.ToString());
                Result.Append(")\r\n");
                Stat.ConjugateBeta(ref Alpha, ref Beta, CountTimes[0] + CountTimes[1], CountTimes[0]);
                Series series = new Series();
                series.Points.AddXY(Classification[0], CountTimes[0]);
                series.Points.AddXY(Classification[1], CountTimes[1]);
                series.ChartType = SeriesChartType.Pie;
                chart_Posterior.Series.Clear();
                chart_Posterior.Series.Add(series);
                Result.Append("似然函数: ");
                Result.Append("Binomial(");
                double p =((double)CountTimes[0])/(double)(CountTimes[0] + CountTimes[1]);
                Result.Append(CountTimes[0] + CountTimes[1]);
                Result.Append(", ");
                Result.Append(MathV.NumberPolish(p.ToString()).Trim());
                Result.Append(")\r\n");
                Result.Append("后验分布: ");
                Result.Append("Beta(");
                Result.Append(Alpha.ToString());
                Result.Append(", ");
                Result.Append(Beta.ToString());
                Result.Append(")\r\n");
                Result.Append("后验分布等效样本量: ");
                Result.Append((Alpha + Beta - 2).ToString());
                Result.Append("\r\n");
                MainForm.S.richTextBox1.AppendText(Result.ToString());
                MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
                MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
                MainForm.S.richTextBox1.ScrollToCaret(); 
                button_PosteriorDensity.Enabled = true;
            }
        }

        private void comboBox_Cols_TextChanged(object sender, EventArgs e)
        {
            int ColNum = Tabulation.FindCol(MainForm.MainDT, comboBox_Cols.Text);
            if (ColNum != -1)
            {
                Classification = Tabulation.Classification(MainForm.MainDT, ColNum);
                int len = Classification.Length;
                if (len > 0)
                {
                    if (len > 2)
                    {
                        MessageBox.Show("选项超过两种，请使用多选单选题进行分析！");
                    }
                    else
                    {
                        listBox_TwoChoices.Items.Clear();
                        listBox_TwoChoices.Items.AddRange(Classification);
                        CountTimes = Tabulation.LikilihoodCount(Classification,MainForm.MainDT,ColNum);
                        StringBuilder OutPut = new StringBuilder();
                        for (int i = 0; i < len;i++)
                        {
                            OutPut.Append(Classification[i]);
                            OutPut.Append("\t");
                            OutPut.Append(CountTimes[i].ToString());
                            OutPut.Append("\r\n");
                        }
                        textBox_Likihood.Clear();
                        textBox_Likihood.AppendText(OutPut.ToString());
                        label4.Text = "其中有多少样本选择了\"" + listBox_TwoChoices.Items[0].ToString() + "\"?";
                    }
                }
            }
        }

        private void button_PosteriorDensity_Click(object sender, EventArgs e)
        {
            BetaPosterior BetaForm = new BetaPosterior();
            BetaForm.Show();
        }
    }
}
