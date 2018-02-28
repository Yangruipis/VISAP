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
    public partial class DirichletPosterior : Form
    {
        public DirichletPosterior()
        {
            InitializeComponent();
        }

        private void button_predict_Click(object sender, EventArgs e)
        {
            //string[] ContentLines = Content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] ContentLines = textBox_successes.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<int> Numbers = new List<int>();
            int Temp = 0;
            int Len = 0;
            StringBuilder Information = new StringBuilder();
            Information.Append(StrManipulation.PadLeftX("组编号", ' ', 12));
            Information.Append("\t");
            Information.Append(StrManipulation.PadLeftX("预测概率值", ' ', 12));
            Information.Append("\r\n");
            int GroupTimes = 1;
            foreach (string EachLine in ContentLines)
            {
                Numbers.Clear();
                string[] Strs = EachLine.Split(',');
                foreach (string EachStr in Strs)
                {
                    if (Int32.TryParse(EachStr, out Temp))
                    {
                        Numbers.Add(Temp);
                    }
                }
                Len = Numbers.Count;
                if (Len != Multinomial.Classification.Length)
                {
                    MessageBox.Show("参数个数不正确！");
                }
                else
                {
                    Information.Append("第");
                    Information.Append(GroupTimes.ToString());
                    Information.Append("组");
                    GroupTimes++;
                    Information.Append("\t");
                    Information.Append(MathV.NumberPolish(Stat.DirichletPrediction(Numbers, Multinomial.Alphas)));
                    Information.Append("\r\n");
                }
            }
            MainForm.S.richTextBox1.AppendText(Information.ToString());
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }
    }
}
