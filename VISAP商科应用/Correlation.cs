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
    public partial class Correlation : Form
    {
        public Correlation()
        {
            InitializeComponent();
            textBox_Cols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_Cols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void textBox_VarNames_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button_Correlation_Click(object sender, EventArgs e)
        {
            string ColNums = textBox_Cols.Text;
            char[] separator = { ',' };
            //string是以逗号分隔的
            string[] AllNum = ColNums.Split(separator);
            //按照逗号分割
            List<int> Cols = new List<int>();
            foreach (string SingleNum in AllNum)
            {
                if (SingleNum != "")
                {
                    Cols.Add(Convert.ToInt32(SingleNum) - 1);
                }
            }
            Stat.MultiCorr(MainForm.MainDT, Cols.ToArray(), MainForm.S.richTextBox1);
        }

        private void textBox_Cols_TextChanged(object sender, EventArgs e)
        {
            textBox_VarNames.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_Cols.Text);
        }
    }
}
