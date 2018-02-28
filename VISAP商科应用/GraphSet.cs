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
    public partial class GraphSet : Form
    {
        public GraphSet()
        {
            InitializeComponent();
            int NumOfSeries = EasyGraph.EasyGraphForm.chart_basic.Series.Count;
            string[] Legends = new string[NumOfSeries];
            for (int i = 0; i < NumOfSeries; i++)
            {
                Legends[i] = EasyGraph.EasyGraphForm.chart_basic.Series[i].LegendText;
                if (Legends[i] == "")
                {
                    Legends[i] = "Series" + (i+1).ToString();
                }
            }
                listBox_series.Items.AddRange(Legends);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            int SeriesIndex = listBox_series.SelectedIndex;
            if (SeriesIndex != -1)
            {

                switch (comboBox_type.Text)
                {
                    case "散点图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Point;
                        break;
                    case "折线图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Line;
                        break;
                    case "阶梯线图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.StepLine;
                        break;
                    case "饼图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Pie;
                        break;
                    case "条形图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Bar;
                        break;
                    case "柱形图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Column;
                        break;
                    case "面积图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Area;
                        break;
                    case "棱锥图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Pyramid;
                        break;
                    case "雷达图":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Radar;
                        break;
                }
                EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].Color = label_ColorShow.BackColor;
                EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].BorderWidth = Convert.ToInt32(textBox_LineWidth.Text);
                EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerSize = Convert.ToInt32(textBox_MarkerSize.Text);
                switch (comboBox_MarkerStyle.Text)
                {
                    case "圆形":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle = MarkerStyle.Circle;
                        break;
                    case "十字形":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle = MarkerStyle.Cross;
                        break;
                    case "菱形":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle = MarkerStyle.Diamond;
                        break;
                    case "无":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle = MarkerStyle.None;
                        break;
                    case "正方形":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle = MarkerStyle.Square;
                        break;
                    case "三角形":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle = MarkerStyle.Triangle;
                        break;
                }
                if (textBox_Main.Text != "")
                {
                    EasyGraph.EasyGraphForm.chart_basic.Titles.Clear();
                    EasyGraph.EasyGraphForm.chart_basic.Titles.Add(textBox_Main.Text);
                    //主标题只有一个
                }

                if (textBox_x.Text != "")
                {
                    EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisX.Title = textBox_x.Text;
                }
                if (textBox_y.Text != "")
                {
                    EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisY.Title = textBox_y.Text;
                }
            }
            this.Close();
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            int SeriesIndex = listBox_series.SelectedIndex;
            if (SeriesIndex != -1)
            {
              
                switch (comboBox_type.Text)
                {
                    case "散点图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Point;
                    break;
                case "折线图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Line;
                    break;
                case "阶梯线图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.StepLine;
                    break;
                case "饼图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Pie;
                    break;
                case "条形图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Bar;
                    break;
                case "柱形图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Column;
                    break;
                case "面积图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Area;
                    break;
                case "棱锥图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Pyramid;
                    break;
                case "雷达图":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType = SeriesChartType.Radar;
                    break;
                }
              EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].Color=  label_ColorShow.BackColor;
                EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].BorderWidth=Convert.ToInt32(textBox_LineWidth.Text);
                EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerSize=Convert.ToInt32(textBox_MarkerSize.Text);
                switch (comboBox_MarkerStyle.Text){
                    case "圆形":
                        EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle =MarkerStyle.Circle;
                        break;
                case "十字形":
                     EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle =MarkerStyle.Cross;
                        break;
                case "菱形":
                    EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle =MarkerStyle.Diamond ;
                        break;
                case "无":
                     EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle =MarkerStyle.None ;
                        break;
                case "正方形":
                     EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle =MarkerStyle.Square ;
                        break;
                case "三角形":
                     EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle =MarkerStyle.Triangle;
                        break;
                }
                if (textBox_Main.Text!=""){
                    EasyGraph.EasyGraphForm.chart_basic.Titles.Clear();
                    EasyGraph.EasyGraphForm.chart_basic.Titles.Add(textBox_Main.Text);
                    //主标题只有一个
                }

                if (textBox_x.Text != "")
                {
                    EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisX.Title = textBox_x.Text;
                }
                if (textBox_y.Text != "")
                {
                    EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisY.Title = textBox_y.Text;
                }
            }
        }

        private void listBox_series_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SeriesIndex = listBox_series.SelectedIndex;
            if (SeriesIndex != -1)
            {
                comboBox_type.Text =QuickPlot.FindTypeName(EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].ChartType.ToString());
                //label_ColorShow.BackColor = EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].Color;
                textBox_LineWidth.Text = EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].BorderWidth.ToString();
                textBox_MarkerSize.Text = EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerSize.ToString();
                comboBox_MarkerStyle.Text =QuickPlot.FindMarkerStyle(EasyGraph.EasyGraphForm.chart_basic.Series[SeriesIndex].MarkerStyle.ToString());
                if (EasyGraph.EasyGraphForm.chart_basic.Titles.Count > 0)
                {
                    textBox_Main.Text = EasyGraph.EasyGraphForm.chart_basic.Titles[0].Text;
                    //主标题只有一个
                }
                if (EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisX.Title.Length > 0)
                {
                    textBox_x.Text = EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisX.Title.ToString();
                }
                if (EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisY.Title.Length > 0)
                {
                    textBox_y.Text = EasyGraph.EasyGraphForm.chart_basic.ChartAreas[0].AxisY.Title.ToString();
                }
            }
        }

        private void label_ColorShow_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog ChooseColor = new ColorDialog();
            if (ChooseColor.ShowDialog() == DialogResult.OK)
            {
                label_ColorShow.BackColor = ChooseColor.Color;
                //textBox_ColorShow.Text = ChooseColor.Color.Name;
            }
        }

        private void textBox_LineWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_ColorShow_Click(object sender, EventArgs e)
        {

        }

        
    }
}
