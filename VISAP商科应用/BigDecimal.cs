using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace VISAP商科应用
{
    public class BigDecimal
    {
        //private const int Base = 10;
        BigInteger IntPart;
        int Rank;
        private const int Precision = 30;
        //Precision为计算精度位数
        public BigDecimal(string Str)
        {
            StringBuilder Numbers = new StringBuilder(Str);
            int len = Numbers.Length;
            int Negative = 0;
            int DecimalPoint = -1;
            int Temp = 0;
            int count = 0;
            for (int i = 0; i < len; i++)
            {
                switch (Numbers[i])
                {
                    case '-':
                        Negative = -1;
                        break;
                    case '.':
                        DecimalPoint = i;
                        break;
                    case '0':
                        Temp = Temp * 10;
                        count++;
                        break;
                    case '1':
                        Temp = Temp * 10 + 1;
                        count++;
                        break;
                    case '2':
                        Temp = Temp * 10 + 2;
                        count++;
                        break;
                    case '3':
                        Temp = Temp * 10 + 3;
                        count++;
                        break;
                    case '4':
                        Temp = Temp * 10 + 4;
                        count++;
                        break;
                    case '5':
                        Temp = Temp * 10 + 5;
                        count++;
                        break;
                    case '6':
                        Temp = Temp * 10 + 6;
                        count++;
                        break;
                    case '7':
                        Temp = Temp * 10 + 7;
                        count++;
                        break;
                    case '8':
                        Temp = Temp * 10 + 8;
                        count++;
                        break;
                    case '9':
                        Temp = Temp * 10 + 9;
                        count++;
                        break;
                }

                if (count >= 8)
                {
                    IntPart = IntPart * 100000000 + Temp;
                    Temp = 0;
                    count = 0;
                }
            }
            IntPart = IntPart * BigInteger.Pow(10, count) + Temp;
            if (Negative == -1)
            {
                IntPart = -IntPart;
            }
            if (DecimalPoint == -1)
            {
                Rank = 0;
            }
            else
            {
                Rank = -(len - DecimalPoint - 1);
            }
        }
        public BigDecimal(BigInteger i, int r)
        {
            this.IntPart = i;
            this.Rank = r;
        }
        private int AcquireRank()
        {
            return Rank;
        }
        private BigInteger AcquireIntPart()
        {
            return IntPart;
        }
        public static BigInteger Transform(string Numbers)
        {
            BigInteger x = 0;
            int len = Numbers.Length;
            for (int Start = 0; Start < len; Start = Start + 8)
            {
                if (Start + 8 <= len)
                {
                    x = Convert.ToInt32(Numbers.Substring(Start, 8)) + x * 100000000;
                }
                else
                {
                    x = Convert.ToInt32(Numbers.Substring(Start, len - Start)) + x * BigInteger.Pow(10, len - Start);
                }
            }
            return x;

        }
        public static BigDecimal Add(BigDecimal Num1, BigDecimal Num2)
        {
            int Rank1 = Num1.AcquireRank();
            int Rank2 = Num2.AcquireRank();
            BigInteger IntPart1 = Num1.AcquireIntPart();
            BigInteger IntPart2 = Num2.AcquireIntPart();
            if (Rank1 > Rank2)
            {
                //第一个数字小数点需往右边移动
                BigInteger x = IntPart1 * BigInteger.Pow(10, Rank1 - Rank2) + IntPart2;
                return new BigDecimal(x, Rank2);
            }
            else if (Rank1 < Rank2)
            {
                //第二个数字小数点需往右边移动
                BigInteger x = IntPart2 * BigInteger.Pow(10, Rank2 - Rank1) + IntPart1;
                return new BigDecimal(x, Rank1);
            }
            else
            {
                //无需调整
                BigInteger x = IntPart1 + IntPart2;
                return new BigDecimal(x, Rank1);
            }
        }
        public static BigDecimal Minus(BigDecimal Num1, BigDecimal Num2)
        {
            //减法运算和加法完全类似
            int Rank1 = Num1.AcquireRank();
            int Rank2 = Num2.AcquireRank();
            BigInteger IntPart1 = Num1.AcquireIntPart();
            BigInteger IntPart2 = Num2.AcquireIntPart();
            if (Rank1 > Rank2)
            {
                //第一个数字小数点需往右边移动
                BigInteger x = IntPart1 * BigInteger.Pow(10, Rank1 - Rank2) - IntPart2;
                return new BigDecimal(x, Rank2);
            }
            else if (Rank1 < Rank2)
            {
                //第二个数字小数点需往右边移动
                BigInteger x = IntPart1 - IntPart2 * BigInteger.Pow(10, Rank2 - Rank1);
                return new BigDecimal(x, Rank1);
            }
            else
            {
                //无需调整
                BigInteger x = IntPart1 - IntPart2;
                return new BigDecimal(x, Rank1);
            }
        }
        public static BigDecimal Multiply(BigDecimal Num1, BigDecimal Num2)
        {
            //BigDecimal 的乘法运算比加减法运算还要简单
            //IntPart相乘，阶数相加即可
            int Rank1 = Num1.AcquireRank();
            int Rank2 = Num2.AcquireRank();
            BigInteger IntPart1 = Num1.AcquireIntPart();
            BigInteger IntPart2 = Num2.AcquireIntPart();
            return new BigDecimal(IntPart1 * IntPart2, Rank1 + Rank2);
        }
        public static BigDecimal Divide(BigDecimal Num1, BigDecimal Num2)
        {
            //暂时没有加入四舍五入的考虑
            int Rank1 = Num1.AcquireRank();
            int Rank2 = Num2.AcquireRank();
            BigInteger IntPart1 = Num1.AcquireIntPart();
            BigInteger IntPart2 = Num2.AcquireIntPart();
            if (-Rank1 + Rank2 < Precision + 1)
            {
                //小于相应精度
                //调整被除数的精度
                BigInteger x = IntPart1 * BigInteger.Pow(10, Precision + 1 - (Rank2 - Rank1)) / IntPart2;
                return new BigDecimal(x, -(Precision + 1));
            }
            else if (-Rank1 + Rank2 > Precision + 1)
            {
                //大于相应精度
                //调整除数的精度
                BigInteger x = IntPart1 / (IntPart2 * BigInteger.Pow(10, (Rank2 - Rank1) - (Precision + 1)));
                return new BigDecimal(x, -(Precision + 1));
            }
            else
            {
                return new BigDecimal(IntPart1 / IntPart2, -(Precision + 1));
            }
        }
        //重载运算符
        public static BigDecimal operator +(BigDecimal a, BigDecimal b)
        {
            return BigDecimal.Add(a, b);
        }
        public static BigDecimal operator -(BigDecimal a, BigDecimal b)
        {
            return BigDecimal.Minus(a, b);
        }
        public static BigDecimal operator *(BigDecimal a, BigDecimal b)
        {
            return BigDecimal.Multiply(a, b);
        }
        public static BigDecimal operator /(BigDecimal a, BigDecimal b)
        {
            return BigDecimal.Divide(a, b);
        }

        public override string ToString()
        {
            string IntPartStr = IntPart.ToString();
            int Negativie = 0;
            if (IntPartStr[0] == '-')
            {
                Negativie = 1;
            }
            if (Rank == 0)
            {
                return IntPartStr;
            }
            else if (Rank < 0)
            {
                int len = IntPartStr.Length;
                //求出整数部分的长度
                if (len - Negativie <= -Rank)
                {
                    //需要补0
                    StringBuilder Str = new StringBuilder();
                    if (Negativie == 1)
                    {
                        Str.Append("-");
                    }
                    Str.Append("0.");
                    string AddZero = new string('0', -Rank - len + Negativie);
                    Str.Append(AddZero);
                    if (Negativie == 1)
                    {
                        Str.Append(IntPartStr.Substring(1, len-1));
                    }
                    else
                    {
                        Str.Append(IntPartStr);
                    }
                    return Str.ToString();
                }
                else
                {
                    return IntPartStr.Insert(len + Rank, ".");
                    //插入小数点
                }
            }
            else
            {
                //Rank > 0
                StringBuilder Str = new StringBuilder();
                Str.Append(IntPartStr);
                //string AddZero = new string('0', -Rank);
                string AddZero = new string('0', Rank);
                Str.Append(AddZero);
                return Str.ToString();
            }
        }
        //下面是隐式转换部分
        //和字符串之间的隐式转换
        public static implicit operator BigDecimal(string x)
        {
            //让string可以隐式转换为BigNumber
            return new BigDecimal(x);
        }
        //和Int，Double之间的隐式转换
        public static implicit operator BigDecimal(int x)
        {
            //让Int可以隐式转换为BigNumber
            return new BigDecimal(x, 0);
        }
        public static implicit operator BigDecimal(double d)
        {
            //让Double可以隐式转换为BigNumber
            //int intd = (int)d; //一下就是整数部分
            //double doubled = d % 1;//这么一下是小数
            //百度知道上找到的简单实用的办法。。。

            BigInteger Num = (BigInteger)d;
            Num = Num * 100000000000000;
            //Num = Num + (int)(doubled * 100000000);
            Num = Num + (BigInteger)((d % 1) * 100000000000000);
            //因为不确定Double型的精度，所以算到小数点后14位
            return new BigDecimal(Num, -14);
        }
        public static int Compare(BigDecimal Num1, BigDecimal Num2)
        {
            //1表示Num1 > Num2
            //-1表示Num1 < Num2
            //0 表示Num1 == Num2
            int Rank1 = Num1.AcquireRank();
            int Rank2 = Num2.AcquireRank();
            BigInteger IntPart1 = Num1.AcquireIntPart();
            BigInteger IntPart2 = Num2.AcquireIntPart();
            int Sign1 = IntPart1.Sign;
            int Sign2 = IntPart2.Sign;
            //Sign正数返回1，负数返回-1，0返回0
            if (Sign1 == 1 && Sign2 == -1)
            {
                //Num1为正，Num2为负
                return 1;
            }
            else if (Sign1 == -1 && Sign2 == 1)
            {
                //Num1为负，Num2为正
                return -1;
            }
            else if (Sign1 == 0 && Sign2 == 0)
            {
                //Num1为0，Num2为0
                return 0;
            }
            /*int Sign12 = (Num1 - Num2).AcquireIntPart().Sign;
            //直接相减虽然简单，但是速度太慢,以后有空我会进行优化
            if (Sign12 > 0)
            {
                return 1;
                //Num1 > Num2
            }
            else if (Sign12 < 0)
            {
                return -1;
                //Num1 < Num2
            }
            else
            {
                return 0;
                //Num1 == Num2
            }*/
            //为了避免转为字符串之后进行比较的尴尬，我想了个办法。。。

            if (Rank1 > Rank2)
            {
                //第一个数字小数点需往右边移动
                IntPart1 = IntPart1 * BigInteger.Pow(10, Rank1 - Rank2);
            }
            else if (Rank1 < Rank2)
            {
                //第二个数字小数点需往右边移动
                IntPart2 = IntPart2 * BigInteger.Pow(10, Rank2 - Rank1);
            }
            //除此之外无需调整
            return BigInteger.Compare(IntPart1, IntPart2);
        }
        //对BigDecimal进行判等运算
        public static bool operator ==(BigDecimal x1, BigDecimal x2)
        {
            if (Compare(x1, x2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //判等与判不等必须同时声明
        public static bool operator !=(BigDecimal x1, BigDecimal x2)
        {
            return !(x1 == x2);
        }
        //判定大于
        public static bool operator >(BigDecimal x1, BigDecimal x2)
        {
            if (Compare(x1, x2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //大于的补集为小于等于
        public static bool operator <=(BigDecimal x1, BigDecimal x2)
        {
            return !(x1 > x2);
        }
        //判定小于
        public static bool operator <(BigDecimal x1, BigDecimal x2)
        {
            if (Compare(x1, x2) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //小于的补集为大于等于
        public static bool operator >=(BigDecimal x1, BigDecimal x2)
        {
            return !(x1 < x2);
        }
    }
}

