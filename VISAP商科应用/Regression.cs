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
    public partial class Regression : Form
    {
        public Regression()
        {
            InitializeComponent();
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_y);
        }

        private void button_Regression_Click(object sender, EventArgs e)
        {
            string ColNums = textBox_Cols.Text;
            char[] separator = { ',' };
            //string是以逗号分隔的
            string[] AllNum = ColNums.Split(separator);
            //按照逗号分割
            List<int> Cols = new List<int>();
            foreach (string SingleNum in AllNum)
            {
                if (SingleNum != "")
                {
                    Cols.Add(Convert.ToInt32(SingleNum) - 1); 
                }
            }

            int[] AllColNums = Cols.ToArray();
            //MessageBox.Show(AllColNums[0].ToString());
            //MessageBox.Show(AllColNums[1].ToString());
            int yCol = Tabulation.FindCol(MainForm.MainDT,comboBox_y.Text);
            List<List<string>> data = new List<List<string>>();
            int RowsCount = MainForm.MainDT.Rows.Count;
            int  InputColsCount = AllColNums.Length;
            //计算总共要录入的列数
            int count = 0;
            //计算实际录入数据数
            List<string>Ydata = new List<string>();
            for (int i = 0; i < InputColsCount; i++)
            {
                data.Add(new List<string>());
            }
                for (int i = 0; i < RowsCount; i++)
                {
                    if (Tabulation.IdentifyNARow(MainForm.MainDT, i, AllColNums))
                    {
                        //确认该行无空格
                        if (MainForm.MainDT.Rows[i][yCol].ToString().Trim() != "")
                        {
                            Ydata.Add(MainForm.MainDT.Rows[i][yCol].ToString().Trim());
                            for (int j = 0; j < InputColsCount; j++)
                            {
                                data[j].Add(MainForm.MainDT.Rows[i][AllColNums[j]].ToString()); //此处队长有bug，已改正
                                
                            }
                            count++;
                        }
                    }
                }
            
            if (count > 2)
            {
                BigDecimal[,] IndependentVariables = new BigDecimal[count, InputColsCount + 1];
                StringBuilder Result = new StringBuilder();
                if (count <= InputColsCount + 1)
                {
                    Result.Append("样本量过少，无法估计");
                }
                else
                {
                    //第一列全是1
                    for (int i = 0; i < count; i++)
                    {
                        IndependentVariables[i, 0] = 1;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < InputColsCount; j++)
                        {
                            //录入时，BigDecimal数组列数要+1，因为第一列全是1
                            IndependentVariables[i, j + 1] = data[j][i];
                        }
                    }
                    //MathV.ArrayPrint(IndependentVariables);
                    BigDecimal[,] DependentVariable = new BigDecimal[count, 1];
                    for (int i = 0; i < count; i++)
                    {
                        DependentVariable[i, 0] = Ydata[i];
                    }
                    int len12 = IndependentVariables.GetLength(1);//列数
                    BigDecimal[,] b1 = MathV.MatTrans(IndependentVariables);
                    BigDecimal[,] b2 = MathV.MatTimes(b1, IndependentVariables);
                    try
                    {
                        BigDecimal[,] b3 = MathV.MatInv(b2, len12);
                        if (b3 != null)
                        {
                            BigDecimal[,] bhat = Stat.MultiRegBeta(b1, b3, IndependentVariables, DependentVariable);
                            BigDecimal[,] value_beta = Stat.MultiRegP(b3, bhat, IndependentVariables, DependentVariable);
                            string[] RandF = Stat.MultiRegR(bhat, IndependentVariables, DependentVariable).Split(separator);
                            //MathV.ArrayPrint(bhat);
                            Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("拟合R^2："), ' ', 12));
                            Result.Append(MathV.NumberPolish(RandF[0]));
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("调整后R^2："), ' ', 12));
                            Result.Append(MathV.NumberPolish(RandF[1]));
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("回归F值："), ' ', 12));
                            Result.Append(MathV.NumberPolish(RandF[2]));
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("回归P值："), ' ', 12));
                            Result.Append(MathV.NumberPolish(Stat.FINV(Convert.ToDouble(RandF[2]),count - InputColsCount - 1,InputColsCount).ToString()));
                            Result.Append("\r\n \r\n");
                            Result.Append(comboBox_y.Text + " = ");

                            int ColumnNumberCount = 0;


                            foreach (BigDecimal EachNum in bhat)
                            {
                                if (ColumnNumberCount == 0)
                                {
                                    Result.Append(MathV.NumberPolish(EachNum.ToString()));
                                    Result.Append(" + ");
                                }
                                else if (ColumnNumberCount == InputColsCount)
                                {
                                    Result.Append(MathV.NumberPolish(EachNum.ToString()));
                                    Result.Append(" ");
                                    Result.Append(MainForm.MainDT.Columns[AllColNums[ColumnNumberCount - 1]].ColumnName);
                                }
                                else
                                {
                                    Result.Append(MathV.NumberPolish(EachNum.ToString()));
                                    Result.Append(MainForm.MainDT.Columns[AllColNums[ColumnNumberCount - 1]].ColumnName);
                                    Result.Append(" + ");
                                }
                                ColumnNumberCount++;
                            }
                            Result.Append("\r\n检验P值:   ");

                            for (int i = 0; i < InputColsCount + 1; i++)
                            {
                                Result.Append(MathV.NumberPolish(value_beta[i, 0].ToString()));
                                Result.Append("  \t");
                            }
                            Result.Append("\r\n检验t值:   ");
                            for (int i = 0; i < InputColsCount + 1; i++)
                            {
                                Result.Append(MathV.NumberPolish(value_beta[i, 1].ToString()));
                                Result.Append("  \t");
                            }
                            Result.Append("\r\n \r\n");
                        }
                        else
                        {
                            Result.Append("矩阵不可逆，回归方程无解");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("存在重复自变量");
                    }
                    

                }
                MainForm.S.richTextBox1.AppendText(Result.ToString());
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
             string ColNums = textBox_Cols.Text;
            char[] separator = { ',' };
            //string是以逗号分隔的
            string[] AllNum = ColNums.Split(separator);
            //按照逗号分割
            List<int> Cols = new List<int>();
            foreach (string SingleNum in AllNum)
            {
                if (SingleNum != "")
                {
                    Cols.Add(Convert.ToInt32(SingleNum) - 1); 
                }
            }

            int[] AllColNums = Cols.ToArray();
            //MessageBox.Show(AllColNums[0].ToString());
            //MessageBox.Show(AllColNums[1].ToString());
            int yCol = Tabulation.FindCol(MainForm.MainDT,comboBox_y.Text);
            List<List<string>> data = new List<List<string>>();
            int RowsCount = MainForm.MainDT.Rows.Count;
            int  InputColsCount = AllColNums.Length;
            //计算总共要录入的列数
            int count = 0;
            //计算实际录入数据数
            List<string>Ydata = new List<string>();
            for (int i = 0; i < InputColsCount; i++)
            {
                data.Add(new List<string>());
            }
                for (int i = 0; i < RowsCount; i++)
                {
                    if (Tabulation.IdentifyNARow(MainForm.MainDT, i, AllColNums))
                    {
                        //确认该行无空格
                        if (MainForm.MainDT.Rows[i][yCol].ToString().Trim() != "")
                        {
                            Ydata.Add(MainForm.MainDT.Rows[i][yCol].ToString().Trim());
                            for (int j = 0; j < InputColsCount; j++)
                            {
                                data[j].Add(MainForm.MainDT.Rows[i][AllColNums[j]].ToString()); //此处队长有bug，已改正
                                
                            }
                            count++;
                        }
                    }
                }

                if (count > 2)
                {
                    BigDecimal[,] IndependentVariables = new BigDecimal[count, InputColsCount + 1];
                    StringBuilder Result = new StringBuilder();
                    if (count <= InputColsCount + 1)
                    {
                        Result.Append("样本量过少，无法估计");
                    }
                    else
                    {
                        //第一列全是1
                        for (int i = 0; i < count; i++)
                        {
                            IndependentVariables[i, 0] = 1;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < InputColsCount; j++)
                            {
                                //录入时，BigDecimal数组列数要+1，因为第一列全是1
                                IndependentVariables[i, j + 1] = data[j][i];
                            }
                        }
                        //MathV.ArrayPrint(IndependentVariables);
                        BigDecimal[,] DependentVariable = new BigDecimal[count, 1];
                        for (int i = 0; i < count; i++)
                        {
                            DependentVariable[i, 0] = Ydata[i];
                        }
                        int len12 = IndependentVariables.GetLength(1);//列数
                        BigDecimal[,] b1 = MathV.MatTrans(IndependentVariables);
                        BigDecimal[,] b2 = MathV.MatTimes(b1, IndependentVariables);
                        BigDecimal[,] b3 = MathV.MatInv(b2, len12);
                        if (b3 != null)
                        {
                            BigDecimal[,] bhat = Stat.MultiRegBeta(b1, b3, IndependentVariables, DependentVariable);
                            BigDecimal[,] value_beta = Stat.MultiRegP(b3, bhat, IndependentVariables, DependentVariable);
                            string[] RandF = Stat.MultiRegR(bhat, IndependentVariables, DependentVariable).Split(separator);


                            //回归诊断开始
                            //#初步判断 ： 根据R^2 adjR^2 Fvalue tvalue 
                            Result.Append("1.初步诊断  \r\n");
                            if ((BigDecimal)RandF[1] < 0.70)
                            {
                                Result.Append("  调整后R^2较小，可能存在遗漏变量\r\n");
                            }

                            if ((BigDecimal)RandF[0] - (BigDecimal)RandF[1] > 0.1)
                            {
                                Result.Append("  调整后R^2与R^2差值较大，可能存在冗余变量\r\n");
                            }
                            if (Stat.FDIST(Convert.ToDouble(RandF[2]),InputColsCount,count - 1) > 0.01)
                            {
                                Result.Append("  模型拟合情况不好，建议更改解释变量\r\n");
                            }
                            else
                            {
                                Result.Append("  模型拟合情况较好\r\n");
                            }

                            int count_nonsignifi = 0;
                            for(int i = 0 ;i < InputColsCount + 1;i++)
                            {
                                if (i == 0)
                                {
                                    if (value_beta[i,0]> 0.05)
                                    {
                                        Result.Append("    常数项在95%置信水平下不显著\r\n");
                                        count_nonsignifi++;
                                    }
                                }
                                else
                                {
                                    if (value_beta[i,0] > 0.05)
                                    {
                                        Result.Append("    变量" + (i + 1).ToString() + "在95%置信水平下不显著\r\n");
                                        count_nonsignifi++;
                                    }
                                }
                            
                            }

                            if ((BigDecimal)RandF[0] > 0.7 && count_nonsignifi > ((InputColsCount+1) / 2))
                            {
                                Result.Append("  高拟合优度伴随着大量非显著解释变量，存在多重共线性\r\n");
                            }
                            Result.Append("\r\n");

                            //#遗漏变量 : 拉姆齐检验
                            Result.Append("2.模型设定偏误检验（拉姆齐检验）\r\n");
                            BigDecimal[,] Y_hat = new BigDecimal[count,1];
                            Y_hat = MathV.MatTimes(IndependentVariables, bhat);
                            BigDecimal[,] Ramsey_indep = new BigDecimal[count, InputColsCount + 3];
                            for (int i = 0; i < count; i++)
                            {
                                for (int j = 0; j < InputColsCount + 3; j++)
                                {
                                    if (j < InputColsCount + 1)
                                    {
                                        Ramsey_indep[i, j] = IndependentVariables[i, j];
                                    }
                                    else if (j == InputColsCount + 1)
                                    {
                                        Ramsey_indep[i, j] = Y_hat[i, 0] * Y_hat[i, 0];
                                    }
                                    else
                                    {
                                        Ramsey_indep[i, j] = Y_hat[i, 0] * Y_hat[i, 0] * Y_hat[i, 0];
                                    }
                                }
                            }
                            BigDecimal[,] b1_ramsey = MathV.MatTrans(Ramsey_indep);
                            BigDecimal[,] b2_ramsey = MathV.MatTimes(b1_ramsey, Ramsey_indep);
                            BigDecimal[,] b3_ramsey = MathV.MatInv(b2_ramsey,InputColsCount +3 );
                            if (b3_ramsey != null && count > InputColsCount + 3)
                            {
                                BigDecimal[,] bhat_ramsey = Stat.MultiRegBeta(b1_ramsey, b3_ramsey, Ramsey_indep, DependentVariable);
                                string[] RandF_ramsey = Stat.MultiRegR(bhat_ramsey, Ramsey_indep, DependentVariable).Split(separator);
                                double R2_ramsey = Convert.ToDouble(RandF_ramsey[0]);
                                double F_ramsey = (R2_ramsey -  Convert.ToDouble(RandF[0])) * (count - InputColsCount - 2) / ((1 - R2_ramsey) * 2 );
                                double F_P_ramsey = Stat.FDIST(Convert.ToDouble(RandF_ramsey[2]), 2, count - InputColsCount - 2);
                                if (F_P_ramsey <= 0.001)
                                {
                                    Result.Append("  模型在99.9%的置信水平下认为存在偏误\r\n");
                                }
                                else
                                {
                                    Result.Append("  模型设定在99.9%的置信水平下认为无偏误\r\n");
                                }

                            }
                            else
                            {
                                Result.Append("  ！样本量过少，无法进行拉姆齐检验\r\n");
                            }
                            Result.Append("");

                            Result.Append("\r\n3.多重共线性检验：方差膨胀因子(VIF)\r\n");

                            //#多重共线性检验：方差膨胀因子（VIF）
                            int count_vif;
                            if (InputColsCount == 1)
                            {
                                Result.Append("  ！一个自变量无法进行方差膨胀因子检验\r\n");
                            }
                            else
                            {
                                for (int i = 0; i < InputColsCount; i++)
                                {
                                    BigDecimal[,] Vif_dep = new BigDecimal[count, 1];
                                    BigDecimal[,] Vif_indep = new BigDecimal[count, InputColsCount ];
                                    for (int j = 0; j < count; j++)
                                    {
                                        count_vif = 0;
                                        Vif_dep[j, 0] = IndependentVariables[j, i + 1];
                                        for (int k = 0; k < InputColsCount + 1; k++)
                                        {
                                            if (k != i + 1)
                                            {
                                                Vif_indep[j, count_vif] = IndependentVariables[j, k];
                                                count_vif++;
                                            }
                                        }
                                    }
                                    //MathV.ArrayPrint(Vif_indep);
                                    // MathV.ArrayPrint(Vif_dep);
                                    BigDecimal[,] b1_vif = MathV.MatTrans(Vif_indep);
                                    BigDecimal[,] b2_vif = MathV.MatTimes(b1_vif, Vif_indep);
                                    BigDecimal[,] b3_vif = MathV.MatInv(b2_vif, InputColsCount );
                                    if (b3_vif != null)
                                    {
                                        BigDecimal[,] bhat_vif = Stat.MultiRegBeta(b1_vif, b3_vif, Vif_indep, Vif_dep);
                                        string[] RandF_vif = Stat.MultiRegR(bhat_vif, Vif_indep, Vif_dep).Split(separator);
                                        //MessageBox.Show(RandF_vif[0]);
                                        BigDecimal VIF = 1 / (1 - Convert.ToDouble(RandF_vif[0]));
                                        if (VIF <= 10)
                                        {
                                            Result.Append("  变量" + (i + 1).ToString() + "在模型中共线性较弱，可以保留\r\n");
                                        }
                                        else if (VIF > 10 && VIF < 100)
                                        {
                                            Result.Append("  变量" + (i + 1).ToString() + "在模型中共线性较强，建议剔除\r\n");
                                        }
                                        else
                                        {
                                            Result.Append("  变量" + (i + 1).ToString() + "在模型中共线性极强，强烈建议剔除\r\n");
                                        }
                                    }
                                }
                            }
                            
                            //#异方差 : White 检验
                            Result.Append("\r\n4.异方差检验：怀特检验与LM统计量\r\n");
                            //Y_hat2 与 u^hat2
                            BigDecimal[,] u_hat2 = new BigDecimal[count,1];
                            BigDecimal[,] u_hat = new BigDecimal[count,1];
                            BigDecimal[,] Y_hat2 = new BigDecimal[count, 1];
                            BigDecimal[,] White_indep = new BigDecimal[count, 3];
                            BigDecimal[,] White_dep = new BigDecimal[count, 1];
                            for (int i = 0; i < count; i++)
                            {
                                u_hat2[i, 0] = (DependentVariable[i, 0] - Y_hat[i, 0]) * (DependentVariable[i, 0] - Y_hat[i, 0]);
                                Y_hat2[i, 0] = Y_hat[i, 0] * Y_hat[i, 0];
                                u_hat[i, 0] = (DependentVariable[i, 0] - Y_hat[i, 0]);
                                White_indep[i, 0] = 1;
                                White_indep[i, 1] = Y_hat[i, 0];
                                White_indep[i, 2] = Y_hat2[i, 0];
                                White_dep[i, 0] = u_hat2[i,0];
                            }
                            BigDecimal[,] b1_white = MathV.MatTrans(White_indep);
                            BigDecimal[,] b2_white = MathV.MatTimes(b1_white, White_indep);
                            BigDecimal[,] b3_white = MathV.MatInv(b2_white, 3);
                            if (b3_white != null)
                            {
                                BigDecimal[,] bhat_white = Stat.MultiRegBeta(b1_white, b3_white, White_indep, White_dep);
                                string[] RandF_white = Stat.MultiRegR(bhat_white, White_indep, White_dep).Split(separator);
                                BigDecimal LM_white = count * Convert.ToDouble(RandF_white[0]);
                                //MessageBox.Show(LM_white.ToString());
                                BigDecimal P_white =1 - Stat.chi2(Convert.ToDouble(LM_white.ToString()), 2);
                                //MessageBox.Show(P_white2.ToString());
                                Result.Append("  LM统计量  \t");
                                Result.Append("           =\t");
                                Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(LM_white.ToString()), ' ', 12));
                                Result.Append("\r\n");
                                Result.Append("  LM > chi(2)\t");
                                Result.Append("           =\t");
                                Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(P_white.ToString()), ' ', 12));
                                Result.Append("\r\n");
                                if (P_white > 0.05)
                                {
                                    Result.Append("  在95%的置信度上认为样本同方差\r\n \r\n");
                                }
                                else
                                {
                                    Result.Append("  在95%的置信度上认为样本异方差\r\n");
                                    Result.Append("  解决方法：变量取对数回归,结果如下：\r\n");
                                    BigDecimal[,] ln_indep = new BigDecimal[count, InputColsCount + 1];
                                    BigDecimal[,] ln_dep = new BigDecimal[count, 1];
                                    for (int i = 0; i < count; i++)
                                    {
                                        for(int j = 0; j < InputColsCount; j++)
                                        {
                                            ln_indep[i, j + 1] = Math.Log(Convert.ToDouble(IndependentVariables[i, j + 1].ToString()));
                                        }
                                        ln_indep[i, 0] = 1;
                                        ln_dep[i, 0] = Math.Log(Convert.ToDouble(DependentVariable[i, 0].ToString()));
                                    }
                                    BigDecimal[,] b1_ln = MathV.MatTrans(ln_indep);
                                    BigDecimal[,] b2_ln = MathV.MatTimes(b1_ln, ln_indep);
                                    BigDecimal[,] b3_ln = MathV.MatInv(b2, len12);
                                    if (b3_ln != null)
                                    {
                                        BigDecimal[,] bhat_ln = Stat.MultiRegBeta(b1_ln, b3_ln, ln_indep, ln_dep);
                                        BigDecimal[,] value_beta_ln = Stat.MultiRegP(b3_ln, bhat_ln, ln_indep, ln_dep);
                                        string[] RandF_ln = Stat.MultiRegR(bhat_ln, ln_indep, ln_dep).Split(separator);
                                        //MathV.ArrayPrint(bhat);
                                        Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("拟合R^2："), ' ', 12));
                                        Result.Append(MathV.NumberPolish(RandF_ln[0]));
                                        Result.Append("\r\n");
                                        Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("调整后R^2："), ' ', 12));
                                        Result.Append(MathV.NumberPolish(RandF_ln[1]));
                                        Result.Append("\r\n");
                                        Result.Append(StrManipulation.PadRightX(StrManipulation.VariableNamePolish("回归F值："), ' ', 12));
                                        Result.Append(MathV.NumberPolish(RandF_ln[2]));
                                        Result.Append("\r\n");
                                        Result.Append("\r\n");
                                        Result.Append(comboBox_y.Text);
                                        Result.Append(" = ");
                                        int ColumnNumberCount = 0;


                                        foreach (BigDecimal EachNum in bhat_ln)
                                        {
                                            if (ColumnNumberCount == 0)
                                            {
                                                Result.Append(MathV.NumberPolish(EachNum.ToString()));
                                                Result.Append(" + ");
                                            }
                                            else if (ColumnNumberCount == InputColsCount)
                                            {
                                                Result.Append(MathV.NumberPolish(EachNum.ToString()));
                                                Result.Append(" ");
                                                Result.Append(" ln " + MainForm.MainDT.Columns[AllColNums[ColumnNumberCount - 1]].ColumnName);
                                            }
                                            else
                                            {
                                                Result.Append(MathV.NumberPolish(EachNum.ToString()));
                                                Result.Append(" ln " + MainForm.MainDT.Columns[AllColNums[ColumnNumberCount - 1]].ColumnName);
                                                Result.Append(" + ");
                                            }
                                            ColumnNumberCount++;
                                        }
                                        Result.Append("\r\n检验P值:   ");
                                        for (int i = 0; i < InputColsCount + 1; i++)
                                        {
                                            Result.Append(MathV.NumberPolish(value_beta_ln[i, 0].ToString()));
                                            Result.Append("  \t");
                                        }
                                        Result.Append("\r\n检验t值:   ");
                                        for (int i = 0; i < InputColsCount + 1; i++)
                                        {
                                            Result.Append(MathV.NumberPolish(value_beta_ln[i, 1].ToString()));
                                            Result.Append("  \t");
                                        }
                                        Result.Append("\r\n\r\n");
                                    }
                                    else
                                    {
                                        Result.Append("矩阵不可逆，回归方程无解 \r\n");
                                    }
                                }
                            }

                           //#自相关(3阶内） ： 

                            Result.Append("5.自相关检验：拉格朗日乘子(LM) \r\n");
                            BigDecimal[,] u_hat_Auto = new BigDecimal[count - 3, 1];
                            BigDecimal[,] indep_Auto = new BigDecimal[count - 3, InputColsCount + 4];


                            for (int i = 0; i < count - 3; i++)
                            {
                                u_hat_Auto[i, 0] = u_hat[i + 3, 0];
                                for (int j = 0; j < InputColsCount + 1; j++)
                                {
                                    indep_Auto[i, j] = IndependentVariables[i + 3, j]; 
                                }
                                indep_Auto[i, InputColsCount + 1] = u_hat[i + 2, 0];
                                indep_Auto[i, InputColsCount + 2] = u_hat[i + 1, 0];
                                indep_Auto[i, InputColsCount + 3] = u_hat[i, 0];
                            }
                            BigDecimal[,] b1_Auto = MathV.MatTrans(indep_Auto);
                            BigDecimal[,] b2_Auto = MathV.MatTimes(b1_Auto, indep_Auto);
                            BigDecimal[,] b3_Auto = MathV.MatInv(b2_Auto, InputColsCount + 4);
                            if (b3_Auto != null)
                            {
                                BigDecimal[,] bhat_Auto = Stat.MultiRegBeta(b1_Auto, b3_Auto, indep_Auto, u_hat_Auto);
                                string[] RandF_Auto = Stat.MultiRegR(bhat_Auto, indep_Auto, u_hat_Auto).Split(separator);
                                BigDecimal LM_Auto = (count - 3) * Convert.ToDouble(RandF_Auto[0].ToString());
                                BigDecimal P_Auto = 1 - Stat.chi2(Convert.ToDouble(LM_Auto.ToString()), 3);
                                Result.Append("  LM统计量  \t");
                                Result.Append("           =\t");
                                Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(LM_Auto.ToString()), ' ', 12));
                                Result.Append("\r\n");
                                Result.Append("  LM > chi(2)\t");
                                Result.Append("           =\t");
                                Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(P_Auto.ToString()), ' ', 12));
                                Result.Append("\r\n");
                                if (P_Auto <= 0.05)
                                {
                                    Result.Append("  在95%的置信水平下拒绝原假设，认为模型序列存在自相关\r\n \r\n");
                                }
                                else
                                {
                                    Result.Append("  在95%的置信水平下接受原假设，认为模型序列不存在自相关\r\n \r\n");
                                }



                            }
                              



                                MainForm.S.richTextBox1.AppendText(Result.ToString());
                        }
                    }
                }
        }
    }
}
