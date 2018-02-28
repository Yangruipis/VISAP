using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace VISAP商科应用
{
    public class QuickPlot
    {
        public static void QPlot(DataTable dt, Chart chart_basic, int xCol, int yCol,string type, string Legend = "",bool IsXLabel = false)
        {
            //如果xCol = -1，则认为x轴没有数值
            //yCol必须存在
            Series series = new Series();
            series.BorderWidth = 3;
            series.MarkerSize = 6;
            series.MarkerStyle = MarkerStyle.Circle;
            if (Legend != ""){
                series.LegendText = Legend;
            }
            switch (type)
            {
                case "散点图":
                    series.ChartType = SeriesChartType.Point;
                    break;
                case "折线图":
                    series.ChartType = SeriesChartType.Line;
                    break;
                case "阶梯线图":
                    series.ChartType = SeriesChartType.StepLine;
                    break;
                case "饼图":
                    series.ChartType = SeriesChartType.Pie;
                    break;
                case "条形图":
                    series.MarkerStyle = MarkerStyle.None;
                    series.ChartType = SeriesChartType.Bar;
                    break;
                case "柱形图":
                    series.MarkerStyle = MarkerStyle.None;
                    series.ChartType = SeriesChartType.Column;
                    break;
                case "面积图":
                    series.MarkerStyle = MarkerStyle.None;
                    series.ChartType = SeriesChartType.Area;
                    break;
                case "棱锥图":
                    series.ChartType = SeriesChartType.Pyramid;
                    break;
                case "雷达图":
                    series.MarkerStyle = MarkerStyle.None;
                    series.ChartType = SeriesChartType.Radar;
                    break;
            }
            
            double TempX = 0;
            double TempY = 0;
            //TempX和TempY用于录入数据
            double MaxXValue = 0;
            double MinXValue = 0;
            //MaxXValue和MinXValue用于找出X的最大和最小值，以供调整间隔使用
            int ReadDataCounts = 0;
            //ReadDataCounts用于计数
            int dtRowsCount = dt.Rows.Count;
            string TempXLabel = "";
            for (int i = 0; i < dtRowsCount; i++)
            {
                if (dt.Rows[i][yCol].ToString() != "")
                {
                    if (xCol != -1)
                    {
                        if (IsXLabel == false)
                        {
                            if (double.TryParse(dt.Rows[i][xCol].ToString(), out TempX) && double.TryParse(dt.Rows[i][yCol].ToString(), out TempY))
                            {
                                //先要检测数据是否为double类型
                                series.Points.AddXY(TempX, TempY);
                                if (ReadDataCounts == 0)
                                {
                                    MaxXValue = TempX;
                                    MinXValue = TempX;
                                }
                                else
                                {
                                    if (MaxXValue < TempX)
                                    {
                                        MaxXValue = TempX;
                                    }
                                    if (MinXValue > TempX)
                                    {
                                        MinXValue = TempX;
                                    }
                                }
                                ReadDataCounts++;
                            }
                        }
                        else
                        {
                            //xLabel = true
                            TempXLabel = dt.Rows[i][xCol].ToString().Trim();
                            if (TempXLabel != "")
                            {
                                if (double.TryParse(dt.Rows[i][yCol].ToString(), out TempY))
                                {
                                    //只需要检测y的数据是否为double类型
                                    //x作为标签，视为字符串
                                    series.Points.AddXY(TempXLabel, TempY);
                                    ReadDataCounts++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (double.TryParse(dt.Rows[i][yCol].ToString(), out TempY))
                        {
                            series.Points.AddY(TempY);
                            if (ReadDataCounts == 0)
                            {
                                MaxXValue = TempX;
                                MinXValue = TempX;
                            }
                            else
                            {
                                if (MaxXValue < TempX)
                                {
                                    MaxXValue = TempX;
                                }
                                if (MinXValue > TempX)
                                {
                                    MinXValue = TempX;
                                }
                            }
                            ReadDataCounts++;
                        }
                    }
                }
            }
            if (ReadDataCounts > 0 && xCol != -1 && IsXLabel == false)
            {
                RegulateAll(ref MinXValue,ref MaxXValue, 6);
                chart_basic.Series.Add(series);
                var XAxis = chart_basic.ChartAreas[0].AxisX;
                XAxis.Maximum = MaxXValue;
                XAxis.Minimum = MinXValue;
                XAxis.MajorGrid.Enabled = false;
                var YAxis = chart_basic.ChartAreas[0].AxisY;
                YAxis.MajorGrid.Enabled = false;
                return;
            }
            else if (xCol != -1 && IsXLabel == true)
            {
                chart_basic.Series.Add(series);
                var XAxis = chart_basic.ChartAreas[0].AxisX;
                XAxis.MajorGrid.Enabled = false;
                var YAxis = chart_basic.ChartAreas[0].AxisY;
                YAxis.MajorGrid.Enabled = false;
                return;
            }
            if (xCol == -1)
            {
                chart_basic.Series.Add(series);
                var XAxis = chart_basic.ChartAreas[0].AxisX;
                XAxis.MajorGrid.Enabled = false;
                var YAxis = chart_basic.ChartAreas[0].AxisY;
                YAxis.MajorGrid.Enabled = false;
                return;
            }
        }
        static void RegulateAll(ref double dMin, ref double dMax, int iMaxAxisNum)
        {
            //用于调整X轴间隔
            if (iMaxAxisNum < 1 || dMax < dMin)
                return;

            double dDelta = dMax - dMin;
            if (dDelta < 1.0) //Modify this by your requirement.
            {
                dMax += (1.0 - dDelta) / 2.0;
                dMin -= (1.0 - dDelta) / 2.0;
            }
            dDelta = dMax - dMin;

            int iExp = (int)(Math.Log(dDelta) / Math.Log(10.0)) - 2;
            double dMultiplier = Math.Pow(10, iExp);
            double[] dSolutions = new double[] { 1, 2, 2.5, 5, 10, 20, 25, 50, 100, 200, 250, 500 };
            int i;
            for (i = 0; i < dSolutions.Length; i++)
            {
                double dMultiCal = dMultiplier * dSolutions[i];
                if (((int)(dDelta / dMultiCal) + 1) <= iMaxAxisNum)
                {
                    break;
                }
            }

            double dInterval = dMultiplier * dSolutions[i];

            double dStartPoint = ((int)Math.Ceiling(dMin / dInterval) - 1) * dInterval;
            int iAxisIndex;
            double dEndPoint = 0;
            for (iAxisIndex = 0; ; iAxisIndex++)
            {
                if (dStartPoint + dInterval * iAxisIndex > dMax)
                {
                    dEndPoint = dStartPoint + dInterval * Convert.ToDouble(iAxisIndex);
                    break;
                }
            }
            dMin = dStartPoint;
            dMax = dEndPoint;
            return;
        }
        public static string FindTypeName(string OriginName){
            switch (OriginName)
            {
                case "Point":
                    return "散点图";
                case "Line":
                    return "折线图";
                case "StepLine":
                    return "阶梯线图";
                case "Pie":
                    return "饼图";
                case "Bar":
                    return "条形图";
                case "Column":
                    return "柱形图";
                case "Area":
                    return "面积图";
                case "Pyramid":
                    return "棱锥图";
                case "Radar":
                    return "雷达图";
            }
            return OriginName;
        }
        public static string FindMarkerStyle(string OriginStyle)
        {
            switch (OriginStyle)
            {
                case "Circle":
                    return "圆形";
                case "Cross":
                    return "十字形";
                case "Diamond":
                    return "菱形";
                case "None":
                    return "无";
                case "Square":
                    return "正方形";
                case "Triangle":
                    return "三角形";
            }
            return OriginStyle;
        }
    }
}
