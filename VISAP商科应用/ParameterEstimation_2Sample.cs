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
    public partial class ParameterEstimation_2Sample : Form
    {
        public ParameterEstimation_2Sample()
        {
            InitializeComponent();
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_ChosenCols1.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_ChosenCols1.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }

        private void textBox_ChosenCols1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                textBox_VarNames.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_ChosenCols1.Text) + "," + Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_ChosenCols2.Text);
            }
            catch(Exception ex){

            }
        }

        private void textBox_ChosenCols2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_VarNames.Text = Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_ChosenCols1.Text) + "," + Tabulation.GetColsName(MainForm.S.dataGridView1, textBox_ChosenCols2.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBox_statistics_TextChanged(object sender, EventArgs e)
        {

            if (comboBox_statistics.Text == "比例差")
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


        private void button_Estimation_Click(object sender, EventArgs e)
        {
            string Cols = textBox_ChosenCols1.Text + "," + textBox_ChosenCols2.Text;
            Stat.LoopCI2(MainForm.S.dataGridView1,MainForm.S.richTextBox1,
                Cols,comboBox_Tail.Text,
                comboBox_statistics.Text, Convert.ToDouble(comboBox_ConfidenceLevel.Text), comboBox_proportion.Text, Convert.ToDouble(textBox_proportion_value.Text));
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_statistics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
