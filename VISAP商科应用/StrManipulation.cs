using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VISAP商科应用
{
    public class StrManipulation
    {
        public static int CountStrLen (string str){
            //这个函数的功能是计算字符串长度
            //一个中文字符看作两个单位的长度
            byte[] sarr = System.Text.Encoding.Default.GetBytes(str);
            //利用byte计算长度
            return sarr.Length;
        }
        public static string PadLeftX(string Str, char ch,int TotalLength)
        {
            
            //该函数在左边补足所需长度
            //Str为需要调整的字符串
            //ch为用于填充的字符
            //TotalLength为希望达到的总长度
            int len = CountStrLen(Str);
            //计算字符串长度
            if (len >= TotalLength)
            {
                return Str;
            }
            else
            {
                int space = TotalLength - len;
                //计算空白个数
                StringBuilder StrX = new StringBuilder();
                string AddStr = new string(ch, space);
                //生成用于补上空缺的字符串
                StrX.Append(AddStr);
                StrX.Append(Str);
                return StrX.ToString();
                //return (AddStr + Str);
                //连接起来即可
            }
        }
        public static string PadRightX(string Str, char ch, int TotalLength)
        {
            //该函数在右边补足所需长度
            //Str为需要调整的字符串
            //ch为用于填充的字符
            //TotalLength为希望达到的总长度
            int len = CountStrLen(Str);
            if (len >= TotalLength)
            {
                return Str;
            }
            else
            {
                int space = TotalLength - len;
                //计算空白个数
                StringBuilder StrX = new StringBuilder(Str);
                string AddStr = new string(ch, space);
                //生成用于补上空缺的字符串
                StrX.Append(AddStr);
                return StrX.ToString();
                //连接起来即可
            }
        }
        public static string VariableNamePolish(string VarName,int Length = 12)
        {
            //这个函数的作用是调整变量名称长度
            VarName = VarName.Trim();
            VarName = VarName.Replace(" ", "_");
            int VarLen = VarName.Length;
            int i = 0;
            int EndSubStr = 0;
            if (CountStrLen(VarName) > Length)
            {

                for (i = 0; i < VarLen; i++)
                {
                    if (CountStrLen(VarName.Substring(0, i)) > Length - 3)
                    {
                        //寻找最合适的长度
                        EndSubStr = i - 1;
                        break;
                    }
                }
                StringBuilder VariableName = new StringBuilder(VarName.Substring(0, EndSubStr));
                VariableName.Append("~");
                VariableName.Append(VarName[VarName.Length - 1]);
                return VariableName.ToString();
            }
            else
            {
                return VarName;
            }
        }
    }
}
