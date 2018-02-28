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
    public partial class ANOVA_OneWay : Form
    {
        public ANOVA_OneWay()
        {
            InitializeComponent();
        }

        private void textBox_Cols_TextChanged(object sender, EventArgs e)
        {
            textBox_VarNames.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_Cols.Text);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_Cols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }
        private const string Header = "        对象\t      自由度\t     平方和\t     方差\r\n";
        private void button_Anova_Click(object sender, EventArgs e)
        {
            char[] separator = { ',' };
            string[] AllCols = textBox_Cols.Text.Split(separator);
            int ColNum = 0;
            int Cols_count = 0;
            int Cols_length = AllCols.Length;       //变量数
            int[] Row_length = new int[Cols_length];//每个变量长度
            int Total_length = 0;                   //总单元数
            string[][] Numbers = new string[Cols_length][];
            foreach (string EachCol in AllCols)
            {
                if (Int32.TryParse(EachCol, out ColNum))
                {
                    Row_length[Cols_count] = 0;
                    Numbers[Cols_count]= Tabulation.ReadVector(MainForm.MainDT, ColNum - 1).ToArray();
                    foreach (string value in Numbers[Cols_count])
                    {
                        if (value != "" && value != null)
                        {
                            Row_length[Cols_count]++;
                        }
                    }
                    Total_length += Row_length[Cols_count];
                    //MessageBox.Show("变量" + Cols_count.ToString());
                    //MessageBox.Show("变量长度" + Total_length.ToString());
                }
                Cols_count++;
            }
            //计算开始
            BigDecimal sum_all = 0;
            BigDecimal[] sum_col = new BigDecimal[Cols_length];
            BigDecimal[] xjbar = new BigDecimal[Cols_length];
            for (int i = 0; i < Cols_length; i++)
            {
                sum_col[i] = 0;
                foreach (BigDecimal value in Numbers[i])
                {
                    sum_all = sum_all + value;
                    sum_col[i] = sum_col[i] + value;
                    xjbar[i] = sum_col[i] / Row_length[i];
                }
            }
            BigDecimal xbarbar = sum_all / Total_length;

            BigDecimal SST = 0;
            BigDecimal SSA = 0;
            BigDecimal SSW = 0;
            BigDecimal[] SSW_list = new BigDecimal[Cols_length];
            for (int i = 0; i < Cols_length; i++)
            {   
                SSW_list[i]= 0;
                foreach (BigDecimal var in Numbers[i])
                {
                    SST = SST + (var - xbarbar) * (var - xbarbar);
                    SSW_list[i] = SSW_list[i] + (var - xjbar[i]) * (var - xjbar[i]);
                }
                SSA = SSA + Row_length[i] * (xjbar[i] - xbarbar) * (xjbar[i] - xbarbar);
                SSW = SSW + SSW_list[i];
            }
            BigDecimal MSA = SSA / (Cols_length - 1);
            BigDecimal MSW = SSW / (Total_length - Cols_length);
            BigDecimal MST = SST / (Total_length - 1);
            BigDecimal Fvalue = MSA / MSW;
            BigDecimal Pvalue = Stat.FDIST(Convert.ToDouble(Fvalue.ToString()), Cols_length - 1, Total_length - 1);

            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("方差分析"),' ',12));
            MainForm.S.richTextBox1.AppendText("\r\n");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("变量名："),' ',12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(textBox_VarNames.Text);
            MainForm.S.richTextBox1.AppendText("\r\n");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("F值："),' ',12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(Fvalue.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\r\n");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("P值："), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(Pvalue.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\r\n");


            MainForm.S.richTextBox1.AppendText(Header);
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("组内"), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish((Cols_length -1).ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(SSA.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(MSA.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\r\n");

            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("组间"), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish((Total_length - Cols_length).ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(SSW.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(MSW.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\r\n");

            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("总"), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish((Total_length -1).ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(SST.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\t");
            MainForm.S.richTextBox1.AppendText(StrManipulation.PadLeftX(MathV.NumberPolish(MST.ToString()), ' ', 12));
            MainForm.S.richTextBox1.AppendText("\r\n");

        }
    }
}
