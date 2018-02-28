using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace VISAP商科应用
{
    public partial class Stockdata : Form
    {
        public Stockdata()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tmp;
            if(int.TryParse(textBox1.Text, out tmp)){
                if (tmp >= 1 && tmp <= 600000 && textBox1.Text.Length == 6)
                {
                    progressBar1.Value = 0;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 106;
                    textBox2.Text = "";
                    string url;
                    WebClient wc = new WebClient();//创建WebClient对象
                    Stream News;
                    StreamReader Newsr;
                    string line = "";
                    Match m;
                    Regex ResultNum = new Regex("<div align=\"center\">([\\d\\.]+)</div></td>");

                    Regex date = new Regex(@"date=(\d{4}-\d{2}-\d{2})'>");
                    Regex title = new Regex("target=\"_self\">(.+)</a></h1>");

                    StringBuilder Result = new StringBuilder();


                    int count;
                    int count2 = 0;
                    for (int year = 1990; year < 2017; year++)
                    {
                        for (int jidu = 1; jidu < 5; jidu++)
                        {
                            count = 0;
                            url = "http://money.finance.sina.com.cn/corp/go.php/vMS_MarketHistory/stockid/" + textBox1.Text + ".phtml?year=" + year.ToString() + "&jidu=" + jidu.ToString();
                            News = wc.OpenRead(url);
                            Newsr = new StreamReader(News, Encoding.Default);
                            while ((line = Newsr.ReadLine()) != null)
                            {
                                m = title.Match(line);
                                if (count2 == 0)//保证以下只出现一次
                                {
                                    if (m.Success)
                                    {
                                        Result.Append(m.Groups[1].ToString() + "\r\n");
                                        Result.Append("date \t , 开盘价 \t , 最高价 \t, 收盘价 \t , 最低价 \t , 交易量（股） \t ,  交易金额（元） \r\n");

                                    }
                                }
                                //导出csv出现中文乱码 通过streamwriter 编码已经解决

                                m = date.Match(line);
                                if (m.Success)
                                {
                                    Result.Append(m.Groups[1].ToString());

                                }

                                m = ResultNum.Match(line);
                                if (m.Success)
                                {
                                    Result.Append(",");
                                    Result.Append(m.Groups[1].ToString());
                                    count++;
                                    if (count % 6 == 0)
                                    {
                                        Result.Append("\r\n");
                                    }

                                }
                            }
                            News.Close();
                            Newsr.Close();
                            count2++;
                            if (progressBar1.Value < progressBar1.Maximum)
                            {
                                progressBar1.Value++;
                                output("( " + Math.Round(((double)progressBar1.Value * 100 / (double)progressBar1.Maximum),2,0).ToString() + "% )");

                            }
                            
                        }
                    }
   
                    //WriteTxt(Result.ToString());
                    string str2 = Environment.CurrentDirectory;
                    string filepath = str2 + "\\" + textBox1.Text + ".csv";
                    output("文件已保存到" + filepath);
                    try
                    {

                        StreamWriter sw = new StreamWriter(filepath, false, UnicodeEncoding.GetEncoding("GB2312"));
                        sw.Write(Result.ToString());
                        sw.Close();
                        MessageBox.Show("保存成功！");
                        
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("输入股票号有误");
                }
            }



        }

        public static void WriteTxt(string Content)
        {
            while (true)
            {
                Console.WriteLine("请输入要保存的txt文件路径:");
                Console.WriteLine("例如：C:\\data.txt");
                string FilePath = Console.ReadLine();
                try
                {
                    StreamWriter sw = new StreamWriter(FilePath);
                    sw.Write(Content);
                    sw.Close();
                    Console.WriteLine("保存成功！");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("路径输入错误！");
                }
            }
        }

        public void output(string log)
        {
            //添加日志
            textBox2.AppendText(DateTime.Now.ToString("HH:mm:ss") + log + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str2 = Environment.CurrentDirectory;
            string filepath = str2 + "\\" + textBox1.Text + ".csv";
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = filepath;
            info.Arguments = "";
            try
            {
                System.Diagnostics.Process.Start(info);
            }
            catch (Exception ex)
            {

            }

        }
        public static string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

       

        private void Stockdata_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
