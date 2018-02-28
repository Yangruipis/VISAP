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
    public partial class ImportCSV : Form
    {
        public ImportCSV()
        {
            InitializeComponent();
        }

        public static List<string> files = new List<string>();
        //用于记录批量导入的文件
        private void button_select_Click(object sender, EventArgs e)
        {
            //打开一个文件选择框
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "csv文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "csv文件(*.csv)|*.csv";
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性
            string ImportMethod = comboBox_method.Text;
            if (ImportMethod == "单个导入")
            {
                ofd.Multiselect = false;
            }
            else if (ImportMethod == "批量导入")
            {
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;
                ofd.Multiselect = true;
            }
            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ImportMethod == "单个导入")
                {
                    strName = ofd.FileName;
                }
                else if (ImportMethod == "批量导入")
                {
                    files.Clear();
                    files = ofd.FileNames.ToList();
                    if (files.Count == 0)
                    {
                        strName = "";
                    }
                    else
                    {
                        strName = "批量导入"+files.Count+"个csv文件";
                    }
                }
            }
            if (strName == "")
            {
                MessageBox.Show("没有选择csv文件！无法进行数据导入");
            }
            textBox_path.Text = strName;
        }

        private void Import_Click(object sender, EventArgs e)
        {
            bool Tab = checkBox_Tab.Checked;
            bool semicolon = checkBox_semicolon.Checked;
            bool comma = checkBox_comma.Checked;
            bool OtherChar = checkBox_OtherChar.Checked;
            if (Tab == false && semicolon == false && comma == false &&  OtherChar == false)
            {
                MessageBox.Show("请选择分割方式。");
            }
            else
            {
                List <char> ch=new List <char> ();
                if (Tab == true)
                {
                    ch.Add('\t');
                }
                if (semicolon == true)
                {
                    ch.Add(';');
                }
                if (comma == true)
                {
                    ch.Add(',');
                }
                if (OtherChar == true)
                {
                    ch.Add(textBox_SplitChar.Text.ToString()[0]);
                }
                if (comboBox_method.Text == "单个导入")
                {
                    DataTable dt = new DataTable();
                    dt = Tabulation.LoadFromCSVFile(textBox_path.Text, ch.ToArray());
                    if (dt != null)
                    {
                        MainForm.MainDT = dt;
                        Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent, 
                    ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                    MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage,MainForm.pageSize);
                    }
                }
                else if(comboBox_method.Text == "批量导入") 
                {
                    DataTable dt = new DataTable();
                    foreach (string EachFile in files)
                    {
                        dt.Merge(Tabulation.LoadFromCSVFile(EachFile,ch.ToArray()));
                    }
                    if (dt != null)
                    {
                        MainForm.MainDT = dt;
                        Tabulation.InitDataSet(MainForm.MainDT, ref MainForm.nMax, ref MainForm.pageCount, ref MainForm.pageCurrent,
                    ref MainForm.nCurrent, MainForm.S.label_CurrentPage, MainForm.S.label_TotalPage,
                    MainForm.S.dataGridView1, MainForm.S.textBox_CurrentPage, MainForm.pageSize);
                    }
                }
                this.Close();
            }
        }
        private const string Help = "导入csv文件帮助：\r\n单个导入：\r\n单击“选择文件”，选择一个csv格式的文件。\r\n选择你用于分割csv文件的分隔符号（默认为逗号）。单击“导入”就可以啦～\r\n批量导入：\r\n单击“选择文件”，可以选择多个csv格式的文件，请注意各个csv文件的表头需要一致，以便于合并。\r\n选择你用于分割csv文件的分隔符号（默认为逗号）。单击“导入”就可以啦～\r\n";

        private void button_Help_Click(object sender, EventArgs e)
        {
            MainForm.S.richTextBox1.AppendText(Help);
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }

        private void textBox_path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
