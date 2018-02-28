using System;
using System.Collections.Generic;
using System.Text;

namespace VISAP商科应用
{
    /// <summary>表示大数的类</summary>
    public class BigNumber : IComparable<BigNumber>
    {
        /// <summary>一位上存储的数位</summary>
        public static readonly int OneCount = 4;

        /// <summary>进位的数</summary>
        public static readonly int Max = (int)Math.Pow(10, OneCount);

        public BigNumber(string text) {
            intPart = new List<int>();
            decimalPart = new List<int>();
            IsPlus = IdentifyNumber.GetBigNumber(text, intPart, decimalPart);
        }

        public BigNumber(List<int> i, List<int> d, bool plus) {
            this.IntPart = i;
            this.DecimalPart = d;
            this.IsPlus = plus;
        }



        #region "属性"
        //整数部分与小数部分都是从左到右存储
        List<int> intPart;
        List<int> decimalPart;

        /// <summary>整数部分 </summary>
        public List<int> IntPart {
            get { return intPart; }
            private set {
                intPart = new List<int>(value);
                //intPart = value;
            }
        }

        /// <summary>整数部分的长度</summary>
        public int IntLength {
            get { return IntPart.Count * OneCount; }
        }

        /// <summary>
        /// 小数部分
        /// </summary>
        public List<int> DecimalPart {
            get { return decimalPart; }
            private set {
                decimalPart = new List<int>(value);
            }
        }
        /// <summary>小数部分的实际长度</summary>
        public int DecimalLength {
            get { return DecimalPart.Count * OneCount; }
        }

        /// <summary>返回0.00001这样的数小数点后、有效数前有几个零</summary>
        internal int GetPrecision(int value) {
            if (value == 0) {
                BigCalculate.RemoveStartZero(IntPart);
                if (IntPart.Count == 1 && IntPart[0] == 0) {
                    if (DecimalPart.Count == 0)
                        return 0;
                    for (int i = 0; i < DecimalPart.Count; i++) {
                        if (DecimalPart[i] != 0)
                            return i;
                    }
                    return DecimalPart.Count;
                }
                return 0;
            } else {
                if (IntPart.Count == 1 && IntPart[0] == 1) {
                    if (DecimalPart.Count == 0)
                        return 0;
                    for (int i = 0; i < DecimalPart.Count; i++) {
                        if (DecimalPart[i] != 0)
                            return i;
                    }
                    return DecimalPart.Count;
                }
                return 0;
            }
        }

        /// <summary>
        /// 是否是正数
        /// </summary>
        public bool IsPlus { get; set; }

        /// <summary>
        /// 返回此实例的绝对值
        /// </summary>
        public BigNumber AbsoluteNumber {
            get { return new BigNumber(IntPart, DecimalPart, true); }
        }

        /// <summary>
        /// 返回此实例的相反数
        /// </summary>
        public BigNumber ReverseNumber {
            get { return new BigNumber(IntPart, DecimalPart, !IsPlus); }
        }

        /// <summary>大数中的零对象</summary>
        public static BigNumber Zero {
            get {
                List<int> intlist = new List<int>();
                List<int> decimallist = new List<int>();
                intlist.Add(0);
                return new BigNumber(intlist, decimallist, true);
            }
        }

        public BigNumber Clone() {
            return new BigNumber(IntPart, DecimalPart, IsPlus);
        }

        /// <summary>保留小数点后n位</summary>
        public void KeepPrecision(int n) {
            if (this.DecimalPart.Count > n) {
                this.DecimalPart.RemoveRange(n, DecimalPart.Count - n);
            }
        }

        #endregion

        #region "重载运算符"
        public static BigNumber operator +(BigNumber a, BigNumber b) {
            return BigCalculate.Add(a, b);
        }
        public static BigNumber operator +(int a, BigNumber b) {
            return (new BigNumber(a.ToString())) + b;
        }
        public static BigNumber operator -(BigNumber a, BigNumber b) {
            return BigCalculate.Minus(a, b);
        }
        public static BigNumber operator *(BigNumber a, BigNumber b) {
            return BigCalculate.Multiply(a, b);
        }
        public static BigNumber operator *(int a, BigNumber b) {
            return (new BigNumber(a.ToString())) * b;
        }
        public static BigNumber operator /(BigNumber a, BigNumber b) {
            return BigCalculate.Division(a, b);
        }
        /// <summary>指定精确的除法</summary>
        public static BigNumber Division(BigNumber dividend, BigNumber divisor, int precision) {
            return BigCalculate.Division(dividend, divisor, precision);
        }
        public static BigNumber operator ++(BigNumber a) {
            return a + new BigNumber("1");
        }

        #endregion

        #region "提供阶乘和幂运算"

        /// <summary>返回正整数的阶乘运算</summary>
        public BigNumber Factorial() {
            if (!IsPlus || DecimalPart.Count != 0)
                throw new NumberException("只有正整数才有阶乘运算", 1);

            BigNumber result = new BigNumber("1");

            for (BigNumber i = new BigNumber("1"); i.CompareTo(this) != 1; i++) {
                result = result * i;
            }
            return result;
        }

        /// <summary>计算幂，现在可支持任意合法的幂运算</summary>
        public BigNumber Power(BigNumber value) {
            return DecimalPowerCalculator.Power(this, value);
        }

        public BigNumber Power(BigNumber value, int n) {
            return DecimalPowerCalculator.Power(this, value, n);
        }

        #endregion
        
        //和字符串之间的隐式转换
        public static implicit operator BigNumber(string x)
        {
            //让string可以隐式转换为BigNumber
            string StrX = x.ToString();
            if (StrX.Contains("E"))
            {
                int position = StrX.IndexOf("E");
                //如果是科学计数法则先转化为常规格式
                
                //StrX = Decimal.Parse(StrX, System.Globalization.NumberStyles.Float).ToString();
                StrX = (new BigNumber(StrX.Substring(0, position - 1))
                    * MathV.Pow(10, StrX.Substring(position + 1,
                        StrX.Length - position - 1))).ToString();
                BigNumber Num = new BigNumber(StrX);
                return Num;
            }
            else
            {
                BigNumber Num = new BigNumber(x);
                return Num;
            }
            
        }
        //和Int，Double之间的隐式转换
        public static implicit operator BigNumber(int x)
        {
            //让Int可以隐式转换为BigNumber
            BigNumber Num = new BigNumber(x.ToString());
            return Num;
        }
        /*public static implicit operator int(BigNumber x)
        {
            //让BigNumber可以隐式转换为Int整型
            return Convert.ToInt32(x.ToString());
        }*/
        public static implicit operator BigNumber(double x)
        {
            //让Double可以隐式转换为BigNumber
            string StrX = x.ToString();
            if (StrX.Contains("E"))
            {
                int position = StrX.IndexOf("E");
                
                //StrX = Decimal.Parse(StrX, System.Globalization.NumberStyles.Float).ToString();
                StrX = (new BigNumber(StrX.Substring(0, position - 1))
                    * MathV.Pow(10, StrX.Substring(position + 1,
                        StrX.Length - position - 1))).ToString();
                BigNumber Num = new BigNumber(StrX);
                return Num;
            }
            else
            {
                BigNumber Num = new BigNumber(x.ToString());
                return Num;
            }
        }
        /*public static implicit operator double(BigNumber x)
        {
            //让BigNumber可以隐式转换为Double双精度浮点型
            return Convert.ToDouble(x.ToString());
        }*/
        //和Int，Double之间的显式转换
        //显式转换主要是为了防止出错和误用
        //转换前请先确认是否可以转换
        public static explicit operator int(BigNumber x)
        {
            //让BigNumber可以显式转换为Int整型
            return Convert.ToInt32(x.ToString());
        }
        public static explicit operator double(BigNumber x)
        {
            //让BigNumber可以显式转换为Double双精度浮点型
            return Convert.ToDouble(x.ToString());
        }
        //新添加的重载运算符
        public static BigNumber operator --(BigNumber a)
        {
            //令其支持a--
            return a - new BigNumber("1");
        }
        //对BigNumber进行判等运算
        public static bool operator ==(BigNumber x1, BigNumber x2)
          {
              if (CompareNumber.Compare(x1,x2) == 0)
              {
                  return true;
              }
             else
              {
                  return false;
             }
         }
        //判等与判不等必须同时声明
        public static bool operator !=(BigNumber x1, BigNumber x2)
         {
             return !(x1 == x2);
         }
        //判定大于
        public static bool operator >(BigNumber x1, BigNumber x2)
        {
            if (CompareNumber.Compare(x1, x2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //大于的补集为小于等于
        public static bool operator <=(BigNumber x1, BigNumber x2)
        {
            return !(x1 > x2);
        }
        //判定小于
        public static bool operator <(BigNumber x1, BigNumber x2)
        {
            if (CompareNumber.Compare(x1, x2) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //小于的补集为大于等于
        public static bool operator >=(BigNumber x1, BigNumber x2)
        {
            return !(x1 < x2);
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            foreach (int i in IntPart) {
                sb.Append(i.ToString().PadLeft(BigNumber.OneCount, '0'));
            }
            if (intPart.Count == 0) {
                sb.Append(0);
            }
            if (DecimalPart.Count != 0) {
                sb.Append(".");

                foreach (int i in DecimalPart) {
                    sb.Append(i.ToString().PadLeft(BigNumber.OneCount, '0'));
                }
            }
            string r = sb.ToString();
            r = r.TrimStart(new char[] { '0' });

            if (r == string.Empty)
                return "0";
            if (r[0] == '.')
                r = "0" + r;
            if (!IsPlus)
                r = "-" + r;
            return r;
        }

        #region IComparable<BigNumber> 成员

        public int CompareTo(BigNumber other) {
            return CompareNumber.Compare(this, other);
        }


        #endregion

        internal bool IsZero() {
            foreach (int i in IntPart)
                if (i != 0)
                    return false;
            foreach (int i in DecimalPart)
                if (i != 0)
                    return false;
            return true;
        }

    }
}
