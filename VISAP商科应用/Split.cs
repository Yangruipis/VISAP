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
    public partial class Split : Form
    {
        public Split()
        {
            InitializeComponent();
        }

        private void button_StartSplit_Click(object sender, EventArgs e)
        {
            string ColNums = textBox_ChosenCols.Text;
            if (ColNums.Contains(","))
            {
                MessageBox.Show("一次只能转换一列数据，请选择单列以后再试。");
            }
            else
            {
                int ColNum = Convert.ToInt32(ColNums.Trim()) - 1;
                if (ColNum >= 0 && ColNum <MainForm.S.dataGridView1.ColumnCount)
                {
                    List<char> separators = new List<char>();
                    if (checkBox_Tab.Checked == true)
                    {
                        separators.Add('\t');
                    }
                    if (checkBox_semicolon.Checked == true)
                    {
                        separators.Add(';');
                    }
                    if (checkBox_comma.Checked == true)
                    {
                        separators.Add(',');
                    }
                    if (checkBox_space.Checked == true)
                    {
                        separators.Add(' ');
                    }
                    if (checkBox_OtherChar.Checked == true)
                    {
                        separators.Add(textBox_SplitChar.Text.ToString()[0]);
                    }


                   MainForm.MainDT = Tabulation.DataTableSplit(MainForm.MainDT, separators.ToArray(), ColNum);
                   Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent,
                   ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                   MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage, MainForm.pageSize);
                   this.Close();
                }
            }
            
            
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
        }
    }
}
