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
using System.Drawing.Drawing2D;

namespace VISAP商科应用
{
    public partial class SpatialMap : Form
    {
        public SpatialMap()
        {
            InitializeComponent();
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                texbox_province.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ProvinceNum = 0;
            int VariableNum = 0;
            if (Int32.TryParse(texbox_province.Text, out ProvinceNum))
            {
                if (Int32.TryParse(textBox_variable.Text, out VariableNum))
                {
                    string[] Province_name = Tabulation.ReadVector(MainForm.MainDT, ProvinceNum - 1).ToArray();
                    string[] Variable_data = Tabulation.ReadVector(MainForm.MainDT, VariableNum - 1).ToArray();
                    double[] data1 = new double[31];

                    string[] match = new string[] { "黑","内","新","吉","辽","甘","河北","京","山西","津","陕","夏","青","山东","藏","河南","苏","安","川","湖北","重","上","浙","湖南","江西","云","贵","福","广西","海南","广东" };
                    for (int i = 0; i < 31; i++)
                    {
                        for(int j = 0 ; j <31 ;j++){
                          if(Province_name[j].IndexOf(match[i]) > -1){
                              data1[i] = Convert.ToDouble(Variable_data[j]);

                              break;
                          }
                        }
                    }
                    string str2 = Environment.CurrentDirectory;
                    DataTable dt = new DataTable();
                    DataTable dt_fill = new DataTable();
                    string coor_path = str2 + "\\coordinates_tiny.csv";
                    string coor_fill = str2 + "\\coordinates_tinyfill.csv";
                    char[] separators = new char[1];
                    separators[0] = ',';
                    dt = Tabulation.LoadFromCSVFile(coor_path, separators);
                    dt_fill = Tabulation.LoadFromCSVFile(coor_fill, separators);
                    int[] X_fill = new int[dt_fill.Rows.Count];
                    int[] Y_fill = new int[dt_fill.Rows.Count];
                    int[] Num_count = new int[31]; //31个省的填充坐标点数
                    Num_count[0] = 5436;
                    Num_count[1] = 18313;
                    Num_count[2] = 35839;
                    Num_count[3] = 37966;
                    Num_count[4] = 39530;
                    Num_count[5] = 43696;
                    Num_count[6] = 45647;
                    Num_count[7] = 45814;
                    Num_count[8] = 47410;
                    Num_count[9] = 47531;
                    Num_count[10] = 49571;
                    Num_count[11] = 50103;
                    Num_count[12] = 57224;
                    Num_count[13] = 58756;
                    Num_count[14] = 70210;
                    Num_count[15] = 71816;
                    Num_count[16] = 72785;
                    Num_count[17] = 74121;
                    Num_count[18] = 78660;
                    Num_count[19] = 80410;
                    Num_count[20] = 81181;
                    Num_count[21] = 81229;
                    Num_count[22] = 82155;
                    Num_count[23] = 84079;
                    Num_count[24] = 85602;
                    Num_count[25] = 89021;
                    Num_count[26] = 90616;
                    Num_count[27] = 91701;
                    Num_count[28] = 93791;
                    Num_count[29] = 94079;
                    Num_count[30] = 95620;

                    for (int i = 0; i < dt_fill.Rows.Count; i++)
                    {
                        //读取每个省的填充坐标数据
                        for (int j = 0; j < 31; j++)
                        {
                            if (j == 0)
                            {
                                if (i < Num_count[j])
                                {
                                    X_fill[i] = Convert.ToInt32(dt_fill.Rows[i][0]); // 经度
                                    Y_fill[i] = Convert.ToInt32(dt_fill.Rows[i][1]); //纬度
                                }
                            }
                            else
                            {
                                if (i < Num_count[j] && i >= Num_count[j - 1])
                                {
                                    X_fill[i] = Convert.ToInt32(dt_fill.Rows[i][0]); // 经度
                                    Y_fill[i] = Convert.ToInt32(dt_fill.Rows[i][1]); //纬度
                                    //ID_coordinates[i] = Convert.ToDouble(dt.Rows[i][0]);
                                }
                            }
                        }
                    }
                    //double[] data1 = new double[] {0.589967025780379,2.76640767785393,2.94486656044847,5.18774795087285,9.55568524078571,7.21217446706751,4.81608668665851,5.67326916712699,9.54321203609774,6.27015178543689,0.354135803190215,8.14711495872654,2.47480472823066,3.05263290782758,2.21504588700546,6.70140475318904,6.05666406518314,2.40509705776911,2.60405493113485,1.6725398082315,5.49355137602265,2.82091154095248,9.6588283411846,5.38501889047855,2.50490878854465,0.604765223162727,1.58887244642718,1.17203933984219,2.20719788025169,2.15731627156846,9.43471799430495}; //按照黑龙江 。。。。 的顺序排好的数
                    double[] data = new double[31];
                    data1.CopyTo(data, 0);

                    double[] datarank = MathV.Sort(31, data1);//从小到大排序
                    this.chart1.Series.Clear();
                    int count_class = 4;
                    double[] quan_value = new double[count_class + 1];
                    quan_value[0] = datarank[0];
                    quan_value[1] = datarank[7];
                    quan_value[2] = datarank[15];
                    quan_value[3] = datarank[23];
                    quan_value[4] = datarank[30];
                    for (int i = 0; i < count_class; i++)
                    {
                        Series series = new Series();
                        series.ChartType = SeriesChartType.FastPoint;
                        this.chart1.Series.Add(series);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        Series series = new Series();
                        series.Name = "(" + MathV.round(quan_value[i].ToString(), 2, 0) + "," + MathV.round(quan_value[i + 1].ToString(), 2, 0) + ")";
                        series.ChartType = SeriesChartType.Column;
                        this.chart1.Series.Add(series);
                    }
                    //台湾不能忘
                    Series series_taiwan = new Series();
                    series_taiwan.ChartType = SeriesChartType.FastPoint;   //边界
                    this.chart1.Series.Add(series_taiwan);
                    series_taiwan.MarkerStyle = MarkerStyle.Circle;
                    series_taiwan.MarkerSize = 2;
                    series_taiwan.IsVisibleInLegend = false;
                    series_taiwan.Color = Color.FromArgb(6, 52, 156);
                    if (comboBox_theme.Text == "蓝色")
                    {
                        this.chart1.Series[0].Color = Color.FromArgb(151, 182, 251);
                        this.chart1.Series[1].Color = Color.FromArgb(78, 131, 248);
                        this.chart1.Series[2].Color = Color.FromArgb(9, 71, 219);
                        this.chart1.Series[3].Color = Color.FromArgb(6, 52, 156);
                        this.chart1.Series[4].Color = Color.FromArgb(151, 182, 251);
                        this.chart1.Series[5].Color = Color.FromArgb(78, 131, 248);
                        this.chart1.Series[6].Color = Color.FromArgb(9, 71, 219);
                        this.chart1.Series[7].Color = Color.FromArgb(6, 52, 156);

                        series_taiwan.Color = Color.FromArgb(6, 52, 156);
                    }
                    else if (comboBox_theme.Text == "青色")
                    {
                        this.chart1.Series[0].Color = Color.FromArgb(128, 234, 248);
                        this.chart1.Series[1].Color = Color.FromArgb(34, 217, 242);
                        this.chart1.Series[2].Color = Color.FromArgb(12, 190, 214);
                        this.chart1.Series[3].Color = Color.FromArgb(8, 119, 134);
                        this.chart1.Series[4].Color = Color.FromArgb(128, 234, 248);
                        this.chart1.Series[5].Color = Color.FromArgb(34, 217, 242);
                        this.chart1.Series[6].Color = Color.FromArgb(12, 190, 214);
                        this.chart1.Series[7].Color = Color.FromArgb(8, 119, 134);

                        series_taiwan.Color = Color.FromArgb(8, 119, 134);
                    }
                    else if (comboBox_theme.Text == "绿色")
                    {
                        this.chart1.Series[0].Color = Color.FromArgb(122, 250, 146);
                        this.chart1.Series[1].Color = Color.FromArgb(55, 247, 92);
                        this.chart1.Series[2].Color = Color.FromArgb(9, 221, 49);
                        this.chart1.Series[3].Color = Color.FromArgb(6, 144, 32);
                        this.chart1.Series[4].Color = Color.FromArgb(122, 250, 146);
                        this.chart1.Series[5].Color = Color.FromArgb(55, 247, 92);
                        this.chart1.Series[6].Color = Color.FromArgb(9, 221, 49);
                        this.chart1.Series[7].Color = Color.FromArgb(6, 144, 32);

                        series_taiwan.Color = Color.FromArgb(6, 144, 32);
                    }
                    else if (comboBox_theme.Text == "红色")
                    {
                        this.chart1.Series[0].Color = Color.FromArgb(253, 149, 141);
                        this.chart1.Series[1].Color = Color.FromArgb(251, 73, 59);
                        this.chart1.Series[2].Color = Color.FromArgb(242, 21, 4);
                        this.chart1.Series[3].Color = Color.FromArgb(196, 0, 0);
                        this.chart1.Series[4].Color = Color.FromArgb(253, 149, 141);
                        this.chart1.Series[5].Color = Color.FromArgb(251, 73, 59);
                        this.chart1.Series[6].Color = Color.FromArgb(242, 21, 4);
                        this.chart1.Series[7].Color = Color.FromArgb(196, 0, 0);

                        series_taiwan.Color = Color.FromArgb(196, 0, 0);
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        this.chart1.Series[i].MarkerStyle = MarkerStyle.Circle;
                        this.chart1.Series[i].MarkerSize = 2;
                        this.chart1.Series[i].IsVisibleInLegend = false;
                    }

                    Series series5 = new Series();
                    series5.ChartType = SeriesChartType.FastPoint;   //边界
                    this.chart1.Series.Add(series5);
                    series5.MarkerStyle = MarkerStyle.Square;
                    series5.MarkerSize = 2;
                    series5.IsVisibleInLegend = false;
                    if (comboBox_boundary.Text == "无边界")
                    {

                    }
                    else if (comboBox_boundary.Text == "白色")
                    {
                        series5.Color = Color.White;
                        for (int i = 0; i < dt.Rows.Count - 168; i++)
                        {
                            series5.Points.AddXY(Convert.ToInt32(dt.Rows[i][1]), Convert.ToInt32(dt.Rows[i][2]));
                        }
                    }
                    else
                    {
                        series5.Color = Color.Black;
                        for (int i = 0; i < dt.Rows.Count - 168; i++)
                        {
                            series5.Points.AddXY(Convert.ToInt32(dt.Rows[i][1]), Convert.ToInt32(dt.Rows[i][2]));
                        }
                    }

                    for (int i = 12504; i < 12672; i++)
                    {
                        series_taiwan.Points.AddXY(Convert.ToInt32(dt.Rows[i][1]), Convert.ToInt32(dt.Rows[i][2]));
                    }

                    for (int i = 0; i < 31; i++)
                    {
                        if (data[i] <= quan_value[1])
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < Num_count[i]; j++)
                                {
                                    //MessageBox.Show(X_fill[j].ToString());
                                    this.chart1.Series[0].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                            else
                            {
                                for (int j = Num_count[i - 1]; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[0].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                        }
                        if (data[i] > quan_value[1] && data[i] <= quan_value[2])
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[1].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                            else
                            {
                                for (int j = Num_count[i - 1]; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[1].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                        }
                        if (data[i] > quan_value[2] && data[i] <= quan_value[3])
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[2].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                            else
                            {
                                for (int j = Num_count[i - 1]; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[2].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                        }
                        if (data[i] > quan_value[3])
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[3].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                            else
                            {
                                for (int j = Num_count[i - 1]; j < Num_count[i]; j++)
                                {
                                    this.chart1.Series[3].Points.AddXY(X_fill[j], Y_fill[j]);  //添加对应数据点
                                }
                            }
                        }
                    }
                }
            }



        }

        private void texbox_province_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_show1.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, texbox_province.Text) ;
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox_variable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_show2.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_variable.Text);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
