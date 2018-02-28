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
    public partial class BetaPosterior : Form
    {
        int Alpha = 0;
        int Beta = 0;
        double MaxValue = 0;
        public BetaPosterior()
        {
            InitializeComponent();
            label4.Text = "输入回答\"" + Binomial.Classification[0] + "\"的次数(用逗号分隔):";
            Alpha = Binomial.Alpha;
            Beta = Binomial.Beta;
            chart_PosteriorDensity.Series.Clear();
            DrawBeta(Alpha - Binomial.CountTimes[0], Beta - Binomial.CountTimes[1],"先验分布");
            DrawBinomial(Binomial.CountTimes[0] + Binomial.CountTimes[1], Binomial.CountTimes[0], "似然函数");
            DrawBeta(Alpha, Beta, "后验分布");
        }
        private void DrawBeta(int Alpha,int Beta,string Name){
            Series series = new Series(Name);
            series.BorderWidth = 3;
            series.ChartType = SeriesChartType.Spline;
            
            double Temp = 0;
            for (double i = 0.01; i < 1; i = i + 0.05)
            {
                Temp = Stat.BetaPDF(i, Alpha, Beta);
                    if (MaxValue < Temp)
                    {
                        MaxValue = Temp;
                    }
                
                series.Points.AddXY(i,Temp);
            }
            chart_PosteriorDensity.Series.Add(series);
            var XAxis = chart_PosteriorDensity.ChartAreas[0].AxisX;
            XAxis.MajorGrid.Enabled = false;
            var YAxis = chart_PosteriorDensity.ChartAreas[0].AxisY;
            YAxis.MajorGrid.Enabled = false;
            XAxis.Maximum = 1;
            XAxis.Minimum = 0;
            YAxis.Maximum = Math.Ceiling(MaxValue);
        }
        private void DrawBinomial(int n, int y, string Name)
        {
            Series series = new Series(Name);
            series.BorderWidth = 3;
            series.ChartType = SeriesChartType.Spline;
            double MaxValue = 0;
            double Temp = 0;
            for (double i = 0.01; i < 1; i = i + 0.05)
            {
                Temp = n * Stat.BinomialPDF(i,n,y);
                 if (MaxValue < Temp)
                    {
                        MaxValue = Temp;
                    }
                
                series.Points.AddXY(i,Temp );
            }
            chart_PosteriorDensity.Series.Add(series);
            var XAxis = chart_PosteriorDensity.ChartAreas[0].AxisX;
            XAxis.MajorGrid.Enabled = false;
            var YAxis = chart_PosteriorDensity.ChartAreas[0].AxisY;
            YAxis.MajorGrid.Enabled = false;
            XAxis.Maximum = 1;
            XAxis.Minimum = 0;
            YAxis.Maximum = Math.Ceiling(MaxValue);
        }

        private void button_Percentile_Click(object sender, EventArgs e)
        {
            char[] separator = { ',' };
            string[] Percentiles = textBox_Percentiles.Text.Split(separator);
            double Temp = 0;
            StringBuilder Str = new StringBuilder();
            foreach (string EachPer in Percentiles)
            {
                if (double.TryParse(EachPer, out Temp))
                {
                    if (Temp > 0 && Temp < 1)
                    {
                        Str.Append(StrManipulation.PadLeftX(Temp.ToString() + "分位数: ", ' ', 12));
                        Str.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Stat.BetaUa(1 - Temp, Alpha, Beta).ToString()),' ',12));
                        Str.Append("\r\n");
                    }
                }
            }
            MainForm.S.richTextBox1.AppendText(Str.ToString());
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }

        private void button_predict_Click(object sender, EventArgs e)
        {
            char[] separator = { ',' };
            string[] Prediction = textBox_success.Text.Split(separator);
            int Temp = 0;
            int n = Convert.ToInt32(textBox_NewSampleSize.Text); 
            StringBuilder Str = new StringBuilder();
            Str.Append(StrManipulation.PadLeftX("次数",' ',12));
            Str.Append("\t");
            Str.Append(StrManipulation.PadLeftX("预测概率值", ' ', 12));
            Str.Append("\r\n");
            foreach (string EachPred in Prediction)
            {
                if (int.TryParse(EachPred, out Temp))
                {
                    if (Temp >= 0 && Temp <= n)
                    {
                        Str.Append(StrManipulation.PadLeftX(Temp.ToString(), ' ', 12));
                        Str.Append("\t");
                        Str.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Stat.BetaPrediction(Alpha,Beta,n,Temp).ToString()), ' ', 12));
                        Str.Append("\r\n");
                    }
                }
            }
            MainForm.S.richTextBox1.AppendText(Str.ToString());
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }
    }
}
