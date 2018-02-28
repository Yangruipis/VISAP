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
    public partial class MultipleChoice : Form
    {
        public MultipleChoice()
        {
            InitializeComponent();
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_Cols);
        }
        private void button_Split_Click(object sender, EventArgs e)
        {
            string Name = "";
            int InterestCol = MainForm.MainDT.Columns.IndexOf(comboBox_Cols.Text);
            int OriginColsCount = MainForm.MainDT.Columns.Count;
            if (InterestCol != -1)
            {
                int RowsCount = MainForm.MainDT.Rows.Count;
                string AllChoices = textBox_Choices.Text;
                if (AllChoices != "")
                {
                   AllChoices = AllChoices.Replace("\r","");
                   string[] Choices = AllChoices.Split('\n');
                   foreach (string Choice in Choices)
                   {
                       if (Choice.Trim() != "")
                       {
                           Name = comboBox_Cols.Text + ": "+Choice.Trim();
                           if (MainForm.MainDT.Columns.IndexOf(Name) == -1)
                           {
                               MainForm.MainDT.Columns.Add(Name);
                           }
                           else
                           {
                               MainForm.MainDT.Columns.Add("");
                           }
                       }
                   }
                   int ColNum = 0;
                    string EachCellContent = "";
                    //记录要寻找的每一个列名
                    //如果找到了相应的选项，则在相应的列名记上1，否则记0
                    for (int i = 0; i < RowsCount; i++)
                    {
                        EachCellContent = MainForm.MainDT.Rows[i][InterestCol].ToString();
                        ColNum = 0;
                        foreach (string Choice in Choices)
                        {
                            if (Choice.Trim() != "")
                            {
                                if (EachCellContent.IndexOf(Choice.Trim()) != -1)
                                {
                                    MainForm.MainDT.Rows[i][OriginColsCount + ColNum] = "1";
                                }
                                else
                                {
                                    MainForm.MainDT.Rows[i][OriginColsCount + ColNum] = "0";
                                }
                                ColNum++;
                            }
                        }
                    }
                    Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent,
                    ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                    MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage, MainForm.pageSize);
                }
            }
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_Cols);
        }
    }
}
