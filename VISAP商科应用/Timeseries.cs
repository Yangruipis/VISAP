using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
namespace VISAP商科应用
{
    public partial class Timeseries : Form
    {
        public Timeseries()
        {
            InitializeComponent();
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                texbox_dep.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_depshow_TextChanged(object sender, EventArgs e)
        {

        }

        private void texbox_dep_TextChanged(object sender, EventArgs e)
        {
            textBox_depshow.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, texbox_dep.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder Result = new StringBuilder();
            int ColNum = 0;
            if (Int32.TryParse(texbox_dep.Text, out ColNum))
            {
                string[] NumberSeries = Tabulation.ReadVector(MainForm.MainDT, ColNum - 1).ToArray();
                int length = 0;
                int lag = 4; //自己给定lag的值
                string[][] NumberCombine = new string[lag + 1][];
                BigDecimal[] corr = new BigDecimal[lag];
                BigDecimal sum_Qtest = 0;
                BigDecimal sum_LBtest = 0;
                foreach (string Num in NumberSeries)
                {
                    if (Num != "" && Num != null)
                    {
                        length++;
                    }

                }
                if (length < 8)
                {
                    MessageBox.Show("数据量过少,建议使用灰色预测");
                }
                else
                {
                    for (int i = 0; i < lag + 1; i++)
                    {
                        NumberCombine[i] = new string[length - lag];
                        for (int j = 0; j < length - lag; j++)
                        {
                            NumberCombine[i][j] = NumberSeries[j + lag - i];
                        }
                        try
                        {
                            corr[i - 1] = Stat.Corr(NumberCombine[i], NumberCombine[i - 1]);
                            sum_Qtest += corr[i - 1] * corr[i - 1];
                            sum_LBtest += corr[i - 1] * corr[i - 1] / (BigDecimal)(length - i);
                        }
                        catch (Exception ex) { }
                    }

                    string[] output = Stat.TimeseriesTest(length, sum_Qtest, sum_LBtest, lag, corr);
                    Result.Append(StrManipulation.PadLeftX("时间序列平稳性检验", ' ', 12));
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadRightX("Q检验:", ' ', 12));
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadLeftX("Q      =", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(output[lag]), ' ', 12));
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadLeftX("Prob > Q =", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(output[lag + 1]), ' ', 12));
                    Result.Append("\r\n");

                    Result.Append(StrManipulation.PadRightX("LB检验:", ' ', 12));
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadLeftX("LB      =", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(output[lag + 2]), ' ', 12));
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadLeftX("Prob > LB =", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(output[lag + 3]), ' ', 12));
                    Result.Append("\r\n");


                    if (Convert.ToDouble(output[lag + 1]) <= 0.05 || Convert.ToDouble(output[lag + 3]) <= 0.05)
                    {
                        Result.Append(StrManipulation.PadRightX("在95%的显著性水平下认为序列非白噪声，观测值间显著相关。", ' ', 50));
                        Result.Append("\r\n");
                    }
                    else
                    {
                        Result.Append(StrManipulation.PadRightX("在95%的显著性水平下认为序列为白噪声，观测值间相互独立。", ' ', 50));
                        Result.Append("\r\n");
                    }
                    Result.Append("\r\n");
                    int period = 0;
                    if (Int32.TryParse(textBox_period.Text, out period))
                    {
                        BigDecimal[] AR1 = Stat.AR1(NumberSeries, length, corr, period);
                        BigDecimal[] AR2 = Stat.AR2(NumberSeries, length, corr, period);
                        BigDecimal[] plot_forecast = new BigDecimal[period];
                        if (AR1[period] <= AR2[period])
                        {

                            Result.Append(StrManipulation.PadRightX("最佳预测模型：AR1", ' ', 12));
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadLeftX("序号（预测）", ' ', 12));
                            Result.Append("\t");
                            for (int i = 0; i < period; i++)
                            {
                                Result.Append(StrManipulation.PadLeftX(i.ToString(), ' ', 12));
                                plot_forecast[i] = AR1[i];
                                Result.Append("\t");
                            }
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadLeftX("预测值", ' ', 12));
                            Result.Append("\t");

                            for (int i = 0; i < period; i++)
                            {
                                Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(AR1[i].ToString()), ' ', 12));
                                Result.Append("\t");
                            }
                        }
                        else
                        {
                            Result.Append(StrManipulation.PadRightX("最佳预测模型：AR2", ' ', 12));
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadLeftX("序号（预测）", ' ', 12));
                            Result.Append("\t");
                            for (int i = 0; i < period; i++)
                            {
                                Result.Append(StrManipulation.PadLeftX(i.ToString(), ' ', 12));
                                plot_forecast[i] = AR2[i];
                                Result.Append("\t");
                            }
                            Result.Append("\r\n");
                            Result.Append(StrManipulation.PadLeftX("预测值", ' ', 12));
                            Result.Append("\t");

                            for (int i = 0; i < period; i++)
                            {
                                Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(AR2[i].ToString()), ' ', 12));
                                Result.Append("\t");
                            }
                        }
                        Result.Append("\r\n");
                        Result.Append("\r\n");
                        MainForm.S.richTextBox1.AppendText(Result.ToString());
                        //MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点

                        chart_timeseries.Series.Clear();
                        Series series = new Series("原数据");
                        Series series2 = new Series("预测数据");
                        //ChartArea area = chart_timeseries.ChartAreas.Add("chartArea");
                        //area.AxisX.MajorGrid.LineWidth = 0;
                        series.Color = Color.MidnightBlue;
                        series2.Color = Color.Maroon;
                        if (length <= 50)
                        {
                            series.BorderWidth = 2;
                            series2.BorderWidth = 2;
                        }
                        series.ChartType = SeriesChartType.Line;
                        series2.ChartType = SeriesChartType.Line;
                        for (int i = 0; i < length; i++)
                        {
                            series.Points.AddXY(i + 1, Convert.ToDouble(NumberSeries[i].ToString()));
                        }
                        series2.Points.AddXY(length, Convert.ToDouble(NumberSeries[length - 1].ToString()));
                        for (int i = 0; i < period; i++)
                        {
                            series2.Points.AddXY(i + 1 + length, Convert.ToDouble(plot_forecast[i].ToString()));
                        }
                        chart_timeseries.Series.Add(series);
                        chart_timeseries.Series.Add(series2);
                    }
                    else
                    {
                        MessageBox.Show("请输入预测期数");
                    }
                }
            }
            else
            {
                MessageBox.Show("无此列");
            }  
        }

        private void button_chart_Click(object sender, EventArgs e)
        {
            StringBuilder Result = new StringBuilder();
            int ColNum = 0;
            if (Int32.TryParse(texbox_dep.Text, out ColNum))
            {
                string[] NumberSeries = Tabulation.ReadVector(MainForm.MainDT, ColNum - 1).ToArray();
                int length = 0;
                foreach (string Num in NumberSeries)
                {
                    if (Num != "" && Num != null)
                    {
                        length++;
                    }

                }
                int period = 0;
                if (Int32.TryParse(textBox_period.Text, out period))
                {
                    BigDecimal[] cumsum = new BigDecimal[length];
                    for (int i = 0; i < length; i++)
                    {
                        cumsum[i] = 0;
                        for (int j = 0; j <= i; j++)
                        {
                            cumsum[i] += NumberSeries[j];
                        }
                    }
                    BigDecimal[] C = new BigDecimal[length - 1];
                    for (int i = 0; i < length - 1; i++)
                    {
                        C[i] = 0 - (cumsum[i] + cumsum[i + 1]) / 2;
                    }
                    BigDecimal[,] D = new BigDecimal[length - 1, 1];
                    for (int i = 0; i < length - 1; i++)
                    {
                        D[i, 0] = NumberSeries[i + 1];
                    }
                    BigDecimal[,] E = new BigDecimal[2, length - 1];
                    for (int i = 0; i < length - 1; i++)
                    {
                        E[1, i] = 1;
                        E[0, i] = C[i];
                    }
                    //BigNumber[,] c = MathV.MatTimes(MathV.MatTimes(MathV.MatInv(MathV.MatTimes(E, MathV.MatTrans(E)), 2), E), MathV.MatTrans(D));
                    BigDecimal[,] c = MathV.MatTimes(MathV.MatTimes(MathV.MatInv(MathV.MatTimes(E, MathV.MatTrans(E)), 2), E), D);
                    BigDecimal a = c[0, 0];
                    BigDecimal b = c[1, 0];
                    BigDecimal t = b / a;
                    BigDecimal[] F = new BigDecimal[length + period];
                    for (int i = 0; i < length + period; i++)
                    {

                        BigDecimal e1 = 2.718281828;
                        F[i] = (NumberSeries[0] - t) / Math.Exp((i) * Convert.ToDouble(a.ToString())) + t;
                    }

                    BigDecimal[] G = new BigDecimal[length + period];
                    G[0] = NumberSeries[0];
                    for (int i = 1; i < length + period ; i++)
                    {
                        G[i] = F[i] - F[i - 1];
                    }

                    Result.Append(StrManipulation.PadRightX("灰色预测GM(1,1)模型", ' ', 12));
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadLeftX("序号（所有）", ' ', 12));
                    Result.Append("\t");
                    for (int i = 0; i < period; i++)
                    {
                        Result.Append(StrManipulation.PadLeftX(i.ToString(), ' ', 12));
                        Result.Append("\t");
                    }
                    Result.Append("\r\n");
                    Result.Append(StrManipulation.PadLeftX("预测值", ' ', 12));
                    Result.Append("\t");

                    for (int i = 0; i < period + length; i++)
                    {
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(G[i].ToString()), ' ', 12));
                        Result.Append("\t");
                    }
                    Result.Append("\r\n");
                    Result.Append("\r\n");
                    chart_timeseries.Series.Clear();
                    Series series3 = new Series("原数据(点)");
                    Series series4 = new Series("灰色预测数据");
                    series3.MarkerStyle = MarkerStyle.Circle;
                    series3.MarkerSize = 6;
                    series4.BorderWidth = 2;
                    series3.Color = Color.MidnightBlue;
                    series4.Color = Color.Maroon;
                    series3.ChartType = SeriesChartType.Point;
                    series4.ChartType = SeriesChartType.Line;
                    for (int i = 0; i < length; i++)
                    {
                        series3.Points.AddXY(i + 1, Convert.ToDouble(NumberSeries[i].ToString()));
                    }

                    for (int i = 0; i < period + length; i++)
                    {
                        series4.Points.AddXY(i + 1, Convert.ToDouble(G[i].ToString()));
                    }
                    chart_timeseries.Series.Add(series3);
                    chart_timeseries.Series.Add(series4);

                }
                else
                {
                    MessageBox.Show("请输入预测期数");
                }
            }
            else
            {
                MessageBox.Show("无此列");
            }
        }
    }
}
