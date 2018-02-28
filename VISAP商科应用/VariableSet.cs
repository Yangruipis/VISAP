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
    public partial class VariableSet : Form
    {
        public VariableSet()
        {
            InitializeComponent();
            textBox_VarName.Text = MainForm.MainDT.Columns[MainForm.ColumnNameChange].ColumnName;
            textBox_VarName.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NewName = textBox_VarName.Text;
            if (MainForm.MainDT.Columns.IndexOf(NewName) != -1)
            {
                MessageBox.Show("不能与现有变量名重复！");
            }
            else
            {
                MainForm.MainDT.Columns[MainForm.ColumnNameChange].ColumnName = NewName;
                Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent,
                    ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                    MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage, MainForm.pageSize);
                this.Close();
            }
        }

    }
}
