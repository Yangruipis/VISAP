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
    public partial class HypothesisTesting_2Sample : Form
    {
        public static string result = "";
        public HypothesisTesting_2Sample()
        {
            InitializeComponent();
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_Cols2);
            Tabulation.RenewColsItems(MainForm.MainDT, comboBox_Cols);
            this.comboBox_Cols.Focus();
        }
        private void Actived(object sender, EventArgs e)
        {
            this.comboBox_Cols.Focus();//?????
        }
        private void button_StartTesting_Click(object sender, EventArgs e)
        {
            result = Stat.HypothesisTesting2(MainForm.MainDT,comboBox_Cols.Text,comboBox_Cols2.Text,
                comboBox_Statistics.Text, comboBox_Operation.Text, comboBox_Tail.Text,
                Convert.ToDouble(comboBox_Significance.Text), Convert.ToDouble(textBox_NullHypothesis.Text), comboBox_proportion.Text, Convert.ToDouble(textBox_comapre.Text));
            MainForm.S.richTextBox1.AppendText(result);
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }

        private void comboBox_Statistics_TextChanged(object sender, EventArgs e)
        {
            string Operation = comboBox_Operation.Text;
            if (Operation == "=")
            {
                Operation = "<>";
            }
            else if (Operation == "<=")
            {
                Operation = ">";
            }
            else
            {
                Operation = "<";
            }
            label_Alternative.Text = comboBox_Statistics.Text + " " + Operation + " " + textBox_NullHypothesis.Text;
            if (comboBox_Statistics.Text == "比率差")
            {
                label4.Visible = true;
                textBox_comapre.Visible = true;
                comboBox_proportion.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox_comapre.Visible = false;
                comboBox_proportion.Visible = false;
            }
            if (comboBox_Statistics.Text == "方差比")
            {
                textBox_NullHypothesis.Text = "1";
                textBox_NullHypothesis.ReadOnly = true;
            }
            else
            {
                textBox_NullHypothesis.Text = "0";
                textBox_NullHypothesis.ReadOnly = false;
            }
        }

        private void comboBox_Operation_TextChanged(object sender, EventArgs e)
        {
            string Operation = comboBox_Operation.Text;
            if (Operation == "=")
            {
                comboBox_Tail.Text = "双侧";
                Operation = "<>";
            }
            else if (Operation == "<=")
            {
                comboBox_Tail.Text = "右单侧";
                Operation = ">";
            }
            else
            {
                comboBox_Tail.Text = "左单侧";
                Operation = "<";
            }
            label_Alternative.Text = comboBox_Statistics.Text + " " + Operation + " " + textBox_NullHypothesis.Text;
            textBox_NullHypothesis.Text = "0.5";

        }

        private void textBox_NullHypothesis_TextChanged(object sender, EventArgs e)
        {
            string Operation = comboBox_Operation.Text;
            if (Operation == "=")
            {
                Operation = "<>";
            }
            else if (Operation == "<=")
            {
                Operation =">";
            }
            else
            {
                Operation ="<";
            }
            label_Alternative.Text = comboBox_Statistics.Text + " " + Operation + " " + textBox_NullHypothesis.Text;
        }

        private void label_Alternative_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Statistics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Cols_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
