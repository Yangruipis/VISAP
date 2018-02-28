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
    public partial class NaiveBayesian : Form
    {
        public static DataTable dt = new DataTable();
        string[][] Result = new string[5][];
        //Result锯齿数组用于记录训练集获得的结果
        public NaiveBayesian()
        {
            InitializeComponent();
            textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
        }
        bool IdentifyNARow(int RowsNum, int dtColsCount)
        {
            //这个函数用于确认特定行是否有空缺
            for (int i = 0; i < dtColsCount; i++)
            {
                if (dt.Rows[RowsNum][i].ToString().Trim() == "")
                {
                    return false;
                    //false即为有空格
                }
            }
            return true;
            //true为没有空格
        }
        static double FindElement(string SingleStr, string[] StrArray)
        {
            double counts = 0;
            foreach (string EachStr in StrArray)
            {
                if (EachStr == SingleStr)
                {
                    counts++;
                }
            }
            return counts;
        }
        
       
        static string Search(string Record, string[] Str, string[] Probs)
        {
            int Index = Str.ToList().IndexOf(Record);
            if (Index != -1)
            {
                return Probs[Index];
            }
            else
            {
                return "-1";
            }
        }
        string BayesClassification()
        {
            int dtRowsCount = dt.Rows.Count;
            int dtColsCount = dt.Columns.Count;
            StringBuilder ResultText = new StringBuilder();
            string[][] Classification = new string[dtColsCount][];
            List<List<string>> Data= new List<List<string>>();
            for (int j = 0; j < dtColsCount; j++)
            {
                Data.Add(new List<string>());
                //对每列的数据进行定义
                    for (int i = 0; i < dtRowsCount; i++)
                    {
                        //确保录入的行中无空缺
                        if (IdentifyNARow(i,dtColsCount))
                        {
                        //按行读取每列的数据
                        Data[j].Add(dt.Rows[i][j].ToString());
                        }
                    }
            }
            //现在我们获得了一个Data矩阵
            double Temp = 0;
            List<string> AllClassi = new List<string>();
            List<string> EachProbs = new List<string>();
            for (int i = 0; i < dtColsCount; i++)
            {
                ResultText.Append("第");
                ResultText.Append((i + 1).ToString());
                ResultText.Append("项特征内的各个类别:\r\n");
                Classification[i] = Data[i].Distinct().ToArray();
                foreach (string SingleStr in Classification[i])
                {
                    ResultText.Append(SingleStr);
                    ResultText.Append("  ");
                }
                ResultText.Append("\r\n");
                foreach (string SingleStr in Classification[i])
                {
                    ResultText.Append("P(");
                    ResultText.Append(SingleStr);
                    ResultText.Append(") = ");
                    Temp = FindElement(SingleStr, Data[i].ToArray())
                        / Convert.ToDouble(Data[i].Count);
                    ResultText.Append(Temp.ToString());
                    ResultText.Append("\r\n");
                    AllClassi.Add(SingleStr);
                    EachProbs.Add(Temp.ToString());
                }
                ResultText.Append("\r\n");
            }
            double count = 0;
            int TotalTimes = 0;

            //int InterestCol = FindCol(comboBox_Class.Text);
            int InterestCol = Tabulation.FindCol(dt, comboBox_Class.Text);
            int InterestColCount = Data[InterestCol].Count;
           List<string> str = new  List<string>();
           List<string> Probs = new  List<string>();
           string StrAndDis = "";
            for (int j = 0; j < dtColsCount; j++)
            {
                if (j != InterestCol)
                {
                    foreach (string EachStr in Classification[j])
                    {
                        foreach (string EachDis in Classification[InterestCol])
                        {
                            count = 0;
                            for (int i = 0; i < InterestColCount; i++)
                            {
                                if (Data[InterestCol][i].Trim() == EachDis)
                                {
                                    if (Data[j][i].Trim() == EachStr)
                                    {
                                        count++;
                                    }
                                }
                            }
                            StrAndDis = EachStr + "|" + EachDis;
                            ResultText.Append("P(");
                            ResultText.Append(StrAndDis);
                            ResultText.Append(") = ");
                            Temp = count / FindElement(EachDis, Data[InterestCol].ToArray());
                            ResultText.Append(Temp.ToString());
                            ResultText.Append("\r\n");
                            str.Add(StrAndDis);
                            Probs.Add(Temp.ToString());
                            TotalTimes++;
                        }
                    }
                }
            }
            ResultText.Append("所有类别组合数量总计:");
            ResultText.Append(TotalTimes.ToString());
            //以下数组用于记录训练集所获得的结果
            Result[0] = AllClassi.ToArray();
            Result[1] = EachProbs.ToArray();
            Result[2] = str.ToArray();
            Result[3] = Probs.ToArray();
            Result[4] = Classification[InterestCol];

            return ResultText.ToString();
        }

        bool IdentifyForm1NARow(int RowsNum, string[] ColsOfVariables)
        {
            int MainColsCount = MainForm.MainDT.Columns.Count;
            int Temp = 0;
            foreach (string num in ColsOfVariables)
            {
                if (Int32.TryParse(num, out Temp))
                {
                    if (Temp > 0 && Temp <= MainColsCount)
                    {
                        if (MainForm.MainDT.Rows[RowsNum][Temp-1].ToString().Trim() == "")
                        {
                            return false;
                            //发现空格
                        }
                    }
                }
            }
            return true;
            //未发现空格
        }
        
        private void button_refresh_Click(object sender, EventArgs e)
        {
            textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
        }
       
        void NaiveBayesPrediction()
        {
            if(MainForm.MainDT.Columns.IndexOf("预测结果")==-1){
                MainForm.MainDT.Columns.Add("预测结果");
            }
            else
            {
                MainForm.MainDT.Columns.Add("");
            }
            /*if (MainForm.MainDT.Columns.IndexOf("预测概率") == -1)
            {
                MainForm.MainDT.Columns.Add("预测概率");
            }
            else
            {
                MainForm.MainDT.Columns.Add("");
            }*/
            //新增一列
            int OutputCol = MainForm.MainDT.Columns.Count - 1;
            //输出列为新增列：预测结果
            //int OutputProb = MainForm.MainDT.Columns.Count - 1;
            //该列为新增列：预测概率
            string SelectedCols = textBox_cols.Text;
            char[] separator = { ',' };
            string[] AllCols = SelectedCols.Split(separator);
            int CountValid = 0;
            foreach (string EachCol in AllCols)
            {
                if (EachCol != "")
                {
                    CountValid++;
                }
            }
            string[] ColsOfVariables = new string[CountValid];
            int Counts = 0;
            double Product = 1;
            double[] ForCompare = new double[Result[4].Length];
            int MainDTRowsCount = MainForm.MainDT.Rows.Count;
            int len4 = Result[4].Length;
            for (int RowsNum = 0; RowsNum < MainDTRowsCount; RowsNum++)
            {
                if (IdentifyForm1NARow(RowsNum, AllCols))
                {
                    Counts = 0;
                    foreach (string EachCol in AllCols)
                    {
                        if (EachCol != "")
                        {
                            ColsOfVariables[Counts] = MainForm.MainDT.Rows[RowsNum][Convert.ToInt32(EachCol) - 1].ToString();
                            Counts++;
                        }
                    }
                    //每读出来一行计算一次
                    for (int CountClass = 0; CountClass < len4; CountClass++)
                    {
                        Product = 1;
                        for (int i = 0; i < Counts; i++)
                        {
                            Product *= Convert.ToDouble(Search(ColsOfVariables[i].Trim() + "|" + Result[4][CountClass].Trim(), Result[2], Result[3]));

                        }
                        Product *= Convert.ToDouble(Search(Result[4][CountClass].Trim(), Result[0], Result[1]));
                        //接下来要除以正则常数
                        /*for (int i = 0; i < Counts; i++)
                        {
                            Product =Product / Convert.ToDouble(Search(ColsOfVariables[i].Trim(), Result[0], Result[1]));

                        }*/
                        ForCompare[CountClass] = Product;
                    }
                    //MainForm.MainDT.Rows[RowsNum][OutputProb] = ForCompare.Max();
                    MainForm.MainDT.Rows[RowsNum][OutputCol]= Result[4][FindMaxPosition(ForCompare)];
                    //double ans = Search("打喷嚏|感冒", str, Probs) * Search("建筑工人|感冒", str, Probs) * Search("感冒", AllClassi, EachProbs) / (Search("打喷嚏", AllClassi, EachProbs) * Search("建筑工人", AllClassi, EachProbs));
                }
            }
        }
        int FindMaxPosition(double[] NumberSeries)
        {
            double Temp = NumberSeries[0];
            int MaxPosition = 0;
            int len = NumberSeries.Length;
            for (int i = 1; i < len; i++)
            {
                if (Temp < NumberSeries[i])
                {
                    Temp = NumberSeries[i];
                    MaxPosition = i;
                }
            }
            return MaxPosition;
        }
        void refresh_Combox_Class()
        {
            comboBox_Class.Items.Clear();
            int ColCounts = dataGridView_subset.ColumnCount;
            for (int i = 0; i < ColCounts; i++)
            {
                comboBox_Class.Items.Add(dataGridView_subset.Columns[i].Name);
            }

        }
        private void button_import_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt = Tabulation.GetSubset(MainForm.MainDT, textBox_ChosenCols.Text);
            dataGridView_subset.DataSource = dt;
            refresh_Combox_Class();
        }

       

        private void button_refresh_predict_Click(object sender, EventArgs e)
        {
            textBox_cols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
        }

        private void button_GenrateRules_Click(object sender, EventArgs e)
        {
           textBox_result.Text = BayesClassification();
        }

        private void button_predict_Click(object sender, EventArgs e)
        {
            NaiveBayesPrediction();
            Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent,
                    ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                    MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage, MainForm.pageSize);
            //Tabulation.DataType(dataGridView1);
        }

        private void dataGridView_subset_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int Rows = e.RowIndex;
            int Columns = e.ColumnIndex;
            dt.Rows[Rows][Columns] = dataGridView_subset.Rows[Rows].Cells[Columns].Value;
        }
    }
}
