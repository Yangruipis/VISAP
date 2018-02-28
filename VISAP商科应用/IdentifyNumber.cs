using System;

using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VISAP商科应用
{
    /// <summary>从字符串中识别出大数</summary>
    class IdentifyNumber
    {

        /// <summary>识别出一个大数，返回值为这个是不是正数</summary> 
        public static bool GetBigNumber(string text, List<int> intPart, List<int> decimalPart) {
            ValidateNumber(text);
            bool isPlus = true;
            int haveSym = 0;

            if (text[0] == '-') {
                isPlus = false;
                haveSym = 1;
            } else if (text[0] == '+')
                haveSym = 1;
            int pointIndex = text.IndexOf('.');
            //有小数点
            if (pointIndex != -1) {
                int i = 0;
                if ((pointIndex - haveSym) % BigNumber.OneCount != 0)
                    intPart.Add(Convert.ToInt32(text.Substring(haveSym, (pointIndex - haveSym) % BigNumber.OneCount)));
                for (; i < (pointIndex - haveSym) / BigNumber.OneCount; i++) {
                    intPart.Add(Convert.ToInt32(text.Substring(haveSym + i * BigNumber.OneCount + (pointIndex - haveSym) % BigNumber.OneCount, BigNumber.OneCount)));
                }
                i = pointIndex + 1;
                while (i < text.Length) {
                    if (text.Length - i >= BigNumber.OneCount) {
                        decimalPart.Add(Convert.ToInt32(text.Substring(i, BigNumber.OneCount)));
                    } else {
                        decimalPart.Add(Convert.ToInt32(text.Substring(i, (text.Length - i) % BigNumber.OneCount).PadRight(BigNumber.OneCount, '0')));
                    }
                    i += BigNumber.OneCount;
                }

            }
                //没有小数点
            else {
                if ((text.Length - haveSym) % BigNumber.OneCount != 0)
                    intPart.Add(Convert.ToInt32(text.Substring(haveSym, (text.Length - haveSym) % BigNumber.OneCount)));
                for (int i = 0; i < (text.Length - haveSym) / BigNumber.OneCount; i++) {
                    intPart.Add(Convert.ToInt32(text.Substring(haveSym + i * BigNumber.OneCount + (text.Length - haveSym) % BigNumber.OneCount, BigNumber.OneCount)));
                }

            }
            BigCalculate.RemoveStartZero(intPart);
            if (intPart.Count == 0)
                intPart.Add(0);
            return isPlus;
        }

        static void ValidateNumber(string text) {
            Match m = Regex.Match(text, @"[^\d\.\+-]"); //
            if (m.Success)
                throw new NumberException("含有非法字符", m.Index);
            Match mNum = Regex.Match(text, @"\d");
            if (!mNum.Success)
                throw new NumberException("至少要含有一个数字", 0);
            Match mPlug = Regex.Match(text, @"[\+-]", RegexOptions.RightToLeft);
            if (mPlug.Success && mPlug.Index != 0)
                throw new NumberException("正负号只能在开头", mPlug.Index);
            MatchCollection ms = Regex.Matches(text, @"[\.]");
            if (ms.Count > 1)
                throw new NumberException("不能有一个以上的小数点", ms[1].Index);
            else if (ms.Count == 1 && (ms[0].Index == 0 || ms[0].Index == text.Length - 1))
                throw new NumberException("小数点不能在开头或最后一位", ms[0].Index);
            Match mPoints = Regex.Match(text, @"[\+-]\.");
            if (mPoints.Success)
                throw new NumberException("正负号后不能直接有小数点", mPoints.Index);
        }

    } // end class
} // end namespace
