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
    public partial class SelectExcel : Form
    {
        public SelectExcel()
        {
            InitializeComponent();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            //打开一个文件选择框
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "Excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            //"Excel文件(*.xls)|*.xls;所有文件(*.*)|*.*"
            //"文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性


            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }

            if (strName == "")
            {
                MessageBox.Show("没有选择Excel文件！无法进行数据导入");
            }
            textBox_path.Text = strName;
        }

        private void Import_Click(object sender, EventArgs e)
        {
            //Tabulation.DataType(MainForm.S.dataGridView1);
            DataTable dt = new DataTable();
            dt = Tabulation.ImportExcel(textBox_path.Text, textBox_tabulation.Text);;
            if (dt != null)
            {
                //dataGridView1.DataSource = dt;
                MainForm.MainDT = dt;
                Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent,
                    ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                    MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage, MainForm.pageSize);
                //Tabulation.DataType(dataGridView1);
                this.Close();
            }
            
        }
        private const string Help = "导入Excel文件帮助：\r\n单击“选择文件”，选择一个Excel文件。\r\n输入你要导入的工作表（默认为sheet1），单击“导入”就可以啦～\r\n";

        private void button_Help_Click(object sender, EventArgs e)
        {
            MainForm.S.richTextBox1.AppendText(Help);
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }
    }
}
