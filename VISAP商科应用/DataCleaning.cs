using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace VISAP商科应用
{
    public class DataCleaning
    {
        public static void NAProcess(DataGridView dataGridView1, string Cols, string type, RichTextBox richTextBox1, ComboBox comboBox_user_defined, TextBox textBox_user_defined)
        {
           char [] separator = {','};
		   string [] AllCols = Cols.Split(separator);
		   List <int> ColsNeedRemove = new List<int>();
            int NACount = 0;
            //计算缺失值数量
            DataTable dt = dataGridView1.DataSource as DataTable;
            richTextBox1.AppendText("缺失值处理:\r\n");
            richTextBox1.AppendText("    处理方式: "+type+"\r\n");
            richTextBox1.Select();//让RichTextBox获得焦点
            richTextBox1.Select(richTextBox1.TextLength,0);//将插入符号置于文本结束处 
            richTextBox1.ScrollToCaret();
            BigNumber Mean = 0;
            BigNumber Sum = 0;
		   foreach (string Col in AllCols){
		   int  StartCount = 0;
            //从第一个非空值开始计数
           NACount = 0;
           Sum = 0;
           if (comboBox_user_defined.Text == "平均值")
           {
               string [] Numbers = Tabulation.ReadVector(MainForm.MainDT, Convert.ToInt32(Col) - 1).ToArray();
               int NumCounts = 0;
               foreach (string Num in Numbers)
               {
                   if (Tabulation.IsStrDouble(Num))
                   {
                       Sum += Convert.ToDouble(Num);
                       NumCounts ++;
                   }
               }
               Mean = Sum / NumCounts;
           }
            for(int i = dataGridView1.Rows.Count - 2; i >= 0 ;i--){
                //倒着数，从后往前数
                if (StartCount == 0 && dataGridView1.Rows[i].Cells[Convert.ToInt32(Col)-1].Value.ToString().Trim() != ""){
                    StartCount = 1;
                    continue;
                }
                if (StartCount == 1 && dataGridView1.Rows[i].Cells[Convert.ToInt32(Col) - 1].Value.ToString().Trim() == "")
                {
                    //遇到缺失值了
                    if (type == "计算缺失值个数"){
                        NACount++;
                    }
                    else if (type == "删除整行"){
                        NACount++;
                        //dt.Rows.RemoveAt(i);
						ColsNeedRemove.Add(i);
                    }
                    else if (type == "替换为特定值")
                    {
                        if (comboBox_user_defined.Text == "平均值")
                        {
                            dataGridView1.Rows[i].Cells[Convert.ToInt32(Col) - 1].Value = Mean.ToString();
                        }
                        else if (comboBox_user_defined.Text == "自定义值")
                        {
                            dataGridView1.Rows[i].Cells[Convert.ToInt32(Col) - 1].Value = textBox_user_defined.Text;
                        }
                        NACount++;
                    }
                }
            }

            if (StartCount != 0)
            {
                richTextBox1.AppendText("    " + "第" + Col + "列" + "缺失值个数: " + NACount.ToString() + "\r\n");
                richTextBox1.Select();//让RichTextBox获得焦点
                richTextBox1.Select(richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
                richTextBox1.ScrollToCaret();
            }
		   }
           richTextBox1.AppendText("\r\n");
            if (type == "删除整行"){
                ColsNeedRemove = ColsNeedRemove.Distinct().ToList();
                ColsNeedRemove.Sort();
                int [] SequenceRemove = ColsNeedRemove.ToArray();
                for (int i = SequenceRemove.Length - 1;i>=0;i--)
                {
                    dt.Rows.RemoveAt(SequenceRemove[i]);
                }
                dataGridView1.DataSource = dt;
            }
            
            
        }
    }
}
