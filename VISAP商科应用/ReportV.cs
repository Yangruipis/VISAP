using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
namespace VISAP商科应用
{
    public class ReportV
    {
        public static void ImportFile(RichTextBox richTextBox1)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "RTF Files|*.rtf|txt Files|*.txt|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                openFileDialog1.FileName = openFileDialog1.FileName;
                if (openFileDialog1.FileName != "")
                {
                    if (Path.GetExtension(openFileDialog1.FileName) == ".rtf")
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }
        public static void ExportFiles(RichTextBox richTextBox1)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word Files|*.doc|RTF Files|*.rtf|txt Files|*.txt|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((System.IO.Path.GetExtension(saveFileDialog1.FileName)).ToLower() == ".txt")
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else if ((System.IO.Path.GetExtension(saveFileDialog1.FileName)).ToLower() == ".doc")
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(richTextBox1.Rtf);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName,RichTextBoxStreamType.RichText);
                }
            }
        }
        public static void ChangeFontStyle(FontStyle style, RichTextBox richTextBox1)
        {
            if (style != FontStyle.Bold && style != FontStyle.Italic &&
                style != FontStyle.Underline)
                throw new System.InvalidProgramException("字体格式错误");
            RichTextBox tempRichTextBox = new RichTextBox();  //将要存放被选中文本的副本  
            int curRtbStart = richTextBox1.SelectionStart;
            int len = richTextBox1.SelectionLength;
            int tempRtbStart = 0;
            Font font = richTextBox1.SelectionFont;
            if (len <= 1 && font != null) //与上边的那段代码类似，功能相同  
            {
                if (style == FontStyle.Bold && font.Bold ||
                    style == FontStyle.Italic && font.Italic ||
                    style == FontStyle.Underline && font.Underline)
                {
                    richTextBox1.SelectionFont = new Font(font, font.Style ^ style);
                }
                else if (style == FontStyle.Bold && !font.Bold ||
                         style == FontStyle.Italic && !font.Italic ||
                         style == FontStyle.Underline && !font.Underline)
                {
                    richTextBox1.SelectionFont = new Font(font, font.Style | style);
                }
                return;
            }
            tempRichTextBox.Rtf = richTextBox1.SelectedRtf;
            tempRichTextBox.Select(len - 1, 1); //选中副本中的最后一个文字  
            //克隆被选中的文字Font，这个tempFont主要是用来判断  
            //最终被选中的文字是否要加粗、去粗、斜体、去斜、下划线、去下划线  
            Font tempFont = (Font)tempRichTextBox.SelectionFont.Clone();

            //清空2和3  
            for (int i = 0; i < len; i++)
            {
                tempRichTextBox.Select(tempRtbStart + i, 1);  //每次选中一个，逐个进行加粗或去粗  
                if (style == FontStyle.Bold && tempFont.Bold ||
                    style == FontStyle.Italic && tempFont.Italic ||
                    style == FontStyle.Underline && tempFont.Underline)
                {
                    tempRichTextBox.SelectionFont =
                        new Font(tempRichTextBox.SelectionFont,
                                 tempRichTextBox.SelectionFont.Style ^ style);
                }
                else if (style == FontStyle.Bold && !tempFont.Bold ||
                         style == FontStyle.Italic && !tempFont.Italic ||
                         style == FontStyle.Underline && !tempFont.Underline)
                {
                    tempRichTextBox.SelectionFont =
                        new Font(tempRichTextBox.SelectionFont,
                                 tempRichTextBox.SelectionFont.Style | style);
                }
            }
            tempRichTextBox.Select(tempRtbStart, len);
            richTextBox1.SelectedRtf = tempRichTextBox.SelectedRtf; //将设置格式后的副本拷贝给原型  
            richTextBox1.Select(curRtbStart, len);
        }
        public static void InsertImage(RichTextBox MainBox, MemoryStream ms, int RecordButton)
        {
            //chart_basic.SaveImage(ms, ChartImageFormat.Jpeg);
            Bitmap m = new Bitmap(ms);
            //复制到粘贴板
            Clipboard.SetImage(m);
            //这种做法会使得粘帖板上原有内容丢失
            if (RecordButton == 0)
            {
                MainBox.AppendText("\r\n");
                MainBox.Select();//让RichTextBox获得焦点
                MainBox.Select(MainBox.TextLength, 0);//将插入符号置于文本结束处 
                MainBox.ScrollToCaret();
                MainBox.Paste();
            }
            else
            {
                try
                {
                    MainBox.Rtf = Report.ReportText.richTextBox1.Rtf;
                    MainBox.AppendText("\r\n");
                    MainBox.Select();//让RichTextBox获得焦点
                    MainBox.Select(MainBox.TextLength, 0);//将插入符号置于文本结束处 
                    MainBox.ScrollToCaret();
                    MainBox.Paste();
                    Report.ReportText.richTextBox1.Rtf = MainBox.Rtf;
                }
                catch (Exception ex)
                {

                }
            }
        }
        public static void InsertText(RichTextBox MainBox, string Information, int RecordButton)
        {
            if (RecordButton == 0)
            {
                MainBox.AppendText("\r\n");
                MainBox.AppendText(Information);
            }
            else
            {
                try
                {
                    MainBox.Rtf = Report.ReportText.richTextBox1.Rtf;
                    MainBox.AppendText("\r\n");
                    MainBox.AppendText(Information);
                    Report.ReportText.richTextBox1.Rtf = MainBox.Rtf;
                }
                catch (Exception ex)
                {

                }
        }
    }
}}
