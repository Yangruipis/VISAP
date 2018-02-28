using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
namespace VISAP商科应用
{
    public partial class EasyGraph : Form
    {
        public static EasyGraph EasyGraphForm = null;
        public static DataTable dt = new DataTable();
        public EasyGraph()
        {
            InitializeComponent();
            EasyGraphForm = this;
            if (MainForm.S.dataGridView1.DataSource != null)
            {
                textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            }
        }
        void refresh_Combox()
        {
            comboBox_x.Items.Clear();
            comboBox_y.Items.Clear();
            int ColCounts = dataGridView_subset.ColumnCount;
            for (int i = 0; i < ColCounts; i++)
            {
                comboBox_x.Items.Add(dataGridView_subset.Columns[i].Name);
                comboBox_y.Items.Add(dataGridView_subset.Columns[i].Name);
            }

        }

        

        private void button_refresh_Click(object sender, EventArgs e)
        {
            textBox_ChosenCols.Text = Tabulation.GetGridCols(MainForm.S.dataGridView1);
            
        }

       

        private void button_import_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt = Tabulation.GetSubset(MainForm.MainDT, textBox_ChosenCols.Text);
            dataGridView_subset.DataSource = dt;
            refresh_Combox();
        }

        private void dataGridView_subset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView_subset.CurrentCell.RowIndex;
            label_Row.Text = (rowIndex + 1).ToString();
            int columnIndex = dataGridView_subset.CurrentCell.ColumnIndex;
            label_Column.Text = (columnIndex + 1).ToString();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (comboBox_x.Text.Trim()  != ""){
            QuickPlot.QPlot(dt,chart_basic,
                Tabulation.FindCol(dt, comboBox_x.Text),
                Tabulation.FindCol(dt,comboBox_y.Text),comboBox_type.Text, textBox_Legend.Text,checkBox_IsXLabel.Checked);
            }
            else
            {
                QuickPlot.QPlot(dt, chart_basic,
                -1,
                Tabulation.FindCol(dt, comboBox_y.Text), comboBox_type.Text, textBox_Legend.Text, checkBox_IsXLabel.Checked);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isSave = true;
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "图片保存";
            saveImageDialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif";

            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName.ToString();

                if (fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();

                    System.Drawing.Imaging.ImageFormat imgformat = null;

                    if (fileExtName != "")
                    {
                        switch (fileExtName)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "gif":
                                imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                            default:
                                MessageBox.Show("只能存取为: jpg,bmp,gif 格式");
                                isSave = false;
                                break;
                        }

                    }

                    //默认保存为JPG格式   
                    if (imgformat == null)
                    {
                        imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }

                    if (isSave)
                    {
                        try
                        {
                            chart_basic.SaveImage(fileName, imgformat);
                            //MessageBox.Show("图片已经成功保存!");   
                        }
                        catch
                        {
                            MessageBox.Show("保存失败,你还没有截取过图片或已经清空图片!");
                        }
                    }

                }

            }   
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart_basic.SaveImage(ms, ChartImageFormat.Jpeg);
                Bitmap m = new Bitmap(ms);
                //复制到粘贴板
                Clipboard.SetImage(m);
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart_basic.Series.Clear();
        }

        
        private void button_ImportReport_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            //chart_basic.SaveImage(ms, ChartImageFormat.Jpeg);
            chart_basic.SaveImage(ms, ChartImageFormat.Jpeg);
            ReportV.InsertImage(MainForm.S.rtb,ms,MainForm.S.ReportIsOn);
        }

        private void dataGridView_subset_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int Rows = e.RowIndex;
            int Columns = e.ColumnIndex;
            dt.Rows[Rows][Columns] = dataGridView_subset.Rows[Rows].Cells[Columns].Value;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphSet GraphSetForm = new GraphSet();
            GraphSetForm.ShowDialog();
        }
    }
}
