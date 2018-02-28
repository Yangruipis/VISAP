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
    public partial class Multinomial : Form
    {
        public static string[] Classification;
        public static int[] CountTimes;
        StringBuilder Result = new StringBuilder();
        public static List<int> Alphas = new List<int>();
        //Alphas是狄里克利函数的一系列参数
        public Multinomial()
        {
            InitializeComponent();
            button_PosteriorDensity.Enabled = false;
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_Cols);
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
                        listBox_MultiChoices.Items.Clear();
                        listBox_MultiChoices.Items.AddRange(Classification);
                    textBox_Times.Clear();    
                    for (int i = 0; i < len; i++)
                        {
                            textBox_Times.AppendText("0\r\n");
                        }
                            CountTimes = Tabulation.LikilihoodCount(Classification, MainForm.MainDT, ColNum);
                            StringBuilder OutPut = new StringBuilder();
                            for (int i = 0; i < len; i++)
                            {
                                OutPut.Append(Classification[i]);
                                OutPut.Append("\t");
                                OutPut.Append(CountTimes[i].ToString());
                                OutPut.Append("\r\n");
                            }
                            textBox_Likihood.Clear();
                            textBox_Likihood.AppendText(OutPut.ToString());
                }
            }
        }

        private void textBox_Times_TextChanged(object sender, EventArgs e)
        {
            string[] Str = textBox_Times.Text.Replace("\r", "").Split('\n');
            int sum = 0;
            int Temp = 0;
            foreach (string EachStr in Str)
            {
                if (Int32.TryParse(EachStr, out Temp))
                {
                    sum += Temp;
                }
            }
            label_SampleSize.Text = "您的先验信息相当于"+sum.ToString()+ "个样本";
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            Result.Clear();
            string[] Str = textBox_Times.Text.Replace("\r", "").Split('\n');
            List<int> Nums = new List<int>();
            int Temp = 0;
            foreach (string EachStr in Str)
            {
                if (Int32.TryParse(EachStr, out Temp))
                {
                    Nums.Add(Temp);
                }
            }
            int ClassLen = Classification.Length;
            int CountTimesLen = CountTimes.Length;
            if (Stat.DirichletAlphas(Nums,ClassLen, ref Alphas))
            {
                if (ClassLen != 0 && CountTimesLen != 0)
                {
                    Result.Append("先验分布: ");
                    Result.Append("Dirichlet(");
                    for (int i = 0; i < ClassLen; i++)
                    {
                        Result.Append(Alphas[i].ToString());
                        if (i < ClassLen - 1)
                        {
                            Result.Append(", ");
                        }
                    }
                    Result.Append(")\r\n");
                    Stat.ConjugateDirichlet(ref Alphas, CountTimes);
                    Result.Append("似然函数: ");
                    Result.Append("Binomial(");
                    double p =0;
                    double sum = CountTimes.Sum();
                    Result.Append(sum.ToString());
                    Result.Append(", ");
                    for (int i = 0; i < ClassLen; i++)
                    {
                        p= ((double)CountTimes[i]) / sum;
                        Result.Append(MathV.NumberPolish(p.ToString()).Trim());
                        if (i < ClassLen - 1)
                        {
                            Result.Append(", ");
                        }
                    }
                    Result.Append(")\r\n");
                    Result.Append("Dirichlet(");
                    for (int i = 0; i < ClassLen; i++)
                    {
                        Result.Append(Alphas[i].ToString());
                        if (i < ClassLen - 1)
                        {
                            Result.Append(", ");
                        }
                    }
                    Result.Append(")\r\n");
                    Result.Append("后验分布等效样本量: ");
                    Result.Append((Alphas.Sum() - Alphas.Count).ToString());
                    Result.Append("\r\n");
                    MainForm.S.richTextBox1.AppendText(Result.ToString());
                    MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
                    MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
                    MainForm.S.richTextBox1.ScrollToCaret();
                    button_PosteriorDensity.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("输入次数缺失！");
            }
        }

        private void button_PosteriorDensity_Click(object sender, EventArgs e)
        {
            DirichletPosterior DirPostForm = new DirichletPosterior();
            DirPostForm.Show();
        }
    }
}
