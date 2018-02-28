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
using System.Diagnostics;
namespace VISAP商科应用
{
    public partial class Economicdata : Form
    {
        public Economicdata()
        {
            InitializeComponent();
        }

        Dictionary<string, string> indexcode = new Dictionary<string, string>();//定义字典，实现code和变量名的匹配
        List<string> index_choosen = new List<string>(); //将选择的变量的code保存到list里
        private void button_refresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox_choosen.Text = "";
            indexcode.Clear(); //清空字典
            textBox_log.Text = "";//清空日志
            treeView1.Nodes.Clear(); //清空treeview
            string sUrl = "";  
            string sParam = "";
            Stopwatch stw = new Stopwatch(); //计时器
            stw.Start();//计时器开始
            progressBar1.Value = 0;//进度条初始值
            progressBar1.Minimum = 0;//进度条最小值
            if (comboBox_area.Text == "全国")//分配url（已知）、参数（根据firebugs）和进度条最大值（事先count过）
            {
                switch (comboBox_period.Text)
                {
                    case "年度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=C01"; sParam = "id=zb&dbcode=hgnd&wdcode=zb&m=getTree"; progressBar1.Maximum = 658; break;
                    case "季度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=B01"; sParam = "id=zb&dbcode=hgjd&wdcode=zb&m=getTree"; progressBar1.Maximum = 78; break;
                    case "月度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=A01"; sParam = "id=zb&dbcode=hgyd&wdcode=zb&m=getTree"; progressBar1.Maximum = 147; break;
                }
            }
            else if (comboBox_area.Text == "31省(不含港澳台)")
            {
                switch (comboBox_period.Text)
                {
                    case "年度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=E0103"; sParam = "id=zb&dbcode=fsnd&wdcode=zb&m=getTree"; progressBar1.Maximum = 227; break;
                    case "季度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=E0103"; sParam = "id=zb&dbcode=fsjd&wdcode=zb&m=getTree"; progressBar1.Maximum = 29; break;
                    case "月度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=E0103"; sParam = "id=zb&dbcode=fsyd&wdcode=zb&m=getTree"; progressBar1.Maximum = 86; break;
                }
            }
            else
            {
                switch (comboBox_period.Text)
                {
                    case "年度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=E0105"; sParam = "id=zb&dbcode=csnd&wdcode=zb&m=getTree"; progressBar1.Maximum = 8; break;
                    case "月度": sUrl = "http://data.stats.gov.cn/easyquery.htm?cn=E0104"; sParam = "id=zb&dbcode=csyd&wdcode=zb&m=getTree"; progressBar1.Maximum = 6; break;
                }
            }
            output(" 提交URL");
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8"); //设置编码
            HttpWebRequest req = postrequest(sUrl, sParam);  //提交请求，postrequest函数自己定义的
            output(" 提交当前请求与参数");
            WebResponse myResp = req.GetResponse();//接受响应
            Stream ReceiveStream = myResp.GetResponseStream();//将响应转为文件流
            output(" 获取服务器响应");
            StreamReader readStream = new StreamReader(ReceiveStream, encode);//按utf8解码
            Regex tree = new Regex("{\"dbcode\":\"([a-z]{3})d\",\"id\":\"([A]?[0-9]{0,}[A-Z]?[0-9]{0,})\",\"isParent\":(true|false),\"name\":\"([\\w]+\\(?[\\w]{0,}=?[0-9]{0,}\\)?)\",\"pid");
            //定义正则表达抓取树状图，groups1为dbcode，季度数据、年度数据、月度数据都不一样
            //group2为每个节点的代码，统计局自己定义的A打头，3位、5位、7位的编码（有待完善）
            //group3为是否为parent节点，是的则需要继续挖掘，不是就输出为指标
            //group4为节点名称，有待改进，名称中间可能含有"、","="等符号（懒惰算法）
            //Regex data_reg = new Regex("code\":\"zb.([A]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?)_sj.([0-9]{4})\",\"data\":{\"data\":([\\d\\.]),\"dotcount\":0,\"hasdata\":true");
            Match m;  //定义match
            Match m1;
            Match m2;
            output(" 分配正则表达式");
            int count = 0;
            int count1;
            try
            {
                m = tree.Match(readStream.ReadToEnd()); //匹配一级树节点
                output(" 匹配一级树节点");
                while (m.Success)
                {
                    output(" 抓取" + m.Groups[4].ToString()+"及其从属节点");
                    progressBar1.Value++; //进度条加1
                    treeView1.Nodes.Add(Name = m.Groups[2].ToString(), m.Groups[4].ToString());//一级树节点加到treeview上
                    if (m.Groups[3].ToString() == "true")
                    {
                        count1 = 0;
                        string sParam1 = "id=" + m.Groups[2].ToString() + "&dbcode=" + m.Groups[1].ToString() + "d&wdcode=zb&m=getTree";//拼接新的参数，根据母节点是否为true
                        HttpWebRequest req1 = postrequest(sUrl, sParam1);//提交参数
                        WebResponse myResp1 = req1.GetResponse();//获得响应
                        Stream ReceiveStream1 = myResp1.GetResponseStream();
                        StreamReader readStream1 = new StreamReader(ReceiveStream1, encode);
                        m1 = tree.Match(readStream1.ReadToEnd());
                        while (m1.Success)
                        {
                            progressBar1.Value++;
                            treeView1.Nodes[count].Nodes.Add(Name = m1.Groups[2].ToString(), m1.Groups[4].ToString());//二级树节点加入
                            if (m1.Groups[3].ToString() == "true")
                            {

                                string sParam2 = "id=" + m1.Groups[2].ToString() + "&dbcode=" + m1.Groups[1].ToString() + "d&wdcode=zb&m=getTree";
                                HttpWebRequest req2 = postrequest(sUrl, sParam2);
                                WebResponse myResp2 = req2.GetResponse();
                                Stream ReceiveStream2 = myResp2.GetResponseStream();
                                StreamReader readStream2 = new StreamReader(ReceiveStream2, encode);
                                m2 = tree.Match(readStream2.ReadToEnd());
                                while (m2.Success)
                                {
                                    indexcode.Add(m2.Groups[2].ToString(), m2.Groups[4].ToString());//三级树节点（已无子节点）加入字典，直接和所选指标对应
                                    progressBar1.Value++;
                                    treeView1.Nodes[count].Nodes[count1].Nodes.Add(Name = m2.Groups[2].ToString(), m2.Groups[4].ToString());//三级树节点加入
                                    m2 = m2.NextMatch();
                                }
                                readStream2.Close();//关闭文件流
                                myResp2.Close();//关闭响应
                            }
                            else
                            {
                                indexcode.Add(m1.Groups[2].ToString(), m1.Groups[4].ToString());//二级树节点（已无子节点）加入字典，直接和所选指标对应
                            }
                            count1++;
                            m1 = m1.NextMatch();
                        }
                        readStream1.Close();
                        myResp1.Close();
                    }
                    else{
                         indexcode.Add(m.Groups[2].ToString(), m.Groups[4].ToString());//一级子节点加入字典
                    }
                    count++;
                    m = m.NextMatch();
                }
                //MessageBox.Show(progressBar1.Value.ToString());//输出最大进度条值，事先做好
                output(" 匹配完成");
                stw.Stop();
                output(" 树节点生成完成，用时" + (Convert.ToDouble(stw.Elapsed.TotalMilliseconds)/1000).ToString()+"秒");
                readStream.Close();
                myResp.Close();
                //MessageBox.Show(indexcode["A0101"]);
            }
            catch (Exception ex)
            {
            }

        }


        public static HttpWebRequest postrequest(string sUrl, string sParam)
        {

            //发送请求参数，得到request
            HttpWebRequest req = WebRequest.Create(sUrl) as HttpWebRequest;
            if (req != null)
            {
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] postData = Encoding.GetEncoding("UTF-8").GetBytes(sParam);
                if (postData.Length > 0)
                {
                    req.ContentLength = postData.Length;
                    req.Timeout = 15000;
                    Stream outputStream = req.GetRequestStream();
                    outputStream.Write(postData, 0, postData.Length);
                    outputStream.Flush();
                    outputStream.Close();
                    return req;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void output(string log)
        {
            //添加日志
            textBox_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + log + "\r\n");
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            try
            {
                textBox_choosen.Text = textBox_choosen.Text + treeView1.SelectedNode.Text+ "\r\n";
                index_choosen.Add(treeView1.SelectedNode.Name);
            }
            catch (Exception ex)
            {

            }
        }
        DataTable dt2 = new DataTable();
        private void button_getdata_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox_log.Text = "";
            progressBar1.Value = 0;
            Stopwatch stw = new Stopwatch();
            stw.Start();
            string url = "";
            WebClient wc = new WebClient();//创建WebClient对象
            Stream News;
            StreamReader Newsr;
            Match m;
            int count_row;
            int count_col =0;
            int count_rowchange;
            Regex indexdata = new Regex("zb.([A]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?)_sj.([0-9]+[A-Z]?)\",\"data\":{\"data\":([\\d\\.]+),\"dotcount");
            //group1 具体变量代码（相当于四级树节点）
            //group2 年份、季度或月份
            //group3 变量值
            Regex province_data = new Regex("{\"code\":\"zb.([A]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?)_reg.([0-9]+)_sj.([0-9]+[A-Z]?)\",\"data\":{\"data\":([\\d\\.]+),\"dotcount");
            //group1 具体变量代码（相当于四级树节点）
            //group2 省份6位数编码
            //group4 年份季度或月份
            //group5 变量值
            Regex variablename = new Regex("cname\":\"([\\w\\W]+?)\",\"code\":\"(A?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?[0-9]{0,}[A-Z]?|[2]{1}[0-9]{0,}[A-D]?)\",\"dotcount\":([\\w\\W]+?),\"unit\":\"([\\w]{0,})\"");
            //group1 变量中文名或时间段（包括()=、)
            //group2 变量代码
            //group3 变量描述（无用信息，使用了懒惰算法）
            //group4 变量单位(注意当为指数时单位为"",以及比例时候的反斜杠）
            DataTable dt = new DataTable(); //新建datatable
            int i;
            for (i = 0; i < 100; i++)
            {
                dt.Columns.Add("");
            }
            for (i = 0; i < 2000; i++)
            {
                dt.Rows.Add("");
            }
            dataGridView1.DataSource = dt;//导入datagridview
            output(" 新建数据表");
            output(" 分配正则表达");
            dataGridView1.Columns[0].HeaderCell.Value = "时间";//第一列为时间
            output(" 开始爬取");
            //新建表

            progressBar1.Minimum = 0;
           

            if (comboBox_area.Text == "全国")
            {
                count_rowchange = 0;
                progressBar1.Maximum = index_choosen.Count; //选择了多少个三级指标
                foreach (string index in index_choosen)
                {
                    switch (comboBox_period.Text)
                    {
                        case "年度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=hgnd&rowcode=zb&colcode=sj&wds=%5B%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457707518807"; break;
                        case "季度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=hgjd&rowcode=zb&colcode=sj&wds=%5B%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457707518807"; break;
                        case "月度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=hgyd&rowcode=zb&colcode=sj&wds=%5B%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457707518807"; break;
                    }
                    News = wc.OpenRead(url);
                    Newsr = new StreamReader(News, Encoding.UTF8);
                    string all = Newsr.ReadToEnd(); //最好不要.match(newsr.readtoend())，否则容易第二个match不了（原因未知）
                    m = variablename.Match(all); //匹配变量名
                    int count_year = 0;
                    while (m.Success)
                    {
                        if (Regex.IsMatch(m.Groups[1].ToString(), "^[0-9]{1,}[\\w]{0,}$").ToString() == "True")
                        {
                            dataGridView1.Rows[count_year].Cells[0].Value = m.Groups[2].ToString(); //为第一列年份或是季度赋值（需再做添加）
                            count_year++;
                        }
                        else
                        {
                            dataGridView1.Columns[count_col + 1].HeaderCell.Value = m.Groups[1].ToString() + "(" + m.Groups[4].ToString() + ")";//拼接变量名和变量单位
                            output(" 抓取变量" + m.Groups[1].ToString());
                            count_col++;
                        }
                        m = m.NextMatch();
                    }
                    m = indexdata.Match(all);
                    count_row = 0;
                    while (m.Success)
                    {
                        if (m.Groups[2].ToString() == dataGridView1.Rows[0].Cells[0].Value.ToString())//如果该值对应的时间等于第一列第一个值，则换列，可能有其他更好地方法
                        {
                            count_rowchange++;
                            count_row = 0;
                        }
                        dataGridView1.Rows[count_row].Cells[count_rowchange].Value = m.Groups[3].ToString();//数据导入
                        count_row++;
                        m = m.NextMatch();
                    }
                    News.Close();
                    Newsr.Close();
                    progressBar1.Value++;
                }
            }
            else if (comboBox_area.Text == "31省(不含港澳台)")
            {
                dataGridView1.Columns[1].HeaderCell.Value = "省份";//第二列为省份
                progressBar1.Maximum = 31; //选择了多少个三级指标
                List<string> province_code = new List<string>();
                List<string> province_namelist = new List<string>();
                string Province_url = "http://data.stats.gov.cn/easyquery.htm?m=getOtherWds&dbcode=fsnd&rowcode=zb&colcode=sj&wds=%5B%5D&k1=1457927953426";
                Regex province_codeget = new Regex("code\":\"([0-9]{6})\",\"name\":\"([\\w]+?)\",");
                News = wc.OpenRead(Province_url);
                Newsr = new StreamReader(News, Encoding.UTF8);
                string province_name = Newsr.ReadToEnd();
                m = province_codeget.Match(province_name);
                Dictionary<string, string> province_dict = new Dictionary<string, string>();
                while (m.Success)
                {
                    province_code.Add(m.Groups[1].ToString());//生成省份代号
                    province_dict.Add(m.Groups[1].ToString(), m.Groups[2].ToString());//省份代号加入字典
                    m = m.NextMatch();
                }
                News.Close();
                Newsr.Close();
                int count_province = -1;
                count_row = 0;
                int period_times = 0;
                foreach (string province in province_code)
                {
                    output(" 抓取" + province_dict[province] + "数据");
                    count_rowchange = 1;
                    count_province++;
                    foreach (string index in index_choosen)
                    {
                        switch (comboBox_period.Text)
                        {
                            case "年度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=fsnd&rowcode=zb&colcode=sj&wds=%5B%7B%22wdcode%22%3A%22reg%22%2C%22valuecode%22%3A%22" + province + "%22%7D%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457929014536"; period_times = 10; break;
                            case "季度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=fsjd&rowcode=zb&colcode=sj&wds=%5B%7B%22wdcode%22%3A%22reg%22%2C%22valuecode%22%3A%22" + province + "%22%7D%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457929014536"; period_times = 6; break;
                            case "月度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=fsyd&rowcode=zb&colcode=sj&wds=%5B%7B%22wdcode%22%3A%22reg%22%2C%22valuecode%22%3A%22" + province + "%22%7D%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457929014536"; period_times = 13; break;
                        }
                        News = wc.OpenRead(url);
                        Newsr = new StreamReader(News, Encoding.UTF8);
                        string all = Newsr.ReadToEnd(); //最好不要.match(newsr.readtoend())，否则容易第二个match不了（原因未知）
                        m = variablename.Match(all); //匹配变量名
                        int count_year = 0;
                        while (m.Success)
                        {
                            if (Regex.IsMatch(m.Groups[1].ToString(), "^[0-9]{1,}[\\w]{0,}$").ToString() == "True")
                            {
                                dataGridView1.Rows[count_year + period_times * count_province].Cells[0].Value = m.Groups[2].ToString();
                                //为第一列年份或是季度赋值（需再做添加）10年换一个省
                                dataGridView1.Rows[count_year + period_times * count_province].Cells[1].Value = province_dict[province];
                                count_year++;
                            }
                            else if (Regex.IsMatch(m.Groups[2].ToString(), "^[0-9]{6}$").ToString() == "False")//防止把网页里的省份名称匹配进来
                            {
                                if (count_province == 0)
                                {
                                    dataGridView1.Columns[count_col + 2].HeaderCell.Value = m.Groups[1].ToString() + "(" + m.Groups[4].ToString() + ")";//拼接变量名和变量单位
                                    output(" 抓取 " + m.Groups[1].ToString());
                                    count_col++;
                                }
                            }
                            m = m.NextMatch();
                        }
                        m = province_data.Match(all);
                        while (m.Success)
                        {
                            if (m.Groups[3].ToString() == dataGridView1.Rows[0].Cells[0].Value.ToString())//如果该值对应的时间等于第一列第一个值，则换列，可能有其他更好地方法
                            {
                                count_rowchange++;
                                count_row = 0 + period_times * count_province;
                            }
                            dataGridView1.Rows[count_row].Cells[count_rowchange].Value = m.Groups[4].ToString();//数据导入
                            count_row++;
                            m = m.NextMatch();
                        }
                        News.Close();
                        Newsr.Close();

                    }
                    progressBar1.Value++;
                }
            }
            else
            {
                int count_city2 = -1;
                int period_times = 0;
                int count_city = 0;
                string city_name30 = "{\"code\":\"110000\",\"name\":\"北京\",\"sort\":\"1\"},{\"code\":\"120000\",\"name\":\"天津\",\"sort\":\"1\"},{\"code\":\"130100\",\"name\":\"石家庄\",\"sort\":\"1\"},{\"code\":\"140100\",\"name\":\"太原\",\"sort\":\"1\"},{\"code\":\"150100\",\"name\":\"呼和浩特\",\"sort\":\"1\"},{\"code\":\"210100\",\"name\":\"沈阳\",\"sort\":\"1\"},{\"code\":\"210200\",\"name\":\"大连\",\"sort\":\"1\"},{\"code\":\"220100\",\"name\":\"长春\",\"sort\":\"1\"},{\"code\":\"230100\",\"name\":\"哈尔滨\",\"sort\":\"1\"},{\"code\":\"310000\",\"name\":\"上海\",\"sort\":\"1\"},{\"code\":\"320100\",\"name\":\"南京\",\"sort\":\"1\"},{\"code\":\"330100\",\"name\":\"杭州\",\"sort\":\"1\"},{\"code\":\"330200\",\"name\":\"宁波\",\"sort\":\"1\"},{\"code\":\"340100\",\"name\":\"合肥\",\"sort\":\"1\"},{\"code\":\"350100\",\"name\":\"福州\",\"sort\":\"1\"},{\"code\":\"350200\",\"name\":\"厦门\",\"sort\":\"1\"},{\"code\":\"360100\",\"name\":\"南昌\",\"sort\":\"1\"},{\"code\":\"370100\",\"name\":\"济南\",\"sort\":\"1\"},{\"code\":\"370200\",\"name\":\"青岛\",\"sort\":\"1\"},{\"code\":\"410100\",\"name\":\"郑州\",\"sort\":\"1\"},{\"code\":\"420100\",\"name\":\"武汉\",\"sort\":\"1\"},{\"code\":\"430100\",\"name\":\"长沙\",\"sort\":\"1\"},{\"code\":\"440100\",\"name\":\"广州\",\"sort\":\"1\"},{\"code\":\"440300\",\"name\":\"深圳\",\"sort\":\"1\"},{\"code\":\"450100\",\"name\":\"南宁\",\"sort\":\"1\"},{\"code\":\"460100\",\"name\":\"海口\",\"sort\":\"1\"},{\"code\":\"500000\",\"name\":\"重庆\",\"sort\":\"1\"},{\"code\":\"510100\",\"name\":\"成都\",\"sort\":\"1\"},{\"code\":\"520100\",\"name\":\"贵阳\",\"sort\":\"1\"},{\"code\":\"530100\",\"name\":\"昆明\",\"sort\":\"1\"},{\"code\":\"540100\",\"name\":\"拉萨\",\"sort\":\"1\"},{\"code\":\"610100\",\"name\":\"西安\",\"sort\":\"1\"},{\"code\":\"620100\",\"name\":\"兰州\",\"sort\":\"1\"},{\"code\":\"630100\",\"name\":\"西宁\",\"sort\":\"1\"},{\"code\":\"640100\",\"name\":\"银川\",\"sort\":\"1\"},{\"code\":\"650100\",\"name\":\"乌鲁木齐\",\"sort\":\"1\"}],\"selcode\":\"510100\",\"wdcode\":\"reg\",\"wdname\":\"地区\"},";
                string city_name70 = "{\"returncode\":200,\"returndata\":[{\"issj\":false,\"nodes\":[{\"code\":\"110000\",\"name\":\"北京\",\"sort\":\"1\"},{\"code\":\"120000\",\"name\":\"天津\",\"sort\":\"1\"},{\"code\":\"130100\",\"name\":\"石家庄\",\"sort\":\"1\"},{\"code\":\"130200\",\"name\":\"唐山\",\"sort\":\"1\"},{\"code\":\"130300\",\"name\":\"秦皇岛\",\"sort\":\"1\"},{\"code\":\"140100\",\"name\":\"太原\",\"sort\":\"1\"},{\"code\":\"150100\",\"name\":\"呼和浩特\",\"sort\":\"1\"},{\"code\":\"150200\",\"name\":\"包头\",\"sort\":\"1\"},{\"code\":\"210100\",\"name\":\"沈阳\",\"sort\":\"1\"},{\"code\":\"210200\",\"name\":\"大连\",\"sort\":\"1\"},{\"code\":\"210600\",\"name\":\"丹东\",\"sort\":\"1\"},{\"code\":\"210700\",\"name\":\"锦州\",\"sort\":\"1\"},{\"code\":\"220100\",\"name\":\"长春\",\"sort\":\"1\"},{\"code\":\"220200\",\"name\":\"吉林\",\"sort\":\"1\"},{\"code\":\"230100\",\"name\":\"哈尔滨\",\"sort\":\"1\"},{\"code\":\"231000\",\"name\":\"牡丹江\",\"sort\":\"1\"},{\"code\":\"310000\",\"name\":\"上海\",\"sort\":\"1\"},{\"code\":\"320100\",\"name\":\"南京\",\"sort\":\"1\"},{\"code\":\"320200\",\"name\":\"无锡\",\"sort\":\"1\"},{\"code\":\"320300\",\"name\":\"徐州\",\"sort\":\"1\"},{\"code\":\"321000\",\"name\":\"扬州\",\"sort\":\"1\"},{\"code\":\"330100\",\"name\":\"杭州\",\"sort\":\"1\"},{\"code\":\"330200\",\"name\":\"宁波\",\"sort\":\"1\"},{\"code\":\"330300\",\"name\":\"温州\",\"sort\":\"1\"},{\"code\":\"330700\",\"name\":\"金华\",\"sort\":\"1\"},{\"code\":\"340100\",\"name\":\"合肥\",\"sort\":\"1\"},{\"code\":\"340300\",\"name\":\"蚌埠\",\"sort\":\"1\"},{\"code\":\"340800\",\"name\":\"安庆\",\"sort\":\"1\"},{\"code\":\"350100\",\"name\":\"福州\",\"sort\":\"1\"},{\"code\":\"350200\",\"name\":\"厦门\",\"sort\":\"1\"},{\"code\":\"350500\",\"name\":\"泉州\",\"sort\":\"1\"},{\"code\":\"360100\",\"name\":\"南昌\",\"sort\":\"1\"},{\"code\":\"360400\",\"name\":\"九江\",\"sort\":\"1\"},{\"code\":\"360700\",\"name\":\"赣州\",\"sort\":\"1\"},{\"code\":\"370100\",\"name\":\"济南\",\"sort\":\"1\"},{\"code\":\"370200\",\"name\":\"青岛\",\"sort\":\"1\"},{\"code\":\"370600\",\"name\":\"烟台\",\"sort\":\"1\"},{\"code\":\"370800\",\"name\":\"济宁\",\"sort\":\"1\"},{\"code\":\"410100\",\"name\":\"郑州\",\"sort\":\"1\"},{\"code\":\"410300\",\"name\":\"洛阳\",\"sort\":\"1\"},{\"code\":\"410400\",\"name\":\"平顶山\",\"sort\":\"1\"},{\"code\":\"420100\",\"name\":\"武汉\",\"sort\":\"1\"},{\"code\":\"420500\",\"name\":\"宜昌\",\"sort\":\"1\"},{\"code\":\"420600\",\"name\":\"襄樊\",\"sort\":\"1\"},{\"code\":\"430100\",\"name\":\"长沙\",\"sort\":\"1\"},{\"code\":\"430600\",\"name\":\"岳阳\",\"sort\":\"1\"},{\"code\":\"430700\",\"name\":\"常德\",\"sort\":\"1\"},{\"code\":\"440100\",\"name\":\"广州\",\"sort\":\"1\"},{\"code\":\"440200\",\"name\":\"韶关\",\"sort\":\"1\"},{\"code\":\"440300\",\"name\":\"深圳\",\"sort\":\"1\"},{\"code\":\"440800\",\"name\":\"湛江\",\"sort\":\"1\"},{\"code\":\"441300\",\"name\":\"惠州\",\"sort\":\"1\"},{\"code\":\"450100\",\"name\":\"南宁\",\"sort\":\"1\"},{\"code\":\"450300\",\"name\":\"桂林\",\"sort\":\"1\"},{\"code\":\"450500\",\"name\":\"北海\",\"sort\":\"1\"},{\"code\":\"460100\",\"name\":\"海口\",\"sort\":\"1\"},{\"code\":\"460200\",\"name\":\"三亚\",\"sort\":\"1\"},{\"code\":\"500000\",\"name\":\"重庆\",\"sort\":\"1\"},{\"code\":\"510100\",\"name\":\"成都\",\"sort\":\"1\"},{\"code\":\"510500\",\"name\":\"泸州\",\"sort\":\"1\"},{\"code\":\"511300\",\"name\":\"南充\",\"sort\":\"1\"},{\"code\":\"520100\",\"name\":\"贵阳\",\"sort\":\"1\"},{\"code\":\"520300\",\"name\":\"遵义\",\"sort\":\"1\"},{\"code\":\"530100\",\"name\":\"昆明\",\"sort\":\"1\"},{\"code\":\"532900\",\"name\":\"大理\",\"sort\":\"1\"},{\"code\":\"610100\",\"name\":\"西安\",\"sort\":\"1\"},{\"code\":\"620100\",\"name\":\"兰州\",\"sort\":\"1\"},{\"code\":\"630100\",\"name\":\"西宁\",\"sort\":\"1\"},{\"code\":\"640100\",\"name\":\"银川\",\"sort\":\"1\"},{\"code\":\"650100\",\"name\":\"乌鲁木齐\",\"sort\":\"1\"}],\"selcode\":\"130100\",\"wdcode\":\"reg\",\"wdname\":\"地区\"},{\"issj\":true,\"nodes\":[{\"code\":\"LAST13\",\"name\":\"最近13个月\",\"sort\":\"4\"},{\"code\":\"LAST24\",\"name\":\"最近24个月\",\"sort\":\"4\"},{\"code\":\"LAST36\",\"name\":\"最近36个月\",\"sort\":\"4\"}],\"selcode\":\"last13\",\"wdcode\":\"sj\",\"wdname\":\"时间\"}]}";
                List<string> city_code = new List<string>();
                Dictionary<string, string> city_dict = new Dictionary<string, string>();
                Regex city_codeget = new Regex("code\":\"([0-9]{6})\",\"name\":\"([\\w]+?)\",");
                dataGridView1.Columns[1].HeaderCell.Value = "城市";//第二列为城市
                if (index_choosen.Contains("A0107").ToString() != "True")
                {
                    city_code.Clear();
                    city_dict.Clear();
                    m = city_codeget.Match(city_name30);
                    while (m.Success)
                    {
                        city_code.Add(m.Groups[1].ToString());//生成城市代号
                        city_dict.Add(m.Groups[1].ToString(), m.Groups[2].ToString());//城市代号加入字典
                        count_city++;
                        m = m.NextMatch();
                    }
                }
                else
                {
                    city_code.Clear();
                    city_dict.Clear();
                    m = city_codeget.Match(city_name70);
                    while (m.Success)
                    {
                        city_code.Add(m.Groups[1].ToString());//生成城市代号
                        city_dict.Add(m.Groups[1].ToString(), m.Groups[2].ToString());//城市代号加入字典
                        count_city++;
                        m = m.NextMatch();
                    }
                }
                progressBar1.Maximum = count_city;
                count_row = 0;
                foreach (string city in city_code)
                {
                    output(" 抓取" + city_dict[city] + "数据");
                    count_rowchange = 1;
                    count_city2++;
                    foreach (string index in index_choosen)
                    {
                        switch (comboBox_period.Text)
                        {
                            case "年度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=csnd&rowcode=zb&colcode=sj&wds=%5B%7B%22wdcode%22%3A%22reg%22%2C%22valuecode%22%3A%22" + city + "%22%7D%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457940633101"; period_times = 5; break;
                            case "月度": url = "http://data.stats.gov.cn/easyquery.htm?m=QueryData&dbcode=csyd&rowcode=zb&colcode=sj&wds=%5B%7B%22wdcode%22%3A%22reg%22%2C%22valuecode%22%3A%22" + city + "%22%7D%5D&dfwds=%5B%7B%22wdcode%22%3A%22zb%22%2C%22valuecode%22%3A%22" + index + "%22%7D%5D&k1=1457942380369"; period_times = 13; break;
                        }
                        News = wc.OpenRead(url);
                        Newsr = new StreamReader(News, Encoding.UTF8);
                        string all = Newsr.ReadToEnd(); //最好不要.match(newsr.readtoend())，否则容易第二个match不了（原因未知）
                        m = variablename.Match(all); //匹配变量名
                        int count_year = 0;
                        while (m.Success)
                        {
                            //此处有bug，城市月份数据变量名第二个开始匹配不上
                            if (Regex.IsMatch(m.Groups[1].ToString(), "^[0-9]{1,}[\\w]{0,}$").ToString() == "True")
                            {
                                dataGridView1.Rows[count_year + period_times * count_city2].Cells[0].Value = m.Groups[2].ToString();
                                //为第一列年份或是季度赋值（需再做添加）10年换一个省
                                dataGridView1.Rows[count_year + period_times * count_city2].Cells[1].Value = city_dict[city];
                                count_year++;
                            }
                            else if (Regex.IsMatch(m.Groups[2].ToString(), "^[0-9]{6}").ToString() == "False")
                            {
                                if (count_city2 == 0)
                                {
                                    dataGridView1.Columns[count_col + 2].HeaderCell.Value = m.Groups[1].ToString() + "(" + m.Groups[4].ToString() + ")";//拼接变量名和变量单位
                                    output(" 抓取 " + m.Groups[1].ToString());
                                    count_col++;
                                }
                            }
                            m = m.NextMatch();
                        }
                        m = province_data.Match(all);
                        while (m.Success)
                        {

                            if (m.Groups[3].ToString() == dataGridView1.Rows[0].Cells[0].Value.ToString())//如果该值对应的时间等于第一列第一个值，则换列，可能有其他更好地方法
                            {
                                count_rowchange++;
                                count_row = 0 + period_times * count_city2;
                            }
                            dataGridView1.Rows[count_row].Cells[count_rowchange].Value = m.Groups[4].ToString();//数据导入
                            count_row++;
                            m = m.NextMatch();
                        }
                        News.Close();
                        Newsr.Close();
                    }
                    progressBar1.Value++;
                }
            }

            dt2 = (dataGridView1.DataSource as DataTable);
            output(" 爬取完成,用时" + (Convert.ToDouble(stw.Elapsed.TotalMilliseconds)/1000).ToString()+"秒");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_choosen.Text = "";
            index_choosen.Clear();
            dataGridView1.DataSource = null;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void comboBox_area_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_area.Text == "主要城市")
            {
                comboBox_period.Items.Clear();
                comboBox_period.Items.Add("年度");
                comboBox_period.Items.Add("月度");
            }
            else
            {
                comboBox_period.Items.Clear();
                comboBox_period.Items.Add("年度");
                comboBox_period.Items.Add("季度");
                comboBox_period.Items.Add("月度");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.S.dataGridView1.DataSource = dt2;
            //有待修改，列名称转过去
        }
    }
}
