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
    public partial class ParameterEstimation : Form
    {
        public ParameterEstimation()
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

        private void textBox_ChosenCols_TextChanged(object sender, EventArgs e)
        {
            textBox_VarNames.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_ChosenCols.Text);
        }

        private void comboBox_statistics_TextChanged(object sender, EventArgs e)
        {

            //MessageBox.Show("haha");
            /*if (comboBox_statistics.Text == "均值" || comboBox_statistics.Text == "方差")
            {
                label6.Text = "比例条件（此项不必填写）";
            }
            else
            {
                label6.Text = "比例条件（需要填写）";
            }*/

        }


        private void button_Estimation_Click(object sender, EventArgs e)
        {
            Stat.LoopCI(MainForm.S.dataGridView1,MainForm.S.richTextBox1,
                textBox_ChosenCols.Text,comboBox_Tail.Text,
                comboBox_statistics.Text, Convert.ToDouble(comboBox_ConfidenceLevel.Text), comboBox_proportion.Text, Convert.ToDouble(textBox_proportion_value.Text));
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_statistics_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox_statistics.Text == "比例")
            {
                label6.Visible = true;
                comboBox_proportion.Visible = true;
                textBox_proportion_value.Visible = true;
            }
            else
            {
                label6.Visible = false;
                comboBox_proportion.Visible = false;
                textBox_proportion_value.Visible = false;
            }
        }

        private void comboBox_statistics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
