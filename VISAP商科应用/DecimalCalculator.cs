using System;
using System.Collections.Generic;

using System.Text;

namespace VISAP商科应用
{
    /// <summary>小数次幂的运算</summary>
    class DecimalPowerCalculator
    {

        /// <summary>开方</summary>
        static internal BigNumber Sqrt(BigNumber value, int precision) {
            if (!value.IsPlus)
                throw new ExpressionException("只有正数才有开平方运算");

            List<int> div = new List<int>();
            int index = 0;
            int resultIntCount = (value.IntPart.Count + 1) / 2;

            List<int> result = GetFirstDiv(value, ref div, ref index);

            div = FirstTry(result, div);
            div.AddRange(GetNewTwoDiv(value, ref index));
            BigCalculate.RemoveStartZero(div);
            //考虑精度的计算
            while (true) {
                div = TryDiv(div, result);
                if (result.Count - resultIntCount >= precision)
                    break;

                div.AddRange(GetNewTwoDiv(value, ref index));
                BigCalculate.RemoveStartZero(div);
            }

            return new BigNumber(result.GetRange(0, resultIntCount), result.GetRange(resultIntCount, result.Count - resultIntCount), true);
        }

        /// <summary>获取第一个除数</summary>
        static List<int> GetFirstDiv(BigNumber value, ref List<int> div, ref int index) {
            //这里有待加入对0.02和0.002的考虑
            if (value.IntPart.Count == 1 && value.IntPart[0] == 0) {
                List<int> result = new List<int>();
                result.Add(0);
                while (true) {
                    if (value.DecimalPart[index] != 0) {
                        for (int i = 0; i < index / 2; i++) {
                            result.Add(0);
                        }
                        //0.005
                        if (index % 2 == 0) {
                            div.Add(value.DecimalPart[index]);
                            if (index + 1 < value.DecimalPart.Count) {
                                div.Add(value.DecimalPart[index + 1]);
                            } else {
                                div.Add(0);
                            }
                        }
                            //0.05
                        else {
                            div.Add(value.DecimalPart[index]);
                        }
                        index++;
                        break;
                    }
                    index++;
                    if (index == value.DecimalPart.Count)
                        break;
                }
                index++;
                return result;
            } else {
                //如果是偶数则第一次取两位
                if (value.IntPart.Count % 2 == 0) {
                    div = value.IntPart.GetRange(0, 2);
                    index = 2;
                }
                    //是奇数则只取一位
                else {
                    div = value.IntPart.GetRange(0, 1);
                    index = 1;
                }
                return new List<int>();
            }
        }

        /// <summary>第一次用开方尝试</summary>
        private static List<int> FirstTry(List<int> result, List<int> div) {
            int tryDiv = BigNumber.Max / 2;
            int low = 1;
            int top = BigNumber.Max - 1;
            //第一位数是1

            //第一用平方试商
            while (true) {
                if (BigCalculate.CompareList(new List<int>() { 1 }, div) == 0) {
                    div = BigCalculate.IntMinus(div, new List<int>() { 1 });
                    result.Add(1);
                    break;
                }
                //连9都小了，那么就是9
                if (BigCalculate.CompareList(BigCalculate.Multiply(BigNumber.Max - 1, BigNumber.Max - 1), div) == -1) {
                    div = BigCalculate.IntMinus(div, BigCalculate.Multiply(BigNumber.Max - 1, BigNumber.Max - 1));
                    result.Add(BigNumber.Max - 1);
                    break;
                }
                int c = BigCalculate.CompareList(BigCalculate.Multiply(tryDiv, tryDiv), div);
                //商大了
                if (c == -1) {
                    low = tryDiv;
                    tryDiv = (low + top) / 2;

                } else if (c == 1) { //商小了
                    top = tryDiv;
                    tryDiv = (low + top) / 2;

                } else { //刚好相等
                    div.Clear();
                    result.Add(tryDiv);
                    break;
                }

                if (low + 1 == top) {
                    div = BigCalculate.IntMinus(div, BigCalculate.Multiply(low, low));
                    result.Add(low);
                    break;
                }
            }
            return div;
        }

        /// <summary>获取新的2数字组</summary>
        static List<int> GetNewTwoDiv(BigNumber value, ref int index) {
            List<int> two = new List<int>();
            //正数部分
            if (index <= value.IntPart.Count - 2) {
                two.AddRange(value.IntPart.GetRange(index, 2));
            }
                //已到小数部分
            else {
                if (index - value.IntPart.Count <= value.DecimalPart.Count - 2) {
                    two.AddRange(value.DecimalPart.GetRange(index - value.IntPart.Count, 2));
                } else if (index - value.IntPart.Count == value.DecimalPart.Count - 1) {
                    two.Add(value.DecimalPart[value.DecimalPart.Count - 1]);
                    two.Add(0);
                } else {
                    two.Add(0);
                    two.Add(0);
                }
            }
            index += 2;
            return two;
        }

        /// <summary>执行一次试商的运算</summary>
        /// <param name="div">已经加组的被除数</param>
        /// <param name="result">已生成的结果</param>
        static List<int> TryDiv(List<int> div, List<int> result) {
            int i = BigNumber.Max / 2;
            int low = 0;
            int top = BigNumber.Max - 1;
            //连1都大了,那么商为0，除数不变
            if (CompartDiv(1, result, div) == 1) {
                result.Add(0);
                return div;
            }
            //连9999都小了
            if (CompartDiv(BigNumber.Max - 1, result, div) == -1) {
                List<int> r = BigCalculate.IntMinus(div, CalDiv(BigNumber.Max - 1, result));
                result.Add(BigNumber.Max - 1);
                return r;
            }

            while (true) {

                int c = CompartDiv(i, result, div);
                //商大了
                if (c == 1) {
                    top = i;
                    i = (low + top) / 2;
                }
                    //商小了
                else if (c == -1) {
                    low = i;
                    i = (low + top) / 2;
                }
                    //刚好相等
                else {
                    //div.Clear();
                    result.Add(i);
                    return new List<int>();
                }
                //已找到合适的商
                if (low + 1 == top) {
                    List<int> r = BigCalculate.IntMinus(div, CalDiv(low, result));
                    result.Add(low);
                    return r;
                }
            }
        }

        /// <summary>对除数进行比较</summary>
        static int CompartDiv(int x, List<int> result, List<int> div) {
            return BigCalculate.CompareList(CalDiv(x, result), div);
        }

        /// <summary>计算x(x+20*result)的值</summary>
        static List<int> CalDiv(int x, List<int> result) {
            List<int> result20 = BigCalculate.Multiply(new List<int>() { BigNumber.Max * 2 }, result);
            List<int> add = BigCalculate.IntAdd(new List<int>() { x }, result20, 0);
            List<int> r = BigCalculate.Multiply(new List<int>() { x }, add);

            return r;
        }

        /// <summary>开2的N次方</summary>
        static internal BigNumber Root(BigNumber value, int n, int precison) {
            BigNumber result = value;

            for (int i = 0; i < n; i++) {
                result = Sqrt(result, precison + 1);
            }
            return result;
        }

        private static BigNumber Sqrt(BigNumber value) {
            throw new NotImplementedException();
        }

        /// <summary>计算value^pow</summary>
        static internal BigNumber Power(BigNumber value, BigNumber pow, int precision) {
            if (pow.DecimalPart.Count != 0 && !value.IsPlus)  //第一个条件是小数次幂，第二个条件是负数
                throw new ExpressionException("只有正数才有小数次幂");

            BigNumber result = new BigNumber("1");

            for (BigNumber i = new BigNumber("1"); i.CompareTo(pow) != 1; i++) {
                result = result * value;
            }

            BigNumber two = new BigNumber("2");
            int n = 1;
            BigNumber tt = new BigNumber(new List<int>(), pow.DecimalPart, true) * two;

            while (true) {
                // 如果整数部分为1，那么就得进行一次2^n开方运算
                if (tt.IntPart.Count == 1 && tt.IntPart[0] == 1) {
                    tt.IntPart.Clear();
                    BigNumber r = Root(value, n, precision + 1);

                    if (r.GetPrecision(1) >= precision / BigNumber.OneCount + 2)
                        break;
                    result = result * r;

                } else if (tt.IsZero())
                    break;

                tt = tt * two;
                n++;

            }
            result.KeepPrecision(precision);
            return result;
        }

        internal static BigNumber Power(BigNumber bigNumber, BigNumber value) {
            return Power(bigNumber, value, bigNumber.DecimalPart.Count + 1);
        }

    } // end class
}
