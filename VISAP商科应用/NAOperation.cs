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
    public partial class NAOperation : Form
    {
        public NAOperation()
        {
            InitializeComponent();
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            if (listBox_Methods.SelectedItem != null)
            {
                if (listBox_Methods.SelectedItem.ToString() == "计算缺失值个数" || listBox_Methods.SelectedItem.ToString() == "删除整行" || listBox_Methods.SelectedItem.ToString() == "替换为特定值")
                {
                    DataCleaning.NAProcess(MainForm.S.dataGridView1, textBox_ChosenCols.Text, listBox_Methods.SelectedItem.ToString(), MainForm.S.richTextBox1,comboBox_user_defined,textBox_user_defined);
                }
            }
        }
    }
}
