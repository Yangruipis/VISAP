using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Web.UI;
using System.Drawing;
namespace VISAP商科应用
{
    public class Tabulation
    {
        public static DataTable NewTable(int NumRows, int NumCols){
            //NewTable的作用是创建一张空白表格
            //NumRows为添加的行数，NumCols为添加的列数
            DataTable dt = new DataTable();
            int i;
            for (i = 0; i < NumCols; i++)
            {
                dt.Columns.Add("");
            }
            //添加列
            //默认会添加Colum1，Colum2，……
            for (i = 0; i < NumRows; i++)
            {
                dt.Rows.Add("");
            }
            //添加行
            //要多少列和行就add多少就好
            return dt;
        }
		
        public static DataTable ImportExcel(string filePath, string SheetName)
        {
            //该函数的目的是为了导入Excel表格，并返回DataTable
            //根据路径打开一个Excel文件并将数据填充到DataSet中
            //filePath为文件路径，SheetName为表格名称
            string strConn = "";
            if (Path.GetExtension(filePath) == ".xls")
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";
            }
            else
            {
                //strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0;", path);
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";
            }
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";//导入时包含Excel中的第一行数据，并且将数字和字符混合的单元格视为文本进行导入
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            //strExcel = "select  * from   [sheet1$]";
            strExcel = "select  * from   [" + SheetName + "$]";
            //在这里选择Excel表格的名称
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            //根据DataGridView的列构造一个新的DataTable
            DataTable tb = new DataTable();
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                DataColumn dc = new DataColumn();
                //dc.DataType = dgvc.ValueType;//若需要限制导入时的数据类型则取消注释，前提是DataGridView必须先绑定一个数据源那怕是空的DataTable
                tb.Columns.Add(dc);
            }

            //根据Excel的行逐一对上面构造的DataTable的列进行赋值
            foreach (DataRow excelRow in ds.Tables[0].Rows)
            {
                int i = 0;
                DataRow dr = tb.NewRow();
                foreach (DataColumn dc in tb.Columns)
                {
                    dr[dc] = excelRow[i];
                    i++;
                }
                tb.Rows.Add(dr);
            }
            //在DataGridView中显示导入的数据
            //dgv.DataSource = tb;
            return tb;
            //返回DataTable
        }
        /*public static DataTable ImportCSV()
        {
            string fileToLoad = " ";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "csv文件(*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileToLoad = openFileDialog1.FileName;
                //LoadFromCSVFile(fileToLoad);
                return LoadFromCSVFile(fileToLoad); ;
            }
            else
            {
                return null;
            }
        }*/
        public static DataTable LoadFromCSVFile(string pCsvPath,char[] separators)
        {
            //separators为分割方式
            DataTable dt = new DataTable();
            try
            {
                String line;
                String[] split = null;
                DataRow row = null;
                StreamReader sr = new StreamReader(pCsvPath, System.Text.Encoding.Default);
                //创建与数据源对应的数据列 
                line = sr.ReadLine();
                //split = line.Split(',');
                split = line.Split(separators);
                foreach (String colname in split)
                {
                    dt.Columns.Add(colname, System.Type.GetType("System.String"));
                }
                //将数据填入数据表 
                int j = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    j = 0;
                    row = dt.NewRow();
                    //split = line.Split(',');
                    split = line.Split(separators);
                    foreach (String colname in split)
                    {
                        row[j] = colname;
                        j++;
                    }
                    dt.Rows.Add(row);
                }
                sr.Close();
                //显示数据 
                //this.dataGridView1.DataSource = table.DefaultView;
                return dt;
            }
            catch (Exception vErr)
            {
                MessageBox.Show(vErr.Message);
                return null;
            }
            finally
            {
                GC.Collect();
            }
        }
        public static void ExportCSV(DataTable dt)
        {
            string path = "";

            //File info initialization
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Title = "csv文件";
            ofd.FileName = "";
            ofd.RestoreDirectory = true;
            ofd.CreatePrompt = true;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "csv文件(*.csv)|*.csv";
            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }
            if (strName == "")
            {
                MessageBox.Show("没有选择Excel文件！无法进行数据导入");
                return;
            }
            path = strName;



            System.IO.FileStream fs = new FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            //Tabel header
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i].ColumnName);
                sw.Write("\t");
            }
            sw.WriteLine("");
            //Table body
            int dtRowsCount= dt.Rows.Count;
            int dtColumnsCount = dt.Columns.Count;
            for (int i = 0; i < dtRowsCount; i++)
            {
                for (int j = 0; j < dtColumnsCount; j++)
                {
                    //sw.Write(DelQuota(dt.Rows[i][j].ToString()));
                    sw.Write(dt.Rows[i][j].ToString());
                    sw.Write("\t");
                }
                sw.WriteLine("");
            }
            sw.Flush();
            sw.Close();
            DownLoadFile(path);
        }

        private static bool DownLoadFile(string _FileName)
        {
            //导出CSV文件需要使用该函数
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(_FileName);
                byte[] FileData = new byte[fs.Length];
                fs.Read(FileData, 0, (int)fs.Length);
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.AddHeader("Content-Type", "application/notepad");
                string FileName = System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(_FileName));
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + System.Convert.ToChar(34) + FileName + System.Convert.ToChar(34));
                System.Web.HttpContext.Current.Response.AddHeader("Content-Length", fs.Length.ToString());
                System.Web.HttpContext.Current.Response.BinaryWrite(FileData);
                fs.Close();
                System.IO.File.Delete(_FileName);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
                return true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }
        private static string DelQuota(string str)
        {
            //Delete special symbol
            //导出CSV文件需要使用该函数
            string result = str;
            string[] strQuota = { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "`", ";", "'", ",", ".", "/", ":", "/,", "<", ">", "?" };
            for (int i = 0; i < strQuota.Length; i++)
            {
                if (result.IndexOf(strQuota[i]) > -1)
                    result = result.Replace(strQuota[i], "");
            }
            return result;
        }

        public static void ExportExcel(DataTable MainDT)
        {
            //用于导出Excel文件
            //参数为dataGridView
            #region
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName == "")
                return;
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            string str = "";
            try
            {
                for (int i = 0; i < MainDT.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += MainDT.Columns[i].ColumnName;
                }
                sw.WriteLine(str);
                //行数减去1
                for (int j = 0; j < MainDT.Rows.Count; j++)
                {
                   
                    string tempStr = "";
                    for (int k = 0; k < MainDT.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += MainDT.Rows[j][k].ToString();
                    }
                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
            #endregion
        }
        public static string GetGridCols(DataGridView dataGridView1){
            int selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            int[] ColumnsChosen = new int[selectedCellCount];
            //声明数组，长度为选中的单元格数量
            ColumnsChosen = ColumnsSelected(dataGridView1);
            //单元格的列数不可能超过单元格数量
            string AllSelectedCol = "";
            int Record_Zero = 0;
            //对列数做记录
            if (ColumnsChosen != new int[] { -1, -1, -1, -1 })
            {
                Array.Sort(ColumnsChosen);
                //对列数进行排序
                for (int i = 0; i < selectedCellCount; i++)
                {
                    if (ColumnsChosen[i] >= 0)
                    {
                        Record_Zero = i;
                        //如果发现大于0的列数，则跳出循环
                        //之所以这样操作，原因在于，有可能一些数组中元素因空缺被赋值为-1
                        //所以要记录从何时开始为0，即第一列
                        break;
                    }
                }
                for (int i = Record_Zero; i < selectedCellCount; i++)
                {
                    if (i == Record_Zero)
                    {
                        AllSelectedCol = (ColumnsChosen[i] + 1).ToString();

                    }
                    else
                    {
                        AllSelectedCol = AllSelectedCol + "," + (ColumnsChosen[i] + 1).ToString();
                    }
                }
            }
            return AllSelectedCol;
        }
        private static int[] ColumnsSelected(DataGridView dataGridView1)
        {
            int counts = 0;
            int UseToIdentify = 0;
            int countforNew = 0;
            int selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                int[] ColumnsChosen = new int[selectedCellCount];
                for (int i = 0; i < selectedCellCount; i++)
                {
                    ColumnsChosen[i] = -100;
                }
                if (dataGridView1.AreAllCellsSelected(true))
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        counts = 0;
                        foreach (int EachCol in ColumnsChosen)
                        {
                            if (EachCol == i)
                            {
                                counts++;
                                break;
                            }
                        }
                        if (counts == 0)
                        {
                            ColumnsChosen[i] = i;

                        }
                        else
                        {
                            ColumnsChosen[i] = -100;
                        }

                    }

                }
                else
                {
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        UseToIdentify = dataGridView1.SelectedCells[i].ColumnIndex;
                        counts = 0;
                        foreach (int EachCol in ColumnsChosen)
                        {
                            if (EachCol == UseToIdentify)
                            {
                                counts++;
                                break;
                            }
                        }
                        if (counts == 0)
                        {
                            ColumnsChosen[countforNew] = UseToIdentify;
                            countforNew++;
                        }
                        else
                        {
                            ColumnsChosen[countforNew] = -100;
                            countforNew++;
                        }
                    }
                }
                return ColumnsChosen;
            }
            return new int[] { -1, -1, -1, -1 };
        }
        public static string GetColsName(DataGridView dataGridView1,string ColNums)
        {
            char [] separator = {','};
            //string是以逗号分隔的
            string[] AllNum = ColNums.Split(separator);
            //按照逗号分割
            string AllNames ="";
            foreach (string SingleNum in AllNum){
                if (SingleNum != ""){
                    if (MathV.IsStringInt(SingleNum))
                    {
                        AllNames += dataGridView1.Columns[Convert.ToInt32(SingleNum) - 1].Name + ",";
                    }
                }
            }
            if (AllNames != ""){
                AllNames = AllNames.Substring(0,AllNames.Length -1);
            }
            return AllNames;
        }
        public static List<string> ReadVector(DataTable MainDT, int ColNum){
            List <string> Values= new List <string>();
            int RowsCount = MainDT.Rows.Count;
            for (int i = 0; i < MainDT.Rows.Count; i++)
            {
                //if (MainDT.Rows[i][ColNum].ToString() != "")
                    Values.Add(MainDT.Rows[i][ColNum].ToString());
            }
            return Values;
        }
        public static DataTable GetSubset(DataTable OriginDT, string Cols)
        {
            DataTable NewDT = new DataTable();
            //OriginDT = dataGridView1.DataSource as DataTable;
            if (OriginDT == null)
            {
                return null;
            }
            DataColumn AddCol = new DataColumn();
            char[] separator = { ',' };
            string UseToAddCol = "";
            int AddTimes = 1;
            string[] ColWanted = Cols.Split(separator);
            int OriginRowsCount = OriginDT.Rows.Count;
            int OriginColsCount = OriginDT.Columns.Count;
            if (OriginDT != null)
            {
                for (int q = 0; q < OriginRowsCount; q++)
                {
                    NewDT.Rows.Add();
                }
                for (int i = 0; i < OriginColsCount; i++)
                {
                    foreach (string EachCol in ColWanted)
                    {
                        if (Convert.ToInt32(EachCol) - 1 == i)
                        {
                            NewDT.Columns.Add(OriginDT.Columns[i].ColumnName);
                            for (int m = 0; m < OriginDT.Rows.Count; m++)
                            {
                                UseToAddCol = OriginDT.Rows[m].ItemArray[i].ToString();
                                NewDT.Rows[m][OriginDT.Columns[i].ColumnName] = UseToAddCol;
                                AddTimes++;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                return null;
            }
            return NewDT;
        }
        public static int FindCol(DataTable dt,string ID)
        {
            return dt.Columns.IndexOf(ID);
        }
        public static bool IsStrDouble(string Str)
        {
            //判断一个字符串是否为双浮点型
            if (Str.Trim() == "")
            {
                //为空则不作判断
                return false;
            }
            if (Str.Contains('E'))
            {
                int position = Str.IndexOf('E');
                if (Str.Length == position +1)
                {
                    //E
                    return false;
                }
                if (Str[position + 1] != '+' && Str[position + 1] != '-')
                {
                    return false;
                }
                else if (position + 2 == Str.Length - 1)
                {
                    //如果加号或减号后面什么都没有，则判定为非数字
                    return false; 
                }
                if (Str.Substring(0, position - 1).Contains('E') || Str.Substring(position + 1, Str.Length - position - 1).Contains('E'))
                {
                    return false;
                }
                if (IsStrDouble(Str.Substring(0, position - 1)) && IsStrDouble(Str.Substring(position + 2, Str.Length - position - 2)))
                    //这里加2主要是为了去掉符号
                    //例：3.0E+12
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int DecimalTimes = 0;
                //计算小数点出现的次数，最高不得超过一次
                for (int i = 0; i < Str.Length; i++)
                {
                    if (i == 0 && Str[0] == '-')
                    {
                        continue;
                    }
                    if (i == 0 && Str[0] == '+')
                    {
                        continue;
                    }
                    if (Str[i] == '1' || Str[i] == '2' 
                        ||Str[i] == '3' ||Str[i] == '4' 
                        ||Str[i] == '5' ||Str[i] == '6' 
                        ||Str[i] == '7' ||Str[i] == '8' ||
                        Str[i] == '9' || Str[i] == '0')
                    {
                        continue;
                    }
                    if (DecimalTimes > 1)
                    {
                        return false;
                    }
                    if (Str[i] == '.')
                    {
                        DecimalTimes++;
                        continue;
                    }
                    return false;
                }
                return true;
            }
        }
        public static void DataType(DataGridView datagridview1)
        {
            //这个函数的作用是分辨每一列的数据类型，并对字体进行变色
            //遍历datagridview每一个单元格
            for (int j = 0; j < datagridview1.Columns.Count; j++ )
            {
                for (int i = 0; i < datagridview1.Rows.Count - 1; i++)
                {
                    if (datagridview1.Rows[i].Cells[j].Value.ToString() != null && datagridview1.Rows[i].Cells[j].Value.ToString().Trim() != "")
                    {
                        if (!IsStrDouble(datagridview1.Rows[i].Cells[j].Value.ToString()))
                        {
                            //如果单元格内容为字符串
                            datagridview1.Columns[j].DefaultCellStyle.ForeColor = Color.Firebrick;
                            //整列设置为深红色，然后跳出内层循环
                            break;
                        }
                    }
                }
            }
        }
        /*public static DataTable BulkImportCSV(){
            //批量导入CSV文件
             OpenFileDialog openFileDialog1 = new OpenFileDialog();
             openFileDialog1.InitialDirectory = "c:\\";
             openFileDialog1.Filter = "csv文件(*.csv)|*.csv";
             openFileDialog1.FilterIndex = 2;
             openFileDialog1.RestoreDirectory = true;
             openFileDialog1.Multiselect = true;
             if (openFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 DataTable dt = new DataTable();
                 string[] files = openFileDialog1.FileNames.ToArray();
                 foreach (string EachFile in files)
                 {
                     //dt.Merge(LoadFromCSVFile(EachFile));
                 }
                 return dt;
             }
             return null;

        }*/
        public static void InitDataSet(DataTable dtInfo, ref int nMax, ref int pageCount, ref  int pageCurrent,
            ref  int nCurrent, Label label_CurrentPage, Label label_TotalPage, DataGridView dataGridView1,TextBox textBox_CurrentPage,int pageSize = 1000)
        {
            pageSize = 1000;      //设置页面行数
            nMax = dtInfo.Rows.Count;

            pageCount = (nMax / pageSize);    //计算出总页数

            if ((nMax % pageSize) > 0) pageCount++;

            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始

            LoadData(dtInfo,ref pageCurrent,ref pageCount,ref nMax,ref pageSize,ref nCurrent, textBox_CurrentPage,
            label_CurrentPage,label_TotalPage, dataGridView1);
        }
        public static void LoadData(DataTable dtInfo, ref int pageCurrent,ref int pageCount, ref int nMax,
            ref int pageSize, ref int nCurrent, TextBox textBox_CurrentPage,
            Label label_CurrentPage,Label TotalPage,DataGridView dataGridView1)
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行

            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

            if (pageCurrent == pageCount)
                nEndPos = nMax;
            else
                nEndPos = pageSize * pageCurrent;

            nStartPos = nCurrent;

            TotalPage.Text = "共"+pageCount.ToString()+"页,每页"+pageSize.ToString()+"行";
            textBox_CurrentPage.Text = Convert.ToString(pageCurrent);
            label_CurrentPage.Text = Convert.ToString(pageCurrent);
            //从元数据源复制记录行
            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nCurrent++;
            }
            dataGridView1.DataSource = dtTemp;
        }
        public static DataTable Transposition(DataTable dt,DataTable OriginDT,bool Replace = false)
        {
            //转置DataTable
            //原始DataTable为dt
            //新的DataTable为dtNew
            //Replace属性是指替换原表格还是合并在原表格右边
            //true表示替换，false表示添加
            DataTable dtNew = new DataTable();
            int OriginRowsCount = dt.Rows.Count;
            int OriginColsCount = dt.Columns.Count;
            foreach (DataRow dr in dt.Rows)
            {
                    dtNew.Columns.Add("");
            }
            foreach (DataColumn dc in dt.Columns)
            {
                dtNew.Rows.Add("");
            }
            for (int i = 0; i < OriginColsCount; i++)
            {
                for (int j = 0; j < OriginRowsCount;j++)
                {
                    dtNew.Rows[i][j] = dt.Rows[j].ItemArray[i];
                }
            }
            if (Replace)
            {
                return dtNew;
            }
            else
            {
               int NewRowsCount = OriginDT.Rows.Count;
               for (int i = 0; NewRowsCount + i < OriginColsCount; i++)
                    {
                        //添加需要的行
                        OriginDT.Rows.Add("");
                    }
                
                for (int m = 0; m < OriginRowsCount;m++)
                {
                    OriginDT.Columns.Add("");
                    for (int i = 0; i < OriginColsCount; i++)
                    {
                        OriginDT.Rows[i][OriginDT.Columns.Count - 1] = dtNew.Rows[i][m];
                    }
                }
                return OriginDT;
            }
                
        }
        public static DataTable GetChosenTable(DataTable MainDT,DataGridView dataGridView1)
        {
            //获得用户选中的单元格
            //根据单元格所在行，读取相应的行，拼接成一个DataTable
            DataTable dt = new DataTable();
            List<int> AllRows = new List<int>();
            int OriginCols = MainDT.Columns.Count;
            for (int i = 0; i < OriginCols; i++)
            {
                dt.Columns.Add("");
            }
            int AllCellsNum = dataGridView1.SelectedCells.Count;
            for (int i = 0; i < AllCellsNum; i++)
            {
                AllRows.Add(dataGridView1.SelectedCells[i].RowIndex);
            }
            AllRows = AllRows.Distinct().ToList();
            AllRows.Sort();
            int count = 0;
            foreach (int EachRow in AllRows)
            {
                dt.Rows.Add("");
                for (int i = 0; i < MainDT.Columns.Count; i++)
                {
                    dt.Rows[count][i] = MainDT.Rows[EachRow].ItemArray[i];

                }
                count++;
            }
            return dt;
        }
        public static void DeleteContent(ref DataTable MainDT, DataGridView dataGridView1, int RowOrCol = 0)
        {
            //RowOrCol = 0删除行
            //RowOrCol = 1删除列
            List<int> AllIndex = new List<int>();
            int AllCellsNum = dataGridView1.SelectedCells.Count;
            for (int i = 0; i < AllCellsNum; i++)
            {
                if (RowOrCol == 0)
                {
                    AllIndex.Add(dataGridView1.SelectedCells[i].RowIndex);
                }
                else
                {
                    AllIndex.Add(dataGridView1.SelectedCells[i].ColumnIndex);
                }
            }
            AllIndex = AllIndex.Distinct().ToList();
            AllIndex.Sort();
            int Length = AllIndex.Count;
            for (int i = Length - 1;i >=0;i--)
            {
                if (RowOrCol == 0)
                {
                    MainDT.Rows.RemoveAt(AllIndex[i]);
                }
                else
                {
                    MainDT.Columns.RemoveAt(AllIndex[i]);
                }
            }
            return;
        }
        public static void DeleteCellContent(ref DataTable MainDT, DataGridView dataGridView1)
        {
            int AllCellsNum = dataGridView1.SelectedCells.Count;
            for (int i = 0; i < AllCellsNum; i++){
                MainDT.Rows[dataGridView1.SelectedCells[i].RowIndex][dataGridView1.SelectedCells[i].ColumnIndex] = "";
            }
            return;
        }
        public static DataTable DataTableSplit(DataTable MainDT,char[] separators,int Col)
        {
            int RowsCount = MainDT.Rows.Count;
            int ColsCount = MainDT.Columns.Count;
            //DataTable dt = new DataTable();
            int dtNewCols = 0;
            int len = 0;
            int AddTimes = 0;
            dtNewCols = 0;
            int m = 0;
            //List<string> Strs = new List<string>();
            for (int i = 0; i < RowsCount; i++)
            {
                string [] Strs = MainDT.Rows[i][Col].ToString().Split(separators);
                len = Strs.Length;
                //dtNewCols = dt.Columns.Count;

                if (dtNewCols < len)
                {
                    for (m = 0; dtNewCols + m < len; m++)
                    {
                        MainDT.Columns.Add("");
                        
                    }
                    dtNewCols = dtNewCols +m;
                }
                AddTimes = 0;
                foreach (string EachStr in Strs){
                    MainDT.Rows[i][ColsCount+AddTimes] = EachStr;
                    AddTimes++;
                }
            }
            return MainDT;
        }
        public static void RenewColsItems(DataTable dt, ComboBox comBox1)
        {
            int ColNums = dt.Columns.Count;
            string [] ColNames = new string [ColNums];
            for (int i = 0; i < ColNums; i++){
                ColNames[i]= dt.Columns[i].ColumnName;
            }
            comBox1.Items.Clear();
            foreach (string EachCol in ColNames)
            {
                comBox1.Items.Add(EachCol);
            }
        }
        public static bool IdentifyNARow(DataTable dt,int RowsNum, int[] ColsOfVariables)
        {
            //用于确认是否有空缺行
            int ColsCount = dt.Columns.Count;
            foreach (int num in ColsOfVariables)
            {
                        if (MainForm.MainDT.Rows[RowsNum][num].ToString().Trim() == "")
                        {
                            return false;
                            //发现空格
                        }
                }
            return true;
            //未发现空格
        }
        public static string[] Classification(DataTable dt,int ColNum){
            int RowsCount = dt.Rows.Count;
            List<string> Information = new List<string>();
            string Temp = "";
            for (int i = 0; i < RowsCount; i++)
            {
                Temp = dt.Rows[i][ColNum].ToString().Trim();
                if (Temp != "")
                {
                    Information.Add(Temp);
                }
                
            }
            return Information.Distinct().ToArray();
        }
        public static int[] LikilihoodCount(string[] Classification,DataTable dt,int ColNum)
        {
            //二项分布或多项分布似然函数
            //Classification为分类，CountTimes用于计数
            int RowsCount = dt.Rows.Count;
            int[] CountTimes = new int[Classification.Length];
            string Temp = "";
            int Index = 0;
            List<string>AllClass = Classification.ToList();
            for (int i = 0; i < RowsCount; i++)
            {
                Temp = dt.Rows[i][ColNum].ToString().Trim();
                Index = AllClass.IndexOf(Temp);
                if (Index!=-1)
                {
                    CountTimes[Index]++;
                }
            }
            return CountTimes;
        }
    }
}
